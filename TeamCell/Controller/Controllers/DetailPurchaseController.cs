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
   public class DetailPurchaseController
    {

        public List<DetailPurchase> getDetailsPurchases(int id)
        {
            try
            {
                using (TeamCellContext _BDContext = new TeamCellContext())
                {
                    var result = _BDContext.DetailPurchase.Where(x => x.IdPurchases == id).ToList();
                    return result;

                }

            }
            catch (Exception e)
            {
                return new List<DetailPurchase>();
            }
        }

        public bool AddOrUpdateDetailPurchase(DetailPurchase detailPurchase)
        {
            try
            {
                using (TeamCellContext _DBContext = new TeamCellContext())
                {
                    _DBContext.DetailPurchase.AddOrUpdate(detailPurchase);
                    _DBContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public DetailPurchase GetdetailPurchase(int id)
        {
            try
            {
                using (TeamCellContext _DBContext = new TeamCellContext())
                {
                    return _DBContext.DetailPurchase.Where(x => x.IdDetailPurchase == id).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                return new DetailPurchase();
            }
        }
    }
}
