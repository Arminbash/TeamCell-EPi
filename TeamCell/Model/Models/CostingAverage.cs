using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class CostingAverage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCostingAverage { get; set; }
        public decimal Cost { get; set; }

        [ForeignKey("Kardex")]
        public Nullable<int> IdKardex { get; set; }
        public Kardex Kardex { get; set; }
        public class Map
        {
            public Map(ref DbModelBuilder modelBuilder)
            {
                modelBuilder.HasDefaultSchema("Inventory");
                modelBuilder.Entity<CostingAverage>().ToTable("CostingAverage");

                modelBuilder.Entity<CostingAverage>().HasKey<int>(s => s.IdCostingAverage);
                modelBuilder.Entity<CostingAverage>().Property(x => x.IdCostingAverage).HasColumnName("IdCostingAverage");
                modelBuilder.Entity<CostingAverage>().Property(x => x.Cost).HasColumnName("Cost").HasColumnType("decimal(18,2)");
            }
        }
    }
}
