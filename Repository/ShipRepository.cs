using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using SHIPS.V2.Model;

namespace SHIPS.V2.Repository
{
    public class ShipRepository
    {
        private string connectionString = "Server=localhost;Database=BarcosVendas;Trusted_Connection=True;TrustServerCertificate=True";

        public Ship Create(Ship ship)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = @"INSERT INTO ships (shipType, color, rank_id, price)
                               VALUES (@shipType, @color, @rank_id, @price)";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@shipType", ship.shipType);
                    command.Parameters.AddWithValue("@color", ship.color);
                    command.Parameters.AddWithValue("@rank_id", ship.rank_id);
                    command.Parameters.AddWithValue("@price", ship.price);

                    command.ExecuteNonQuery();
                }

            }
            return ship;
        }

        public Ship? RetrieveById (int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = @"SELECT * FROM ships WHERE id = @id";

                using (SqlCommand command = new SqlCommand (sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Ship ship = new Ship();

                        ship.id = Convert.ToInt32(reader["shipId"]);
                        ship.shipType = reader["shipType"].ToString();
                        ship.color = reader["color"].ToString();
                        ship.rank_id = Convert.ToInt32(reader["rank_id"]);
                        ship.price = reader["price"].ToString();
                        return ship;
                    }
                }
            }
            return null;
        }

        public List<Ship> RetrieveAll()
        {
            List<Ship> shipList = new List<Ship>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM ships";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Ship ship = new Ship
                            {
                                id = Convert.ToInt32(reader["shipId"]),
                                shipType = reader["shipType"]?.ToString(),
                                color = reader["color"]?.ToString(),
                                rank_id = Convert.ToInt32(reader["rank_id"]),
                                price = reader["price"].ToString(),
                            };
                            shipList.Add(ship);
                        }
                    }
                }
            }
            return shipList;
        }
        public void Update (Ship ship)
        {
            using SqlConnection connection = new SqlConnection (connectionString);
            {
                connection.Open();
                string sql = @"UPDATE ships GET
                               shipType = @shipType
                               color = @color
                                rank_id = @rank_id
                                price = @price";

                using SqlCommand command = new SqlCommand (sql, connection);
                {
                    command.Parameters.AddWithValue("@shipType", ship.shipType);
                    command.Parameters.AddWithValue("@color", ship.color);
                    command.Parameters.AddWithValue("@rank_id", ship.rank_id);
                    command.Parameters.AddWithValue("@price", ship.price);

                    command.ExecuteNonQuery();
                }
            }
        }

        public Ship? Delete (int id)
        {
            Ship? shipToDelete = RetrieveById(id);
            if (shipToDelete == null) return null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "DELETE from ships WHERE id = @id";

                using (SqlCommand command = new SqlCommand (sql,connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery ();
                }
            }
            return shipToDelete;
        }

    }
}
