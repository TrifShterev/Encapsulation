using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType.ToLower();
            BakingTechnique = bakingTechnique.ToLower();
            Weight = weight;
        }

        public string FlourType
        {
            get
            {
                return flourType;
            }
            private set
            {
                if (value != "white" && value != "wholegrain")
                {
                    throw new Exception("Invalid type of dough.");
                }

                flourType = value;

            }
        }
        public string BakingTechnique
        {
            get { return bakingTechnique; }
            private set
            {
                if (value != "chewy" && value != "crispy" && value != "homemade")
                {
                    throw new Exception("Invalid type of dough");

                }
                bakingTechnique = value;
            }
        }
        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }   public double DoughCalories()
        {
            var total = (2 * Weight)  * FlourModifier() * BakingModifier();
            return total;
        }
        private double FlourModifier()
        {
            if (FlourType == "white")
            {
                return 1.5;
            };

            return 1.0;
        }
        private double BakingModifier()
        {
            if (BakingTechnique == "chewy")
            {
                return 1.1;
            }
            else if (BakingTechnique == "crispy")
            {
                return 0.9;
            }
            else
            {
                return 1.0;
            }
        }
    }
}



