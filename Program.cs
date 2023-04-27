using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace recipe_app_POE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            recipe recipe = new recipe();


            Console.WriteLine("Welcome To Sanele's Recipe Application!"); //first line welcomes the user to the app
            Console.WriteLine("----------------     A new Recipe   ---------------- ");
            

            Console.WriteLine("Enter number of ingredients in your recipe: ");
            int noIngredients = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < noIngredients; i++)
            {
                recipe.addingredient();
            }

            Console.WriteLine("How many Steps does this recipe Have?");
            int noSteps = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < noSteps; i++)
                {
                int num;
                num = i + 1;
                Console.WriteLine("Step " + num);
                recipe.addStep();
                }

            recipe.displayRecipe();
            Console.WriteLine("View the recipe in different scales: ");
            Console.WriteLine("Enter 1: a factor of 0.5 (half) | Enter 2: a factor of 2 (double) | Enter 3: a factor of 3 (triple) | Enter 4: Goto Main menu" );
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)//references the above choices
            {
                case 1: 
                    recipe.scale(0.5);

                    break;
                case 2: 
                    recipe.scale(2);
                    break;

                case 3:
                    recipe.scale(3);
                    break;
                
                case 4:
                    break;
            }












        }
    }

    class mainProgram
    {

    }

    class recipe
    {
        public ArrayList ingredientName = new ArrayList();
        public ArrayList quantities = new ArrayList();
        public ArrayList units = new ArrayList();
        public ArrayList steps = new ArrayList();
        public ArrayList recipeName = new ArrayList();
        public ArrayList originalQuantities = new ArrayList();


        public void addingredient()
        {
            
            Console.Write("Please Enter The Ingredient's name: ");
            string ingredient = Console.ReadLine();
            ingredientName.Add(ingredient);

            Console.Write("Please Enter quantity: ");//how much of something has to be added e.g. 200/50/150 etc...
            double quantity = Convert.ToDouble(Console.ReadLine());
            quantities.Add(quantity);
            originalQuantities.Add(quantity);


            Console.Write("Please Enter The unit of measurement: ");//example: grams/mls/tablespoon etc.
            string unit = Console.ReadLine();
            units.Add(unit);



        }

        public void addStep()
        {
            Console.Write("Describe this step:  ");//describes the step in the recipe e.g. mix the dry ingredients
            string step = Console.ReadLine();
            steps.Add(step);

        }

        public void displayRecipe()
        {

            Console.WriteLine("Ingredients:");

            for (int i = 0; i < ingredientName.Count; i++)
            {
                Console.WriteLine("- " + ingredientName[i] + " " + quantities[i] + " " + units[i]);
            }

            Console.WriteLine("Steps:");

            for (int i = 0; i < steps.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + steps[i]);
            }
        }

        public void scale(double factor)
        {
            Console.WriteLine("Scaling the recipe by a factor of " + factor);

            for (int i = 0; i < quantities.Count; i++)
            {
                double scaledQuantity = (double)quantities[i] * factor;
                quantities[i] = scaledQuantity;
            }

            Console.WriteLine("Scaled Recipe:");
            displayRecipe();
            Console.WriteLine("if you wish to view the original quantities Enter 'Y' ");
            string n = Console.ReadLine();
            if (n.Equals("y") ) { resetQuantities(); }

        }

        public void resetQuantities()
        {
            Console.WriteLine("Resetting quantities to original values");
            quantities.Clear();
            quantities.AddRange(originalQuantities);
            Console.WriteLine("Original Recipe:");
            displayRecipe();
        }

    }
}
