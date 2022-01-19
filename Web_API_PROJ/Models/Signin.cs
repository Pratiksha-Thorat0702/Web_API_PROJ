using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_API_PROJ.Models
{
    [Table("Logininfo")]
    public class Signin
    {
        public string Usename { get; set; }
        public string Password { get; set; }

    }
}
