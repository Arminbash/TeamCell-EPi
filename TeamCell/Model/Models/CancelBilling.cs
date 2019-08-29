using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
namespace Model.Models
{
    public class CancelBilling
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCancelBilling { get; set; }
        public DateTime DateCancelBilling { get; set; }
        public bool Status { get; set; }

        [ForeignKey("Billing")]
        public Nullable<int> IdBilling { get; set; }
        public Billing Billing { get; set; }

        public class Map
        {
            public Map(ref DbModelBuilder modelBuilder)
            {
                modelBuilder.HasDefaultSchema("Billing");
                modelBuilder.Entity<CancelBilling>().ToTable("CancelBilling");

                modelBuilder.Entity<CancelBilling>().HasKey<int>(s => s.IdCancelBilling);
                modelBuilder.Entity<CancelBilling>().Property(x => x.IdCancelBilling).HasColumnName("IdCancelBilling");
                modelBuilder.Entity<CancelBilling>().Property(x => x.DateCancelBilling).HasColumnName("DateCancelBilling").HasColumnType("datetime");
                modelBuilder.Entity<CancelBilling>().Property(x => x.Status).HasColumnName("Status").HasColumnType("bit");
            }
        }

    }
}
