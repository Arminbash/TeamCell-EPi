using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace Model
{
   public class TeamCellContext : DbContext
    {
       public TeamCellContext()
           : base("TeamCellContext")
       {
           //Database.SetInitializer<TeamCellContext>(new DropCreateDatabaseAlways<TeamCellContext>());
       }
       public virtual DbSet<Employee> Employee { get; set; }
       public virtual DbSet<Client> Client { get; set; }
       public virtual DbSet<User> User { get; set; }
       public virtual DbSet<Brand> Brand { get; set; }
       public virtual DbSet<Provider> Provider { get; set; }
       
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Product> Product { get; set; }

       protected override void OnModelCreating(DbModelBuilder modelBuilder)
       {
           modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

           new Employee.Map(ref modelBuilder);
           new Client.Map(ref modelBuilder);
           new User.Map(ref modelBuilder);
           new Product.Map (ref modelBuilder);
           new Brand.Map(ref modelBuilder);
           new Provider.Map(ref modelBuilder);
            new Country.Map(ref modelBuilder);
            base.OnModelCreating(modelBuilder);
       }
    }
}
