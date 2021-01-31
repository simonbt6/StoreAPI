using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using AdminPanel.Content.Views.Frames;
using System.Windows.Navigation;

namespace AdminPanel.Content.Views.Components.Product
{
    public class ProductBox : StackPanel
    {
        private Model.Product.Product product;
        private TextBlock titleLabel;
        private Image image;
        private Page frame;

        public ProductBox(Model.Product.Product product, Page frame)
        {
            this.product = product;
            this.frame = frame;

            // StackPanel properties.
            Height = 100;
            Width = 100;

            // TextBlock properties.
            titleLabel = new TextBlock
            {
                Text = product.getName()
            };

            image = new Image
            {
                Source = product.getImage(),
                Height = 100,
                Width = 100
            };

            Children.Add(titleLabel);
            Children.Add(image);

        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            Console.WriteLine(product.getName());
            ProductShowcase productShowcase = new ProductShowcase(product);
            frame.NavigationService.Navigate(productShowcase);

        }

        
    }
}
