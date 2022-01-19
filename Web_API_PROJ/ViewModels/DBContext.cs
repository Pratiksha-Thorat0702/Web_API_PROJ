using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API_PROJ.Models;
using Web_API_PROJ.ViewModels;




namespace Web_API_PROJ.ViewModels
{
    public class DBContext :DbContext
    {
      
            public DBContext(DbContextOptions<DBContext> options) : base(options)
            { }
            public DbSet<Web_API_PROJ.Models.Book_info> Book_info { get; set; }
            public DbSet<Web_API_PROJ.Models.Cart> Cart { get; set; }
            public DbSet<Web_API_PROJ.Models.Signup> Login { get; set; }
            public DbSet<Web_API_PROJ.Models.Signup> signup { get; set; }
        }
    }

