using Order.Files;
using Order_;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Threading;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Order
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {

          
            InitializeComponent();
            CreatingOrder page1 = new CreatingOrder();
            MainFrame.Content = page1;
        }

        private void CreatingOrderButton_Click(object sender, RoutedEventArgs e)
        {
            CreatingOrder page1 = new CreatingOrder();
            MainFrame.Content = page1;
        }

        private void DatabaseEditButton_Click(object sender, RoutedEventArgs e)
        {
            DatabaseEdit page2 = new DatabaseEdit();
            MainFrame.Content = page2;
        }
    }
}
