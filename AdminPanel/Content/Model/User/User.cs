using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanel.Content.Model.User
{
    public class User
    {
        private string UUID;
        private string Firstname;
        private string Lastname;
        private string Email;

        public User(string UUID)
        {
            this.UUID = UUID;
        }
        
        public User(string UUID, string Firstname, string Lastname, string Email):this(UUID)
        {
            this.Firstname = Firstname;
            this.Lastname = Lastname;
            this.Email = Email;
        }

        public string getID()
        {
            return UUID;
        }

        public string getFirstname()
        {
            return Firstname;
        }

        public string getLastname()
        {
            return Lastname;
        }

        public string getEmail()
        {
            return Email;
        }
    }
}
