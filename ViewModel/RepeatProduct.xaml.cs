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
using System.Windows.Shapes;

namespace Order
{
    /// <summary>
    /// Logika interakcji dla klasy RepeatProduct.xaml
    /// </summary>
    public partial class RepeatProduct : Window
    {
        public RepeatProduct(string name, string modell, string catalogNumber, int price)
        {
            InitializeComponent();
            NameSelectedProductLabel.Content = name;
            CatalogNumberSelectedProductLabel.Content = catalogNumber;
            PriceSelectedProduct.Content = price;
            ModellSelectedProductLabel.Content = modell;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
