using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using AdminPanel.Content.Model.User;

namespace AdminPanel.Content.Views.Frames.ManagementTools.Mailing.Component
{
    public class UserListItem : ListViewItem
    {
        private User user;
        private MainMailling page;

        public UserListItem(User user, MainMailling page)
        {
            this.user = user;
            this.page = page;

            Button button = new Button 
            {
                Content = "Add User",

            };
            TextBlock userNameBox = new TextBlock
            {
                Text = user.getFirstname() + " " + user.getLastname()
            };

            Grid grid = new Grid
            {

            };
            ColumnDefinition c1 = new ColumnDefinition
            {
                Width = new GridLength(1, GridUnitType.Star)
            };
            ColumnDefinition c2 = new ColumnDefinition
            {
                Width = new GridLength(5, GridUnitType.Star)
            };
            grid.ColumnDefinitions.Add(c1);
            grid.ColumnDefinitions.Add(c2);
            grid.Children.Add(button);
            grid.Children.Add(userNameBox);
            Grid.SetColumn(button, 0);
            Grid.SetColumn(userNameBox, 1);

            button.Click += addUserToList;

            AddChild(grid);
        }

        public void addUserToList(object sender, RoutedEventArgs e)
        {
            if (!page.userListItems.Contains(this))
            {
                page.selectedUsersList.Items.Add(new SelectedUserListItem(user));
                page.userListItems.Add(this);
                page.userList.Items.Remove(this);
            }
        }
    }
}
