using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminPanel.Content.Model.User;
using System.Windows;
using System.Windows.Controls;

namespace AdminPanel.Content.Views.Frames.ManagementTools.Mailing.Component
{
    public class SelectedUserListItem : ListViewItem
    {
        private User user;
        public SelectedUserListItem(User user)
        {
            this.user = user;

            TextBlock nameBlock = new TextBlock
            {
                Text = user.getFirstname() + " " + user.getLastname()
            };

            AddChild(nameBlock);
        }



        public User GetUser()
        {
            return user;
        }
    }
}
