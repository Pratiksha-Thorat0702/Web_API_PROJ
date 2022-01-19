using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

//Book Product details page

namespace Web_API_PROJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IConfiguration _congfiguration;
        public BookController(IConfiguration congfiguration)
        {

            _congfiguration = congfiguration;
        }
        [HttpGet]
         public JsonResult Get()
        {
            string query = @"
                      select BookName,
                             Author, 
                             Language,
                              Price from
                dbo.BookInfo";
            DataTable table = new DataTable();
            string sqlDataSource = _congfiguration.GetConnectionString("name");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {

                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
            }

            }
                
            return new JsonResult(table);



        }

    }
}
