using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Shopping_Spree
{
  public  class StartUp
    {
        static void Main(string[] args)
        {
            var InputPersons = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var InputProducts = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            List<Product> products = new List<Product>();
            List<Person> persons = new List<Person>();
            try
            {
                foreach (var item in InputProducts)
                {
                    var tokens = item.Split("=", StringSplitOptions.RemoveEmptyEntries)
                        .ToList();
                    var name = tokens[0];
                    var cost = decimal.Parse(tokens[1]);
                    Product product = new Product(name, cost);
                    products.Add(product);
                }
                foreach (var item in InputPersons)
                {
                    var tokens = item.Split("=", StringSplitOptions.RemoveEmptyEntries)
                        .ToList();
                    var name = tokens[0];
                    var money = decimal.Parse(tokens[1]);
                    Person person = new Person(name, money);
                    persons.Add(person);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return;
            }
           
            string input;

            while ((input=Console.ReadLine())!="END")
            {
                var commands = input.Split();
                string personName = commands[0];
                string productName = commands[1];

                var person = persons.FirstOrDefault(x => x.Name == personName);
                var product = products.FirstOrDefault(x => x.Name == productName);
                Console.WriteLine(person.BuyProduct(product)); 
            }

            foreach (var person in persons)
            {
                Console.WriteLine(person  ); 
            }
        }
    }
}
