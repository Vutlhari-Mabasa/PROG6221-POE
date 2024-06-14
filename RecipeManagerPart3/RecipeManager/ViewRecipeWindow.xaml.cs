using System.Linq;
using System.Windows;

namespace RecipeManager
{
    public partial class ViewRecipeWindow : Window
    {
        public ViewRecipeWindow(Recipe recipe)
        {
            InitializeComponent();
            DisplayRecipe(recipe);
        }

        // Method to display the recipe details
        private void DisplayRecipe(Recipe recipe)
        {
            string details = $"Recipe Name: {recipe.Name}\n\nIngredients:\n";

            foreach (var ingredient in recipe.Ingredients)
            {
                details += $"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} (Calories: {ingredient.Calories}, Food Group: {ingredient.FoodGroup})\n";
            }

            details += "\nSteps:\n";

            for (int i = 0; i < recipe.Steps.Count; i++)
            {
                details += $"{i + 1}. {recipe.Steps[i]}\n";
            }

            details += $"\nTotal Calories: {recipe.Ingredients.Sum(i => i.Calories)}";

            RecipeDetails.Text = details;

            if (recipe.Ingredients.Sum(i => i.Calories) > 300)
            {
                MessageBox.Show("Warning: Total calories exceed 300!");
            }
        }
    }
}
