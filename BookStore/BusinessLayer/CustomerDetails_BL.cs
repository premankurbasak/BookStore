using BookStore.BusinessLayer.BusinessModel;
using System;
using System.Data;

namespace BookStore.BusinessLayer
{
    /// <summary>
    /// Customer Details Buiness Layer Class
    /// </summary>
    class CustomerDetails_BL:Interface.ICustomerDetails_BL
    {
        /// <summary>
        /// Function to Search Customer
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="lName"></param>
        /// <param name="phone"></param>
        /// <returns>CustomerDetails</returns>
        public CustomerDetails SearchCustomer(string fName, string lName, string phone)
        {
            var dt = new DataTable();
            var cd = new CustomerDetails();
            DataBaseLayer.Interface.ICustomerDetails_DL dl = new DataBaseLayer.CustomerDetails_DL();
            var ds = dl.SearchCustomerDetails(fName, lName, phone);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count>0)
            {
                dt = ds.Tables[0];
                cd.FirstName = dt.Rows[0][0].ToString();
                cd.LastName = dt.Rows[0][1].ToString();
                cd.Address = dt.Rows[0][2].ToString();
                cd.Phone = dt.Rows[0][3].ToString();
                cd.DOB = Convert.ToDateTime(dt.Rows[0][4].ToString());
                cd.Member = Convert.ToBoolean(dt.Rows[0][5].ToString());
                cd.JoiningYear = Convert.ToInt32(dt.Rows[0][6].ToString());
                return cd;
            }
            return null;
        }
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
        public int AddCustomer(string fName, string lName, string address, string phone, DateTime dob, bool member, int membershipYear)
        {
            DataBaseLayer.Interface.ICustomerDetails_DL dl = new DataBaseLayer.CustomerDetails_DL();
            var ds = dl.AddCustomerDetails(fName, lName, address, phone, dob, member, membershipYear);
            return ds;
        }
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
        /// <returns></returns>
        public int UpdateCustomer(string fName, string lName, string address, string phone, DateTime dob, bool member, int membershipYear, int cid)
        {
            DataBaseLayer.Interface.ICustomerDetails_DL dl = new DataBaseLayer.CustomerDetails_DL();
            var ds = dl.UpdateCustomerDetails(fName, lName, address, phone, dob, member, membershipYear, cid);
            return ds;
        }
        /// <summary>
        /// Function to Delete Customer
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="lName"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        public int DeleteCustomer(string fName, string lName, string reason)
        {
            DataBaseLayer.Interface.ICustomerDetails_DL dl = new DataBaseLayer.CustomerDetails_DL();
            var ds = dl.DeleteCutomerDetails(fName,lName, reason);
            return  ds;
        }
        /// <summary>
        /// Function to  Get Customer ID
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public int GetCustomerID(string phone)
        {
            DataBaseLayer.Interface.ICustomerDetails_DL dl = new DataBaseLayer.CustomerDetails_DL();
            var ds = dl.GetCustomerID(phone);
            return ds;
        }
        /// <summary>
        /// Function to get number of purchase
        /// </summary>
        /// <param name="cid"></param>
        /// <returns>int</returns>
        public int GetPurchaseCount(int cid)
        {
            DataBaseLayer.Interface.ICustomerDetails_DL dl = new DataBaseLayer.CustomerDetails_DL();
            var ds = dl.GetPurchaseCount(cid);
            return ds;
        }
        /// <summary>
        /// Function to Get Purchase Details
        /// </summary>
        /// <param name="cid"></param>
        /// <returns>decimal</returns>
        public decimal GetPurchaseAmt(int cid)
        {
            DataBaseLayer.Interface.ICustomerDetails_DL dl = new DataBaseLayer.CustomerDetails_DL();
            var ds = dl.GetPurchaseAmt(cid);
            return ds;
        }
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
        public int AddBillDetails(int cid, DateTime dop, decimal BAmt, bool member, decimal disc,int itemCount)
        {
            DataBaseLayer.Interface.ICustomerDetails_DL dl = new DataBaseLayer.CustomerDetails_DL();
            var ds = dl.AddBillDetails(cid, dop, BAmt,  member,  disc,  itemCount);
            return ds;
        }
    }
}
