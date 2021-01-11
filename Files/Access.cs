using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows;


namespace Order
{
    class Access
    {
        readonly OleDbConnection dataConnection;
        public Access()
        {
            try
            {
                dataConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=bazadanych1.accdb;Persist Security Info=False");
                dataConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        public int MaxIDKlienci()
        {
            string MaxIDc = "SELECT MAX(Identyfikator) From Klienci";
            int MaxID1;


            var dataCommand = new OleDbCommand();
            dataCommand.Connection = dataConnection;

            try
            {
                dataCommand.CommandText = MaxIDc;
                dataCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MaxID1 = Convert.ToInt32(dataCommand.ExecuteScalar());

            return MaxID1;
        }

        public void CloseAccess()
        {
            dataConnection.Close();
        }
        public int MaxIDProdukt()
        {
            string MaxIDc = "SELECT MAX(Identyfikator) From Cennik";
            int MaxID1;

            var dataCommand = new OleDbCommand();
            dataCommand.Connection = dataConnection;

            try
            {
                dataCommand.CommandText = MaxIDc;

                dataCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            MaxID1 = Convert.ToInt32(dataCommand.ExecuteScalar());



            return MaxID1;
        }


        public string CatalogNumber(int Id)
        {
            string CatalogNumber = null;
            try
            {
                var dataCommand = new OleDbCommand();
                dataCommand.Connection = dataConnection;
                string SQLcom = "SELECT Nr_Kat From Cennik Where Identyfikator =" + Id;
                dataCommand.CommandText = SQLcom;
                dataCommand.ExecuteNonQuery();
                CatalogNumber = Convert.ToString(dataCommand.ExecuteScalar());

                return CatalogNumber;
            }
            catch (Exception ex)
            {
                MessageBox.Show("CatalogNumber");
                MessageBox.Show(ex.Message);
                return CatalogNumber;

            }
        }
        public string ProductModel(int Id)
        {
            string ProductModel = null;
            try
            {
                var dataCommand = new OleDbCommand();
                dataCommand.Connection = dataConnection;
                string SQLcom = "SELECT Modell From Cennik Where Identyfikator =" + Id;
                dataCommand.CommandText = SQLcom;
                dataCommand.ExecuteNonQuery();
                ProductModel = Convert.ToString(dataCommand.ExecuteScalar());

                return ProductModel;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ProductModel");
                MessageBox.Show(ex.Message);
                return ProductModel;
            }
        }
        public string ProductPrice(int Id)
        {
            string ProductPrice = null;
            try
            {
                var dataCommand = new OleDbCommand();
                dataCommand.Connection = dataConnection;
                string SQLcom = "SELECT Cena_Kat From Cennik Where Identyfikator =" + Id;
                dataCommand.CommandText = SQLcom;
                dataCommand.ExecuteNonQuery();
                ProductPrice = Convert.ToString(dataCommand.ExecuteScalar());

                return ProductPrice;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ProductModel");
                MessageBox.Show(ex.Message);
                return ProductPrice;
            }
        }
        public string ProductName(int Id)
        {
            string ProductName = null;
            try
            {
                var dataCommand = new OleDbCommand();
                dataCommand.Connection = dataConnection;
                string SQLcom = "SELECT Nazwa_Polska From Cennik Where Identyfikator =" + Id;
                dataCommand.CommandText = SQLcom;
                dataCommand.ExecuteNonQuery();
                ProductName = Convert.ToString(dataCommand.ExecuteScalar());

                return ProductName;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ProductModel");
                MessageBox.Show(ex.Message);
                return ProductName;
            }
        }

        #region Client
        public string ClientName(int Id)
        {
            string SqlCommand = $"SELECT Firma From Klienci Where Identyfikator={Id}";
            string ClientName;
            var dataCommand = new OleDbCommand();
            dataCommand.Connection = dataConnection;

            try
            {
                dataCommand.CommandText = SqlCommand;
                dataCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            ClientName = Convert.ToString(dataCommand.ExecuteScalar());
            return ClientName;
        }
        public string ClientCity(int Id)
        {
            string SqlCommand = $"SELECT miejscowość From Klienci Where Identyfikator={Id}";
            string ClientCity;
            var dataCommand = new OleDbCommand();
            dataCommand.Connection = dataConnection;

            try
            {
                dataCommand.CommandText = SqlCommand;
                dataCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            ClientCity = Convert.ToString(dataCommand.ExecuteScalar());
            return ClientCity;
        }
        public string ClientStreet(int Id)
        {
            string SqlCommand = $"SELECT ulica From Klienci Where Identyfikator={Id}";
            string ClientStreet;
            var dataCommand = new OleDbCommand();
            dataCommand.Connection = dataConnection;

            try
            {
                dataCommand.CommandText = SqlCommand;
                dataCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            ClientStreet = Convert.ToString(dataCommand.ExecuteScalar());
            return ClientStreet;
        }
        public string ClientContact(int Id)
        {
            string SqlCommand = $"SELECT mail From Klienci Where Identyfikator={Id}";
            string ClientContact;
            var dataCommand = new OleDbCommand();

            dataCommand.Connection = dataConnection;

            try
            {
                dataCommand.CommandText = SqlCommand;
                dataCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            ClientContact = Convert.ToString(dataCommand.ExecuteScalar());
            return ClientContact;
        }
        public string ClientPostalCode(int Id)
        {
            string SqlCommand = $"SELECT kod_pocztowy From Klienci Where Identyfikator={Id}";
            string ClientPostalCode;
            var dataCommand = new OleDbCommand();
            dataCommand.Connection = dataConnection;

            try
            {
                dataCommand.CommandText = SqlCommand;
                dataCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            ClientPostalCode = Convert.ToString(dataCommand.ExecuteScalar());
            return ClientPostalCode;
        }
        public string ClientPhoneNumber(int Id)
        {
            string SqlCommand = $"SELECT telefon From Klienci Where Identyfikator={Id}";
            string ClientPhoneNumber;
            var dataCommand = new OleDbCommand();
            dataCommand.Connection = dataConnection;

            try
            {
                dataCommand.CommandText = SqlCommand;
                dataCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            ClientPhoneNumber = Convert.ToString(dataCommand.ExecuteScalar());
            return ClientPhoneNumber;
        }
        public string ClientNumber(int Id)
        {
            string SqlCommand = $"SELECT nr_klienta From Klienci Where Identyfikator={Id}";
            string ClientNumber;
            var dataCommand = new OleDbCommand();
            dataCommand.Connection = dataConnection;

            try
            {
                dataCommand.CommandText = SqlCommand;
                dataCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

             ClientNumber = Convert.ToString(dataCommand.ExecuteScalar());
           
            
            return ClientNumber;
        }
        public string ClientRabatGroup(int Id)
        {
            string SqlCommand = $"SELECT Grupa_rabatowa From Klienci Where Identyfikator={Id}";
            string ClientRabatGroup;
            var dataCommand = new OleDbCommand();
            dataCommand.Connection = dataConnection;

            try
            {
                dataCommand.CommandText = SqlCommand;
                dataCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            ClientRabatGroup = Convert.ToString(dataCommand.ExecuteScalar());
            return ClientRabatGroup;
        }
        public string ClientNip(int Id)
        {
            string SqlCommand = $"SELECT NIP From Klienci Where Identyfikator={Id}";
            string ClientNip;
            var dataCommand = new OleDbCommand();
            dataCommand.Connection = dataConnection;

            try
            {
                dataCommand.CommandText = SqlCommand;
                dataCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            ClientNip = Convert.ToString(dataCommand.ExecuteScalar());
            return ClientNip;
        }
        #endregion

        #region clients and Products List
        public List<Clients> FirstPartClients()
    {

        List<Clients> Clients = new List<Clients>();
        int MaxClients = MaxIDKlienci();
        string name;
        string city;
        string SQLcom;
        try
        {
            var dataCommand = new OleDbCommand();
            dataCommand.Connection = dataConnection;

            for (int i = 1; i < MaxClients / 2; i++)
            {

                SQLcom = "SELECT Firma From Klienci Where Identyfikator =" + i;
                dataCommand.CommandText = SQLcom;
                dataCommand.ExecuteNonQuery();
                name = Convert.ToString(dataCommand.ExecuteScalar());
                SQLcom = "SELECT miejscowość From Klienci Where Identyfikator =" + i;
                dataCommand.CommandText = SQLcom;
                dataCommand.ExecuteNonQuery();
                city = Convert.ToString(dataCommand.ExecuteScalar());
                Clients.Add(new Clients.LoadClientsToMainProgram(name, city));

            }

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            MessageBox.Show("First");

        }



        return Clients;
    }
    public List<Clients> SecondPartClients()
    {
        List<Clients> Clients = new List<Clients>();
        int MaxClients = MaxIDKlienci();
        string name;
        string city;
        string SQLcom;
        try
        {
            var dataCommand = new OleDbCommand();
            dataCommand.Connection = dataConnection;

            for (int i = MaxClients / 2; i <= MaxClients; i++)
            {
                SQLcom = "SELECT Firma From Klienci Where Identyfikator =" + i;
                dataCommand.CommandText = SQLcom;
                dataCommand.ExecuteNonQuery();
                name = Convert.ToString(dataCommand.ExecuteScalar());
                SQLcom = "SELECT miejscowość From Klienci Where Identyfikator =" + i;
                dataCommand.CommandText = SQLcom;
                dataCommand.ExecuteNonQuery();
                city = Convert.ToString(dataCommand.ExecuteScalar());
                Clients.Add(new Clients.LoadClientsToMainProgram(name, city));
            }

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            MessageBox.Show("Second");

        }
        return Clients;
    }
    public List<Products> FirstPartProducts()
    {

        List<Products> Products = new List<Products>();
        int MaxProducts = MaxIDProdukt();
        string PolishName;
        string CatalogNumber;
        string Modell;
        string SQLcom;
        try
        {
            var dataCommand = new OleDbCommand();
            dataCommand.Connection = dataConnection;
            for (int i = 1; i < MaxProducts / 4; i++)
            {
                SQLcom = "SELECT Nazwa_Polska From Cennik Where Identyfikator =" + i;
                dataCommand.CommandText = SQLcom;
                dataCommand.ExecuteNonQuery();
                PolishName = Convert.ToString(dataCommand.ExecuteScalar());
                SQLcom = "SELECT Nr_Kat From Cennik Where Identyfikator =" + i;
                dataCommand.CommandText = SQLcom;
                dataCommand.ExecuteNonQuery();
                CatalogNumber = Convert.ToString(dataCommand.ExecuteScalar());
                SQLcom = "SELECT Modell From Cennik Where Identyfikator =" + i;
                dataCommand.CommandText = SQLcom;
                dataCommand.ExecuteNonQuery();
                Modell = Convert.ToString(dataCommand.ExecuteScalar());
                Products.Add(new Products.ProductsToComboBox(PolishName, CatalogNumber, Modell));
            }

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            MessageBox.Show("niedziala");
        }

        return Products;
    }
    public List<Products> SecondPartProducts()
    {
        List<Products> Products = new List<Products>();
        int MaxProducts = MaxIDProdukt();
        string PolishName;
        string CatalogNumber;
        string Modell;
        string SQLcom;
        try
        {
            var dataCommand = new OleDbCommand();
            dataCommand.Connection = dataConnection;
            for (int i = MaxProducts / 4; i < MaxProducts / 2; i++)
            {
                SQLcom = "SELECT Nazwa_Polska From Cennik Where Identyfikator =" + i;
                dataCommand.CommandText = SQLcom;
                dataCommand.ExecuteNonQuery();
                PolishName = Convert.ToString(dataCommand.ExecuteScalar());
                SQLcom = "SELECT Nr_Kat From Cennik Where Identyfikator =" + i;
                dataCommand.CommandText = SQLcom;
                dataCommand.ExecuteNonQuery();
                CatalogNumber = Convert.ToString(dataCommand.ExecuteScalar());
                SQLcom = "SELECT Modell From Cennik Where Identyfikator =" + i;
                dataCommand.CommandText = SQLcom;
                dataCommand.ExecuteNonQuery();
                Modell = Convert.ToString(dataCommand.ExecuteScalar());
                Products.Add(new Products.ProductsToComboBox(PolishName, CatalogNumber, Modell));
            }

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            MessageBox.Show("niedziala");
        }
        return Products;
    }
    public List<Products> ThirdPartProducts()
    {
        List<Products> Products = new List<Products>();
        int MaxProducts = MaxIDProdukt();
        string PolishName;
        string CatalogNumber;
        string Modell;
        string SQLcom;
        try
        {
            var dataCommand = new OleDbCommand();
            dataCommand.Connection = dataConnection;
            for (int i = MaxProducts / 2; i < (MaxProducts / 4) * 3; i++)
            {
                SQLcom = "SELECT Nazwa_Polska From Cennik Where Identyfikator =" + i;
                dataCommand.CommandText = SQLcom;
                dataCommand.ExecuteNonQuery();
                PolishName = Convert.ToString(dataCommand.ExecuteScalar());
                SQLcom = "SELECT Nr_Kat From Cennik Where Identyfikator =" + i;
                dataCommand.CommandText = SQLcom;
                dataCommand.ExecuteNonQuery();
                CatalogNumber = Convert.ToString(dataCommand.ExecuteScalar());
                SQLcom = "SELECT Modell From Cennik Where Identyfikator =" + i;
                dataCommand.CommandText = SQLcom;
                dataCommand.ExecuteNonQuery();
                Modell = Convert.ToString(dataCommand.ExecuteScalar());
                Products.Add(new Products.ProductsToComboBox(PolishName, CatalogNumber, Modell));
            }

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            MessageBox.Show("niedziala");
        }
        return Products;
    }
    public List<Products> FourthPartProducts()
    {
        List<Products> Products = new List<Products>();
        int MaxProducts = MaxIDProdukt();
        string PolishName;
        string CatalogNumber;
        string Modell;
        string SQLcom;
        try
        {
            var dataCommand = new OleDbCommand();
            dataCommand.Connection = dataConnection;
            for (int i = (MaxProducts / 4) * 3; i <= MaxProducts; i++)
            {
                SQLcom = "SELECT Nazwa_Polska From Cennik Where Identyfikator =" + i;
                dataCommand.CommandText = SQLcom;
                dataCommand.ExecuteNonQuery();
                PolishName = Convert.ToString(dataCommand.ExecuteScalar());
                SQLcom = "SELECT Nr_Kat From Cennik Where Identyfikator =" + i;
                dataCommand.CommandText = SQLcom;
                dataCommand.ExecuteNonQuery();
                CatalogNumber = Convert.ToString(dataCommand.ExecuteScalar());
                SQLcom = "SELECT Modell From Cennik Where Identyfikator =" + i;
                dataCommand.CommandText = SQLcom;
                dataCommand.ExecuteNonQuery();
                Modell = Convert.ToString(dataCommand.ExecuteScalar());
                Products.Add(new Products.ProductsToComboBox(PolishName, CatalogNumber, Modell));
            }

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            MessageBox.Show("niedziala");
        }
        return Products;
    }
    #endregion
}
}

