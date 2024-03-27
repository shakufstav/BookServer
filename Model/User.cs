using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User:BaseEntity
    {
        private string userName;
        private int Ppassword;
        private string email;

        public string Email { get => email; set => email = value; }
        public string UserName { get => userName; set => userName = value; }
        public int Ppassword1 { get => Ppassword; set => Ppassword = value; }
    }
}
 