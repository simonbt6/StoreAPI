using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanel.Content.Model.User
{
    public class AdminUser: User
    {
        private int AuthLevel;
        private string UUID;

        public AdminUser(string UUID, string Firstname, string Lastname, string Email, int AuthLevel): base(UUID, Firstname, Lastname, Email)
        {
            this.AuthLevel = AuthLevel;
        }

        public int getAuthLevel()
        {
            return AuthLevel;
        }
    }
}
