using System;
using System.Collections.Generic;
using System.Text;

namespace FluentInterface2
{
    public class Order
    {
        public List<Product> Products { get; } = new List<Product>();
        public decimal TotalPrice => Products.Sum(p => p.Price);

        public Order AddProduct(Product product)
        {
            Products.Add(product);
            return this;
        }
        public Order RemoveProducts(Product product)
        {
            Products.Remove(product);
            return this;
        }

    }
}
