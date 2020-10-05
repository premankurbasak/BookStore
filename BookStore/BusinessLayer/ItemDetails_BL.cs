using BookStore.BusinessLayer.BusinessModel;
using System.Data;
using System;

namespace BookStore.BusinessLayer
{
    /// <summary>
    /// ItemDetails Business Layer Class
    /// </summary>
    class ItemDetails_BL:Interface.IItemDetails_BL
    {
        /// <summary>
        /// Function to search Item
        /// </summary>
        /// <param name="item"></param>
        /// <returns>ItemDetails</returns>
        public ItemDetails SearchItem(string item)
        {
            var dt = new DataTable();
            var id = new ItemDetails();
            DataBaseLayer.Interface.IItemDetails_DL dl = new DataBaseLayer.ItemDetails_DL();
            var ds = dl.SearchItemDetails(item);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dt = ds.Tables[0];
                id.ItemDesc = dt.Rows[0][0].ToString();
                id.ItemPrice = Convert.ToDecimal(dt.Rows[0][1].ToString());
                return id;
            }
            return null;
        }
        /// <summary>
        /// Function to Add Item
        /// </summary>
        /// <param name="item"></param>
        /// <param name="price"></param>
        /// <returns>int</returns>
        public int AddItem(string item, string price)
        {
            DataBaseLayer.Interface.IItemDetails_DL dl = new DataBaseLayer.ItemDetails_DL();
            var ds = dl.AddItemDetails(item, price);
            return ds;
        }
        /// <summary>
        /// Function to Update Item
        /// </summary>
        /// <param name="item"></param>
        /// <param name="price"></param>
        /// <returns>int</returns>
        public int UpdateItem(string item, string price)
        {
            DataBaseLayer.Interface.IItemDetails_DL dl = new DataBaseLayer.ItemDetails_DL();
            var ds = dl.UpdateItemDetails(item, price);
            return ds;
        }
        /// <summary>
        /// Function to Delete Item
        /// </summary>
        /// <param name="item"></param>
        /// <param name="reason"></param>
        /// <returns>int</returns>
        public int DeleteItem(string item, string reason)
        {
            DataBaseLayer.Interface.IItemDetails_DL dl = new DataBaseLayer.ItemDetails_DL();
            var ds = dl.DeleteItemDetails(item, reason);
            return ds;
        }
    }
}
