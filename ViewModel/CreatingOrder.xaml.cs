using Order.Files;
using Order_;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Order
{
    /// <summary>
    /// Logika interakcji dla klasy CreatingOrder.xaml
    /// </summary>
    public partial class CreatingOrder : Page
    {
        readonly LoadingWindow loadingWindow = new LoadingWindow();
        public CreatingOrder()
        {
            loadingWindow.Show();
            InitializeComponent();

            LoadClients();
            LoadProduct();
            loadingWindow.Close();
        }
        readonly Access access = new Access();

        //products list 
        #region product list
        List<Products> FirstProductsList = new List<Products>();
        List<Products> SecondProductsList = new List<Products>();
        List<Products> ThirdtProductsList = new List<Products>();
        List<Products> FourthProductsList = new List<Products>();
        readonly List<Products> AllProductsList = new List<Products>();
        #endregion


        //loading functions
        #region LoadingFunctions
        private void LoadClients()
        {
            //clients list
            List<Clients> FirstCLientsList = new List<Clients>();
            List<Clients> SecondCLientsList = new List<Clients>();
            List<Clients> AllCLientsList = new List<Clients>();

            //task which add client to list
            Task FirstClientsTask = Task.Run(() => FirstCLientsList = LoadFirstClientsList());
            Task SecondClientsTask = Task.Run(() => SecondCLientsList = LoadSecondClientsList());
            FirstClientsTask.Wait();

            SecondClientsTask.Wait();

            FirstCLientsList.AddRange(SecondCLientsList);
            AllCLientsList.AddRange(FirstCLientsList);

            //add clients to ClientComboBox
            foreach (Clients client in AllCLientsList)
            {
                ClientComboBox.Items.Add(client.ClientsName + " | " + client.City);
            }
        }
        private void LoadProduct()
        {
            Task FirstProductsTask = Task.Run(() => FirstProductsList = LoadFirstProductsList());
            Task SecondProductTask = Task.Run(() => SecondProductsList = LoadSecondProductList());
            Task ThirdProductTask = Task.Run(() => ThirdtProductsList = LoadThirdProductsList());
            Task FourthProductTask = Task.Run(() => FourthProductsList = LoadFourthProductsList());
            FirstProductsTask.Wait();
            SecondProductTask.Wait();

            ThirdProductTask.Wait();
            FourthProductTask.Wait();

            AllProductsList.AddRange(FirstProductsList);
            AllProductsList.AddRange(SecondProductsList);
            AllProductsList.AddRange(ThirdtProductsList);
            AllProductsList.AddRange(FourthProductsList);


            foreach (Products product in AllProductsList)
            {
                ProductComboBox.Items.Add(product.CatalogNumber + " | " + product.Name + " | " + product.Modell);
            }
        }
        #endregion

        //lists
        #region ListFunctions
        List<Clients> LoadFirstClientsList()
        {

            var clients = access.FirstPartClients();

            return clients;
        }
        List<Clients> LoadSecondClientsList()
        {

            var clients = access.SecondPartClients();

            return clients;
        }
        List<Products> LoadFirstProductsList()
        {

            var products = access.FirstPartProducts();

            return products;
        }
        List<Products> LoadSecondProductList()
        {

            var products = access.SecondPartProducts();

            return products;
        }
        List<Products> LoadThirdProductsList()
        {

            var products = access.ThirdPartProducts();

            return products;
        }
        List<Products> LoadFourthProductsList()
        {

            var products = access.FourthPartProducts();

            return products;
        }
        #endregion

        //button functions
        #region ButtonFunctions
        private void CreateOrederButton_Click(object sender, RoutedEventArgs e)
        {
            CreateNewOrder();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = GetInfomationAboutSelectedProduct().name;
            string modell = GetInfomationAboutSelectedProduct().modell;
            string catalogNumber = GetInfomationAboutSelectedProduct().catalogNumber;
            int price = GetInfomationAboutSelectedProduct().price;
            int quanitity;

            DialogWindow dialogWindow = new DialogWindow(name, modell, catalogNumber, price);

            dialogWindow.ShowDialog();

            quanitity = dialogWindow.Quantity;
            if (quanitity != 0)
            {
                Products product = new Products.ProductToTable(catalogNumber, name, quanitity, modell, price);

                ProductsTable.Items.Add(product);
            }


            dialogWindow.Quantity = 0;






        }
        #endregion
        private void AddProductToTable(string catalogNumber, string name, string modell, int quantity, int price)
        {
            Products product = new Products.ProductToTable(catalogNumber, name, quantity, modell, price);

            ProductsTable.Items.Add(product);
        }


        private (string name, string modell, string catalogNumber, int price) GetInfomationAboutSelectedProduct()
        {
            int Identifier = ProductComboBox.SelectedIndex;
            string name = null;
            string modell = null;
            string catalogNumber = null;
            int price = 0;

            Task ProductNameTask = Task.Run(() => name = access.ProductName(Identifier + 1));
            Task ProductModelTask = Task.Run(() => modell = access.ProductModel(Identifier + 1));
            Task CatalogNumberTask = Task.Run(() => catalogNumber = access.CatalogNumber(Identifier + 1));
            Task ProductPriceTask = Task.Run(() => price = Convert.ToInt32(access.ProductPrice(Identifier + 1)));

            ProductNameTask.Wait();
            ProductModelTask.Wait();
            CatalogNumberTask.Wait();
            ProductPriceTask.Wait();

            return (name, modell, catalogNumber, price);
        }




        //Creating a new order 
        private void CreateNewOrder()
        {

            Excel excel = new Excel();
            var client = new Clients.SetOrderClient(ClientComboBox.SelectedIndex + 1);
            var products = GetProducts();

            var order = new OrderClass(products, client, PaymentMethodRadioButtonCheck(), OrderFulfillmentRadioButtonCheck(), StringFromRichTextBox(DeliveryAddress), StringFromRichTextBox(CustomersOrderNumber), StringFromRichTextBox(Comments));
            excel.OpenNewExcelFile(order);


        }

        //Additional Information
        private string OrderFulfillmentRadioButtonCheck()
        {
            if (ImplementationInFullRadioButton.IsChecked == true)
            {
                return "realizacja w całości";
            }
            else if (SendAvailableRadioButton.IsChecked == true)
            {
                return "wysłać dostępne";
            }
            else
            {
                return null;
            }
        }
        private string PaymentMethodRadioButtonCheck()
        {
            if (TransferRadioButton.IsChecked == true)
            {
                return "przelew";
            }
            else if (PrepaymentRadioButton.IsChecked == true)
            {
                return "przedpłata";
            }
            else if (CashOnDeliveryRadioButton.IsChecked == true)
            {
                return "za pobraniem";
            }
            else
            {
                return null;
            }
        }
        private string StringFromRichTextBox(RichTextBox rtb)
        {
            TextRange textRange = new TextRange(
                rtb.Document.ContentStart,
                rtb.Document.ContentEnd
                );
            return textRange.Text;
        }

        //get product form table
        List<Products.ProductSet> GetProducts()
        {
            TextBlock CatalogNumberText;
            List<Products.ProductSet> productSets = new List<Products.ProductSet>();
            string[] items = new string[5];
            for (int item = 0; item < ProductsTable.Items.Count; item++)
            {
                for (int column = 0; column < ProductsTable.Columns.Count; column++)
                {
                    CatalogNumberText = ProductsTable.Columns[column].GetCellContent(ProductsTable.Items[item]) as TextBlock;
                    items[column] = CatalogNumberText.Text;
                }
                var product = new Products.ProductSet(items[0], items[1], Convert.ToInt32(items[2]), items[3], Convert.ToInt32(items[4]));
                productSets.Add(product);

            }
            return productSets;
        }
    }
}
