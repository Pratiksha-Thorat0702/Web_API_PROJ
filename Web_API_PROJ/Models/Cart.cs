using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Web_API_PROJ.Models
{
    [Table("Cart_details")]
    public class Cart
    {
        public string BookName { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }

    }
}
