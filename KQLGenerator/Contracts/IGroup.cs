namespace KQLGenerator.Contracts
{
    public interface IGroup : IManageToken<IGroup>, IToken
    {
        KQLQuery KqlQuery
        {
            get;
            set;
        }

        IKQLQuery CloseGroup();

        IGroup OpenGroup();
    }
}