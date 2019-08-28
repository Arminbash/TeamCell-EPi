using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Model.Models
{
    public class Billing
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdBilling { get; set; }
        public DateTime DateBilling { get; set; }
        public bool Status { get; set; }


        [ForeignKey("Client")]
        public Nullable<int> IdClient { get; set; }
        public Client Client { get; set; }
        public ICollection<DetailBilling> Client { get; set; }

        public class Map
        {
            public Map(ref DbModelBuilder modelBuilder)
            {
                modelBuilder.HasDefaultSchema("Billing");
                modelBuilder.Entity<Billing>().ToTable("Billing");

                modelBuilder.Entity<Billing>().HasKey<int>(s => s.IdBilling);
                modelBuilder.Entity<Billing>().Property(x => x.IdBilling).HasColumnName("IdBilling");
                modelBuilder.Entity<Billing>().Property(x => x.DateBilling).HasColumnName("DateBilling").HasColumnType("datetime");
                modelBuilder.Entity<Billing>().Property(x => x.Status).HasColumnName("Status").HasColumnType("bit");
            }
        }
    }
}
