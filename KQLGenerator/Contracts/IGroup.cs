namespace KQLGenerator.Contracts
{
    public interface IGroup : IManageToken<IGroup>, IToken
    {
        Query Query
        {
            get;
            set;
        }

        IQuery CloseGroup();

        IGroup OpenGroup();
    }
}