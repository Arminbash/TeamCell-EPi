using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Client
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string CardIdentification { get; set; }
        public Boolean Status { get; set; }

        public class Map
        {
            public Map(ref DbModelBuilder modelBuilder)
            {
                modelBuilder.HasDefaultSchema("Client");
                modelBuilder.Entity<Client>().ToTable("Client");

                modelBuilder.Entity<Client>().HasKey<int>(s => s.Id);
                modelBuilder.Entity<Client>().Property(x => x.Id).HasColumnName("IdClient");
                modelBuilder.Entity<Client>().Property(x => x.Name).HasColumnName("Name").HasMaxLength(200);
                modelBuilder.Entity<Client>().Property(x => x.CardIdentification).HasColumnName("CardIdentification").HasMaxLength(100);
                modelBuilder.Entity<Client>().Property(x => x.Status).HasColumnName("Status").HasColumnType("Bit");
            }
        }
    }
}
