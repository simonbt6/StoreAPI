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
using AdminPanel.Data.Database;
using AdminPanel.Data.Database.Query;
using AdminPanel.Content.Model.Product;
using MySql.Data.MySqlClient;
using AdminPanel.Data.Server.Performance;
using AdminPanel.Content.Model.User;

namespace AdminPanel.Content.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private Database database;


        public LoginWindow()
        {
            InitializeComponent();
            database = Database.Instance();
        }

        private void onLogin(object sender, RoutedEventArgs e)
        { 
            AdminUser user = UserQuery.login(emailField.Text, passwordField.Password);
            if(user != null)
            {
                Console.WriteLine("Hello " + user.getFirstname() + " " + user.getLastname());
                Main main = new Main(user);
                main.Show();
                Close();
            }
            else
            {
                emailField.Text = "";
                passwordField.Password = "";
                Console.WriteLine("Wrong username or password.");
            }
        }

        private void onClose(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
