using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FormPost.Models
{

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UnitsInStock { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
    }

    public class NorthwindDb
    {
        private string _connectionString;
        public NorthwindDb(string connectionString)
        {
            _connectionString = connectionString;   
        }

        public List<Product> SearchProducts(int minStock, int maxStock)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Products WHERE UnitsInStock BETWEEN @min AND @max";
            cmd.Parameters.AddWithValue("@min", minStock);
            cmd.Parameters.AddWithValue("@max", maxStock);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                products.Add(new Product
                {
                    Id = (int)reader["ProductId"],
                    Name = (string)reader["ProductName"],
                    QuantityPerUnit = (string)reader["QuantityPerUnit"],
                    UnitPrice = (decimal)reader["UnitPrice"],
                    UnitsInStock = (short)reader["UnitsInStock"]
                }); 
            }

            return products;
        }

    }
}