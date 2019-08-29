using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Models;
namespace Controller.Controllers
{
   public class CostingWeightedController
    {
        public List<CostingWeighted> getCostingWeighted()
        {
            try
            {
                using (TeamCellContext _BDContext = new TeamCellContext())
                {
                    var result = _BDContext.CostingWeighted.ToList();
                    return result;
                }
            }
            catch (Exception e)
            {
                return new List<CostingWeighted>();
            }
        }

        public bool AddOrUpdateCostingWeighted(CostingWeighted CostingWeighted)
        {
            try
            {
                using (TeamCellContext _DBContext = new TeamCellContext())
                {
                    _DBContext.CostingWeighted.AddOrUpdate(CostingWeighted);
                    _DBContext.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public CostingWeighted getCostingWeightedXId(int id)
        {
            try
            {
                using (TeamCellContext _DBContext = new TeamCellContext())
                {
                    return _DBContext.CostingWeighted.Where(x => x.IdCostingWeighted == id).FirstOrDefault();
                }
            }
            catch
            {
                return new CostingWeighted();
            }
        }

        public decimal getUltimoCosteoxIdProducto(int id)
        {
            try
            {
                using (TeamCellContext _DBContext = new TeamCellContext())
                {
                    var result = (from k in _DBContext.Kardex 
                                join ct in _DBContext.CostingAverage 
                                on k.IdKardex equals ct.IdKardex
                                select new { ct.Cost}).LastOrDefault();
                    return result.Cost;
                }
            }
            catch
            {
                return 0;
            }
        }
    }
}
