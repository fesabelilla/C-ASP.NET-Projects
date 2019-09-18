using DataBaseConnect.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataBaseConnect.Controllers
{
    public class LogInController : Controller
        
    {
        string connectionString = @"Data Source = DESKTOP-BNOJ060\SQLEXPRESS ; Initial Catalog = SDLab ; Integrated Security = true ";
        // GET: LogIn
        public ActionResult Index()
        {
            var dtblUser = new DataTable();
            using (var sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM LogIn", sqlCon);
                sqlDa.Fill(dtblUser);
            }

            return View(dtblUser);
        }

        public ActionResult Create()
        {
            var user = new User();

            return View(user);
        }

        [HttpPost]

        public ActionResult Create( User user)
        {
            using (var sqlCon = new SqlConnection(connectionString))
            {

                sqlCon.Open();
                string query = "insert into LogIn values (@name,@password)";
                var sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@name",user.Name);
                sqlCmd.Parameters.AddWithValue("@password", user.Password);
                sqlCmd.ExecuteNonQuery();
            }
                return RedirectToAction("Index");
        }

        [HttpGet]

        public ActionResult Delete(String id)
        {
            using (var sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                String query = "delete from LogIn where name = @name";
                var sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@name", id);
                sqlCmd.ExecuteNonQuery();
            }


            return RedirectToAction("Index");
        }

    }
}