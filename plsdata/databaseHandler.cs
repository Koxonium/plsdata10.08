using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace plsdata
{

    public class databaseHandler
    {
        MySqlConnection connection;
        string tablename = "product";
        public databaseHandler()
        {
            string dbname = "store";
            string host = "localhost";
            string username = "root";
            string pass = "";
            string connectionString = $"database={dbname};username={username};password={pass};host={host}";

            connection = new MySqlConnection(connectionString);
        }

        public List<food> prodlist = new List<food>();

        public void ReadDB()
        {
            try
            {
                connection.Open();
                string query = $"SELECT * FROM {tablename}";
                MySqlCommand command = new MySqlCommand(query,connection);
                MySqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    food oneFood = new food();
                    oneFood.id = read.GetInt32(read.GetOrdinal("ID"));
                    oneFood.name = read.GetString("nev");
                    oneFood.quantity = read.GetInt32(read.GetOrdinal("mennyiseg"));
                    food.prodlist.Add(oneFood);
                }
                read.Close();
                command.Dispose();
                connection.Close();
                MessageBox.Show("beolvasás");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        public void deleteOne(food oneFood)
        {
            try
            {
                connection.Open();
                string query = $"DELETE FROM {tablename} WHERE ID = {oneFood.id}";
                MySqlCommand command = new MySqlCommand(query,connection);
                command.ExecuteNonQuery();

                command.Dispose();
                connection.Close();
                MessageBox.Show("törlés");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void deleteAll()
        {
            try
            {
                connection.Open();
                string query = $"DELETE FROM {tablename}";
                MySqlCommand command = new MySqlCommand(query,connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                MessageBox.Show("Minden");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void insertOne(food oneFood)
        {
            try
            {
                connection.Open();
                string query = $"INSERT INTO {tablename}('nev', 'mennyiseg') VALUES('{oneFood.name}',{oneFood.quantity})";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                MessageBox.Show("Hozzáadva");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

    }
}
