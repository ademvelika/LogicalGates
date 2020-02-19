using System.Windows;
using System.Windows.Controls;

namespace LogicalGates.MyController
{
    /// <summary>
    /// Interaction logic for Switch.xaml
    /// </summary>
    public partial class Switch : UserControl
    {
        private readonly char name;
        public Switch()
        {
            InitializeComponent();
        }

        public Switch(char n)
        {
            InitializeComponent();

            Inputer.Content = n;
            name = n;
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {     
                (App.Current.MainWindow as MainWindow).AssignValue(name, true);
        }

        private void SwitchBtn_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current.MainWindow as MainWindow).AssignValue(name, false);
        }
    }
}
