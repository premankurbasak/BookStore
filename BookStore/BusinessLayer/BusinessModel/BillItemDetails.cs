namespace BookStore.BusinessLayer.BusinessModel
{
    /// <summary>
    /// Bill Item Details Class
    /// </summary>
    public class BillItemDetails
    {
        /// <summary>
        /// Item Details
        /// </summary>
        public ItemDetails ItemDetail { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        public int Qty { get; set; }
        /// <summary>
        /// Total
        /// </summary>
        public decimal Total { get; set; }       
    }
}
