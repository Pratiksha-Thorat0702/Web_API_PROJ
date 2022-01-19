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

//Cart Page
namespace Web_API_PROJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IConfiguration _congfiguration;
        public CartController(IConfiguration congfiguration)
        {

            _congfiguration = congfiguration;
        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                      select BookName,
                             Author, 
                             Price from
                dbo.Cart_details";
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
        [HttpPost]
        public JsonResult Post(Cart Ca)
        {
            string query = @"
                      insert into 
                            dbo.Cart_details
                            (BookName,Author,Price)
                           values(@BookName, @Author, @Price)";
            DataTable table = new DataTable();
            string sqlDataSource = _congfiguration.GetConnectionString("name");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {

                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@BookName", Ca.BookName);
                    myCommand.Parameters.AddWithValue("@Author", Ca.Author);
                    myCommand.Parameters.AddWithValue("@Price", Ca.Price);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }

            }

            return new JsonResult("Added sucessfully");



        }
       

        [HttpDelete("{Bn}")]
        public JsonResult Delete(string Bn)
        {
            string query = @"
                      delete from
                dbo.Cart_details
                where BookName=@BookName";
            DataTable table = new DataTable();
            string sqlDataSource = _congfiguration.GetConnectionString("name");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {

                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@BookName", Bn);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }

            }

            return new JsonResult("deleted sucessfully");



        }
    }
}
