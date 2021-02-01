using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AdminPanel.Data.Database.Query;
using AdminPanel.Content.Model.User;
using AdminPanel.Data.SMTP;

namespace AdminPanel.Content.Views.Frames.ManagementTools.Mailing
{
    /// <summary>
    /// Interaction logic for MainMailling.xaml
    /// </summary>
    public partial class MainMailling : Page
    {
        public List<Component.UserListItem> userListItems = new List<Component.UserListItem>();

        public MainMailling()
        {
            InitializeComponent();

            List<User> users = UserQuery.getUsers();

            users.ForEach(user =>
            {
                Component.UserListItem item = new Component.UserListItem(user, this);
                userList.Items.Add(item);
            });

            sendMailButton.Click += sendMail;

            
        }

        private void sendMail(object sender, RoutedEventArgs args)
        {
            SMTPConnection smtp = new SMTPConnection();
            List<String> addresses = new List<String>();

            smtp.sendMail("Test mail page", "This message only sends to users selected.", addresses);
        }

    }
}
