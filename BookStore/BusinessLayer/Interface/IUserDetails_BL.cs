using BookStore.BusinessLayer.BusinessModel;

namespace BookStore.BusinessLayer.Interface
{
    /// <summary>
    /// User Details Businesslayer Interface
    /// </summary>
    public interface IUserDetails_BL
    {
        /// <summary>
        /// Function to Search User
        /// </summary>
        /// <param name="uname"></param>
        /// <returns>UserDetails</returns>
        UserDetails SearchUser(string uname);
        /// <summary>
        /// Function to Add User 
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        /// <returns>int</returns>
        int AddUser(string uname, string password, string role);
        /// <summary>
        /// Function to Update user
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        /// <returns>int</returns>
        int UpdateUser(string uname, string password, string role);
        /// <summary>
        /// Function to Delete user
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="reason"></param>
        /// <returns>int</returns>
        int DeleteUser(string uname, string reason);
    }
}
