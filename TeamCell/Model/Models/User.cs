using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Model.Models
{
   public class User
    {
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public byte[] Salt { get; set; }
        public byte[] Password { get; set; }
        public int IdEmployee { get; set; }
        public Employee Employee { get; set; }
        public bool Status { get; set; }

        public class Map
        {
            public Map(ref DbModelBuilder modelBuilder)
            {
                modelBuilder.HasDefaultSchema("User");
                modelBuilder.Entity<User>().ToTable("User");

                modelBuilder.Entity<User>().HasKey<int>(x => x.IdUser);
                modelBuilder.Entity<User>().Property(x => x.UserName).HasColumnName("UserName").HasMaxLength(50);
                modelBuilder.Entity<User>().Property(x => x.Salt).HasColumnName("Salt").HasColumnType("varbinary(MAX)");
                modelBuilder.Entity<User>().Property(x => x.Password).HasColumnName("Password").HasColumnType("varbinary(MAX)");
                modelBuilder.Entity<User>().Property(x => x.IdEmployee).HasColumnName("IdEmployee").HasColumnType("int");
                modelBuilder.Entity<User>().Property(x => x.Status).HasColumnName("Status").HasColumnType("bit");
                //modelBuilder.Entity<User>().HasOne(x => x.Employee);
            }
        }
    }
}
