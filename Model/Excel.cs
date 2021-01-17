
using Order_;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using _Excel = Microsoft.Office.Interop.Excel;
using System.Globalization;
using System;

namespace Order.Files
{
    class Excel
    {
        readonly _Excel.Application ExcelApplication = new _Excel.Application();
        _Excel._Workbook WorkBook;
        _Excel._Worksheet WorkSheet;

        //Constructor
        public void OpenNewExcelFile(OrderClass Order)
        {
           

            //Get a new workbook
            WorkBook = (_Excel._Workbook)(ExcelApplication.Workbooks.Add(Missing.Value));

            //Get a new worksheet
            WorkSheet = (_Excel._Worksheet)WorkBook.ActiveSheet;
            ExcelApplication.Visible = true;

            SetAll(Order);
        }

        //setting styles in an excel file
        void SetExcelStyle()
        {
           _Excel.Range range;
            #region columnWidth

            range = (_Excel.Range)WorkSheet.Cells[1, 1];
            range.ColumnWidth = 7.22;
            range = (_Excel.Range)WorkSheet.Cells[1, 2];
            range.ColumnWidth = 10.67;
            range = (_Excel.Range)WorkSheet.Cells[1, 3];
            range.ColumnWidth = 8.22;
            range = (_Excel.Range)WorkSheet.Cells[1, 4];
            range.ColumnWidth = 6.57;
            range = (_Excel.Range)WorkSheet.Cells[1, 5];
            range.ColumnWidth = 7;
            range = (_Excel.Range)WorkSheet.Cells[1, 6];
            range.ColumnWidth = 8;
            range = (_Excel.Range)WorkSheet.Cells[1, 7];
            range.ColumnWidth = 5;
            range = (_Excel.Range)WorkSheet.Cells[1, 8];
            range.ColumnWidth = 12.22;
            range = (_Excel.Range)WorkSheet.Cells[1, 9];
            range.ColumnWidth = 8.67;
            range = (_Excel.Range)WorkSheet.Cells[1, 10];
            range.ColumnWidth = 7;
            range = (_Excel.Range)WorkSheet.Cells[1, 10];
            range.ColumnWidth = 13.11;
            #endregion

            #region Font
            WorkSheet.Range["A1", "K51"].Font.Name = "Arial";
            WorkSheet.Range["H4"].Font.Italic = true;
            WorkSheet.Range["H4"].Font.Underline = true;
            WorkSheet.Range["K19", "K45"].Style = "Currency";
            WorkSheet.Range["H19", "H45"].Style = "Currency";
            WorkSheet.Range["I19", "I42"].Style = "Percent";
            WorkSheet.Range["J19", "J42"].Style = "Percent";
            #endregion

            #region Merge
            for(int i= 18;i<44;i++)
            {
                WorkSheet.Range["C" + i, "F" + i].Merge();
            }
            #endregion

            WorkSheet.Range["A18", "K43"].Borders.LineStyle = _Excel.XlLineStyle.xlContinuous;
            WorkSheet.Range["A18", "K43"].Borders.Weight = _Excel.XlBorderWeight.xlThin;
            WorkSheet.Range["H18"].Cells.WrapText = true;
            WorkSheet.Range["B12"].Cells.WrapText = false;
            WorkSheet.Range["C15"].Cells.WrapText = false;
            WorkSheet.Range["C4"].Cells.WrapText = false;
            
        }

