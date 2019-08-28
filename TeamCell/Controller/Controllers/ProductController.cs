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
   public class ProductController
    {
        public List<Product> getProduct()
        {
            try
            {
                using (TeamCellContext _BDContext = new TeamCellContext())
                {
                    var result = _BDContext.Product.ToList();
                    return result;
                }
            }
            catch (Exception e)
            {
                return new List<Product>();
            }
        }

        public bool AddOrUpdateProduct(Product prod)
        {
            try
            {
                using (TeamCellContext _BDContext = new TeamCellContext())
                {
                    _BDContext.Product.AddOrUpdate(prod);
                    _BDContext.SaveChanges();
                    return true;
                }

            }
            catch (Exception e)
            {
                return false;
            }
        }

        //public Product getIdProduct(int id)
        //{
        //    try
        //    {
        //        using (TeamCellContext _BDContext = new TeamCellContext())
        //        {
        //            //return _BDContext.Product.Where(x => x.Id == id).FirstOrDefault();
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        return new Product();
        //    }

        //}
    }
}
