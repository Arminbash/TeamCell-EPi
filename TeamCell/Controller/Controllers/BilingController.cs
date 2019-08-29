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
  public  class BilingController
    {
        public List<Billing> getBilling()
        {
            try
            {
                using (TeamCellContext _BDContext = new TeamCellContext())
                {
                    var result = _BDContext.Billing.ToList();
                    return result;

                }

            }
            catch (Exception e)
            {
                return new List<Billing>();
            }
        }

        public bool AddOrUpdateBilling(Billing billing)
        {
            try
            {
                using (TeamCellContext _DBContext = new TeamCellContext())
                {
                    _DBContext.Billing.AddOrUpdate(billing);
                    _DBContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Billing GetIdBilling(int id)
        {
            try
            {
                using (TeamCellContext _DBContext = new TeamCellContext())
                {
                    return _DBContext.Billing.Where(x => x.IdBilling == id).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                return new Billing();
            }
        }
    }
}
