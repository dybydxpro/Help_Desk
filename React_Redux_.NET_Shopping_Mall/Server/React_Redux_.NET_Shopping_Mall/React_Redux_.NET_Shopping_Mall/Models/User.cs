using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace React_Redux_.NET_Shopping_Mall.Data
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; } 
    }

    public struct UserLogin {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public struct UserRegister
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public struct PasswordSet{
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}