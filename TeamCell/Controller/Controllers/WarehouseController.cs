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
public class WarehouseController
    {
        public List<Warehouse> getWarehouse()
        {
            try
            {
                using (TeamCellContext _BDContext = new TeamCellContext())
                {
                    var result = _BDContext.Warehouse.ToList();
                    return result;
                }
            }
            catch (Exception e)
            {
                return new List<Warehouse>();
            }
        }

        public bool AddOrUpdateWarehouse(Warehouse Warehouse)
        {
            try
            {
                using (TeamCellContext _DBContext = new TeamCellContext())
                {
                    _DBContext.Warehouse.AddOrUpdate(Warehouse);
                    _DBContext.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public Warehouse getWarehouseXId(int id)
        {
            try
            {
                using (TeamCellContext _DBContext = new TeamCellContext())
                {
                    return _DBContext.Warehouse.Where(x => x.IdWarehouse == id).FirstOrDefault();
                }
            }
            catch
            {
                return new Warehouse();
            }
        }

    }
}
