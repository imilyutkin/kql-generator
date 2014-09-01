﻿using System;
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

        public IQuery AddCompositeQuery(String managedProperty, List<String> values, Operation operation,
            ConcatOperator compoundOperator, ConcatOperator? concatOperator = null)
        {
            Tokens.Push(new CompositeTerm(managedProperty, values, operation, compoundOperator, concatOperator));
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
}
