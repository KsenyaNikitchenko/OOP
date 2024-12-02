﻿

using Npgsql;

namespace library
{
    class DatabaseConnection
    {
        private static DatabaseConnection instance;
        private NpgsqlConnection connection;
        private DatabaseConnection(string conn)
        {
            connection = new NpgsqlConnection(conn);
            connection.Open();
        }
        public static DatabaseConnection GetInstance(string conn) { 
            if (instance == null)
                instance = new DatabaseConnection(conn);
            return instance;
        }
        public NpgsqlCommand CreateCommand(string sql) { 
            return new NpgsqlCommand(sql, connection);        
        }
        public void Close()
        {
            connection.Close();
        }
    }
}