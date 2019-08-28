using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Warehouse
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdWarehouse { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Boolean Status { get; set; }

        public ICollection<Kardex> Kardex { get; set; }

        public class Map
        {
            public Map(ref DbModelBuilder modelBuilder)
            {
                modelBuilder.HasDefaultSchema("Inventory");
                modelBuilder.Entity<Warehouse>().ToTable("Warehouse");

                modelBuilder.Entity<Warehouse>().HasKey<int>(s => s.IdWarehouse);
                modelBuilder.Entity<Warehouse>().Property(x => x.IdWarehouse).HasColumnName("IdWarehouse");
                modelBuilder.Entity<Warehouse>().Property(x => x.Name).HasColumnName("Name").HasMaxLength(200);
                modelBuilder.Entity<Warehouse>().Property(x => x.Description).HasColumnName("Description").HasMaxLength(1000);
                modelBuilder.Entity<Warehouse>().Property(x => x.Status).HasColumnName("Status").HasColumnType("bit");
            }
        }
    }
}
