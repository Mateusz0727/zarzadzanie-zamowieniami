namespace Order
{
    class Products
    {
        private string _polishName;
        private string _catalogNumber;
        private string _modell;
        private int _price;
        private int _quantity;
        public string Name { get { return _polishName; } set { _polishName = value; } }
        public string CatalogNumber { get { return _catalogNumber; } set { _catalogNumber = value; } }
        public string Modell { get { return _modell; } set { _modell = value; } }
        public int Price { get { return _price; } set { _price = value; } }
        public int Quantity { get { return _quantity; } set { _quantity = value; } }
        public class ProductsToComboBox : Products
        {
            public ProductsToComboBox(string name, string catalogNumber, string modell)
            {
                _polishName = name;
                _catalogNumber = catalogNumber;
                _modell = modell;

            }
        }
        public class ProductToTable : Products
        {
            public ProductToTable(string catalogNumber, string polishname, int quantity, string modell, int price)
            {
                _catalogNumber = catalogNumber;
                _polishName = polishname;
                _quantity = quantity;
                _modell = modell;
                _price = price;
            }
        }
        public class ProductSet : Products
        {
            public ProductSet(string catalogNumber, string polishname, int quantity, string modell, int price)
            {
                _catalogNumber = catalogNumber;
                _polishName = polishname;
                _quantity = quantity;
                _modell = modell;
                _price = price;
            }
        }


    }
}
