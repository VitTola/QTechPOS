using QTech.Base.Helpers;
using QTech.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Db.Logics
{
    public class DiscountLogic : DbLogic<Discount, DiscountLogic>
    {
        public override Discount AddAsync(Discount entity)
        {
            var result = base.AddAsync(entity);
            if (result != null)
            {
                AuditTrailLogic.Instance.AddManualAuditTrail<Discount, int, Discount>(entity, null, GeneralProcess.Add);
            }
            return result;
        }
        public override Discount UpdateAsync(Discount entity)
        {
            var oldEntity = base.GetOldEntityAsync(entity).Result;
            var result = base.UpdateAsync(entity);
            if (result != null)
            {
                AuditTrailLogic.Instance.AddManualAuditTrail<Discount, int, Discount>(entity, oldEntity, GeneralProcess.Update);
            }
            return result;
        }
        public override bool CanRemoveAsync(Discount entity)
        {
            return base.CanRemoveAsync(entity);
        }
    }
}
