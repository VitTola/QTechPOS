using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTechSearch = QTech.Base.BaseModels;

namespace QTech.Base.SearchModels
{
    public class ScaleSearch : QTechSearch.BasicSearchModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
