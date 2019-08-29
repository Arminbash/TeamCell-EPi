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
    public class KardexController
    {
        public List<Kardex> GetKardex()
        {
            try
            {
                using (TeamCellContext _BDContext = new TeamCellContext())
                {
                    var result = _BDContext.Kardex.ToList();
                    return result;
                }

            }
            catch (Exception)
            {
                return new List<Kardex>();
            }
        }


        public decimal GetStockActual(int idProducto)
        {
            try
            {
                using (TeamCellContext _BDContext = new TeamCellContext())
                {
                    decimal result = _BDContext.Kardex.Where(x =>x.IdProducto == idProducto).Sum(x => x.EntryAmount - x.OutputAmount);
                    return result;
                }

            }
            catch (Exception)
            {
                return 0;
            }
        }

        public bool AddOrUpdateClient(Kardex kardex)
        {
            try
            {
                using (TeamCellContext _DBContext = new TeamCellContext())
                {
                    _DBContext.Kardex.AddOrUpdate(kardex);
                    _DBContext.SaveChanges();
                    return true;
                }

            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Kardex GetIdKardex(int id)
        {
            try
            {
                using (TeamCellContext _DBContext = new TeamCellContext())
                {
                    return _DBContext.Kardex.Where(x => x.IdKardex == id).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                return new Kardex();
            }
        }
    }
}
