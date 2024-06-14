using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Wpf;

namespace RecipeManager
{
    public partial class MainWindow : Window
    {
        public List<Recipe> Recipes { get; set; } = new List<Recipe>();

        public MainWindow()
        {
            InitializeComponent();
            // Initialize the RecipeList's item source
            RecipeList.ItemsSource = Recipes.OrderBy(r => r.Name);
        }

        // Event handler for adding a new recipe
        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            var addRecipeWindow = new AddRecipeWindow();
            if (addRecipeWindow.ShowDialog() == true)
            {
                Recipes.Add(addRecipeWindow.Recipe);
                RefreshRecipeList();
            }
        }

        // Event handler for clearing all recipes
        private void ClearData_Click(object sender, RoutedEventArgs e)
        {
            Recipes.Clear();
            RefreshRecipeList();
        }

        // Event handler for scaling the selected recipe
        private void ScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeList.SelectedItem is Recipe selectedRecipe)
            {
                double scaleFactor = double.Parse(((Button)sender).Tag.ToString());
                selectedRecipe.Scale(scaleFactor);
                RefreshRecipeList();
            }
        }

        // Event handler for resetting quantities of the selected recipe
        private void ResetQuantities_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeList.SelectedItem is Recipe selectedRecipe)
            {
                selectedRecipe.ResetQuantities();
                RefreshRecipeList();
            }
        }

        // Event handler for selecting a recipe from the list
        private void RecipeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RecipeList.SelectedItem is Recipe selectedRecipe)
            {
                var viewRecipeWindow = new ViewRecipeWindow(selectedRecipe);
                viewRecipeWindow.Show();
            }
        }

        // Event handler for showing the menu pie chart
        private void ShowMenuPieChart_Click(object sender, RoutedEventArgs e)
        {
            var menuPieChartWindow = new MenuPieChartWindow(Recipes);
            menuPieChartWindow.Show();
        }

        // Method to refresh the recipe list
        private void RefreshRecipeList()
        {
            RecipeList.ItemsSource = null;
            RecipeList.ItemsSource = Recipes.OrderBy(r => r.Name);
        }
    }

    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<string> Steps { get; set; } = new List<string>();
        public double OriginalScale { get; private set; } = 1;

        // Method to scale the ingredient quantities
        public void Scale(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
            }
            OriginalScale *= factor;
        }

        // Method to reset ingredient quantities to original values
        public void ResetQuantities()
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity /= OriginalScale;
            }
            OriginalScale = 1;
        }
    }

    public class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public double Calories { get; set; }
        public string FoodGroup { get; set; }
    }
}
