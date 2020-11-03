using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Shopping_Spree
{
    public class Person
    {
        private string name;
        private decimal money;
        private ICollection<Product> bagWithProducts;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            bagWithProducts = new List<Product>();
        }

        public IReadOnlyCollection<Product> BagWithProducts
        {
            get
            {
                return (IReadOnlyCollection<Product>)bagWithProducts;
            }
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty.");
                }
                name = value;
            }
        }
        public decimal Money
        {
            get { return money; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

        public string BuyProduct(Product product)
        {
            if (product.Cost > Money)
            {
                return $"{Name} can't afford {product.Name}";
            }
            else
            {
                money -= product.Cost;
                bagWithProducts.Add(product);
                return $"{Name} bought {product.Name}";



            }

        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (bagWithProducts.Count == 0)
            {
                sb.AppendLine($"{Name} - Nothing bought");
            }
            else
            {
                sb.AppendLine($"{Name} - {string.Join(", ", bagWithProducts.Select(x => x.Name))}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
