using QTech.Base;
using QTech.Base.BaseModels;
using QTech.Base.Helpers;
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
    public class CustomerLogic : DbLogic<Customer, CustomerLogic>
    {
        public CustomerLogic()
        {

        }
        public override Customer AddAsync(Customer entity)
        {
            var result = base.AddAsync(entity);
            if (result != null)
            {
                AuditTrailLogic.Instance.AddManualAuditTrail<Customer, int, Customer>(entity, null, GeneralProcess.Add);
            }
            return entity;
        }
        public override Customer FindAsync(int id)
        {
            var result = All().FirstOrDefault(x => x.Active && x.Id == id);
            return result;
        }
        public override bool CanRemoveAsync(Customer entity)
        {
            return true;
        }
        public override List<Customer> SearchAsync(ISearchModel model)
        {
            var result = Search(model).ToList();
            return result;
        }
        public override IQueryable<Customer> Search(ISearchModel model)
        {
            var param = model as CustomerSearch;
            var par = param?.Search;
            var q = All().Where(x => x.Active);
            if (!string.IsNullOrEmpty(param.Search))
            {
                q = q.Where(x => x.Name.ToLower().Contains(param.Search.ToLower()));
            }

            return q;
        }
        public override Customer UpdateAsync(Customer entity)
        {
            var oldEntity = base.GetOldEntityAsync(entity).Result;
            var result = base.UpdateAsync(entity);
            if (result != null)
            {
                AuditTrailLogic.Instance.AddManualAuditTrail<Customer, int, Customer>(entity, oldEntity, GeneralProcess.Update);
            }
            return entity;
        }
       
        public List<Customer> GetCustomersById(List<int> Ids)
        {
            var customers = _db.Customers.Where(cus => cus.Active && Ids.Any(id => id == cus.Id));
            return customers.ToList();
        }
}
}
