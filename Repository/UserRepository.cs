using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using SHIPS.V2.Model;
using Microsoft.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
namespace SHIPS.V2.Repository
{
    public class UserRepository
    {
        private string connectionString = "Server=localhost;Database=BarcosVendas;Trusted_Connection=True;TrustServerCertificate=True";


        public User? GetbyUsername(string username) //pra autenticar o login
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); //abra conexao

                string sql = "SELECT * FROM users WHERE username = @username"; //usa SELECT pra colocar o ponteiro do sql em users, na condiçao (WHERE) de username ser igual ao @username

                using(SqlCommand command = new SqlCommand(sql, connection)) //vai iniciar o comando
                {
                    command.Parameters.AddWithValue("@username", username); //coloca o VALUE de username como @username la na query
                    using (SqlDataReader reader = command.ExecuteReader()) //vai começar o reader
                    {
                        if (reader.Read()) //se o ponteiro nao for nulo
                        {
                            User user = new User(); //cria um objeto provisorio

                            user.id = Convert.ToInt32(reader["id"]); //passa os dados recebidos pelo console (@username etc) para os dados do DB
                            user.username = reader["username"].ToString();
                            user.password = reader["password_"].ToString();
                            user.isadmin = Convert.ToBoolean(reader["isadmin"]);

                            return user;
                        }
                    }
                }
            }
            return null;
        }
        public User Create(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = @"INSERT INTO users (username, password_, isadmin)
                            VALUES (@username, @password_, @isadmin)"; // atribui os valores da DB de acordo com os @

                using (SqlCommand command = new SqlCommand(sql, connection)) // inicia um command
                {
                    command.Parameters.AddWithValue("@username", user.username); //so adiciona valores, a sintaxe é padrão
                    command.Parameters.AddWithValue("@password_", user.password);
                    command.Parameters.AddWithValue("@isadmin", user.isadmin);

                    command.ExecuteNonQuery(); // executa um command
                }
            }

            return user;
        }

       public User? RetrievedById(int id)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            {
                connection.Open();

                string sql = "SELECT * FROM users WHERE id = @id"; //mostrar os users cujo id ONDE for igual ao que o console leu

                using SqlCommand command = new SqlCommand(sql, connection);
                {
                    command.Parameters.AddWithValue("@id", id); //o id de Users q eu usarei sera aquele que o console leu (@id)

                    using SqlDataReader reader = command.ExecuteReader();
                    {
                        if (reader.Read()) //reader.Read() é como se fosse um "if (argv[1][i] != null" (se o cursor nao achar um nulo)
                        {
                            User user = new User(); //add um objeto user pra eu usar aqui

                            //essa sintaxe é fixa, só decorar por enquanto
                            user.id = Convert.ToInt32(reader["id"]); 
                            user.username = reader["username"].ToString();
                            user.password = reader["password_"].ToString();
                            user.isadmin = Convert.ToBoolean(reader["isadmin"]);
                            return user; //retornar oq eu modifiquei neh
                        }
                    }
                }
            }
            return null; //isso aqui é se der erro e nao entrar no if pra retornar user, ai retorna nulo msm
        }

        public List<User> RetrieveAll()
        {
            List <User> users = new  List<User>(); //cria lista pq sim

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM users"; //pra mostrar td

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read()) //argv[i] != null
                        {
                            User user = new User();

                            user.id = Convert.ToInt32(reader["id"]);
                            user.username = reader["username"].ToString();
                            user.password = reader["password_"].ToString();
                            user.isadmin = Convert.ToBoolean(reader["isadmin"]);

                            users.Add(user); //como se fosse um return(user), soq no list
                        }
                    }
                }
            }
            return users;
        }

        public void Update(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = @"UPDATE users SET
                    username = @username
                    password_ = @password_
                    isadmin = @isadmin
                WHERE id = @id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", user.id);
                    command.Parameters.AddWithValue("@username", user.username);
                    command.Parameters.AddWithValue("@isadmin", user.isadmin);

                    command.ExecuteNonQuery();

                }
            }          
        }

        public User? Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "DELETE from users WHERE id = @id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
            return null;
        }
    }
}
