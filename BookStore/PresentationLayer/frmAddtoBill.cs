using BookStore.BusinessLayer.BusinessModel;
using System;
using System.Windows.Forms;

namespace BookStore.PresentationLayer
{
    /// <summary>
    /// Add billing Details Form
    /// </summary>
    public partial class frmAddtoBill : Form
    {
        /// <summary>
        /// Item Details Variable
        /// </summary>
        private BillItemDetails _billItemDetails = new BillItemDetails();
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="billItemDetails"></param>
        public frmAddtoBill(BillItemDetails billItemDetails)
        {
            InitializeComponent();
            _billItemDetails.ItemDetail = new ItemDetails();
            _billItemDetails = billItemDetails;

            tbItem.Text = billItemDetails.ItemDetail.ItemDesc;
            tbRate.Text = billItemDetails.ItemDetail.ItemPrice.ToString();
            tbQty.Text = billItemDetails.Qty.ToString();
            tbTotal.Text = billItemDetails.Total.ToString();
        }
        /// <summary>
        /// OnTextChanged Event 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTextChanged_Qty(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbQty.Text) && !string.IsNullOrEmpty(tbRate.Text))
            {
                var qty = Convert.ToInt16(tbQty.Text);
                var rate = Convert.ToDecimal(tbRate.Text);

                tbTotal.Text = (qty * rate).ToString();
            }
        }
        /// <summary>
        /// OnTextChanged Event 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTextChanged_Rate(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbQty.Text) && !string.IsNullOrEmpty(tbRate.Text))
            {
                var qty = Convert.ToInt16(tbQty.Text);
                var rate = Convert.ToDecimal(tbRate.Text);

                tbTotal.Text = (qty * rate).ToString();
            }
        }
        /// <summary>
        /// Button Search Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var item = tbItem.Text.Trim();
            BusinessLayer.Interface.IItemDetails_BL bl = new BusinessLayer.ItemDetails_BL();
            var Id = bl.SearchItem(item);

            if (Id != null)
            {
                tbItem.Text = Id.ItemDesc;
                tbRate.Text = Id.ItemPrice.ToString();
            }
            else
                MessageBox.Show("Item not Found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        /// <summary>
        /// Button Add Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddtoBill_Click(object sender, EventArgs e)
        {
            _billItemDetails.ItemDetail.ItemDesc = tbItem.Text.Trim();
            _billItemDetails.ItemDetail.ItemPrice = Convert.ToDecimal(tbRate.Text.Trim());
            _billItemDetails.Qty = Convert.ToInt16(tbQty.Text.Trim());
            _billItemDetails.Total = Convert.ToDecimal(tbTotal.Text.Trim());
            Close();
        }
        /// <summary>
        /// OnTextChanged Event 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTextChanged_Total(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(tbTotal.Text) > 0)
                btnAddtoBill.Enabled = true;
            else
                btnAddtoBill.Enabled = false;
        }
    }
}
