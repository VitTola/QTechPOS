using EasyServer.Domain.Models;
using QTech.Base.Enums;
using QTech.Base.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Base
{
    public class Sale: ActiveBaseModel
    {
        [AuditData(resourceName: "SaleDate", index:1)]
        public DateTime SaleDate { get; set; }
        [AuditData(resourceName: "InvoiceNo", index:2)]
        public string InvoiceNo { get; set; }
        [DisplayName("Employee")]
        [AuditData(resourceName: "Employee", index:3)]
        public int EmployeeId { get; set; }
        [AuditData(Ignored: true)]
        public PayStatus PayStatus { get; set; }
        [AuditData(resourceName: "CustomerName", index:4)]
        public string CustomerName { get; set; }
        [AuditData(resourceName: "Phone", index:5)]
        public string Phone { get; set; }
        [AuditData(Ignored:true)]
        public decimal Profit { get; set; }
        [AuditData(resourceName: "OtherExpense", index:6)]
        public decimal OtherExpense { get; set; }
        [AuditData(Ignored: true)]
        public SaleType SaleType { get; set; }
        [DisplayName("Customer")]
        [AuditData(resourceName: "Customer", index:7)]
        public int CustomerId { get; set; }
        [AuditData(resourceName: "Note", index:8)]
        public string Note { get; set; }
        [AuditData(resourceName: "PaymentRecieve", index:9)]
        public decimal PaymentRecieve { get; set; }
        [AuditData(resourceName: "PaymentLeft", index:10)]
        public decimal PaymentLeft { get; set; }
        [AuditData(resourceName: "Total", index:11)]
        public decimal Total { get; set; }
        [AuditData(resourceName: "SaleDetails", index:12)]
        public List<SaleDetail> SaleDetails { get; set; }
    }

    public class SaleDetail : ActiveBaseModel
    {
        [AuditData(Ignored: true)]
        public int SaleId { get; set; }
        [DisplayName("Product")]
        [AuditData(resourceName: "Product", index:1)]
        public int ProductId { get; set; }
        [DisplayName("Scale")]
        [AuditData(resourceName: "Scale", index:2)]
        public int ScaleId { get; set; }
        [AuditData(resourceName: "Quantity", index:3)]
        public int Quantity { get; set; }
        [AuditData(resourceName: "UnitPrice", index:4)]
        public decimal UnitPrice { get; set; }
        [AuditData(resourceName: "Total", index:5)]
        public decimal Total{ get; set; }
    }
}






