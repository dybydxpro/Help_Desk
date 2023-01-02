namespace React_Redux_.NET_Shopping_Mall.Data
{
    public class DatabaseConfig
    {
        public string Connection()
        {
            return "LAPTOP-THARINDU\\SQLEXPRESS;Database=shoppingmall;Trusted_Connection=True;MultipleActiveResultSets=true";
        }

        // Server=THARINDUD\\SQLEXPRESS;Database=LMS;TrustServerCertificate=True;Trusted_Connection=True;MultipleActiveResultSets=true;
        // Server=LAPTOP-THARINDU\\SQLEXPRESS;Database=shoppingmall;Trusted_Connection=True;MultipleActiveResultSets=true
        // server=localhost;user=root;database=shoppingmall;port=3306;password=Tharindu@1563
        // Server=localhost;Database=shoppingmall;User Id=sa;Password=Tharindu@1563
    }
}