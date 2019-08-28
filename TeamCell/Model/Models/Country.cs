using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model.Models
{
    public  class Country
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int IdCountry { get; set; }
        public string NameCountry { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<Provider> Proveedor { get; set; }

        public class Map
        {
            public Map(ref DbModelBuilder modelBuilder)
            {
                modelBuilder.HasDefaultSchema("Country");
                modelBuilder.Entity<Country>().ToTable("Country");

                modelBuilder.Entity<Country>().HasKey<int>(s => s.IdCountry);
                modelBuilder.Entity<Country>().Property(x => x.IdCountry).HasColumnName("Id");
                modelBuilder.Entity<Country>().Property(x => x.NameCountry).HasColumnName("Name").HasMaxLength(200);
                modelBuilder.Entity<Country>().Property(x => x.Status).HasColumnName("Status").HasColumnType("bit");
            }
        }
    }
}
