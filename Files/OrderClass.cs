using Order;
using System.Collections.Generic;

namespace Order_
{
    class OrderClass
    {
        protected List<Products.ProductSet> _products;
        protected Clients.SetOrderClient _setclient;
        protected string _paymentmethod;
        protected string _orderfulfillment;
        protected string _deliveryadress;
        protected string _customersordernumber;
        protected string _comments;

        public List<Products.ProductSet> Products
        {
            get { return _products; }
            set { _products = value; }
        }
        public Clients.SetOrderClient Client
        {
            get { return _setclient; }
            set { _setclient = value; }
        }
        public string PaymentMethod
        {
            get { return _paymentmethod; }
            set { _paymentmethod = value; }
        }
        public string OrderFulfillment
        {
            get { return _orderfulfillment; }
            set { _orderfulfillment = value; }
        }
        public string DeliveryAdress
        {
            get { return _deliveryadress; }
            set { _deliveryadress = value; }
        }
        public string CustomersOrderNumber
        {
            get { return _customersordernumber; }
            set { _customersordernumber = value; }
        }
        public string Comments
        {
            get { return _comments; }
            set { _comments = value; }
        }
        public OrderClass(List<Products.ProductSet> products, Clients.SetOrderClient clients, string paymentmethod, string orderfulfillment, string deliveryadress, string customersordernumber, string comments)
        {
            _products = products;
            _setclient = clients;
            _paymentmethod = paymentmethod;
            _orderfulfillment = orderfulfillment;
            _deliveryadress = deliveryadress;
            _customersordernumber = customersordernumber;
            _comments = comments;
        }

    }
}
