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
        public virtual DbSet<Warehouse> Warehouse {get; set;}
        public virtual DbSet<Kardex> Kardex {get; set;}
        public virtual DbSet<CostingPeps> CostingPeps {get; set;}
        public virtual DbSet<CostingAverage> CostingAverage {get; set;}
        public virtual DbSet<CostingWeighted> CostingWeighted {get; set;}
        public virtual DbSet<Purchases> Purchases { get; set; }
<<<<<<< HEAD
        public virtual DbSet<DetailPurchase> DetailPurchases { get; set; }
=======
        public virtual DbSet<DetailPurchase> DetailPurchase { get; set; }
        public virtual DbSet<Segment> Segment { get; set; }

>>>>>>> 0bde1b848a70351f4342e3678de61ab1d7cb482d
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
           new Warehouse.Map(ref modelBuilder);
           new Kardex.Map(ref modelBuilder);
           new CostingPeps.Map(ref modelBuilder);
           new CostingAverage.Map(ref modelBuilder);
           new CostingWeighted.Map(ref modelBuilder);
<<<<<<< HEAD
            new Purchases.Map(ref modelBuilder);
            new DetailPurchase.Map(ref modelBuilder);
=======
           new Purchases.Map(ref modelBuilder);
           new DetailPurchase.Map(ref modelBuilder);
           new Segment.Map(ref modelBuilder);

>>>>>>> 0bde1b848a70351f4342e3678de61ab1d7cb482d
            base.OnModelCreating(modelBuilder);
       }
    }
}
