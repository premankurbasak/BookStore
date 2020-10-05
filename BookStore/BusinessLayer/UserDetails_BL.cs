using BookStore.BusinessLayer.BusinessModel;
using System.Data;

namespace BookStore.BusinessLayer
{
    /// <summary>
    /// User Details Businesslayer Class
    /// </summary>
    class UserDetails_BL: Interface.IUserDetails_BL
    {
        /// <summary>
        /// Function to Search User
        /// </summary>
        /// <param name="uname"></param>
        /// <returns>UserDetails</returns>
        public UserDetails SearchUser(string uname)
        {
            var dt = new DataTable();
            var ud = new UserDetails();
            DataBaseLayer.Interface.IUserDetails_DL dl = new DataBaseLayer.UserDetails_DL();
            var ds = dl.SearchUserDetails(uname);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count>0)
            {
                dt = ds.Tables[0];
                ud.UserName = dt.Rows[0][0].ToString();
                ud.Password = dt.Rows[0][1].ToString();
                ud.Role = dt.Rows[0][2].ToString();
                return ud;
            }
            return null;
        }
        /// <summary>
        /// Function to Add User 
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        /// <returns>int</returns>
        public int AddUser(string uname, string password, string role)
        {
            DataBaseLayer.Interface.IUserDetails_DL dl = new DataBaseLayer.UserDetails_DL();
            var ds = dl.AddUserDetails(uname, password, role);
            return ds;
        }
        /// <summary>
        /// Function to Update user
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        /// <returns>int</returns>
        public int UpdateUser(string uname, string password, string role)
        {
            DataBaseLayer.Interface.IUserDetails_DL dl = new DataBaseLayer.UserDetails_DL();
            var ds = dl.UpdateUserDetails(uname, password, role);
            return ds;
        }
        /// <summary>
        /// Function to Delete user
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="reason"></param>
        /// <returns>int</returns>
        public int DeleteUser(string uname, string reason)
        {
            DataBaseLayer.Interface.IUserDetails_DL dl = new DataBaseLayer.UserDetails_DL();
            var ds = dl.DeleteUserDetails(uname, reason);
            return ds;
        }
    }
}
