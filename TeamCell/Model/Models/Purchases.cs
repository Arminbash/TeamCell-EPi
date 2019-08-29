using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Purchases
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPurchases { get; set; }
        public string Factura { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime EntryDate { get; set; }
        public int IdEmployee { get; set; }

        [ForeignKey("Warehouse")]
        public Nullable<int> IdWarehouse { get; set; }
        public Warehouse Warehouse { get; set; }

         [ForeignKey("Provider")]
        public Nullable<int> IdProvider { get; set; }
        public Provider Provider { get; set; }

        public virtual ICollection<DetailPurchase> DetailPurchase { get; set; }
        public virtual ICollection<CancelPurchase> CancelPurchase { get; set; }
        public class Map
        {
            public Map(ref DbModelBuilder modelBuilder)
            {
                modelBuilder.HasDefaultSchema("PV");
                modelBuilder.Entity<Purchases>().ToTable("Purchases");

                modelBuilder.Entity<Purchases>().HasKey<int>(s => s.IdPurchases);
                modelBuilder.Entity<Purchases>().Property(x => x.IdPurchases).HasColumnName("IdPurchases");
                modelBuilder.Entity<Purchases>().Property(x => x.Factura).HasColumnName("Factura").HasMaxLength(200);
                modelBuilder.Entity<Purchases>().Property(x => x.PurchaseDate).HasColumnName("PurchaseDate").HasColumnType("date");
                modelBuilder.Entity<Purchases>().Property(x => x.EntryDate).HasColumnName("EntryDate").HasColumnType("date");
                modelBuilder.Entity<Purchases>().Property(x => x.IdEmployee).HasColumnName("IdEmployee").HasColumnType("int");;
            }
        }
    }
}