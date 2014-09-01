using System;
using KQLGenerator.Enums;

namespace KQLGenerator.Contracts
{
    public interface IQuery : IManageToken<IQuery>, IToken
    {
        IGroup OpenGroup();
    }
}