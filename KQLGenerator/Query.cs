using System;
using System.Collections.Generic;
using KQLGenerator.Contracts;
using KQLGenerator.Enums;

namespace KQLGenerator
{
    public class Query : IQuery
    {
        protected Stack<IToken> Tokens;

        public Query()
        {
            Tokens = new Stack<IToken>();
        }

        public string Build()
        {
            throw new NotImplementedException();
        }

        public IQuery AddTerm(String managedProperty, String value, Operation operation, ConcatOperator? concatOperator = null)
        {
            Tokens.Push(new Term(managedProperty, value, operation, concatOperator));
            return this;
        }

        public IGroup OpenGroup()
        {
            var group = new Group();
            group.Query = this;
            Tokens.Push(group);
            return group;
        }
    }

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

        public string Build()
        {
            throw new NotImplementedException();
        }

        public IGroup AddTerm(String managedProperty, String value, Operation operation, ConcatOperator? concatOperator = null)
        {
            Tokens.Push(new Term(managedProperty, value, operation, concatOperator));
            return this;
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
