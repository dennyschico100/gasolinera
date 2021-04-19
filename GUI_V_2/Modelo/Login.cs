using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gasolinera.Modelo
{
    class Login
    {
        private string email;
        private string password;

        public Login(string email, string password)
        {
            this.Email= email;
            this.Password = password;
        }
        public Login()
        {

        }


        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email= value;
            }
        } 

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        
    }
}
