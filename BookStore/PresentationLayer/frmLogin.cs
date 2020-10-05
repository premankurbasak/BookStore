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
    /// Login Windows Form
    /// </summary>
    public partial class frmLogin : Form
    {
        /// <summary>
        /// User Details Variable
        /// </summary>
        private BusinessLayer.BusinessModel.UserDetails ud = new BusinessLayer.BusinessModel.UserDetails();
        /// <summary>
        /// Constructor
        /// </summary>
        public frmLogin()
        {
            InitializeComponent();
            tbUserName.Text = "Admin";
            tbPassword.Text = "Admin";
        }
        /// <summary>
        /// Button Cancel click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Button Login click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (IsValidUser())
            {
                this.Hide();
                var _main = new frmMain(ud);
                _main.Show();
            }
            else
            {
                MessageBox.Show("User Name or Password didnot match. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Function to check valid user
        /// </summary>
        /// <returns></returns>
        private bool IsValidUser()
        {
            var username = tbUserName.Text.Trim();
            BusinessLayer.Interface.IUserDetails_BL bl = new BusinessLayer.UserDetails_BL();
            ud = bl.SearchUser(username);

            if (tbUserName.Text == ud.UserName && tbPassword.Text ==ud.Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
