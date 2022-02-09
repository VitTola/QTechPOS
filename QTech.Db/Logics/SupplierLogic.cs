using QTech.Base;
using QTech.Base.BaseModels;
using QTech.Base.Models;
using QTech.Base.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QTech.Db.MasterLogic;

namespace QTech.Db.Logics
{
    public class SupplierLogic : DbLogic<Supplier, SupplierLogic>
    {
        public SupplierLogic()
        {

        }
        public override Supplier AddAsync(Supplier entity)
        {
            var Supplier = base.AddAsync(entity);
            return entity;
        }
        public override Supplier FindAsync(int id)
        {
            var result = All().FirstOrDefault(x => x.Active && x.Id == id);
            return result;
        }
        public override bool CanRemoveAsync(Supplier entity)
        {
            return true;
        }
        public override List<Supplier> SearchAsync(ISearchModel model)
        {
            var result = Search(model).ToList();
            return result;
        }
        public override IQueryable<Supplier> Search(ISearchModel model)
        {
            var param = model as SupplierSearch;
            var par = param?.Search;
            var q = All().Where(x => x.Active);
            if (!string.IsNullOrEmpty(param.Search))
            {
                q = q.Where(x => x.Name.ToLower().Contains(param.Search.ToLower()));
            }

            return q;
        }
        public override Supplier UpdateAsync(Supplier entity)
        {
            base.UpdateAsync(entity);
            return entity;
        }
       
}
}
