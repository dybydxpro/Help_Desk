namespace React_Redux_.NET_Shopping_Mall.Data
{
    public class DatabaseConfig
    {
        public string Connection()
        {
            return "Server=THARINDUD\\SQLEXPRESS;Database=LMS;TrustServerCertificate=True;Trusted_Connection=True;MultipleActiveResultSets=true;";
        }
    }
}