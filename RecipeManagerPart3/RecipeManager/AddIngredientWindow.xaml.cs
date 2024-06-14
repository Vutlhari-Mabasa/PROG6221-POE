using System;
using System.Windows;

namespace RecipeManager
{
    public partial class AddIngredientWindow : Window
    {
        public Ingredient Ingredient { get; private set; }

        public AddIngredientWindow()
        {
            InitializeComponent();
        }

        // Event handler for adding a new ingredient
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Ingredient = new Ingredient
                {
                    Name = IngredientName.Text,
                    Quantity = double.Parse(Quantity.Text),
                    Unit = Unit.Text,
                    Calories = double.Parse(Calories.Text),
                    FoodGroup = FoodGroup.Text
                };

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
