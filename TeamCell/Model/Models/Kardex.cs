using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Kardex
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdKardex { get; set; }
        public decimal EntryAmount {get; set;}
        public decimal OutputAmount {get; set;}
        public decimal Stock {get; set;}
        public int IdDocument {get; set;}
        public string Document {get; set;}

        public class Map
        {
            public Map(ref DbModelBuilder modelBuilder)
            {
                modelBuilder.HasDefaultSchema("Inventory");
                modelBuilder.Entity<Client>().ToTable("Kardex");

                modelBuilder.Entity<Client>().HasKey<int>(s => s.IdKardex);
                modelBuilder.Entity<Client>().Property(x => x.IdKardex).HasColumnName("IdKardex");
                modelBuilder.Entity<Client>().Property(x => x.EntryAmount).HasColumnName("EntryAmount").HasColumnType("decimal(18,2)");
                modelBuilder.Entity<Client>().Property(x => x.OutputAmount).HasColumnName("OutputAmount").HasColumnType("decimal(18,2)");
                modelBuilder.Entity<Client>().Property(x => x.Stock).HasColumnName("Stock").HasColumnType("decimal(18,2)");
                modelBuilder.Entity<Client>().Property(x => x.IdDocument).HasColumnName("IdDocument").HasColumnType("int");
                modelBuilder.Entity<Client>().Property(x => x.Document).HasColumnName("Document").HasMaxLength(200);
            }
        }
    }
}