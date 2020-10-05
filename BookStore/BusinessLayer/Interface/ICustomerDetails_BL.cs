using BookStore.BusinessLayer.BusinessModel;
using System;

namespace BookStore.BusinessLayer.Interface
{
    /// <summary>
    /// Customer Details Buiness Layer Interface
    /// </summary>
    public interface ICustomerDetails_BL
    {
        /// <summary>
        /// Function to Search Customer
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="lName"></param>
        /// <param name="phone"></param>
        /// <returns>CustomerDetails</returns>
        CustomerDetails SearchCustomer(string fName, string lName, string phone);
        /// <summary>
        /// Function to Add Customer
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="lName"></param>
        /// <param name="address"></param>
        /// <param name="phone"></param>
        /// <param name="dob"></param>
        /// <param name="member"></param>
        /// <param name="membershipYear"></param>
        /// <returns>int</returns>
        int AddCustomer(string fName, string lName, string address, string phone, DateTime dob, bool member, int membershipYear);
        /// <summary>
        /// Function to Update Customer
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="lName"></param>
        /// <param name="address"></param>
        /// <param name="phone"></param>
        /// <param name="dob"></param>
        /// <param name="member"></param>
        /// <param name="membershipYear"></param>
        /// <param name="cid"></param>
        /// <returns>int</returns>
        int UpdateCustomer(string fName, string lName, string address, string phone, DateTime dob, bool member, int membershipYear, int cid);
        /// <summary>
        /// Function to Delete Customer
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="lName"></param>
        /// <param name="reason"></param>
        /// <returns>int</returns>
        int DeleteCustomer(string fName, string lName, string reason);
        /// <summary>
        /// Function to  Get Customer ID
        /// </summary>
        /// <param name="phone"></param>
        /// <returns>int</returns>
        int GetCustomerID(string phone);
        /// <summary>
        /// Function to get number of purchase
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        int GetPurchaseCount(int cid);
        /// <summary>
        /// Function to Get Purchase Details
        /// </summary>
        /// <param name="cid"></param>
        /// <returns>decimal</returns>
        decimal GetPurchaseAmt(int cid);
        /// <summary>
        /// Function to Add Bill Details
        /// </summary>
        /// <param name="cid"></param>
        /// <param name="dop"></param>
        /// <param name="BAmt"></param>
        /// <param name="member"></param>
        /// <param name="disc"></param>
        /// <param name="itemCount"></param>
        /// <returns>int</returns>
        int AddBillDetails(int cid, DateTime dop, decimal BAmt, bool member, decimal disc, int itemCount);
    }
}
