using QTech.Base;
using QTech.Base.BaseModels;
using QTech.Base.Enums;
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
    public class InvoiceLogic : DbLogic<Invoice, InvoiceLogic>
    {
        public InvoiceLogic()
        {
        }
        public override Invoice FindAsync(int id)
        {
            var result = All().FirstOrDefault(x => x.Active && x.Id == id);
            return result;
        }
        public override bool CanRemoveAsync(Invoice entity)
        {
            if (!All().Any(x => x.Active && x.Id == entity.Id))
            {
                return false;
            }
            else if (entity.InvoiceStatus == InvoiceStatus.Paid)
            {
                return false;
            }
            if (entity.InvoiceStatus == InvoiceStatus.PaySome)
            {
                return false;
            }
            return true;
        }
        public override List<Invoice> SearchAsync(ISearchModel model)
        {
            var result = Search(model).ToList();
            return result;
        }
        public override IQueryable<Invoice> Search(ISearchModel model)
        {
            var param = model as InvoiceSearch;
            var q = All().Where(x => x.Active);
            if (!string.IsNullOrEmpty(param.Search))
            {
                q = q.Where(x => x.InvoiceNo.ToLower().Contains(param.Search.ToLower()));
            }
            if (param.CustomerId != 0)
            {
                q = q.Where(x=>x.CustomerId == param.CustomerId);
            }
            if (param.InvoiceStatus == InvoiceStatus.WaitPayment |
                param.InvoiceStatus == InvoiceStatus.Paid |
                param.InvoiceStatus == InvoiceStatus.PaySome)
            {
                q = q.Where(x => x.InvoiceStatus == param.InvoiceStatus);
            }
            if (param?.Paging?.IsPaging == true)
            {
                q = q.GetPaged(param.Paging).Results;
            }
            return q;
        }
        public override Invoice AddAsync(Invoice entity)
        {
            entity.InvoiceNo = NewInvoiceNumber();
            var invoice = base.AddAsync(entity);
            
            return invoice;
        }
        private string NewInvoiceNumber()
        {
            string invoiceNo;
            try
            {
                var lastInvoiceNo = _db.Invoices.Max(x => x.InvoiceNo);
                      
                if (lastInvoiceNo == null)
                {
                    invoiceNo = "SYSINV-000001";
                }
                else
                {
                    int interval = int.Parse(lastInvoiceNo.Substring(7,6));
                    interval = interval + 1;
                    invoiceNo = string.Format("SYSINV-{0:000000}",interval);
                }
                return invoiceNo;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override Invoice UpdateAsync(Invoice entity)
        {
            var invoice = base.UpdateAsync(entity);
            return entity;
        }
        
        public override bool CanRemoveAsync(int id)
        {
            if (!All().Any(x => x.Active && x.Id == id))
            {
                return false;
            }
            else if (_db.Invoices.Any(x => (x.Active && x.InvoiceStatus == InvoiceStatus.Paid) ||
            (x.Active && x.InvoiceStatus == InvoiceStatus.PaySome)))
            {
                return false;
            }
            return true;
        }
        public override Invoice RemoveAsync(Invoice entity)
        {
           var result =  base.RemoveAsync(entity);
            return result;
        }
    }
}
