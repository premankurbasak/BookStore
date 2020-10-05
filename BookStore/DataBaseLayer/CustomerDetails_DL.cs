using System;
using System.Data;
using System.Data.SqlClient;

namespace BookStore.DataBaseLayer
{
    /// <summary>
    /// Customer Details Database Layer Class
    /// </summary>
    class CustomerDetails_DL :Interface.ICustomerDetails_DL
    {
        /// <summary>
        /// Function to Search Customer
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="lName"></param>
        /// <param name="phone"></param>
        /// <returns>DataSet</returns>
        public DataSet SearchCustomerDetails(string fName, string lName, string phone)
        {
            var dl = new SQLInterface();
            var ds = new DataSet();
            try
            {
                var cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                if (!string.IsNullOrEmpty(fName) || !string.IsNullOrEmpty(lName))
                {
                    cmd.CommandText = "SearchCustomersUsingName";
                    cmd.Parameters.Add("@CFName", SqlDbType.VarChar).Value = fName;
                    cmd.Parameters.Add("@CLName", SqlDbType.VarChar).Value = lName;
                    ds = dl.SqlAdapter(cmd);
                    return ds;
                }
                if (!string.IsNullOrEmpty(phone))
                {
                    cmd.CommandText = "SearchCustomersUsingPhone";
                    cmd.Parameters.Add("@CPhone", SqlDbType.VarChar).Value = phone;
                    ds = dl.SqlAdapter(cmd);
                    return ds;
                }
                return ds;
            }
            catch (Exception)
            {
                return null;
            }
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
        public int AddCustomerDetails(string fName, string lName, string address, string phone, DateTime dob, bool member, int membershipYear)
        {
            var dl = new SQLInterface();
            try
            {
                var cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddCustomer";
                cmd.Parameters.Add("@CFName", SqlDbType.VarChar).Value = fName;
                cmd.Parameters.Add("@CLName", SqlDbType.VarChar).Value = lName;
                cmd.Parameters.Add("@CAddress", SqlDbType.VarChar).Value = address;
                cmd.Parameters.Add("@CPhone", SqlDbType.NChar).Value = phone;
                cmd.Parameters.Add("@CDOB", SqlDbType.SmallDateTime).Value = dob;
                cmd.Parameters.Add("@CMem", SqlDbType.Bit).Value = member;
                cmd.Parameters.Add("@CMemJoinYear", SqlDbType.Int).Value = membershipYear;
                var ds = dl.ExecuteNonQuery(cmd);
                return ds;
            }
            catch (Exception)
            {
                return 0;
            }
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
        /// <returns>int</returns>
        public int UpdateCustomerDetails(string fName, string lName, string address, string phone, DateTime dob, bool member, int membershipYear, int cid)
        {
            var dl = new SQLInterface();
            try
            {
                var cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateCustomer";
                cmd.Parameters.Add("@CFName", SqlDbType.VarChar).Value = fName;
                cmd.Parameters.Add("@CLName", SqlDbType.VarChar).Value = lName;
                cmd.Parameters.Add("@CAddress", SqlDbType.VarChar).Value = address;
                cmd.Parameters.Add("@CPhone", SqlDbType.NChar).Value = phone;
                cmd.Parameters.Add("@CDOB", SqlDbType.SmallDateTime).Value = dob;
                cmd.Parameters.Add("@CMem", SqlDbType.Bit).Value = member;
                cmd.Parameters.Add("@CMemJoinYear", SqlDbType.Int).Value = membershipYear;
                cmd.Parameters.Add("@CID", SqlDbType.Int).Value = cid;
                var ds = dl.ExecuteNonQuery(cmd);
                return ds;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        /// <summary>
        /// Function to Delete Customer
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="lName"></param>
        /// <param name="reason"></param>
        /// <returns>int</returns>
        public int DeleteCutomerDetails(string fName, string lName, string reason)
        {
            var dl = new SQLInterface();
            try
            {
                var cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteCustomer";
                cmd.Parameters.Add("@CFName", SqlDbType.VarChar).Value = fName;
                cmd.Parameters.Add("@CLName", SqlDbType.VarChar).Value = lName;
                cmd.Parameters.Add("@Reason", SqlDbType.VarChar).Value = reason;
                var ds = dl.ExecuteNonQuery(cmd);
                return ds;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        /// <summary>
        /// Function to  Get Customer ID
        /// </summary>
        /// <param name="phone"></param>
        /// <returns>int</returns>
        public int GetCustomerID(string phone)
        {
            var dl = new SQLInterface();
            var ds = new DataSet();
            try
            {
                var cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetCustomerID";
                cmd.Parameters.Add("@CPhone", SqlDbType.NVarChar).Value = phone;
                ds = dl.SqlAdapter(cmd);
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            catch (Exception)
            {
                return 0;
            }
        }
        /// <summary>
        /// Function to get number of purchase
        /// </summary>
        /// <param name="cid"></param>
        /// <returns>int</returns>
        public int GetPurchaseCount(int cid)
        {
            var dl = new SQLInterface();
            var ds = new DataSet();
            try
            {
                var cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetPurchaseCount";
                cmd.Parameters.Add("@CID", SqlDbType.Int).Value = cid;
                ds = dl.SqlAdapter(cmd);
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            catch (Exception)
            {
                return 0;
            }
        }
        /// <summary>
        /// Function to Get Purchase Details
        /// </summary>
        /// <param name="cid"></param>
        /// <returns>decimal</returns>
        public decimal GetPurchaseAmt(int cid)
        {
            var dl = new SQLInterface();
            var ds = new DataSet();
            decimal amt = 0;
            try
            {
                var cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetTotalPurChase";
                cmd.Parameters.Add("@CID", SqlDbType.Int).Value = cid;
                ds = dl.SqlAdapter(cmd);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        amt = amt + Convert.ToDecimal(ds.Tables[0].Rows[i][0].ToString());
                    }
                }
                return amt;
            }
            catch (Exception)
            {
                return 0;
            }
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
        public int AddBillDetails(int cid, DateTime dop, decimal BAmt, bool member, decimal disc, int itemCount)
        {
            var dl = new SQLInterface();
            try
            {
                var cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddBillDetails";
                cmd.Parameters.Add("@CID", SqlDbType.Int).Value = cid;
                cmd.Parameters.Add("@DOP", SqlDbType.SmallDateTime).Value = dop;
                cmd.Parameters.Add("@BAmt", SqlDbType.Decimal).Value = BAmt;
                cmd.Parameters.Add("@CMem", SqlDbType.Bit).Value = member;
                cmd.Parameters.Add("@Disc", SqlDbType.Decimal).Value = disc;
                cmd.Parameters.Add("@ItemPurchased", SqlDbType.Int).Value = itemCount;
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
