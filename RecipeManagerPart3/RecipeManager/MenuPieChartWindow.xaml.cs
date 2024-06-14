using LiveCharts;
using LiveCharts.Wpf;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace RecipeManager
{
    public partial class MenuPieChartWindow : Window
    {
        public MenuPieChartWindow(List<Recipe> recipes)
        {
            InitializeComponent();
            DisplayPieChart(recipes);
        }

        // Method to display the pie chart
        private void DisplayPieChart(List<Recipe> recipes)
        {
            var foodGroupCounts = new Dictionary<string, double>();

            foreach (var recipe in recipes)
            {
                foreach (var ingredient in recipe.Ingredients)
                {
                    if (!foodGroupCounts.ContainsKey(ingredient.FoodGroup))
                    {
                        foodGroupCounts[ingredient.FoodGroup] = 0;
                    }
                    foodGroupCounts[ingredient.FoodGroup] += ingredient.Quantity;
                }
            }

            var pieSeries = new SeriesCollection();

            foreach (var foodGroup in foodGroupCounts)
            {
                pieSeries.Add(new PieSeries
                {
                    Title = foodGroup.Key,
                    Values = new ChartValues<double> { foodGroup.Value },
                    DataLabels = true
                });
            }

            PieChart.Series = pieSeries;
        }
    }
}
