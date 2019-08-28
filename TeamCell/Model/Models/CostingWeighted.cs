using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class CostingWeighted
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCostingWeighted { get; set; }
        public decimal Cost { get; set; }

        [ForeignKey("Kardex")]
        public Nullable<int> IdKardex { get; set; }
        public Kardex Kardex { get; set; }
        public class Map
        {
            public Map(ref DbModelBuilder modelBuilder)
            {
                modelBuilder.HasDefaultSchema("Inventory");
                modelBuilder.Entity<CostingWeighted>().ToTable("CostingWeighted");

                modelBuilder.Entity<CostingWeighted>().HasKey<int>(s => s.IdCostingWeighted);
                modelBuilder.Entity<CostingWeighted>().Property(x => x.IdCostingWeighted).HasColumnName("IdCostingWeighted");
                modelBuilder.Entity<CostingWeighted>().Property(x => x.Cost).HasColumnName("Cost").HasColumnType("decimal(18,2)");
            }
        }
    }
}
