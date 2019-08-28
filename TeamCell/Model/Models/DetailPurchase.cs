using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class DetailPurchase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDetailPurchase { get; set; }
        public decimal Quantity { get; set; }
        public decimal Cost { get; set; }
        public decimal IVA { get; set; }

        [ForeignKey("Purchases")]
        public Nullable<int> IdPurchases { get; set; }
        public Purchases Purchases { get; set; }

         [ForeignKey("Product")]
        public Nullable<int> IdProduct { get; set; }
        public Product Product { get; set; }
        public class Map
        {
            public Map(ref DbModelBuilder modelBuilder)
            {
                modelBuilder.HasDefaultSchema("PV");
                modelBuilder.Entity<DetailPurchase>().ToTable("DetailPurchase");

                modelBuilder.Entity<DetailPurchase>().HasKey<int>(s => s.IdDetailPurchase);
                modelBuilder.Entity<DetailPurchase>().Property(x => x.IdDetailPurchase).HasColumnName("IdDetailPurchase");
                modelBuilder.Entity<DetailPurchase>().Property(x => x.Quantity).HasColumnName("Quantity").HasColumnType("decimal").HasPrecision(18, 2);
                modelBuilder.Entity<DetailPurchase>().Property(x => x.Cost).HasColumnName("Cost").HasColumnType("decimal").HasPrecision(18, 2);
                modelBuilder.Entity<DetailPurchase>().Property(x => x.IVA).HasColumnName("IVA").HasColumnType("decimal").HasPrecision(18, 2);
            }
        }
    }
}