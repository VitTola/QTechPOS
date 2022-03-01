using QTech.Base;
using QTech.Base.BaseModels;
using QTech.Base.Enums;
using QTech.Base.Helpers;
using QTech.Base.Models;
using QTech.Base.OutFaceModels;
using QTech.Base.SearchModels;
using Storm.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static QTech.Db.MasterLogic;

namespace QTech.Db.Logics
{
    public class SaleLogic : DbLogic<Sale, SaleLogic>
    {
        public SaleLogic()
        {
            
        }
        private string NewInvoiceNumber()
        {
            string invoiceNo;
            try
            {
                var lastInvoiceNo = _db.Sales.Max(x => x.InvoiceNo);

                if (lastInvoiceNo == null)
                {
                    invoiceNo = "SYSINV-000001";
                }
                else
                {
                    int interval = int.Parse(lastInvoiceNo.Substring(7, 6));
                    interval = interval + 1;
                    invoiceNo = string.Format("SYSINV-{0:000000}", interval);
                }
                return invoiceNo;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override Sale AddAsync(Sale entity)
        {
            entity.InvoiceNo = NewInvoiceNumber();
            var result = base.AddAsync(entity);
            if (result != null)
            {
                AuditTrailLogic.Instance.AddManualAuditTrail<Sale, int, SaleDetail>(entity, null, GeneralProcess.Add);
            }

            entity.SaleDetails.ForEach(x => {
                x.SaleId = result.Id;
                SaleDetailLogic.Instance.AddAsync(x);
            });

            return result;
        }
        public override Sale UpdateAsync(Sale entity)
        {
            var oldObject = SaleLogic.Instance.FindAsync(entity.Id);
            oldObject.SaleDetails = SaleDetailLogic.Instance.SearchAsync(new SaleDetailSearch { SaleId = entity.Id });
            var result = base.UpdateAsync(entity);
            if (result != null)
            {
                var newEntity = new Sale();
                entity.CopyTo<Sale>(newEntity);
                newEntity.SaleDetails = newEntity.SaleDetails.Where(x => x.Active).ToList();
                AuditTrailLogic.Instance.AddManualAuditTrail<Sale, int, SaleDetail>(newEntity, oldObject, GeneralProcess.Update);
            }
            UpdateSaleDetail(result.SaleDetails, result);
            return result;
        }
        private void UpdateSaleDetail(List<SaleDetail> saleDetails, Sale sale)
        {
            if (saleDetails?.Any() ?? false)
            {
                foreach (var s in saleDetails)
                {
                    if (s.Id != 0)
                    {
                        SaleDetailLogic.Instance.UpdateAsync(s);
                    }
                    else
                    {
                        s.SaleId = sale.Id;
                        SaleDetailLogic.Instance.AddAsync(s);
                    }
                }
            }
        }
        public override Sale FindAsync(int id)
        {
            var sale = All().FirstOrDefault(x => x.Active && x.Id == id);
            if (sale != null)
            {
                sale.SaleDetails = _db.SaleDetails?.Where(x => x.SaleId == sale.Id)?.ToList();
            }
            return sale;
        }
        public override bool CanRemoveAsync(Sale entity)
        {
            if (!All().Any(x => x.Active && x.Id == entity.Id))
            {
                return false;
            }
            return true;
        }
        public override List<Sale> SearchAsync(ISearchModel model)
        {
            var result = Search(model)?.ToList();
            return result;
        }
        public override IQueryable<Sale> Search(ISearchModel model)
        {
            var param = model as SaleSearch;
            var _saleSearchKey = param.saleSearchKey;
            var q = All().Where(x => x.Active && x.SaleDate >= param.FromDate && x.SaleDate <= param.ToDate);
            if (_saleSearchKey == SaleSearchKey.InvoiceNo && !string.IsNullOrEmpty(param.Search))
            {
                q = q.Where(x => x.InvoiceNo.ToLower().Contains(param.Search.ToLower()));
            }
            else if (_saleSearchKey == SaleSearchKey.CustomerName && !string.IsNullOrEmpty(param.Search))
            {
                q = from s in q
                    join c in _db.Customers.Where(x => x.Active) on s.CustomerId equals c.Id into cus
                    from c in cus.DefaultIfEmpty()
                    where s.CustomerName.ToLower() == param.Search.ToLower() || c.Name.ToLower() == param.Search.ToLower()
                    select s;
            }
            if (param.payStatus == PayStatus.Paid)
            {
                q = q.Where(x => x.PayStatus == PayStatus.Paid);
            }
            else if (param.payStatus == PayStatus.NotYetPaid)
            {
                q = q.Where(x => x.PayStatus == PayStatus.NotYetPaid);
            }
            else if (param.payStatus == PayStatus.WaitPayment)
            {
                q = q.Where(x => x.PayStatus == PayStatus.WaitPayment);
            }
            var tmp = q.ToList();
            return q;
        }
        public List<Sale> GetSaleByIds(List<int> saleIds)
        {
            var q = All().Where(x => x.Active);
            q = q.Where(s => saleIds.Any(i => i == s.Id));
            return q.ToList();
        }
        public override Sale RemoveAsync(Sale entity)
        {
            var result = base.RemoveAsync(entity);
            entity.SaleDetails.ForEach(x => SaleDetailLogic.Instance.RemoveAsync(x));
            return result;
        }
       
        public override bool CanRemoveAsync(int id)
        {
            var entity = base.FindAsync(id);
            if (entity.PayStatus != PayStatus.NotYetPaid)
            {
                return false;
            }
            return true;
        }
       
        public bool IsExistedInvoiceNo(Sale sale)
        {
            return _db.Sales.Any(x => x.Active && x.InvoiceNo == sale.InvoiceNo && x.Id != sale.Id);
        }

        public override bool IsExistsAsync(Sale entity)
        {
            return _db.Sales.Any(x=>x.Active && x.Id == entity.Id);
        }
    }
}
