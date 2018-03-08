using System;
using System.Data;
using BaltaStore.Shered;
using Npgsql;

namespace BaltaStore.Infra.StoreContext.DataContexts
{
    public class BaltaDataContext : IDisposable
    {
        public BaltaDataContext()
        {
            Connection = new NpgsqlConnection(Settings.ConnectionString);
            Connection.Open();
        }

        public NpgsqlConnection Connection { get; set; }

        public void Dispose()
        {
            if(Connection.State == ConnectionState.Open)
                Connection.Close();
        }
    }
}