using System.Data;

namespace BookStore.DataBaseLayer.Interface
{
    /// <summary>
    /// ItemDetails Database Layer Interface
    /// </summary>
    public interface IItemDetails_DL
    {
        /// <summary>
        /// Function to search Item
        /// </summary>
        /// <param name="item"></param>
        /// <returns>DataSet</returns>
        DataSet SearchItemDetails(string item);
        /// <summary>
        /// Function to Add Item
        /// </summary>
        /// <param name="item"></param>
        /// <param name="price"></param>
        /// <returns>int</returns>
        int AddItemDetails(string item, string price);
        /// <summary>
        /// Function to Update Item
        /// </summary>
        /// <param name="item"></param>
        /// <param name="price"></param>
        /// <returns>int</returns>
        int UpdateItemDetails(string item, string price);
        /// <summary>
        /// Function to Delete Item
        /// </summary>
        /// <param name="item"></param>
        /// <param name="reason"></param>
        /// <returns>int</returns>
        int DeleteItemDetails(string item, string reason);
    }
}
