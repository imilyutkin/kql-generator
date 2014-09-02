using System;
using KQLGenerator.Enums;

namespace KQLGenerator.Contracts
{
    public interface IToken
    {
        ConcatOperator? ConcatOperator
        {
            get;
            set;
        }

        String Build();
    }
}