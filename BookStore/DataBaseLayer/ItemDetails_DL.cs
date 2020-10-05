using System;
using System.Data;
using System.Data.SqlClient;

namespace BookStore.DataBaseLayer
{
    /// <summary>
    /// ItemDetails Database Layer Class
    /// </summary>
    class ItemDetails_DL :Interface.IItemDetails_DL
    {
        /// <summary>
        /// Function to search Item
        /// </summary>
        /// <param name="item"></param>
        /// <returns>DataSet</returns>
        public DataSet SearchItemDetails(string item)
        {
            var dl = new SQLInterface();
            var ds = new DataSet();
            try
            {
                var cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SearchItem";
                cmd.Parameters.Add("@TName", SqlDbType.VarChar).Value = item;
                ds = dl.SqlAdapter(cmd);
                return ds;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// Function to Add Item
        /// </summary>
        /// <param name="item"></param>
        /// <param name="price"></param>
        /// <returns>int</returns>
        public int AddItemDetails(string item, string price)
        {
            var dl = new SQLInterface();
            try
            {
                var cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddItem";
                cmd.Parameters.Add("@TName", SqlDbType.VarChar).Value = item;
                cmd.Parameters.Add("@TRate", SqlDbType.Decimal).Value = Convert.ToDecimal(price);
                var ds = dl.ExecuteNonQuery(cmd);
                return ds;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        /// <summary>
        /// Function to Update Item
        /// </summary>
        /// <param name="item"></param>
        /// <param name="price"></param>
        /// <returns>int</returns>
        public int UpdateItemDetails(string item, string price)
        {
            var dl = new SQLInterface();
            try
            {
                var cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateItem";
                cmd.Parameters.Add("@TName", SqlDbType.VarChar).Value = item; 
                cmd.Parameters.Add("@TRate", SqlDbType.Decimal).Value = Convert.ToDecimal(price);
                var ds = dl.ExecuteNonQuery(cmd);
                return ds;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        /// <summary>
        /// Function to Delete Item
        /// </summary>
        /// <param name="item"></param>
        /// <param name="reason"></param>
        /// <returns>int</returns>
        public int DeleteItemDetails(string item, string reason)
        {
            var dl = new SQLInterface();
            try
            {
                var cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteItem";
                cmd.Parameters.Add("@TName", SqlDbType.NVarChar).Value = item;
                cmd.Parameters.Add("@Reason", SqlDbType.NVarChar).Value = reason;
                var ds = dl.ExecuteNonQuery(cmd);
                return ds;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
