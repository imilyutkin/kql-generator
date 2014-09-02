using System;
using System.Collections.Generic;
using KQLGenerator.Contracts;
using KQLGenerator.Enums;

namespace KQLGenerator
{
    public class Group : IGroup
    {
        protected Stack<IToken> Tokens;

        public Group()
        {
            Tokens = new Stack<IToken>();
        }

        public Query Query
        {
            get;
            set;
        }

        public ConcatOperator? ConcatOperator { get; set; }

        public string Build()
        {
            throw new NotImplementedException();
        }

        public IGroup AddTerm(String managedProperty, String value, Operation operation, ConcatOperator? concatOperator = null)
        {
            Tokens.Push(new Term(managedProperty, value, operation, concatOperator));
            return this;
        }

        public IGroup AddCompositeQuery(string managedProperty, List<string> values, Operation operation, ConcatOperator compoundOperator,
            ConcatOperator? concatOperator = null)
        {
            throw new NotImplementedException();
        }

        public IGroup OpenGroup()
        {
            var group = new Group();
            group.Query = Query;
            Tokens.Push(group);
            return group;
        }

        public IQuery CloseGroup()
        {
            return Query;
        }
    }
}