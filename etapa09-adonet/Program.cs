using System;
using System.Data;
using System.Data.SqlClient;

namespace etapa09_adonet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var input = Console.ReadLine();

            var connectionString =
                @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\samuel.belo\source\repos\etapa09-adonet\etapa09-adonet\AppData\mdfaula9.mdf;Integrated Security=True";
            /// Alterar connection string para seu path

            var cmdText = "INSERT INTO Pessoa" +
                            "(Nome)" +
                            "VALUES(@pessoaNome);";




            using(var sqlConnection = new SqlConnection(connectionString))
            using (var sqlCommand = new SqlCommand(cmdText, sqlConnection)) 
            {
                sqlCommand.CommandType = CommandType.Text;

                sqlCommand.Parameters.Add("@pessoaNome", SqlDbType.VarChar).Value = input;

                sqlConnection.Open();

                var resultScalar = sqlCommand.ExecuteScalar();
            }


        }
    }
}
