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
using AdminPanel.Content.Model.Product;
using AdminPanel.Content.Views.Components.Product;
using System.Windows.Media.Effects;

namespace AdminPanel.Content.Views.Frames
{
    /// <summary>
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class Products : Page
    {

        public Products()
        {
            InitializeComponent();
            listProducts();
            ShowsNavigationUI = false;
        }

        private void listProducts()
        {
            List<Product> products = ProductQuery.getProducts();
            foreach(Product product in products)
            {

                ProductBox productBox = new ProductBox(product, this);

                Border border = new Border();

                border.BorderBrush = Brushes.Black;
                border.BorderThickness = new Thickness(2);
                border.CornerRadius = new CornerRadius(5);
                border.Margin = new Thickness(20);
                border.Padding = new Thickness(15);
                border.Background = Brushes.White;

                DropShadowEffect DropShadow = new DropShadowEffect();
                DropShadow.BlurRadius = 5;
                DropShadow.Color = Color.FromRgb(0, 0, 0);
                DropShadow.Opacity = 1;

                border.Effect = DropShadow;

                border.Child = productBox;
                
                _productContainer.Children.Add(border);

            }

        }
    }
}
