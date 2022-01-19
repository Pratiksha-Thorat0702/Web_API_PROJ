using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Web_API_PROJ.Models;

//Registration page
namespace Web_API_PROJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignupController : ControllerBase
    {
        private readonly IConfiguration _congfiguration;
        public SignupController(IConfiguration congfiguration)
        {

            _congfiguration = congfiguration;
        }
        [HttpPost]
        public JsonResult Post(Signup Sa)
        {
            string query = @"
                      insert into 
                            dbo.Logininfo
                            (ID, Usename,Password)
                           values(@ID, @Usename, @Password)";
            DataTable table = new DataTable();
            string sqlDataSource = _congfiguration.GetConnectionString("name");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {

                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ID",Sa.ID);
                    myCommand.Parameters.AddWithValue("@Usename",Sa.Usename);
                    myCommand.Parameters.AddWithValue("@Password",Sa.Password);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }

            }

            return new JsonResult("Signup sucessfully");



        }

    }
}
