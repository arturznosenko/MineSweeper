using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweaperProject.Logic
{
    class DataBaseLogic
    {
        private SqlConnection _connection;
        private SqlConnectionStringBuilder _connectionString = new SqlConnectionStringBuilder();
        private SqlCommand commandread;
        private SqlCommand commandwrite;
        private SqlDataReader dataReader;
        private SqlDataAdapter dataWriter = new SqlDataAdapter();
        private string sqlread = "";
        private string sqlinsert = "";
        private List<string> output = new List<string>();


        public DataBaseLogic ()   
        {
        
        }
        public List<string> ReadFromDb (string Level)
        {
            try
            {
                output.Clear();
                _connectionString.DataSource = @"(localdb)\MSSQLLocalDB";
                _connectionString.InitialCatalog = "master";
                sqlread = $"select TOP (7) Name, Time from [MineSweeperResults].[dbo].[Results] where Gamelevel ='{Level}'order by Time";

                using (_connection = new SqlConnection(_connectionString.ConnectionString))
                {
                    _connection.Open();
                    //Console.WriteLine("Done.");
                    commandread = new SqlCommand(sqlread, _connection);
                    using (dataReader = commandread.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            output.Add(dataReader.GetValue(0) + " " + dataReader.GetValue(1));
                        }
                    }

                }

             }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return output;
        }

        public void WritetoDb ( string Name, int WinnerTime, string GameLevel)
        {
            try
            {
                sqlinsert = $"insert into [MineSweeperResults].[dbo].[Results] (Id, Name, Time, Gamelevel) values (13,'{Name}',{WinnerTime}, '{GameLevel}')";
                _connectionString.DataSource = @"(localdb)\MSSQLLocalDB";
                _connectionString.InitialCatalog = "master";
                using (_connection = new SqlConnection(_connectionString.ConnectionString))
                {
                    _connection.Open();
                    //Console.WriteLine("Done.");
                    using (commandwrite = new SqlCommand(sqlinsert, _connection))
                    {
                        dataWriter.InsertCommand = commandwrite;
                        dataWriter.InsertCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
 
        }
    }
}
