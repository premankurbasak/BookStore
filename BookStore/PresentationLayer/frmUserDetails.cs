using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore.PresentationLayer
{
    /// <summary>
    /// User Details Windows Form 
    /// </summary>
    public partial class frmUserDetails : Form
    {
        /// <summary>
        /// User Details Variable
        /// </summary>
        private BusinessLayer.BusinessModel.UserDetails _ud = new BusinessLayer.BusinessModel.UserDetails();
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ud"></param>
        public frmUserDetails(BusinessLayer.BusinessModel.UserDetails ud)
        {
            InitializeComponent();
            _ud = ud;
            if (ud.Role == "Manager")
            {
                btnDel.Enabled = true;
                btnAdd.Enabled = true;
                btnUpdate.Enabled = true;
            }
        }
        /// <summary>
        /// Button Search Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var username = tbUname.Text.Trim();
            BusinessLayer.Interface.IUserDetails_BL bl = new BusinessLayer.UserDetails_BL();
            var ud = bl.SearchUser(username);

            if (ud != null)
            {
                tbUname.Text = ud.UserName;
                tbPassword.Text = ud.Password;
                if (ud.Role == "Manager")
                    rbManager.Checked = true;
                else
                    rbSalesman.Checked = true;
            }
            else
                MessageBox.Show("Username not Found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Hand);

        }
        /// <summary>
        /// Button Add Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var username = tbUname.Text.Trim();
            var role = string.Empty;
            BusinessLayer.Interface.IUserDetails_BL bl = new BusinessLayer.UserDetails_BL();
            var ud = bl.SearchUser(username);

            if(ud!= null && tbUname.Text == ud.UserName)
            {
                MessageBox.Show("Username already Taken. Please provide a different User Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if (rbManager.Checked)
                role = "Manager";
            else
                role = "SalesMan";

            var val = bl.AddUser(tbUname.Text.Trim(), tbPassword.Text.Trim(), role);
            if(val==1)
                MessageBox.Show("User Added successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Failed to add New User Details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        /// <summary>
        /// Button Update Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var username = tbUname.Text.Trim();
            var role = string.Empty;
            BusinessLayer.Interface.IUserDetails_BL bl = new BusinessLayer.UserDetails_BL();
           
            if (rbManager.Checked)
                role = "Manager";
            else
                role = "SalesMan";

            var val = bl.UpdateUser(tbUname.Text.Trim(), tbPassword.Text.Trim(), role);
            if (val == 1)
                MessageBox.Show("User details updated successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Failed to update User Details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);

        }
        /// <summary>
        /// Button Delete Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            var username = tbUname.Text.Trim();
            BusinessLayer.Interface.IUserDetails_BL bl = new BusinessLayer.UserDetails_BL();
            var ud = bl.SearchUser(username);
            if (ud==null)
            {
                MessageBox.Show("Username not found. Please provide a different User Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            using (var frm = new frmDelReason())
            {
                frm.ShowDialog();
            }

            var val = bl.DeleteUser(tbUname.Text.Trim(), frmMain._reason);
            if (val == 1)
                MessageBox.Show("User details deleted successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Failed to delete User Details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
    }
}
