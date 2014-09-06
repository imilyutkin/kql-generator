using System;
using System.Collections.Generic;
using System.Linq;
using KQLGenerator.Contracts;
using KQLGenerator.Enums;
using KQLGenerator.Exceptions;

namespace KQLGenerator
{
    public class KQLQuery : IKQLQuery
    {
        protected List<IToken> Tokens;

        protected const String TokenSeparator = " ";

        public KQLQuery()
        {
            Tokens = new List<IToken>();
        }

        public ConcatOperator? ConcatOperator
        {
            get;
            set;
        }

        public string Build()
        {
            CheckConcatOperators();
            return String.Join(TokenSeparator, Tokens.Select(token => token.Build()));
        }

        private void CheckConcatOperators()
        {
            var copyTokens = Tokens.ToList();
            if (copyTokens.Count != 0)
            {
                copyTokens.Remove(copyTokens.Last());
            }
            foreach (var token in copyTokens)
            {
                if (!token.ConcatOperator.HasValue)
                {
                    throw new ConcatTermsException(String.Format("Token: [{0}] haven't concat operator", token.Build()));
                }
            }
        }

        public IKQLQuery AddTerm(String managedProperty, String value, Operation operation, ConcatOperator? concatOperator = null)
        {
            Tokens.Add(new Term(managedProperty, value, operation, concatOperator));
            return this;
        }

        public IKQLQuery AddCompositeQuery(String managedProperty, List<String> values, Operation operation,
            ConcatOperator compoundOperator, ConcatOperator? concatOperator = null)
        {
            Tokens.Add(new CompositeTerm(managedProperty, values, operation, compoundOperator, concatOperator));
            return this;
        }

        public IGroup OpenGroup()
        {
            var group = new Group();
            group.KqlQuery = this;
            Tokens.Add(group);
            return group;
        }
    }
}
