using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LogicalGates.MyController
{
    /// <summary>
    /// Interaction logic for Lamp.xaml
    /// </summary>
    public partial class Lamp : UserControl
    {
        public Lamp()
        {
            InitializeComponent();
        }

        public void Swich(bool state)
        {
            if (state)
            {
                OFF.Visibility = Visibility.Collapsed;
                ON.Visibility = Visibility.Visible;
            }
            else
            {
                ON.Visibility = Visibility.Collapsed;
                OFF.Visibility = Visibility.Visible;
            }
        }
    }
}
