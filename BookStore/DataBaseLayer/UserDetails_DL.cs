using System;
using System.Data;
using System.Data.SqlClient;

namespace BookStore.DataBaseLayer
{
    /// <summary>
    /// 
    /// </summary>
    class UserDetails_DL:Interface.IUserDetails_DL
    {
        /// <summary>
        /// Function to Search User
        /// </summary>
        /// <param name="uname"></param>
        /// <returns></returns>
        public DataSet SearchUserDetails(string uname)
        {
            var dl = new SQLInterface();
            var ds = new DataSet();
            try
            {
                var cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SearchUsers";
                cmd.Parameters.Add("@UName", SqlDbType.NVarChar).Value = uname;
                ds = dl.SqlAdapter(cmd);
                return ds;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// Function to Add User 
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public int AddUserDetails(string uname, string password, string role)
        {
            var dl = new SQLInterface();
            try
            {
                var cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddUser";
                cmd.Parameters.Add("@UName", SqlDbType.NVarChar).Value = uname;
                cmd.Parameters.Add("@UPassword", SqlDbType.NVarChar).Value = password;
                cmd.Parameters.Add("@URole", SqlDbType.NVarChar).Value = role;
                var ds = dl.ExecuteNonQuery(cmd);
                return ds;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        /// <summary>
        /// Function to Update user
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public int UpdateUserDetails(string uname, string password, string role)
        {
            var dl = new SQLInterface();
            try
            {
                var cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateUser";
                cmd.Parameters.Add("@UName", SqlDbType.NVarChar).Value = uname;
                cmd.Parameters.Add("@UPassword", SqlDbType.NVarChar).Value = password;
                cmd.Parameters.Add("@URole", SqlDbType.NVarChar).Value = role;
                var ds = dl.ExecuteNonQuery(cmd);
                return ds;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        /// <summary>
        /// Function to Delete user
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        public int DeleteUserDetails(string uname, string reason)
        {
            var dl = new SQLInterface();
            try
            {
                var cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteUser";
                cmd.Parameters.Add("@UName", SqlDbType.NVarChar).Value = uname;
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
