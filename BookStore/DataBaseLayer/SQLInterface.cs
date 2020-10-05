using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BookStore.DataBaseLayer
{
    /// <summary>
    /// SQL DB Interfacing Layer
    /// </summary>
    class SQLInterface
    {
        /// <summary>
        /// Connection variable
        /// </summary>
        private SqlConnection con;
        /// <summary>
        /// Checks for connection
        /// </summary>
        /// <returns>bool</returns>
        private bool IsConnected()
        {
            try
            {
                ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["bookstore"];
                con = new SqlConnection(settings.ConnectionString);
                con.Open();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// ExecuteNonQuery function for Insert, Update, Delete
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns>int</returns>
        public int ExecuteNonQuery(SqlCommand cmd)
        {
            try
            {
                if (IsConnected())
                {
                    cmd.Connection = con;
                    int k = cmd.ExecuteNonQuery();
                    con.Close();
                    return k;
                }
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        /// <summary>
        /// SqlAdapter function for Select Query
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns>DataSet</returns>
        public DataSet SqlAdapter(SqlCommand cmd)
        {
            var ds = new DataSet();
            try
            {
                if (IsConnected())
                {
                    cmd.Connection = con;
                    var adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds);
                    con.Close();
                    return ds;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
