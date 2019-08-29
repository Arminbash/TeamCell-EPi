using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Model.Models
{
   public class CancelPurchase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCancelPurchases { get; set; }
        public DateTime CancelDate { get; set; }
        public int IdEmployee { get; set; }

        [ForeignKey("Purchases")]
        public Nullable<int> IdPurchases { get; set; }
        public Purchases Purchases { get; set; }

        public class Map
        {
            public Map(ref DbModelBuilder modelBuilder)
            {
                modelBuilder.HasDefaultSchema("PV");
                modelBuilder.Entity<CancelPurchase>().ToTable("Purchases");

                modelBuilder.Entity<CancelPurchase>().HasKey<int>(s => s.IdCancelPurchases);
                modelBuilder.Entity<CancelPurchase>().Property(x => x.IdCancelPurchases).HasColumnName("IdCancelPurchases");
                modelBuilder.Entity<CancelPurchase>().Property(x => x.CancelDate).HasColumnName("CancelDate").HasColumnType("date");
                modelBuilder.Entity<CancelPurchase>().Property(x => x.IdEmployee).HasColumnName("IdEmployee").HasColumnType("int"); ;
            }
        }

    }
}
