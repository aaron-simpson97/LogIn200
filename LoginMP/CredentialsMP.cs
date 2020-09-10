using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginMP
{
    public class CredentialsMP
    {
        private String validUname;
        private String validPassword;

        public CredentialsMP()
        {
            this.validUname = "user";
            this.validPassword = "password";
        }

        public CredentialsMP(String un, String up)
        {
            Uname = un;
            Password = up;
        }

        public string Uname { get => validUname; set => validUname = value; }

        public string Password { get => validPassword; set => validPassword = value; }

        public bool Validate(String un, String up)
        {
            bool result = false;

            if (validUname.Equals(un) && validPassword.Equals(up))
            {
                result = true;
            }

            return result;
        }
    }
}
