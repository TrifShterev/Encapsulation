using System;
using System.IO;
using System.Runtime.InteropServices;

namespace PizzaCalories
{
 public   class StartUp
    {
        static void Main(string[] args)
        {
            string[] productName = Console.ReadLine().Split();
            string pizzaName = productName[1];


            var dough = Console.ReadLine().Split();
            Dough baseDough; /*= new Dough(dough[1],dough[2],double.Parse(dough[3]));*/
            try
            {
                baseDough = new Dough(dough[1], dough[2], double.Parse(dough[3]));
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return;
            }
            baseDough = new Dough(dough[1], dough[2], double.Parse(dough[3]));
            Pizza pizza = new Pizza(pizzaName) { Dough= baseDough };
           
            string input ;

            while ((input = Console.ReadLine())!="END")
            {
                var tokens = input.Split();
                Topping topping;
                try
                {
                     topping = new Topping(tokens[1],double.Parse(tokens[2]));
                    pizza.ListOfTopings(topping);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    return;
                }
                //topping = new Topping(tokens[1], double.Parse(tokens[2]));
                
               
            }
            Console.WriteLine(pizza);
        }
    }
}
