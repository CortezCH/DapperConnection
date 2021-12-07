using Dapper;
using DapperConnection.Models;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperConnection.Controllers
{
    // To makle a controllersubclass controller
    // .Net expects your controller name to have the word Controller at the end
    public class RestaurantController : Controller
    {
        //Host Name     : 127.0.0.1
        //UserName      : root
        //Password      : abc123
        //Database Name : restaurant
        //Public static string connection {get; set;} = "server=hostName;uid=user;pwd=blah;database=dbName";


        public IActionResult Index()
        {
            using(var connect = new MySqlConnection(Secret.Connection))
            {
                //So using dapper we are able to pur sql queries into a string
                //and pass them along to our database
                //All MySql syntax is useable here
                string sql = "select * from dishes";

                //open out connection to the DB
                connect.Open();

                //We need to go and pass thje sql string to the database 
                //Expecting to return a single model or a list of models or nothing
                //Depending on the type of query
                List<Dish> dishes = connect.Query<Dish>(sql).ToList();

                //Close our connection to our DB, if we don't then the database
                //may not let another method use it
                connect.Close();

                Dish d = dishes[0];
                return View(d);
            }
            return View();
        }
    }
}
