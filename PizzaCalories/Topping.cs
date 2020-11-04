using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
   public class Topping
    {
       

        private string toppingType;
        private double toppingWeight;

       
        public Topping(string topping, double weight)
        {
            ToppingType = topping.ToLower();
            ToppingWeight = weight;

            
        }
        public string ToppingType
        {
            get { return toppingType; }
            set
            {
               
                if (value!="meat"&&value!="cheese"&&value!= "veggies"&&value!="sauce")
                {
                    var valueName = value[0].ToString().ToUpper() + value.Substring(1);
                    throw new ArgumentException($"Cannot place {valueName} on top of your pizza.");
                }
                toppingType = value;
            } }
        public double ToppingWeight
        {
            get { return toppingWeight; }
            set
            {
                if (value<=0||value>50)
                {
                    var valueName = toppingType[0].ToString().ToUpper() + toppingType.Substring(1);
                    throw new ArgumentException($"{valueName} weight should be in the range [1..50].");
                }
                toppingWeight = value;
            } }
        

       

        public double ToppingCalories()
        {
            return ToppingModifier() * (toppingWeight*2);
        }
        private double ToppingModifier()
        {
            switch (toppingType)
            {
                case "meat":
                    return 1.2;
                    
                case "veggies":
                    return 0.8;
                    
                case "cheese":
                    return  1.1;
                    
                default:
                   return 0.9;
                   
            }
        }
    }
}