        //setting default informations
        void SetDefault()
        {
            WorkSheet.get_Range("K43", "K43").Formula = "=SUM(K19:K42)";
            
            
            WorkSheet.Cells[1, 5] = "ZAMÓWIENIE";
            DateTime thisDay = DateTime.Today;
            WorkSheet.Cells[2, 8] = "z dnia ";
            WorkSheet.Cells[2, 9] = thisDay.ToString("D");
            WorkSheet.Cells[4, 1] = "Zamawiający:";
            WorkSheet.Cells[5, 1] = "Nr klienta";
            WorkSheet.Cells[5, 3] = "Grupa rabatowa";
            WorkSheet.Cells[4, 8] = "Realizujący:";
            WorkSheet.Cells[6, 1] = "Firma";
            WorkSheet.Cells[5, 8] = "XXX POLSKA";
            WorkSheet.Cells[6, 8] = "Rzeszów ul.miejska 3";
            WorkSheet.Cells[7, 8] = "35-506 Rzeszów";
            WorkSheet.Cells[8, 8] = "tel. 887 234 887";
            WorkSheet.Cells[9, 8] = "fax ";
            WorkSheet.Cells[7, 1] = "Ulica";
            WorkSheet.Cells[8, 1] = "Kod";
            WorkSheet.Cells[8, 4] = "Miasto";
            WorkSheet.Cells[9, 1] = "Kontakt";
            WorkSheet.Cells[9, 1] = "Tel.";
            WorkSheet.Cells[10, 4] = "fax";
            WorkSheet.Cells[10, 5] = "j.w.";
            WorkSheet.Cells[11, 1] = "NIP";
            WorkSheet.Cells[12, 1] = "Uwagi";

            WorkSheet.Cells[12, 7] = "Forma płatności:";

            WorkSheet.Cells[15, 1] = "Adres dostawy:";
          
            WorkSheet.Cells[14, 7] = "Przedst Handlowy :";
            WorkSheet.Cells[14, 10] = "Mateusz Zięba";
            WorkSheet.Cells[16, 7] = "Realizacja zamówienia";

            WorkSheet.Cells[18, 1] = "l.p";
            WorkSheet.Cells[18, 2] = "nr art.";
            WorkSheet.Cells[18, 4] = "Nazwa";
            WorkSheet.Cells[18, 7] = "ilość";
            WorkSheet.Cells[18, 8] = "Cena detal netto";
            WorkSheet.Cells[18, 9] = "Rabat I";
            WorkSheet.Cells[18, 10] = "Rabat II";
            WorkSheet.Cells[18, 11] = "Wartosć netto";
            WorkSheet.Cells[43, 10] = "Suma";
            WorkSheet.Cells[44, 7] = "Płatność w terminie";
            WorkSheet.Cells[45, 7] = "Płatność gotówką:";
            WorkSheet.Cells[47, 9] = "Razem";
            WorkSheet.Cells[44, 11] = "=(-K43*I44)";
            WorkSheet.Cells[45, 11] = "=(-K43-K44)*I45";
            WorkSheet.Cells[47, 11] = "=K43+K44+K45";

            //Net value function
            WorkSheet.Cells[19, 11] = "=(H19*(1-I19))*(1-J19)*G19";
            WorkSheet.Cells[20, 11] = "=(H20*(1-I20))*(1-J20)*G20";
            WorkSheet.Cells[21, 11] = "=(H21*(1-I21))*(1-J21)*G21";
            WorkSheet.Cells[22, 11] = "=(H22*(1-I22))*(1-J22)*G22";
            WorkSheet.Cells[23, 11] = "=(H23*(1-I23))*(1-J23)*G23";
            WorkSheet.Cells[24, 11] = "=(H24*(1-I24))*(1-J24)*G24";
            WorkSheet.Cells[25, 11] = "=(H25*(1-I25))*(1-J25)*G25";
            WorkSheet.Cells[26, 11] = "=(H26*(1-I26))*(1-J26)*G26";
            WorkSheet.Cells[27, 11] = "=(H27*(1-I27))*(1-J27)*G27";
            WorkSheet.Cells[28, 11] = "=(H28*(1-I28))*(1-J28)*G28";
            WorkSheet.Cells[29, 11] = "=(H29*(1-I29))*(1-J29)*G29";
            WorkSheet.Cells[30, 11] = "=(H30*(1-I30))*(1-J30)*G30";
            WorkSheet.Cells[31, 11] = "=(H31*(1-I31))*(1-J31)*G31";
            WorkSheet.Cells[32, 11] = "=(H32*(1-I32))*(1-J32)*G32";
            WorkSheet.Cells[33, 11] = "=(H33*(1-I33))*(1-J33)*G33";
            WorkSheet.Cells[34, 11] = "=(H34*(1-I34))*(1-J34)*G34";
            WorkSheet.Cells[35, 11] = "=(H35*(1-I35))*(1-J35)*G35";
            WorkSheet.Cells[36, 11] = "=(H36*(1-I36))*(1-J36)*G36";
            WorkSheet.Cells[37, 11] = "=(H37*(1-I37))*(1-J37)*G37";
            WorkSheet.Cells[38, 11] = "=(H38*(1-I38))*(1-J38)*G38";
            WorkSheet.Cells[39, 11] = "=(H39*(1-I39))*(1-J39)*G39";
            WorkSheet.Cells[40, 11] = "=(H40*(1-I40))*(1-J40)*G40";
            WorkSheet.Cells[41, 11] = "=(H41*(1-I41))*(1-J41)*G41";
            WorkSheet.Cells[42, 11] = "=(H42*(1-I42))*(1-J42)*G42";

            //ordinal number
            for (int i = 1; i < 24; i++)
            {
                int a = i + 18;
                WorkSheet.Cells[a, 1] = i;
            }

        }

        //setting customer informations
        void SetClientData(Clients.SetOrderClient client)
        {
            WorkSheet.Cells[8, 5] = client.City;

            WorkSheet.Cells[5, 2] = client.ClientNummber;

            WorkSheet.Cells[5, 4] = client.RabatGroup;

            WorkSheet.Cells[6, 2] = client.ClientsName;

            WorkSheet.Cells[7, 2] = client.Street;

            WorkSheet.Cells[8, 2] = client.PostalCode;
                        

            WorkSheet.Cells[9, 2] = client.PhoneNumber;

            WorkSheet.Cells[11, 2] = client.NIP;
        }

        //setting products informations
        void SetProduct(List<Products.ProductSet> products)
        {
            int a;
             for (int i = 0; i < products.Count; i++)
             {
                 a = i + 19;
                 WorkSheet.Cells[a, 8] = products[i].Price;
                 WorkSheet.Cells[a, 7] = products[i].Quantity;
                 WorkSheet.Cells[a, 3] = products[i].Name;
                 WorkSheet.Cells[a, 2] = products[i].CatalogNumber;
             }
        }
        
        //setting additional informations
        void SetAdditionalInformation(OrderClass order)
        {
            WorkSheet.Cells[12, 9] = order.PaymentMethod;
            WorkSheet.Cells[15,3]= order.DeliveryAdress;
            WorkSheet.Cells[12, 2] = order.Comments;
            WorkSheet.Cells[4,3]= order.CustomersOrderNumber;
            WorkSheet.Cells[16, 10] = order.OrderFulfillment;
        }

        void SetAll(OrderClass Order)
        {
            var client = Order.Client;
            var product = Order.Products;
            SetDefault();
            SetProduct(product);
            SetClientData(client);
            SetAdditionalInformation(Order);
            SetExcelStyle();
        }
    }
}
