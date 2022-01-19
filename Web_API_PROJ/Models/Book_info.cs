using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_API_PROJ.Models
{
    [Table("BookInfo")]
    public class Book_info
    {
        public string BookName { get; set; }
        public string Author { get; set; }
        public string Language{ get; set; }
        public int Price { get; set; }


    }
}
