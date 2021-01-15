namespace Order
{
    class Clients
    {
        protected string _name;
        protected string _city;
        protected string _street;
        protected string _contact;
        protected string _postalcode;
        protected string _phonenumber;
        protected string _clientnumber;
        protected string _rabatgroup;
        protected string _nip;

        //properties
        #region properties
        public string ClientsName
        {
            get { return _name; }
            set { _name = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        public string Street
        {
            get { return _street; }
            set { _street = value; }
        }
        public string Contact
        {
            get { return _contact; }
            set { _contact = value; }
        }
        public string PostalCode
        {
            get { return _postalcode; }
            set { _postalcode = value; }
        }
        public string PhoneNumber
        {
            get { return _phonenumber; }
            set { _phonenumber = value; }
        }
        public string ClientNummber
        {
            get { return _clientnumber; }
            set { _clientnumber = value; }
        }
        public string RabatGroup
        {
            get { return _rabatgroup; }
            set { _rabatgroup = value; }
        }
        public string NIP
        {
            get { return _nip; }
            set { _nip = value; }
        }



        #endregion

        public class LoadClientsToMainProgram : Clients
        {
            public LoadClientsToMainProgram(string name, string city)
            {
                _name = name;
                _city = city;
            }
        }

        public class OrderClient : Clients
        {
            public OrderClient(string name, string city, string street, string contact, string postalcode, string phonenumber, string clientnumber, string rabatgroup, string nip)
            {
                _name = name;
                _city = city;
                _street = street;
                _contact = contact;
                _postalcode = postalcode;
                _phonenumber = phonenumber;
                _clientnumber = clientnumber;
                _rabatgroup = rabatgroup;
                _nip = nip;

            }
        }
        public class SetOrderClient : Clients
        {
            public SetOrderClient(int Id)
            {
                Access getClientAccess = new Access();
                _name = getClientAccess.ClientName(Id);
                _city = getClientAccess.ClientCity(Id);
                _street = getClientAccess.ClientStreet(Id);
                _contact = getClientAccess.ClientContact(Id);
                _postalcode = getClientAccess.ClientPostalCode(Id);
                _phonenumber = getClientAccess.ClientPhoneNumber(Id);       
                _clientnumber = getClientAccess.ClientNumber(Id);
                _rabatgroup = getClientAccess.ClientRabatGroup(Id);
                _nip = getClientAccess.ClientNip(Id);
                
            }
        }
    }

}
