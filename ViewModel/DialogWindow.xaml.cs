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
   
    public partial class DialogWindow : Window
    {
        public DialogWindow(string name, string modell, string catalogNumber, int price)
        {
            InitializeComponent();
           
            NameSelectedProductLabel.Content = name;
            CatalogNumberSelectedProductLabel.Content = catalogNumber;
            PriceSelectedProduct.Content = price;
            ModellSelectedProductLabel.Content = modell;
        }
        private int _quantity;
        public int Quantity { get { return _quantity; }set { _quantity = value; } }
        private void SubmitProductButtonClick(object sender, RoutedEventArgs e)
        {
            _quantity =Convert.ToInt32( ProductQuantityTextBox.Text.ToString());
            Close();
        }
    }

}


