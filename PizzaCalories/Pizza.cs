using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;
        

        public Pizza()
        {
            toppings = new List<Topping>();
        }

        public Pizza(string name)
            : this()
        {
            Name = name;
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (value==String.Empty||value.Length>15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            } }

        public Dough Dough { get; set; }
        public int NumberOfToppings { get { return toppings.Count; } }
        public double TotalCalories { get { return Calories(); } }
        public void ListOfTopings(Topping topp)
        {
            
            if (toppings.Count>=10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
                return;
            }
            toppings.Add(topp);
        }
        private double Calories()
        {
            double sumCal = 0.00;
            foreach (var item in toppings)
            {
                sumCal += item.ToppingCalories();
            }
            return Dough.DoughCalories() + sumCal;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{Name} - {TotalCalories:f2} Calories.");
            return sb.ToString().TrimEnd();
        }
    }
}
