using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Model.Models
{
    public class DetailBilling
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDetailBilling { get; set; }
        public decimal Quantity { get; set; }
        public decimal Cost { get; set; }
        public decimal IVA { get; set; }
        public decimal Desc { get; set; }


        [ForeignKey("Billing")]
        public Nullable<int> IdBilling { get; set; }
        public Billing Billing { get; set; }

        [ForeignKey("Product")]
        public Nullable<int> IdProduct { get; set; }
        public Product Product { get; set; }
        public class Map
        {
            public Map(ref DbModelBuilder modelBuilder)
            {
                modelBuilder.HasDefaultSchema("PV");
                modelBuilder.Entity<DetailBilling>().ToTable("DetailBilling");

                modelBuilder.Entity<DetailBilling>().HasKey<int>(s => s.IdDetailBilling);
                modelBuilder.Entity<DetailBilling>().Property(x => x.IdDetailBilling).HasColumnName("IdDetailBilling");
                modelBuilder.Entity<DetailBilling>().Property(x => x.Quantity).HasColumnName("Quantity").HasColumnType("decimal").HasPrecision(18, 2);
                modelBuilder.Entity<DetailBilling>().Property(x => x.Cost).HasColumnName("Cost").HasColumnType("decimal").HasPrecision(18, 2);
                modelBuilder.Entity<DetailBilling>().Property(x => x.IVA).HasColumnName("IVA").HasColumnType("decimal").HasPrecision(18, 2);
                modelBuilder.Entity<DetailBilling>().Property(x => x.Desc).HasColumnName("Desc").HasColumnType("decimal").HasPrecision(18, 2);

            }
        }
    }
}
