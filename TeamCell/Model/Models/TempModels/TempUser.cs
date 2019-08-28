using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
   public class TempUser
    {
           public int IdUser { get; set; }
           public string UserName { get; set; }
           public string Password { get; set; }
           public int IdEmployee { get; set; }
           public Employee Employee { get; set; }
           public bool Status { get; set; }
     }
}
