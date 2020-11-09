namespace Survey.Application.Utilites
{
    public interface IPasswordUtility
    {
        (string hash, string salt) Hash(string password);
        bool Verify(string password, string hash, string salt);

    }
}
