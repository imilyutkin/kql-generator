using System;
using KQLGenerator.Enums;

namespace KQLGenerator.Contracts
{
    public interface IManageToken<TReturn> where TReturn : IToken
    {
        TReturn AddTerm(String managedProperty, String value, Operation operation, ConcatOperator? concatOperator = null);


    }
}
