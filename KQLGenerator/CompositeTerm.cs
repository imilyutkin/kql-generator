using System;
using System.Collections.Generic;
using System.Linq;
using KQLGenerator.Contracts;
using KQLGenerator.Enums;
using KQLGenerator.Exceptions;

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

        protected const String ConcatOperatorTemplate = "{0} {1}";

        protected const String CompoundOperatorTemplate = " {0} ";

        public CompositeTerm(String managedProperty, List<String> values, Operation operation,
            ConcatOperator compoundOperator, ConcatOperator? concatOperator = null)
        {
            CompoundOperator = compoundOperator;
            ConcatOperator = concatOperator;
            Terms = values != null && values.Count != 0
                ? values.Select(value => new Term(managedProperty, value, operation)).ToList()
                : new List<Term>();
        }

        public ConcatOperator? ConcatOperator
        {
            get;
            set;
        }
        public String Build()
        {
            if (Terms != null && Terms.Count != 0)
            {
                var buildedQuery =
                    String.Join(String.Format(CompoundOperatorTemplate, CompoundOperator.ToString().ToUpper()),
                        Terms.Select(term => term.Build()));
                if (ConcatOperator.HasValue)
                {
                    return String.Format(ConcatOperatorTemplate, buildedQuery, ConcatOperator.Value.ToString().ToUpper());
                }
                return buildedQuery;
            }
            throw new ValueNullOrEmptyException("Managed property or values is null or empty");
        }
    }
}
