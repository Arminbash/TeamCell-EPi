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
    public class InventarioController
    {
        public object FiltroXbodegaXProducto(int idBodega, int idProducto)
        {
            try
            {
                using (TeamCellContext _BDContext = new TeamCellContext())
                {
                    var result = (from k in _BDContext.Kardex
                                  join p in _BDContext.Product
                                  on k.IdProducto equals p.IdProducto
                                  where k.IdProducto == idProducto && k.IdWarehouse == idBodega
                                  select new { p.Codigo,p.Name,k.EntryAmount,k.OutputAmount,k.Stock,k.Document }).ToList();
                    return result;
                }
            }
            catch (Exception e)
            {
                return new List<object>();
            }
        }

        public List< object> StockGlobal()
        {
            try
            {
                using (TeamCellContext _BDContext = new TeamCellContext())
                {
                    List<Product> lstID = _BDContext.Product.ToList();

                    KardexController kardCont = new KardexController();
                    List<object> result = null;
                    foreach(Product i in lstID)
                    {
                        result.Add(new {
                            Codigo = i.Codigo,
                            Nombre = i.Name,
                            Stock = kardCont.GetStockActual(i.IdProducto)
                        });
                    }

                    return result;
                }
            }
            catch (Exception e)
            {
                return new List<object>();
            }
        }
    }
}
