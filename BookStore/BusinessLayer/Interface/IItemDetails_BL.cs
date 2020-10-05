using BookStore.BusinessLayer.BusinessModel;

namespace BookStore.BusinessLayer.Interface
{
    /// <summary>
    /// ItemDetails Business Layer Interface
    /// </summary>
    public interface IItemDetails_BL
    {
        /// <summary>
        /// Function to search Item
        /// </summary>
        /// <param name="item"></param>
        /// <returns>ItemDetails</returns>
        ItemDetails SearchItem(string item);
        /// <summary>
        /// Function to Add Item
        /// </summary>
        /// <param name="item"></param>
        /// <param name="price"></param>
        /// <returns>int</returns>
        int AddItem(string item, string price);
        /// <summary>
        /// Function to Update Item
        /// </summary>
        /// <param name="item"></param>
        /// <param name="price"></param>
        /// <returns>int</returns>
        int UpdateItem(string item, string price);
        /// <summary>
        /// Function to Delete Item
        /// </summary>
        /// <param name="item"></param>
        /// <param name="reason"></param>
        /// <returns>int</returns>
        int DeleteItem(string item, string reason);
    }
}
