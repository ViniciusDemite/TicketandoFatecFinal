using System;
using System.Data.SqlClient;

namespace InterTicketandoFatec.DAL
{
    public class DAL : IDisposable
    {
        protected SqlConnection connection;

        public DAL()
        {
            
            string strConn = @"Data Source = localhost; Initial Catalog = TICKETANDO4;
            User ID = sa; Password = dba";
            connection = new SqlConnection(strConn);
            connection.Open();
        }

        public void Dispose()
        {
            connection.Close();
        }
    }
}