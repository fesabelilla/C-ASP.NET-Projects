using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using MVCEF.Models;

namespace MVCEF.Controllers
{
    public class ProductController : Controller
    {
        string connectionString = @"Data Source = DESKTOP-1TLCT0C\SQLEXPRESS1; Initial Catalog = MvcCrudDB; Integrated Security = True";
        // GET: Product
        [HttpGet]
        public ActionResult Index()
        {
            DataTable dtblProduct = new DataTable();

            using(SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Product",sqlCon);
                sqlDa.Fill(dtblProduct);
            }

            return View(dtblProduct);
        }


        [HttpGet]
        // GET: Product/Create
        public ActionResult Create()
        {
            ProductModel productModel = new ProductModel();

            return View(productModel);
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(ProductModel productModel)
        {

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "INSERT INTO Product VALUES(@ProductName,@Price,@Count)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@Productname",productModel.ProductName);
                sqlCmd.Parameters.AddWithValue("@Price", productModel.Price);
                sqlCmd.Parameters.AddWithValue("@Count", productModel.Count);
                sqlCmd.ExecuteNonQuery();

            }
                return RedirectToAction("Index");
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            ProductModel productModel = new ProductModel();
            DataTable dataTable = new DataTable();
            using(SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "select * from Product where ProductID = @ProductID";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query,sqlCon);
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@ProductID",id);
                sqlDataAdapter.Fill(dataTable);
            }

            if(dataTable.Rows.Count == 1)
            {
                productModel.ProductID = Convert.ToInt32(dataTable.Rows[0][0].ToString());
                productModel.ProductName = dataTable.Rows[0][1].ToString();
                productModel.Price = Convert.ToDecimal(dataTable.Rows[0][2].ToString());
                productModel.Count = Convert.ToInt32(dataTable.Rows[0][3].ToString());

                return View(productModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(ProductModel productModel)
        {

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "update Product set ProductName = @ProductName , Price = @Price , Count = @Count  where ProductID = @ProductID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@ProductID", productModel.ProductID);
                sqlCmd.Parameters.AddWithValue("@ProductName", productModel.ProductName);
                sqlCmd.Parameters.AddWithValue("@Price", productModel.Price);
                sqlCmd.Parameters.AddWithValue("@Count", productModel.Count);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string query = "delete from Product where ProductID = @ProductID";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@ProductID", id);
                sqlCommand.ExecuteNonQuery();

            }


                return RedirectToAction("Index");
        }

        
    }
}
