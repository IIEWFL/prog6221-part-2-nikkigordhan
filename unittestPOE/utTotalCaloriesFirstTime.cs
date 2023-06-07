using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROG_PoE;



namespace unittestPOE
{
    [TestClass]
    public class utTotalCaloriesFirstTime
    {
        [TestMethod]
        public void TestMethod_Calculate_Total_Calories_With_1_Ingreident()
        {
            // Arrange
            int iCalories = 5;
            int iExpectedTotCalories = 5;

            Recipe oRecipe = new Recipe();

            // Act
            oRecipe.Calculate_Total_Calories(iCalories);

            // Assert
            int iActualTotalCalories = oRecipe.iTotal_Calories;

            Assert.AreEqual(iActualTotalCalories, iExpectedTotCalories, "Total Calories for the first ingriedent not calculated correctly.");

            // the code for the test is adapted from Microsoft
            // https://learn.microsoft.com/en-us/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code?view=vs-2022#create-a-unit-test-project
            // there are 17 contributors.

        }

        [TestMethod]
        public void TestMethod_Calculate_Total_Calories_With_Multiple_Ingreidents()
        {
            // Arrange
            int iCalories1 = 10;
            int iCalories2 = 10;
            int iExpectedTotCalories = 20;

            Recipe oRecipe = new Recipe();

            // Act
            oRecipe.Calculate_Total_Calories(iCalories1);
            oRecipe.Calculate_Total_Calories(iCalories2);

            // Assert
            int iActualTotalCalories = oRecipe.iTotal_Calories;

            Assert.AreEqual(iActualTotalCalories, iExpectedTotCalories, "Total Calories for the recipe is not calculated correctly.");

            // the code for the test is adapted from Microsoft
            // https://learn.microsoft.com/en-us/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code?view=vs-2022#create-a-unit-test-project
            // there are 17 contributors.

        }

    }
}
