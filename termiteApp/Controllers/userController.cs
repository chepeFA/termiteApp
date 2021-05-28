using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace termiteApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public userController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        //get all user details
        [HttpGet]

        public JsonResult get()
        {
            string query = @"select usrId, usrName, usrPassword, inId from dbo.User ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("termiteAppCon");
            SqlDataReader myReader;
            using(SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query,myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }
            //return data table as json result
            return new JsonResult(table);
        }


    }
}
