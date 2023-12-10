using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Server=localhost,1433;Database=BabiliaBookstoreDB;User Id=sa;Password=123;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string tableName = "authors";

            using (SqlCommand command = new SqlCommand($"SELECT * FROM {tableName}", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write($"{reader.GetName(i)}: {reader.GetValue(i)}\t");
                        }
                        Console.WriteLine();
                    }
                }
            }
            connection.Close();
        }

    }
}

