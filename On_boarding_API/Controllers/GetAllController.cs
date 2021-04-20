using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using On_boarding_API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace On_boarding_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetAllController : ControllerBase
    {
       // private readonly AppDBContext appDBContext;

        public GetAllController(IConfiguration configuration)
        {
            conFig = configuration;
        }

        public IConfiguration conFig { get; }


        public JsonResult Get()
        {
            string query = @"SELECT acc.contactPerson, acc.businessName, acc.district,  bill.district, ship.district
                FROM Account_Info as acc 
                INNER JOIN Billing_Address as bill 
                ON acc.custRegistrationId = bill.custRegistrationId
                INNER JOIN Shipping_Address as ship 
                ON acc.custRegistrationId = ship.custRegistrationId
                ";

            DataTable table = new DataTable();
            string sqlDBSourse = conFig.GetConnectionString("API_OnBording_Exe");
            SqlDataReader dbReader;
            using (SqlConnection sqlConnection = new SqlConnection(sqlDBSourse))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    dbReader = sqlCommand.ExecuteReader();
                    table.Load(dbReader);
                    dbReader.Close();
                    sqlConnection.Close();
                }
            }

            Console.WriteLine("result " + table);
            return new JsonResult(table);

        }

    }
}
