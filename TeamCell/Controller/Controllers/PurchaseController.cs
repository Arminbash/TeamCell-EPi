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
    public class PurchaseController 
    {
        public List<Purchases> getPurchases()
        {
            try
            {
                using (TeamCellContext _BDContext = new TeamCellContext())
                {
                    var result = _BDContext.Purchases.ToList();
                    return result;

                }

            }
            catch (Exception e)
            {
                return new List<Purchases>();
            }
        }

        public bool AddOrUpdatePurchases(Purchases purchases)
        {
            try
            {
                using (TeamCellContext _DBContext = new TeamCellContext())
                {
                    _DBContext.Purchases.AddOrUpdate(purchases);
                    _DBContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Purchases GetIdPurchases(int id)
        {
            try
            {
                using (TeamCellContext _DBContext = new TeamCellContext())
                {
                    return _DBContext.Purchases.Where(x => x.IdPurchases == id).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                return new Purchases();
            }
        }
    }
}
