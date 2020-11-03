using System;
using System.Runtime.InteropServices;

namespace PizzaCalories
{
 public   class Program
    {
        static void Main(string[] args)
        {
            string input ;

            while ((input = Console.ReadLine())!="END")
            {
                var tokens = input.ToLower().Split();
                try
                {
                    Dough dough = new Dough(tokens[1], tokens[2], double.Parse(tokens[3]));
                    Console.WriteLine(dough.DoughCalories());
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
               
            }
        }
    }
}
