using System;
using System.Windows;

namespace RecipeManager
{
    public partial class AddRecipeWindow : Window
    {
        public Recipe Recipe { get; private set; }

        public AddRecipeWindow()
        {
            InitializeComponent();
        }

        // Event handler for adding a new recipe
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var recipe = new Recipe
                {
                    Name = RecipeName.Text
                };

                int numIngredients = int.Parse(NumIngredients.Text);
                int numSteps = int.Parse(NumSteps.Text);

                // Collecting ingredient details
                for (int i = 0; i < numIngredients; i++)
                {
                    var ingredientWindow = new AddIngredientWindow();
                    if (ingredientWindow.ShowDialog() == true)
                    {
                        recipe.Ingredients.Add(ingredientWindow.Ingredient);
                    }
                }

                // Collecting step details
                for (int i = 0; i < numSteps; i++)
                {
                    var stepWindow = new AddStepWindow();
                    if (stepWindow.ShowDialog() == true)
                    {
                        recipe.Steps.Add(stepWindow.Step);
                    }
                }

                Recipe = recipe;
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid input. Please try again.\n" + ex.Message);
            }
        }
    }
}
