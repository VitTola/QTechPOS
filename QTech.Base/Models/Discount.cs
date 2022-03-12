using QTech.Base.Enums;
using QTech.Base.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Base.Models
{
    public class Discount : ActiveBaseModel
    {
        [AuditData(resourceName: "Name", index: 1)]
        public string Name { get; set; }
        [AuditData(resourceName: "FromDate",dateformat:"dd-MMM-yyyy", index: 2)]
        public DateTime StartDate { get; set; }
        [AuditData(resourceName: "ToDate", dateformat: "dd-MMM-yyyy", index: 3)]
        public DateTime ToDate { get; set; }
        [AuditData(resourceName: "DiscountType", index: 4)]
        public DiscountType DiscountType { get; set; }
        [AuditData(resourceName: "DiscountByProduct", index: 5)]
        public string DiscountByProduct { get; set; }
        [AuditData(resourceName: "DiscountByTotal", index: 6)]
        public string DiscountByTotal { get; set; }
        [AuditData(resourceName: "Note", index: 7)]
        public string Note { get; set; }
    }
    public class DiscountByTotal
    {
        public int Order { get; set; }
        public decimal FromPrice { get; set; }
        public decimal ToPrice { get; set; }
        public decimal Percent { get; set; }
        
    }
    public class DiscountByProduct
    {
        public int Order { get; set; }
        public int ProductId { get; set; }
        public decimal Percent { get; set; }
        
    }
}
