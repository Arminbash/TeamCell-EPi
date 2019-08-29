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
   public class CostingAverageController
    {
        public List<CostingAverage> getCostingAverage()
        {
            try
            {
                using (TeamCellContext _BDContext = new TeamCellContext())
                {
                    var result = _BDContext.CostingAverage.ToList();
                    return result;
                }
            }
            catch (Exception e)
            {
                return new List<CostingAverage>();
            }
        }

        public bool AddOrUpdateCostingAverage(CostingAverage CostingAverage)
        {
            try
            {
                using (TeamCellContext _DBContext = new TeamCellContext())
                {
                    _DBContext.CostingAverage.AddOrUpdate(CostingAverage);
                    _DBContext.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public CostingAverage getCostingAverageXId(int id)
        {
            try
            {
                using (TeamCellContext _DBContext = new TeamCellContext())
                {
                    return _DBContext.CostingAverage.Where(x => x.IdCostingAverage == id).FirstOrDefault();
                }
            }
            catch
            {
                return new CostingAverage();
            }
        }
        public decimal getCalcularPromedioSimple(int id)
        {
            try
            {
                using (TeamCellContext _DBContext = new TeamCellContext())
                {
                    var TotalMonto = (from k in _DBContext.Kardex
                                  join ct in _DBContext.CostingAverage
                                  on k.IdKardex equals ct.IdKardex
                                  where k.IdProducto == id
                                  select new { ct.Cost }).Sum(x =>x.Cost);

                    var TotalCant = (from k in _DBContext.Kardex
                                      join ct in _DBContext.CostingAverage
                                      on k.IdKardex equals ct.IdKardex
                                      where k.IdProducto == id
                                      select new { ct.Cost }).Count();

                    return TotalMonto / TotalCant;
                }
            }
            catch
            {
                return 0;
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
                                  where k.IdProducto == id
                                  select new { ct.Cost }).LastOrDefault();
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
