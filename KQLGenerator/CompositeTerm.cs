using System;
using System.Collections.Generic;
using System.Linq;
using KQLGenerator.Contracts;
using KQLGenerator.Enums;

namespace KQLGenerator
{
    public class CompositeTerm : IToken
    {
        protected List<Term> Terms
        {
            get;
            set;
        }

        public ConcatOperator CompoundOperator
        {
            get;
            set;
        }

        protected const String CompoundOperatorTemplate = " {0} ";

        public CompositeTerm(String managedProperty, List<String> values, Operation operation,
            ConcatOperator compoundOperator, ConcatOperator? concatOperator = null)
        {
            CompoundOperator = compoundOperator;
            Terms = values != null && values.Count != 0
                ? values.Select(value => new Term(managedProperty, value, operation)).ToList()
                : new List<Term>();
            if (concatOperator.HasValue)
            {
                SetToLastTermConcatOperator(concatOperator);   
            }
        }

        private void SetToLastTermConcatOperator(ConcatOperator? concatOperator)
        {
            var last = Terms.LastOrDefault();
            if (last != null)
            {
                Terms.Remove(last);
                Terms.Add(new Term(last.ManagedProperty, last.Value, last.Operation, concatOperator));   
            }
        }

        public String Build()
        {
            if (Terms != null && Terms.Count != 0)
            {
                return String.Join(String.Format(CompoundOperatorTemplate, CompoundOperator.ToString().ToUpper()),
                    Terms.Select(term => term.Build()));
            }
            throw new ArgumentException("Managed property or values is null or empty");
        }
    }
}
