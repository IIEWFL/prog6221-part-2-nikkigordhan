using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
//new comment to test commit

// working PoE with latest changes
//Nikki Gordhan
//POE Part2 
namespace PROG_PoE
{
    public class Ingredient
    {
        //https://www.w3schools.com/cs/cs_properties.php
        //w3schools

        public string sIngredient_name;
        //creates a variable called sIngredient_name of type string.
        public string Ingredient_Name
        {
            get { return sIngredient_name; }
            set { sIngredient_name = value; }
        }
        //getters and setters using automatic properties.

        public double dIngredient_quantity;
        //creates a variable called dIngredient_quantity of type double.
        public double Ingredient_Quantity
        {
            get { return dIngredient_quantity; }
            set { dIngredient_quantity = value; }
        }
        //getters and setters using automatic properties.

        public string sIngredient_unit;
        //creates a variable called sIngredient_unit of type string.
        public string Ingredient_Unit
        {
            get { return sIngredient_unit; }
            set { sIngredient_unit = value; }
        }
        //getters and setters using automatic properties.

        public int iNumber_Of_Calories;
        //creates a variable called iNumber_Of_Calories of type int.
        public int Number_Of_Calories
        {
            get { return iNumber_Of_Calories; }
            set { iNumber_Of_Calories = value; }
        }
        //getters and setters using automatic properties.

        public string sFood_Group;
        //creates a variable called sFood_Group of type string.
        public string Food_Group
        {
            get { return sFood_Group; }
            set { sFood_Group = value; }
        }
        //getters and setters using automatic properties.

    }
    //class to store the ingredient values.

    public delegate void dCalories(int iNumber_Of_Calories);

    public class Recipe
    {
        public string Name_of_Recipe;
        //creates a variable called Name_of_Recipe of type string.
        public string sName_of_Recipe
        {
            get { return Name_of_Recipe; }
            set { Name_of_Recipe = value; }
        }
        //getters and setters using automatic properties.

        public int iTotal_Calories;
        //creates a variable called iNumber_Of_Calories of type int.
        public int Total_Calories
        {
            get { return iTotal_Calories; }
            set { iTotal_Calories = value; }
        }
        //getters and setters using automatic properties.

        public Ingredient[] ingredients;
        //creates a variable called ingredients of type Ingredient array.

        List<Ingredient> lIngredient = new List<Ingredient>();
        // creates a list for ingredients
        public Ingredient[] Ingredients
        {
            get { return ingredients; }
            set { ingredients = value; }
        }
        //getters and setters using automatic properties.

        public string[] sSteps;
        //creates a variable called sSteps of type string array.

        List<string> lSteps = new List<string>();
        // creates a list for steps

        public string[] steps
        {
            get { return sSteps; }
            set { sSteps = value; }
        }
        //getters and setters using automatic properties.

        public float factor;
        //creates a variable called factor of type float.
        public float ffactor
        {
            get { return factor; }
            set { factor = value; }
        }
        //getters and setters using automatic properties.

        public Boolean bScaled;

        public Boolean Scaled
        {
            get { return bScaled; }
            set { bScaled = value; }
        }
        //getters and setters using automatic properties.

        public Boolean Check_For_Found_Recipe;
        //creates a variable called Name_of_Recipe of type string.
        public Boolean bCheck_For_Found_Recipe
        {
            get { return Check_For_Found_Recipe; }
            set { Check_For_Found_Recipe = value; }
        }
        //getters and setters using automatic properties.

        public void Reset_Total_Calories()
        {
            iTotal_Calories = 0;
        }

        public void Create_A_Recipe()
        {
            Console.WriteLine('\t' + "Enter the recipe name: ");
            string sRecipeName = Console.ReadLine();
            // asks the user to enter the name of the recipe.
            Name_of_Recipe = sRecipeName;

            Reset_Total_Calories();

            ingredients = Enter_Ingredients();
            //gets the values from Enter_Ingredients() and assigns it to the variable ingredients.

            lIngredient = ingredients.ToList();

            if (lIngredient != null)
            {
                sSteps = Enter_Steps();
                //gets the steps from Enter_Steps() and assigns it to the variable steps.

                lSteps = sSteps.ToList();
            }
        }
        //creates a new recipe.

