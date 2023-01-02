using Angular_.NET_SignalR_ChatApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Angular_.NET_SignalR_ChatApp.Data
{
    public class AppDatabaseContext : DbContext
    {
        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
