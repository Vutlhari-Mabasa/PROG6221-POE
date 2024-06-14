using System.Windows;

namespace RecipeManager
{
    public partial class AddStepWindow : Window
    {
        public string Step { get; private set; }

        public AddStepWindow()
        {
            InitializeComponent();
        }

        // Event handler for adding a new step
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Step = StepDescription.Text;
            DialogResult = true;
            Close();
        }
    }
}
