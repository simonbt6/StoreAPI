using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using AdminPanel.Data.Database.Query;

namespace AdminPanel.Content.Model.Product
{

    public class Product : Comparer<Product>
    {
        private int ID;
        private string Name;
        private string Url;
        private float Price;
        private string Brand;
        private string ImageUrl;
        private float Rating;

        public Product(int ID, string Name, string Url, float Price, string Brand, string ImageUrl, float Rating)
        {
            this.ID = ID;
            this.Name = Name;
            this.Url = Url;
            this.Price = Price;
            this.Brand = Brand;
            this.ImageUrl = ImageUrl;
            this.Rating = Rating;
        }

        // Setters

        public void setName(string name)
        {
            string queryString = "";
            ProductQuery.updateProduct(queryString);

        }

        public void setUrl(string url)
        {

        }

        public void setPrice(float price)
        {

        }

        public void setBrand(string brand)
        {

        }

        public void setImageUrl(string imageUrl)
        {

        }

        public void setRating(float ratingValue)
        {

        }

        // Getters

        public int getID()
        {
            return ID;
        }

        public string getName()
        {
            return Name;
        }

        public string getUrl()
        {
            return Url;
        }

        public float getPrice()
        {
            return Price;
        }

        public string getBrand()
        {
            return Brand;
        }

        public string getImageUrl()
        {
            return ImageUrl;
        }
        
        public BitmapImage getImage()
        {
            // Image properties.
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(getImageUrl(), UriKind.Absolute);
            bitmap.EndInit();
            return bitmap;
        }

        public float getRating()
        {
            return Rating;
        }



        /**
         * 
         * <summary>
         * Compares a product to another.
         * </summary>
         * 
         * <example>
         * product.Compare(product, anotherProduct)
         * </example>
         * 
         **/
        override public int Compare(Product product1, Product product2)
        {
            return 0;
        }
    }
}
