using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Model.Models
{
   public class Segment
    {
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSegment { get; set; }
        public string Name { get; set; }
        public class Map
        {
            public Map(ref DbModelBuilder modelBuilder)
            {
                modelBuilder.HasDefaultSchema("Pv");
                modelBuilder.Entity<Segment>().ToTable("Segment");

                modelBuilder.Entity<Segment>().HasKey<int>(x => x.IdSegment);
                modelBuilder.Entity<Segment>().Property(x => x.Name).HasColumnName("Name").HasMaxLength(50);

            }
        }
    }
}