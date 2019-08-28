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
    public class BrandController
    {
        public List<Brand> getBrand()
        {
            try
            {
                using (TeamCellContext _BDContext = new TeamCellContext())
                {
                    var result = _BDContext.Brand.ToList();
                    return result;
                }
            }
            catch (Exception e)
            {
                return new List<Brand>();
            } 
        }

        public bool AddOrUpdateEmployee(Brand bran)
        {
            try
            {
                using (TeamCellContext _DBContext = new TeamCellContext())
                {
                    _DBContext.Brand.AddOrUpdate(bran);
                    _DBContext.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public Brand getBrandXId(int id)
        {
            try
            {
                using (TeamCellContext _DBContext = new TeamCellContext())
                {
                    return _DBContext.Brand.Where(x => x.IdBrand == id).FirstOrDefault();
                }
            }
            catch
            {
                return new Brand();
            }
        }
    }
}
