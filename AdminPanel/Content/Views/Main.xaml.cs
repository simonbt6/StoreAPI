using System;
using System.Windows;
using AdminPanel.Data.Server.Performance;
using AdminPanel.Content.Model.User;
using AdminPanel.Content.Model.Product;

namespace AdminPanel.Content.Views
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {

        private AdminUser User;

        private bool sidenavPosition = true;

        public Main(AdminUser User)
        {
            InitializeComponent();
            this.User = User;
            usernameLabel.Text = this.User.getFirstname() + " " + this.User.getLastname();
            _mainFrame.Navigate(new Frames.HomePage(User));
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void logout(object sender, RoutedEventArgs e)
        {
            User = null;
            new LoginWindow().Show();
            Close();
        }

        private void toggleSidebar(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(sidenavPosition);
            // Close sidenav
            if (sidenavPosition)
            {
                frameGrid.Margin = new Thickness(50, 40, 0, 0);
                sideNav.Width = 0;
                sideBarToggleIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.ChevronTripleRight;
                sidenavPosition = false;
            }
            // Open sidenav
            else
            {
                frameGrid.Margin = new Thickness(300, 40, 0, 0);
                sideNav.Width = 300;
                sideBarToggleIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.ChevronTripleLeft;
                sidenavPosition = true;
            }
        }
    }
}
