using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
  public  class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Costing { get; set; }
        public string Description { get; set; }
        public Nullable<int> Id_Brand { get; set; }
        public Brand Brand { get; set; }
        public Nullable<int> Id_Provider { get; set; }
        public Provider Provider { get; set; }
        public bool Status { get; set; }
   
        public class Map
        {
            public Map (ref DbModelBuilder modelbuilder)
            {
                modelbuilder.HasDefaultSchema("Product");
                modelbuilder.Entity<Product>().ToTable("Product");

                modelbuilder.Entity<Product>().HasKey<int>(s => s.Id);
                modelbuilder.Entity<Product>().Property(x => x.Id).HasColumnName("Id");
                modelbuilder.Entity<Product>().Property(x => x.Name).HasColumnName("NameProduct").HasMaxLength(50);
                modelbuilder.Entity<Product>().Property(x => x.Costing).HasColumnName("Preci").HasMaxLength(100);
                modelbuilder.Entity<Product>().Property(x => x.Description).HasColumnName("Description").HasMaxLength(100);
                modelbuilder.Entity<Product>().Property(x => x.Id_Brand).HasColumnName("IdBrand");
                modelbuilder.Entity<Product>().Property(x => x.Id_Provider).HasColumnName("IdProvider");
                modelbuilder.Entity<Product>().Property(x => x.Status).HasColumnName("Status").HasColumnType("bit");
                
               
            }
        }

        
    }
}
