using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FormPost.Models
{

    public class FurnitureItem
    {
        public int Id { get; set; }
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

        public List<FurnitureItem> GetAll()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Furniture";
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<FurnitureItem> items = new List<FurnitureItem>();
            while (reader.Read())
            {
                items.Add(new FurnitureItem
                {
                    Id = (int)reader["Id"],
                    Color = (string)reader["Color"],
                    Name = (string)reader["Name"],
                    Price = (decimal)reader["Price"],
                    QuantityInStock = (int)reader["QuantityInStock"]
                });
            }

            return items;
        }

        public void Delete(int id)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM Furniture WHERE Id = @id";

            cmd.Parameters.AddWithValue("@id", id);
            connection.Open();
            cmd.ExecuteNonQuery();
        }
    }
}