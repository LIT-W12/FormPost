using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FormPost.Models
{

    public class FurnitureItem
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
    }

    public class FurnitureDb
    {
        private string _connectionString;

        public FurnitureDb(string connectionString)
        {
            _connectionString = connectionString;    
        }

        public int GetCount()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM Furniture";
            connection.Open();
            return (int)cmd.ExecuteScalar();
        }

        public void Add(FurnitureItem item)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO Furniture (Name, Color, Price, QuantityInStock, PreAssembled) " +
                "VALUES (@name, @color, @price, @qty, 1)";

            cmd.Parameters.AddWithValue("@name", item.Name);
            cmd.Parameters.AddWithValue("@color", item.Color);
            cmd.Parameters.AddWithValue("@price", item.Price);
            cmd.Parameters.AddWithValue("@qty", item.QuantityInStock);
            connection.Open();
            cmd.ExecuteNonQuery();

        }
    }
}