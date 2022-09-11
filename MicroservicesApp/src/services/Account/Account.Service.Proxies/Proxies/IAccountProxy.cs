namespace Account.Service.Proxies
{
    public interface IAccountProxy
    {
        Task<int> GetAccountIdAsync(string accountType);

        Task<string> GetAccountName(int idAccount);
    }
}
