using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Model.Models
{
    public class Provider
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdProvider { get; set; }
        public string NameProvider { get; set; }
        public string Address { get; set; }
        public bool Status { get; set; }
        public ICollection<Product> Producto { get; set; }

        // public virtual ICollection<Product> Productos { get; set; }

        public class Map
        {
            public Map(ref DbModelBuilder modelBuilder)
            {
                modelBuilder.HasDefaultSchema("Provider");
                modelBuilder.Entity<Provider>().ToTable("Provider");

                modelBuilder.Entity<Provider>().HasKey<int>(s => s.IdProvider);
                modelBuilder.Entity<Provider>().Property(x => x.IdProvider).HasColumnName("Id");
                modelBuilder.Entity<Provider>().Property(x => x.NameProvider).HasColumnName("Name").HasMaxLength(200);
                modelBuilder.Entity<Provider>().Property(x => x.Address).HasColumnName("Address").HasMaxLength(200);
                modelBuilder.Entity<Provider>().Property(x => x.Status).HasColumnName("Status").HasColumnType("Bit");
            }
        }
    }
}

