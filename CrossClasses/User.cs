using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossClasses
{
    [Serializable]
    public class User
    {
        public string Login { get; set; }
        public string Pwd { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public byte[] Img { get; set; }

        public User()
        {
            Id = 0;
            Name = String.Empty;
            Email = String.Empty;
            Login = String.Empty;
            Pwd = String.Empty;
            Country = String.Empty;
            City = String.Empty;
            Img = new byte[1];
        }
    }
    [Serializable]
    public class RegisterUser : User { }
    [Serializable]
    public class LoginUser : User { }
    [Serializable]
    public class UpdateUser : User { }
    [Serializable]
    public class DeleteUser : User { }
}
