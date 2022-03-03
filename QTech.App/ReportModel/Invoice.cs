using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.ReportModel
{
    public class Invoice
    {
        public string Company { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Cashier { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoicingDate { get; set; }
        public string TotalAmount { get; set; }
        public string PaidAmount { get; set; }
        public string LeftAmount { get; set; }

    }
    
    public class InvoiceDetail
    {
        public string Product { get; set; }
        public int Qauntity { get; set; }
        public string UnitPrice { get; set; }
        public string Total { get; set; }

    }
}
