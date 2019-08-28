using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProducto { get; set; }
        public string Codigo { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public bool HandleIdentifier {get; set;}
        public bool DriveLot { get; set; }

        public string TypeCosting  { get; set; }
        public bool Iva { get; set; }

        [ForeignKey("Brand")]
        public Nullable<int> Id_Brand { get; set; }
        public Brand Brand { get; set; }

        [ForeignKey("Provider")]
        public Nullable<int> Id_Provider { get; set; }
        public Provider Provider { get; set; }

        public bool Status { get; set; }

        





        public class Map
        {
            public Map (ref DbModelBuilder modelbuilder)
            {
                modelbuilder.HasDefaultSchema("Product");
                modelbuilder.Entity<Product>().ToTable("Product");

                modelbuilder.Entity<Product>().HasKey<int>(s => s.IdProducto);
                modelbuilder.Entity<Product>().Property(x => x.IdProducto).HasColumnName("Id");
                modelbuilder.Entity<Product>().Property(x => x.Name).HasColumnName("NameProduct").HasMaxLength(50);
                modelbuilder.Entity<Product>().Property(x => x.Description).HasColumnName("Description").HasMaxLength(100);
                modelbuilder.Entity<Product>().Property(x => x.HandleIdentifier).HasColumnName("HandleIdentifier").HasColumnType("bit");
                modelbuilder.Entity<Product>().Property(x => x.DriveLot).HasColumnName("DriveLot").HasColumnType("bit");
                modelbuilder.Entity<Product>().Property(x => x.TypeCosting).HasColumnName("TypeCosting").HasMaxLength(100);
                modelbuilder.Entity<Product>().Property(x => x.Iva).HasColumnType("IvaHas").HasColumnType("bit");
                modelbuilder.Entity<Product>().Property(x => x.Status).HasColumnName("Status").HasColumnType("bit");
                
               
            }
        }

        
    }
}
