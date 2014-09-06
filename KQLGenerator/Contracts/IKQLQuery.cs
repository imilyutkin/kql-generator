using System;
using KQLGenerator.Enums;

namespace KQLGenerator.Contracts
{
    public interface IKQLQuery : IManageToken<IKQLQuery>, IToken
    {
        IGroup OpenGroup();
    }
}