        public string[] Enter_Steps()
        {
            Console.WriteLine('\t' + "Enter the number of steps: ");
            string snum_of_Steps = Console.ReadLine();
            int num_of_Steps;
            if (!int.TryParse(snum_of_Steps, out num_of_Steps))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a numeric value.");
                return null;
            }
            //asks the user to enter the number of steps and then converts in to an integer.
            else
            {
                string[] Steps = new string[num_of_Steps];
                //calls the Steps array to store the number of steps and creates the Steps object.

                for (int i = 0; i < num_of_Steps; i++)
                {
                    Console.WriteLine('\t' + $"Enter the step #{i + 1}:");
                    string steps = Console.ReadLine();
                    //asks the user to enter the step, if the user enters 3 steps then because i is = 0 it will add 1 and output the first step.

                    Steps[i] = steps;
                    //stores the step in the Step array.
                }

                return Steps;
            }

        }
        //enters the steps


        public void Check_Calories(int iTotal_Number_Of_Calories)
        {
            if (iTotal_Number_Of_Calories > 300)
            {
                Console.WriteLine("The total calories have exceeded 300.");
            }
        }

        public void Calculate_Total_Calories(int iCalories)
        {
            iTotal_Calories = iTotal_Calories + iCalories;
            //iTotal_Calories = iTotal_Calories + iCalories + 1;
            // is used for negative unit testing
        }

        // the format of a delagte is adapted from CodeGuru
        // https://www.codeguru.com/csharp/c-sharp-delegates-2/
        // Joydip Kanjilal
        // https://www.codeguru.com/author/joydip-kanjilal/


       
        public Ingredient[] Enter_Ingredients()
        {

            Console.WriteLine('\t' + "Enter the number of ingredients: ");
            string snum_of_Ingredients = Console.ReadLine();
            int num_of_Ingredients;
            if (!int.TryParse(snum_of_Ingredients, out num_of_Ingredients))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a numeric value.");
                return null;
            }
            else
            {

                //asks the user for the number of ingredients and then converts it to an integer.

                Ingredient[] ingredients = new Ingredient[num_of_Ingredients];
                //calls the Ingredients array to store the ingredients and creates the Ingredient object.

                for (int i = 0; i < num_of_Ingredients; i++)
                {

                    Console.WriteLine('\t' + "Enter the ingredient name: ");
                    string Name_of_Ingredient = Console.ReadLine();
                    //asks the user to enter the ingredients name and then converts it to a string.

                    Console.WriteLine('\t' + "Enter the ingredients quantity: " + '\n' + '\t' + "Please enter only the number.Example: 2 (tablespoon of sugar)");
                    double Quantity_of_Ingedient = double.Parse(Console.ReadLine());
                    //asks the user to enter the quantity of the ingredient and then converts it to a double.

                    Console.WriteLine('\t' + "Enter the unit of mesurement: " + '\n' + '\t' + "Example: teaspoon, tablespoon, cup, ect");
                    string Unit_of_Ingredient = Console.ReadLine();
                    //asks the user to enter the unit of measurement for the ingredient and then converts it to a string.

                    Console.WriteLine('\t' + "Enter the number of calories ");
                    int Number_of_Calories = int.Parse(Console.ReadLine());

                    //sum part for each entry 
                    //if sum > 300 then inform user calorie has exceeded 300
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Choose a food group");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine('\t' + "(1) Fruit");
                    Console.WriteLine('\t' + "(2) Vegatables");
                    Console.WriteLine('\t' + "(3) Grains");
                    Console.WriteLine('\t' + "(4) Protein");
                    Console.WriteLine('\t' + "(5) Carbohydrates");
                    // options for the user to choose from.
                    string FoodGroupChoice = Console.ReadLine();
                    //gives the user options to choose from.

                    if (!int.TryParse(FoodGroupChoice, out int choice))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Invalid option. Please enter a number from 1 to 5.");
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }
                    //if the user chooses an invalid option.


                    string FoodChoice = "";
                    switch (choice)
                    {
                        case 1:
                            FoodChoice = "Fruit";
                            break;
                        case 2:
                            FoodChoice = "Vegatables";
                            break;
                        case 3:
                            FoodChoice = "Grains";
                            break;
                        case 4:
                            FoodChoice = "Protein";
                            break;
                        case 5:
                            FoodChoice = "Carbohydrates";
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid option. Please enter a number from 1 to 5.");
                            //user chooses an invalid option.
                            break;

                    }

                    dCalories dCalculate_Total_Calories = new dCalories(Calculate_Total_Calories);
                    dCalories dCheck_Calories = new dCalories(Check_Calories);

                    dCalculate_Total_Calories(Number_of_Calories);
                    dCheck_Calories(iTotal_Calories);



                    ingredients[i] = new Ingredient { Ingredient_Name = Name_of_Ingredient, Ingredient_Quantity = Quantity_of_Ingedient, Ingredient_Unit = Unit_of_Ingredient, Number_Of_Calories = Number_of_Calories, Food_Group = FoodChoice };
                    //adds the ingredient details to the igredient list.


                }

