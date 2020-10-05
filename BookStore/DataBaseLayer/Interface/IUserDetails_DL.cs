using System.Data;

namespace BookStore.DataBaseLayer.Interface
{
    /// <summary>
    /// User Details Businesslayer Class
    /// </summary>
    public interface IUserDetails_DL
    {
        /// <summary>
        /// Function to Search User
        /// </summary>
        /// <param name="uname"></param>
        /// <returns></returns>
        DataSet SearchUserDetails(string uname);
        /// <summary>
        /// Function to Add User 
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        int AddUserDetails(string uname, string password, string role);
        /// <summary>
        /// Function to Update user
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        int UpdateUserDetails(string uname, string password, string role);
        /// <summary>
        /// Function to Delete user
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        int DeleteUserDetails(string uname, string reason);
    }
}
