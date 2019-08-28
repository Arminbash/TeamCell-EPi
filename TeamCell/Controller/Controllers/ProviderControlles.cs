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
    public class ProviderControlles
    {
        public List<Provider> getProvider()
        {
            try
            {
                using (TeamCellContext _DBContext = new TeamCellContext())
                {
                    var result = _DBContext.Provider.ToList();
                    return result;
                }
            }
            catch
            {
                return new List<Provider>();
            }
        }
        public bool AddOrUpdateEmployee(Provider prov)
        {
            try
            {
                using (TeamCellContext _DBContext = new TeamCellContext())
                {
                    _DBContext.Provider.AddOrUpdate(prov);
                    _DBContext.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public Provider getProviderXId(int id)
        {
            try
            {
                using (TeamCellContext _DBContext = new TeamCellContext())
                {
                    return _DBContext.Provider.Where(x => x.IdProvider == id).FirstOrDefault();
                }
            }
            catch
            {
                return new Provider();
            }
        }
    }
}