                return ingredients;

            }

        }
        //enters the ingredients

        public void Calory_Category()
        {
            if (iTotal_Calories <= 100)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Total calories is less than 100.");
            }
            else if (iTotal_Calories >= 101 && iTotal_Calories <= 200)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Total calories is less than 200 but more than 100.");
            }
            else if (iTotal_Calories >= 201 && iTotal_Calories <= 299)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Total calories is less than 300.");
            }
            else if (iTotal_Calories >= 300)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The total calories have exceed 300.");
            }
        }
      // method to show an explanation depending on the calory range.

public void Display_Recipe()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine('\t' + "The recipe is shown below:");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine('\t' + "The ingredients are: ");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Ingredient ingredient in lIngredient)
            {
                Console.WriteLine('\t' + "The name of ingredient : " + ingredient.sIngredient_name + '\n' +  '\t' +"Ingredient quantity is : " + ingredient.dIngredient_quantity + " " + ingredient.sIngredient_unit + '\n' + '\t' + "The food group is : " + ingredient.sFood_Group);

            }
            //goes through the Ingreident array to output each ingredient name, quantity and mesurement.

            Console.WriteLine('\t' + "The total calories for this recipe is : " + iTotal_Calories);

            Calory_Category();

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine('\t' + "The steps are: ");
            Console.ForegroundColor = ConsoleColor.White;
            int iStepCounter = 1;

            foreach (String steps in lSteps)
            {
                Console.WriteLine('\t' + "Step " + iStepCounter + " : " + steps);
            }
            //goes through the Steps array to output step.

        }
        //displays the recipe.

        public void Conversion_Scaled(int iLoopCounter, double scaled)
        {
            switch (ingredients[iLoopCounter].sIngredient_unit.ToUpper())
            {
                case "TABLESPOON":
                    {
                        if (scaled % 8 == 0)
                        {
                            ingredients[iLoopCounter].dIngredient_quantity = scaled / 8;
                            // assign the ingredient.value to the divied (whole no) no.

                            ingredients[iLoopCounter].Ingredient_Unit = "CUPS";
                            // change ingreindets measurement to cups.
                        }
                        else
                        {
                            ingredients[iLoopCounter].dIngredient_quantity = scaled;
                        }

                        break;
                    }
                default:
                    {
                        ingredients[iLoopCounter].dIngredient_quantity = scaled;
                        break;
                    }
            }
        }

        public void Conversion_Reset(int iLoopCounter, double scaled)
        {
            if (bScaled)
            {
                switch (ingredients[iLoopCounter].sIngredient_unit.ToUpper())
                {

                    case "CUPS":
                        {

                            ingredients[iLoopCounter].dIngredient_quantity = scaled * 8;
                            // assign the ingredient.value to the divied (whole no) no.

                            ingredients[iLoopCounter].Ingredient_Unit = "TABLESPOON";
                            // change ingreindets measurement to cups.
                            bScaled = false;

                            break;
                        }
                    default:
                        {
                            ingredients[iLoopCounter].dIngredient_quantity = scaled;
                            bScaled = false;
                            break;
                        }
                }
            }
        }

        public void Scale_Recipe()
        {
            double scaled = 1;
            //variable called scaled and is equal to 1.
            int iLoopCounter = 0;


            foreach (Ingredient ingredient in lIngredient)
            {
                scaled = ingredient.Ingredient_Quantity * factor;
                String sMeasurement = ingredient.sIngredient_unit;

                ingredient.Ingredient_Quantity = scaled;
                Conversion_Scaled( iLoopCounter ,scaled );

            }
            //gets the ingredient quantity and times it by the factor to get the scaled value.

            bScaled = true;
        }
        //allows the user to scale the recipe.

        public void Reset_Quantities(double factor)
        {
            int iLoopCounter = 0;
            foreach (Ingredient ingredients in lIngredient)
            {
                double scaled = ingredients.Ingredient_Quantity / factor;
                String sMeasurement = ingredients.sIngredient_unit;

                ingredients.Ingredient_Quantity = scaled;

                Conversion_Reset(iLoopCounter, scaled);


                Console.WriteLine("Quantities are reset to orginal quantity.The orginal quantity is " + ingredients.Ingredient_Quantity);
            }
            //gets the scaled quantity and divides it by the factor to get the orginal quantity.
        }
        //allows the user to reset the quantites back to the orginal quantity.

        
    }
    //gets the recipe ingredients and steps.

    class eCookBook
    {
        

        static void Main(string[] args)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                //changes the colour of the font.
                Console.Title = "eCookBook";
                Console.WriteLine("Welcome to your very own eCook-Book. Where you can create any one of your favourite recipes.");

                List<Recipe> lRecipe = new List<Recipe>();
                // creates a list of type Recipe 
                    // the format of a list is adapted from C# Corner
                    // https://www.c-sharpcorner.com/article/c-sharp-list/
                    // Mahesh Chand
                    // https://www.c-sharpcorner.com/members/mahesh-chand

                Recipe oSelectedRecipe = new Recipe();
                //creates an object oSelectedRecipe of type Recipe.
                oSelectedRecipe.Check_For_Found_Recipe = false;

                while (true)
                {

                    Console.ForegroundColor = ConsoleColor.White;
                    //https://www.tutorialspoint.com/how-to-change-the-foreground-color-of-text-in-chash-console#:~:text=To%20change%20the%20Foreground%20Color%20of%20text%2C%20use%20the%20Console,ForegroundColor%20property%20in%20C%23.
                    //AmitDiwan
                    //updated 13 November 2019

                    Console.ForegroundColor = ConsoleColor.DarkCyan; 
                    Console.WriteLine("Choose an option for what you want to do.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine('\t' + "(1) Create a new recipe");
                    Console.WriteLine('\t' + "(2) Search for a certain recipe to display");
                    Console.WriteLine('\t' + "(3) Display all the recipe names");
                    Console.WriteLine('\t' + "(4) Scale the recipe");
                    Console.WriteLine('\t' + "(5) Reset the ingredient quantity to its orginal value");
                    Console.WriteLine('\t' + "(6) Clear the recipe");
                    Console.WriteLine('\t' + "(7) Quit");

                    string choiceString = Console.ReadLine();
                    //gives the user options to choose from.

                    if (!int.TryParse(choiceString, out int choice))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Invalid option. Please enter a number from 1 to 7.");
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }
                    //if the user chooses an invalid option.

                    switch (choice)
                    {
                        case 1:
                                Recipe orecipe = new Recipe();
                                orecipe.Create_A_Recipe();
                            //calls the Create_A_Recipe() method from Recipe class.
                            
                                lRecipe.Add(orecipe);
                                break;
                            
                        case 2:
                            if (oSelectedRecipe == null )
                            {
                                Console.WriteLine("No recipe is created yet. Please enter a recipe.");
                                //if the user chooses an invalid option.
                            }
                            else
                            {
                                Console.WriteLine('\t' + "Please enter the name of the recipe you want to search for:");
                                string sSearchRecipeName = Console.ReadLine();

                                int icount = lRecipe.Count;
                                Recipe oFoundRec = lRecipe.First(item => item.Name_of_Recipe == sSearchRecipeName);
                                // the format of List.First() is adapted from StackOverFlow
                                // https://stackoverflow.com/questions/3154310/search-list-of-objects-based-on-object-variable
                                // Jaroslav Jandek
                                // https://stackoverflow.com/users/379714/jaroslav-jandek
                                // searches for a recipe

                                oSelectedRecipe = oFoundRec;
                                oSelectedRecipe.Check_For_Found_Recipe = true;

                                oSelectedRecipe.Display_Recipe();
                                // displays the searched recipe.

                                oFoundRec = null;
                            }
                            break;
                        case 3:
                            
                            List<Recipe> SortedList = lRecipe.OrderBy(r => r.Name_of_Recipe).ToList();
                                // the format of List.Sort() is adapted from StackOverFlow
                                // https://stackoverflow.com/questions/3309188/how-to-sort-a-listt-by-a-property-in-the-object
                                // Lazarus
                                // https://stackoverflow.com/users/19540/lazarus
                                // orders the recipe names alphabetically.
                            int iNumberRecipes = lRecipe.Count;

                            for (int i = 0; i < iNumberRecipes; i++)
                            {

                                Console.WriteLine("Recipe " + (i+1) + ": "+ SortedList[i].Name_of_Recipe);
                            }


                            break;
                        case 4:
                            if (oSelectedRecipe == null || oSelectedRecipe.Check_For_Found_Recipe == false)
                            {
                                Console.WriteLine("No recipe is found. Please search for a recipe first.");
                            }
                            else
                            {
                                Console.WriteLine('\t' + "Enter the scaling factor:" + '\n' + "Choose from halfing (0,5), doubling (2) or tripling (3).");
                                //asks the user for a factor.
                                string sfactor = Console.ReadLine();
                                //converts it to a string value.

                                if (sfactor.Length < 0)
                                {

                                    Console.WriteLine("Invalid scaling factor. Please enter a valid number.");
                                    //if the user chooses an invalid factor.
                                    continue;
                                }
                                else
                                {
                                    oSelectedRecipe.ffactor = float.Parse(sfactor);
                                    //converts the factor to a float.
                                    try
                                    {
                                        if (oSelectedRecipe.sName_of_Recipe != "")
                                        {
                                            
                                            oSelectedRecipe.Scale_Recipe();
                                            //calls the Scale_Recipe() method from Recipe class.
                                            foreach (Ingredient ingredient in oSelectedRecipe.Ingredients)
                                            {
                                                Console.WriteLine('\t' + $"Recipe scaled by factor of {oSelectedRecipe.ffactor}. The new quantity is " + ingredient.Ingredient_Quantity);

                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Please search for the recipe that needs to be scaled first.");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Please search for the recipe that needs to be scaled first.");
                                    }
                                }
                            }
                            break;
                        case 5:
                            if (oSelectedRecipe == null || oSelectedRecipe.Check_For_Found_Recipe == false)
                            {
                                Console.WriteLine("No recipe is found. Please search for a recipe first.");
                            }
                            else
                            {
                                oSelectedRecipe.Reset_Quantities(oSelectedRecipe.factor);
                                //calls the Reset_Quantities() method and passes factor in from Recipe class.
                            }

                           break;
                        case 6:
                            if (oSelectedRecipe == null || oSelectedRecipe.Check_For_Found_Recipe == false)
                            {
                                Console.WriteLine("No recipe is found. Please search for a recipe first.");
                            }
                            else
                            {
                                Console.WriteLine('\t' + "Would you like to clear the recipe. YES or NO.");
                                string sResetRecipe = Console.ReadLine();

                                if (sResetRecipe.ToUpper() == "YES")
                                {
                                    oSelectedRecipe = null;
                                    //makes sure that the object oSelectedRecipe is cleared.
                                    Console.WriteLine("Recipe has been cleared.");
                                }
                                else
                                {
                                    Console.WriteLine("No recipe was created to clear.");
                                }
                            }
                            return;
                        case 7:

                            Console.WriteLine("Thank you for using the eCook_Book!");
                            //allows the user to quit.
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid option. Please enter a number from 1 to 7.");
                            //user chooses an invalid option.
                            break;
                    }
                }


            }

            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Restart application. Error occcured in application. ");
                Console.ReadLine();

            }

            //contains main method to output the recipe.

        }

        
       
    }
}
//namespace