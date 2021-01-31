using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
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
using AdminPanel.Content.Model.User;
using AdminPanel.Data.Server.Status.HTTP;

namespace AdminPanel.Content.Views.Frames
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {

        /**
         * - Settings
         * - Performances
         * - Administrative assignments and schedule.
         * - Requests
         *      - Status
         * - Users
         * - Products
         * 
         **/

        private AdminUser user;

        public HomePage(AdminUser user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void navigatePerformanceMeter(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PerformanceTools.MainPerfomanceTool());
        }

        private void navigateTODO(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ManagementTools.TODO.TodoPage(user));
        }
    }
}
