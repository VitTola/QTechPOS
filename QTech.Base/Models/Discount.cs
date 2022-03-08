using QTech.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Base.Models
{
    public class Discount : ActiveBaseModel
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ToDate { get; set; }
        public DiscountType DiscountType { get; set; }
        public string DiscountByProduct { get; set; }
        public string DiscountByTotal { get; set; }
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
