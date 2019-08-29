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
 public   class DetailBilingController
    {
        public List<DetailBilling> getDetailBilling(int id)
        {
            try
            {
                using (TeamCellContext _BDContext = new TeamCellContext())
                {
                    var result = _BDContext.DetailBilling.Where(x => x.IdDetailBilling == id).ToList();
                    return result;

                }

            }
            catch (Exception e)
            {
                return new List<DetailBilling>();
            }
        }

        public bool AddOrUpdateDetailBilling(DetailBilling DetailBilling)
        {
            try
            {
                using (TeamCellContext _DBContext = new TeamCellContext())
                {
                    _DBContext.DetailBilling.AddOrUpdate(DetailBilling);
                    _DBContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public DetailBilling GetDetailBilling(int id)
        {
            try
            {
                using (TeamCellContext _DBContext = new TeamCellContext())
                {
                    return _DBContext.DetailBilling.Where(x => x.IdDetailBilling == id).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                return new DetailBilling();
            }
        }
    }
}
