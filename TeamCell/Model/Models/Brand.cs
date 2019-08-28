using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Model.Models
{
    public class Brand
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdBrand { get; set; }
        public string NameBrand { get; set; }
       
        public bool Status { get; set; }
        public ICollection<Product> Producto { get; set; }

       

        public class Map
        {
            public Map(ref DbModelBuilder modelBuilder)
            {
                modelBuilder.HasDefaultSchema("Brand");
                modelBuilder.Entity<Brand>().ToTable("Brand");

                modelBuilder.Entity<Brand>().HasKey<int>(s => s.IdBrand);
                modelBuilder.Entity<Brand>().Property(x => x.IdBrand).HasColumnName("Id");
                modelBuilder.Entity<Brand>().Property(x => x.NameBrand).HasColumnName("Name").HasMaxLength(200);
                modelBuilder.Entity<Brand>().Property(x => x.Status).HasColumnName("Status").HasColumnType("Bit");
            }
        }

    }

    

}
