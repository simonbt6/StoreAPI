using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanel.Content.Model.User
{
    public class User
    {
        private int ID;
        private string Firstname;
        private string Lastname;
        private string Email;

        public User(int ID)
        {
            this.ID = ID;
        }
        
        public User(int ID, string Firstname, string Lastname, string Email):this(ID)
        {
            this.Firstname = Firstname;
            this.Lastname = Lastname;
            this.Email = Email;
        }

        public int getID()
        {
            return ID;
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
