using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Kardex
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdKardex { get; set; }
        public decimal EntryAmount {get; set;}
        public decimal OutputAmount {get; set;}
        public decimal Stock {get; set;}
        public int IdDocument {get; set;}
        public string Document {get; set;}

        [ForeignKey("Product")]
        public Nullable<int> IdProducto { get; set; }
        public Product Product { get; set; }

        [ForeignKey("Warehouse")]
        public Nullable<int> IdWarehouse { get; set; }
        public Warehouse Warehouse { get; set; }

        public ICollection<CostingPeps> CostingPeps { get; set; }
        public ICollection<CostingAverage> CostingAverage { get; set; }
        public ICollection<CostingWeighted> CostingWeighted { get; set; }
        public class Map
        {
            public Map(ref DbModelBuilder modelBuilder)
            {
                modelBuilder.HasDefaultSchema("Inventory");
                modelBuilder.Entity<Kardex>().ToTable("Kardex");

                modelBuilder.Entity<Kardex>().HasKey<int>(s => s.IdKardex);
                modelBuilder.Entity<Kardex>().Property(x => x.IdKardex).HasColumnName("IdKardex");
                modelBuilder.Entity<Kardex>().Property(x => x.EntryAmount).HasColumnName("EntryAmount").HasColumnType("decimal").HasPrecision(18, 2);
                modelBuilder.Entity<Kardex>().Property(x => x.OutputAmount).HasColumnName("OutputAmount").HasColumnType("decimal").HasPrecision(18, 2);
                modelBuilder.Entity<Kardex>().Property(x => x.Stock).HasColumnName("Stock").HasColumnType("decimal").HasPrecision(18, 2);
                modelBuilder.Entity<Kardex>().Property(x => x.IdDocument).HasColumnName("IdDocument").HasColumnType("int");
                modelBuilder.Entity<Kardex>().Property(x => x.Document).HasColumnName("Document").HasMaxLength(200);
            }
        }
    }
}