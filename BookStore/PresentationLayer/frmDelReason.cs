using System;
using System.Windows.Forms;

namespace BookStore.PresentationLayer
{ 
    /// <summary>
    /// Delete Reason Windows Form 
    /// </summary>
    public partial class frmDelReason : Form
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public frmDelReason()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Button Ok click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbReason.Text.Trim()))
            {
                MessageBox.Show("Please provide a reason", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            else
            {
                frmMain._reason = tbReason.Text.Trim();
                Close();
            }
        }
    }
}
