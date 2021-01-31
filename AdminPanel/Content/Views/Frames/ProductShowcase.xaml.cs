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
using AdminPanel.Content.Model.Product;


namespace AdminPanel.Content.Views.Frames
{
    /// <summary>
    /// Interaction logic for ProductShowcase.xaml
    /// </summary>
    public partial class ProductShowcase : Page
    {
        private Product product;

        public ProductShowcase(Product product)
        {
            InitializeComponent();
            ShowsNavigationUI = false;
            this.product = product;

            productName.Text = product.getName();
            productImage.Source = product.getImage();
            ratingBar.Value = (int)product.getRating();
        }

        private void linkAmazon(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(product.getUrl());
        }
    }
}
