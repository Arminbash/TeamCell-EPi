using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class CostingPeps
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCostingPeps { get; set; }
        public decimal EntryQuantity { get; set; }
        public decimal EntryCost { get; set; }
        public decimal OutputQuantity { get; set; }
        public decimal OutputCost { get; set; }
        public decimal Available {get; set;}

        [ForeignKey("Kardex")]
        public Nullable<int> IdKardex { get; set; }
        public Kardex Kardex { get; set; }
        public class Map
        {
            public Map(ref DbModelBuilder modelBuilder)
            {
                modelBuilder.HasDefaultSchema("Inventory");
                modelBuilder.Entity<CostingPeps>().ToTable("CostingPeps");

                modelBuilder.Entity<CostingPeps>().HasKey<int>(s => s.IdCostingPeps);
                modelBuilder.Entity<CostingPeps>().Property(x => x.IdCostingPeps).HasColumnName("IdCostingPeps");
                modelBuilder.Entity<CostingPeps>().Property(x => x.EntryAmount).HasColumnName("EntryAmount").HasColumnType("decimal(18,2)");
                modelBuilder.Entity<CostingPeps>().Property(x => x.EntryCost).HasColumnName("EntryCost").HasColumnType("decimal(18,2)");
                modelBuilder.Entity<CostingPeps>().Property(x => x.OutputQuantity).HasColumnName("OutputQuantity").HasColumnType("decimal(18,2)");
                modelBuilder.Entity<CostingPeps>().Property(x => x.OutputCost).HasColumnName("OutputCost").HasColumnType("decimal(18,2)");
                modelBuilder.Entity<CostingPeps>().Property(x => x.Available).HasColumnName("Available").HasColumnType("decimal(18,2)");
            }
        }
    }
}
