namespace React_Redux_.NET_Shopping_Mall.Repository
{
    public interface  IUserRepository
    {
        public bool CheckUserAvailability(string email);
        
        public void CreatePasswordHash(string password);

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);

        public string CreateToken(User user);

        public static string EncryptString(string text, string keyString);

        public static string DecryptString(string cipherText, string keyString);
    }
}