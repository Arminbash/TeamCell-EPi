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
   public class CountryController
    {
        public List<Country> getCountry()
        {
            try
            {
                using (TeamCellContext _BDContext = new TeamCellContext())
                {
                    var result = _BDContext.Country.ToList();
                    return result;

                }

            }
            catch (Exception e)
            {
                return new List<Country>();
            }
        }

        public bool AddOrUpdateCountry(Country country)
        {
            try
            {
                using (TeamCellContext _DBContext = new TeamCellContext())
                {
                    _DBContext.Country.AddOrUpdate(country);
                    _DBContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }         
        }

        public Country GetIdCountry(int id)
        {
            try
            {
                using (TeamCellContext _DBContext = new TeamCellContext())
                {
                    return _DBContext.Country.Where(x => x.IdCountry == id).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
               return new Country();
            }
        }
      
    }
}
