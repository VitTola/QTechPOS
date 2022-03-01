using QTech.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTech.Base.Helpers
{
    public static class Constants
    {
        public static Dictionary<SaleSearchKey, Keys> KeyShortcut => new Lazy<Dictionary<SaleSearchKey, Keys>>(() =>
           new Dictionary<SaleSearchKey, Keys>()
           {
                {SaleSearchKey.InvoiceNo, Keys.F3 },
                {SaleSearchKey.CustomerName, Keys.F4 },
           }).Value;



    }
}
