using System.Windows.Forms;

namespace BookStore.PresentationLayer
{
    /// <summary>
    /// Items Details Windows Form
    /// </summary>
    public partial class frmItemDetails : Form
    {
        /// <summary>
        /// String variable
        /// </summary>
        public string _reason = string.Empty;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ud"></param>
        public frmItemDetails(BusinessLayer.BusinessModel.UserDetails ud)
        {
            InitializeComponent();

            if (ud.Role == "Manager")
            {
                btnDel.Enabled = true;
            }
        }
        /// <summary>
        /// Button Add click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            var item = tbItemDesc.Text.Trim();
            BusinessLayer.Interface.IItemDetails_BL bl = new BusinessLayer.ItemDetails_BL();
            var Id = bl.SearchItem(item);

            if (Id!= null && tbItemDesc.Text == Id.ItemDesc)
            {
                MessageBox.Show("Item already added. Please add a different Item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            var val = bl.AddItem(tbItemDesc.Text.Trim(), tbItemPrice.Text.Trim());
            if (val == 1)
                MessageBox.Show("Item Added successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Failed to add New Item Details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        /// <summary>
        /// Button Search click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            var item = tbItemDesc.Text.Trim();
            BusinessLayer.Interface.IItemDetails_BL bl = new BusinessLayer.ItemDetails_BL();
            var Id = bl.SearchItem(item);

            if (Id != null)
            {
                tbItemDesc.Text = Id.ItemDesc;
                tbItemPrice.Text = Id.ItemPrice.ToString();
            }
            else
                MessageBox.Show("Item not Found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        /// <summary>
        /// Button Update click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            var item = tbItemDesc.Text.Trim();
            BusinessLayer.Interface.IItemDetails_BL bl = new BusinessLayer.ItemDetails_BL();

            var val = bl.UpdateItem(tbItemDesc.Text.Trim(), tbItemPrice.Text.Trim());
            if (val == 1)
                MessageBox.Show("Item details updated successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Failed to update Item Details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        /// <summary>
        /// Button Delete click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, System.EventArgs e)
        {
            var item = tbItemDesc.Text.Trim();
            BusinessLayer.Interface.IItemDetails_BL bl = new BusinessLayer.ItemDetails_BL();
            var id = bl.SearchItem(item);
            if (id== null)
            {
                MessageBox.Show("Item not found. Please provide a different Item Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            using (var frm = new frmDelReason())
            {
                frm.ShowDialog();
            }

            var val = bl.DeleteItem(tbItemDesc.Text.Trim(), frmMain._reason);
            if (val == 1)
                MessageBox.Show("Item details updated successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Failed to delete Item Details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        /// <summary>
        /// OnKeyPress Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnKeyPress_Rate(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back|| e.KeyChar=='.');
        }
    }
}
