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
                modelBuilder.Entity<CostingAverage>().ToTable("CostingWeighted");

                modelBuilder.Entity<CostingAverage>().HasKey<int>(s => s.IdCostingWeighted);
                modelBuilder.Entity<CostingAverage>().Property(x => x.IdCostingWeighted).HasColumnName("IdCostingWeighted");
                modelBuilder.Entity<CostingAverage>().Property(x => x.Cost).HasColumnName("Cost").HasColumnType("decimal(18,2)");
            }
        }
    }
}
