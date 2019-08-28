using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
namespace Model.Models
{
   public class Employee
   {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdEmployee { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string FirstSurname { get; set; }
    public string SecondSurname { get; set; }
    public DateTime BirthDay { get; set; }
    public string IdentificationCard { get; set; }
    public string State { get; set; }
    public bool Status { get; set; }

    public class Map
    {
        public Map(ref DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("RRHH");
            modelBuilder.Entity<Employee>().ToTable("Employee");

            modelBuilder.Entity<Employee>().HasKey<int>(s => s.IdEmployee);
            modelBuilder.Entity<Employee>().Property(x => x.IdEmployee).HasColumnName("IdEmployee");
            modelBuilder.Entity<Employee>().Property(x => x.FirstName).HasColumnName("FirstName").HasMaxLength(50);
            modelBuilder.Entity<Employee>().Property(x => x.SecondName).HasColumnName("SecondName").HasMaxLength(50);
            modelBuilder.Entity<Employee>().Property(x => x.FirstSurname).HasColumnName("FirstSurname").HasMaxLength(50);
            modelBuilder.Entity<Employee>().Property(x => x.SecondSurname).HasColumnName("SecondSurname").HasMaxLength(50);
            modelBuilder.Entity<Employee>().Property(x => x.BirthDay).HasColumnName("BirthDay").HasColumnType("Datetime");
            modelBuilder.Entity<Employee>().Property(x => x.IdentificationCard).HasColumnName("IdentificationCard").HasMaxLength(100);
            modelBuilder.Entity<Employee>().Property(x => x.State).HasColumnName("State").HasMaxLength(50);
            modelBuilder.Entity<Employee>().Property(x => x.Status).HasColumnName("Status").HasColumnType("bit");
        }
    }
    }
}
