using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Models;
using System.Data.Entity.Migrations;
namespace Controller
{
   public class EmployeeController
    {   
       public List<Employee> getEmployees()
       {
           try
           {
               using( TeamCellContext _DBContext = new TeamCellContext())
               {
                   var result = _DBContext.Employee.ToList();
                   return result;
               }
           }
           catch
           {
               return new List<Employee>();
           }
       }

       public bool AddOrUpdateEmployee(Employee emp)
       {
           try
           {
               using (TeamCellContext _DBContext = new TeamCellContext())
               {
                   _DBContext.Employee.AddOrUpdate(emp);
                   _DBContext.SaveChanges();
                   return true;
               }
           }
           catch
           {
               return false;
           }
       }

       public Employee getEmployeeXId(int id)
       {
           try
           {
               using (TeamCellContext _DBContext = new TeamCellContext())
               {
                   return _DBContext.Employee.Where(x => x.IdEmployee == id).FirstOrDefault();
               }
           }
           catch
           {
               return new Employee();
           }
       }
    }
}
