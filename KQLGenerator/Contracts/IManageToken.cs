using System;
using System.Collections.Generic;
using KQLGenerator.Enums;

namespace KQLGenerator.Contracts
{
    public interface IManageToken<TReturn> where TReturn : IToken
    {
        TReturn AddTerm(String managedProperty, String value, Operation operation, ConcatOperator? concatOperator = null);

        TReturn AddCompositeQuery(String managedProperty, List<String> values, Operation operation,
            ConcatOperator compoundOperator, ConcatOperator? concatOperator = null);
    }
}
