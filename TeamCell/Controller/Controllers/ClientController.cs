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
   public class ClientController
    {

        public List<Client> GetClient()
        {
            try
            {
                using (TeamCellContext _BDContext = new TeamCellContext())
                {
                    var result = _BDContext.Client.ToList();
                    return result;
                }

            }
            catch (Exception )
            {
                return new List<Client>();
            }
        }

        public bool AddOrUpdateClient(Client client)
        {
            try
            {
                using (TeamCellContext _DBContext= new TeamCellContext() )
                {
                    _DBContext.Client.AddOrUpdate(client);
                    _DBContext.SaveChanges();
                    return true;
                }

            }
            catch (Exception e)
            {
                return false;
            }   
        }

        public Client GetIdClient(int id)
        {
            try
            {
                using (TeamCellContext _DBContext= new TeamCellContext())
                {
                    return _DBContext.Client.Where(x => x.Id == id).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
               return new Client();
            }
        }
    }
}
