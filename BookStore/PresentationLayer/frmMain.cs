using BookStore.BusinessLayer.BusinessModel;
using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace BookStore.PresentationLayer
{
    /// <summary>
    /// Application Main Windows Form
    /// </summary>
    public partial class frmMain : Form
    {
        /// <summary>
        /// User Details Variable
        /// </summary>
        private UserDetails _ud = new UserDetails();
        /// <summary>
        /// Customer Details Variable
        /// </summary>
        private CustomerDetails _cd = new CustomerDetails();
        /// <summary>
        /// String Variable
        /// </summary>
        public static string _reason = string.Empty;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ud"></param>
        public frmMain(UserDetails ud)
        {
            Thread t = new Thread(new ThreadStart(frmSplashShow));
            t.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            t.Abort();
            lblTxtUname.Text = ud.UserName;
            lblTxtRole.Text = ud.Role;

            if (ud.Role == "Manager") usersToolStripMenuItem.Visible = true;
            _ud = ud;
        }
        /// <summary>
        /// Invoking Splash Windows Form
        /// </summary>
        public void frmSplashShow()
        {
            Application.Run(new frmSplash());
        }
        /// <summary>
        /// Form Close Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFormClose(object sender, FormClosedEventArgs e)
        {

            Application.Exit();
        }
        /// <summary>
        /// Button Search Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            BusinessLayer.Interface.ICustomerDetails_BL bl = new BusinessLayer.CustomerDetails_BL();
            var dt = bl.SearchCustomer(tbFName.Text.Trim(), tbLName.Text.Trim(), tbMobile.Text.Trim());
            _cd = dt;

            if (dt!=null)
            {
                dgvCustomer.Rows.Add(dt.FirstName,dt.LastName,dt.Phone);
                lblSearchCount.Text = dgvCustomer.Rows.Count.ToString();
            }
            else
            {
                dgvCustomer.Rows.Clear();
                lblSearchCount.Text = "0";
            }
        }
        /// <summary>
        /// Keypress event on text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnKeyPress_Phone(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }
        /// <summary>
        /// Keypress event on text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnKeyPress_LName(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back|| char.IsDigit(e.KeyChar));
        }
        /// <summary>
        /// Keypress event on text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnKeyPress_FName(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back|| char.IsDigit(e.KeyChar));
        }
        /// <summary>
        /// OnCellClick event in DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCellMouseClick_dgvCustomer(object sender, DataGridViewCellMouseEventArgs e)
        {
            tbCFName.Text = _cd.FirstName;
            tbCLName.Text = _cd.LastName;
            tbCAddress.Text = _cd.Address;
            tbCPhone.Text = _cd.Phone.ToString();
            tbCYear.Text = _cd.JoiningYear.ToString();
            if (_cd.Member) rbValid.Checked = true;
            dtpDOB.Value = _cd.DOB;
        }
        /// <summary>
        /// Button Edit Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            tbCFName.ReadOnly = false;
            tbCLName.ReadOnly = false;
            tbCPhone.ReadOnly = false;
            tbCAddress.ReadOnly = false;
            tbCYear.ReadOnly = false;
            dtpDOB.Enabled = true;
            rbGuest.Enabled = true;
            rbValid.Enabled = true;
            rbYes.Enabled = true;
            rbNo.Enabled = true;
            rbNA.Enabled = true;

            if (string.IsNullOrEmpty(tbCFName.Text))
                btnAdd.Enabled = true;
            else
                btnUpdate.Enabled = true;

            if (lblTxtRole.Text == "Manager") btnDel.Enabled = true;

        }
        /// <summary>
        /// Button Update Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool member = false;
            BusinessLayer.Interface.ICustomerDetails_BL bl = new BusinessLayer.CustomerDetails_BL();
            if (rbValid.Checked) member = true;
            if (rbGuest.Checked && rbYes.Checked) member = true;

            var cid = bl.GetCustomerID(tbCPhone.Text.Trim());

            var val = bl.UpdateCustomer(tbCFName.Text.Trim(), tbCLName.Text.Trim(), tbCAddress.Text.Trim(), tbCPhone.Text.Trim(), dtpDOB.Value, member, Convert.ToInt32(tbCYear.Text.Trim()),cid);
            if (val == 1)
                MessageBox.Show("Customer details updated successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Failed to update Customer Details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);

            ChangeState();

        }
        /// <summary>
        /// User Details Menu Item Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new frmUserDetails(_ud))
            {
                frm.ShowDialog();
            }
        }
        /// <summary>
        /// Button Delete Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            BusinessLayer.Interface.ICustomerDetails_BL bl = new BusinessLayer.CustomerDetails_BL();
            var ud = bl.SearchCustomer(tbCFName.Text.Trim(), tbCLName.Text.Trim(), tbCPhone.Text.Trim());
            if (ud == null)
            {
                MessageBox.Show("Username not found. Please provide a different User Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            using (var frm = new frmDelReason())
            {
                frm.ShowDialog();
            }

            var val = bl.DeleteCustomer(tbCFName.Text.Trim(), tbCLName.Text.Trim(), _reason);
            if (val == 1)
                MessageBox.Show("User details deleted successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Failed to delete User Details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            ChangeState();
            ClearCustomerDetails();
        }
        /// <summary>
        /// Change the state of the controls Enabled/Disabled
        /// </summary>
        private void ChangeState()
        {
            tbCFName.ReadOnly = true;
            tbCLName.ReadOnly = true;
            tbCPhone.ReadOnly = true;
            tbCAddress.ReadOnly = true;
            tbCYear.ReadOnly = true;
            dtpDOB.Enabled = false;
            rbGuest.Enabled = false;
            rbValid.Enabled = false;
            rbYes.Enabled = false;
            rbNo.Enabled = false;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDel.Enabled = false;
            rbNA.Enabled = false;
        }
        /// <summary>
        /// Button Add Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool member = false;
            BusinessLayer.Interface.ICustomerDetails_BL bl = new BusinessLayer.CustomerDetails_BL();
            var dt = bl.SearchCustomer(tbCFName.Text.Trim(), tbCLName.Text.Trim(), tbCPhone.Text.Trim());

            if (dt!=null)
            {
                MessageBox.Show("Customer already added. Please provide a different Customer Details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }



            if (rbValid.Checked) member = true;
            if (rbGuest.Checked && rbYes.Checked) member = true;

            if (CheckInput())
            {
                var val = bl.AddCustomer(tbCFName.Text.Trim(), tbCLName.Text.Trim(), tbCAddress.Text.Trim(), tbCPhone.Text.Trim(), dtpDOB.Value, member, Convert.ToInt32(tbCYear.Text.Trim()));
                if (val == 1)
                {
                    MessageBox.Show("Customer Details Added successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var cd = bl.SearchCustomer(tbCFName.Text.Trim(), tbCLName.Text.Trim(), tbCPhone.Text.Trim());
                    tbCFName.Text = cd.FirstName;
                    tbCLName.Text = cd.LastName;
                    tbCAddress.Text = cd.Address;
                    tbCPhone.Text = cd.Phone.ToString();
                    tbCYear.Text = cd.JoiningYear.ToString();
                    if (cd.Member) rbValid.Checked = true;
                    dtpDOB.Value = cd.DOB;

                    if (rbYes.Checked)
                    {
                        btnBill.Enabled = false;
                        dgvBilling.Rows.Add("Membership Fee", "1", "500", "500");
                        tbDisc.Enabled = false;
                        btnCalc.Enabled = false;
                        btnCalculate.Enabled = false;
                        lblGTotal.Text = "500";
                    }
                }
                else
                    MessageBox.Show("Failed to add New Customer Details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                ChangeState();
            }
            else
                MessageBox.Show("Please provide valid input.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Hand);

        }
        /// <summary>
        /// Item Details Menu Item Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new frmItemDetails(_ud))
            {
                frm.ShowDialog();
            }
        }
        /// <summary>
        /// Button Add Billing Details Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBill_Click(object sender, EventArgs e)
        {
            var billItemDetails = new BillItemDetails();
            billItemDetails.ItemDetail = new ItemDetails();
            using (var frm = new frmAddtoBill(billItemDetails))
            {
                frm.ShowDialog();
            }
            dgvBilling.Rows.Add(billItemDetails.ItemDetail.ItemDesc, billItemDetails.Qty, billItemDetails.ItemDetail.ItemPrice,billItemDetails.Total);
        }
        /// <summary>
        /// OnCellClick event in DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCellContentClick_dgvBilling(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvBilling.Columns[e.ColumnIndex].Name =="Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this record ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    dgvBilling.Rows.RemoveAt(e.RowIndex);
            }
            if (dgvBilling.Columns[e.ColumnIndex].Name == "Edit")
            {
                
                var billItemDetails = new BillItemDetails();
                billItemDetails.ItemDetail = new ItemDetails();

                billItemDetails.ItemDetail.ItemDesc = dgvBilling.Rows[e.RowIndex].Cells[0].Value.ToString();
                billItemDetails.Qty = Convert.ToInt32(dgvBilling.Rows[e.RowIndex].Cells[1].Value.ToString());
                billItemDetails.ItemDetail.ItemPrice = Convert.ToDecimal(dgvBilling.Rows[e.RowIndex].Cells[2].Value.ToString());
                billItemDetails.Total = Convert.ToDecimal(dgvBilling.Rows[e.RowIndex].Cells[3].Value.ToString());

                using (var frm = new frmAddtoBill(billItemDetails))
                {
                    frm.ShowDialog();
                }

                dgvBilling.Rows.RemoveAt(e.RowIndex);
                dgvBilling.Rows.Add(billItemDetails.ItemDetail.ItemDesc, billItemDetails.Qty, billItemDetails.ItemDetail.ItemPrice, billItemDetails.Total);
            }
        }
        /// <summary>
        /// Button Calculate Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            decimal grandTotal = 0, total =0, discnt=0, disc=0 ,res=0;
            

            total = Convert.ToDecimal(lblTotal.Text);
            Decimal.TryParse(tbDisc.Text, out res);
            disc = Convert.ToDecimal(lblCalDisc.Text) + res;

            discnt = total * (disc / 100);
            grandTotal = total - discnt;
            lblGTotal.Text = grandTotal.ToString();
        }
        /// <summary>
        /// Button Clear Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearCustomerDetails();
        }
        /// <summary>
        /// Function to clear customer details from the Windows From 
        /// </summary>
        private void ClearCustomerDetails()
        {
            tbCFName.Text = string.Empty;
            tbCLName.Text = string.Empty;
            tbCAddress.Text = string.Empty;
            tbCPhone.Text = string.Empty;
            tbCYear.Text = string.Empty;
            rbValid.Checked = false;
            rbGuest.Checked = true;
            rbNA.Checked = true;
            dtpDOB.Value = DateTime.Now;
        }
        /// <summary>
        /// Function to validate input
        /// </summary>
        /// <returns>bool</returns>
        private bool CheckInput()
        {
            bool valid = false;
            if (string.IsNullOrEmpty(tbCFName.Text) || string.IsNullOrEmpty(tbCLName.Text) || string.IsNullOrEmpty(tbCAddress.Text) || string.IsNullOrEmpty(tbCPhone.Text) || string.IsNullOrEmpty(tbCYear.Text))
            {
                MessageBox.Show("Please Fill all the input details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valid = false;
            }
            else
                valid = true;

            if (tbCPhone.Text.Length < 10)
            {
                MessageBox.Show("Please enter a valid Mobile Number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valid = false;
            }
            else
                valid = true;
            if (dtpDOB.Value.Year > Convert.ToInt32(tbCYear.Text))
            {
                MessageBox.Show("Membership year cannot be else than Date of Birth.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valid = false;
            }
            else
                valid = true;
            return valid;
        }
        /// <summary>
        /// Keypress event on text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnKeyPress_MYear(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }
        /// <summary>
        /// Keypress event on text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnKeyPress_Mobile(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }
        /// <summary>
        /// Button Save Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool member = false;
            decimal res = 0;
            BusinessLayer.Interface.ICustomerDetails_BL bl = new BusinessLayer.CustomerDetails_BL();
            
            if (rbValid.Checked) member = true;
            if (rbGuest.Checked && rbYes.Checked) member = true;
            var cid = bl.GetCustomerID(tbCPhone.Text.Trim());
            Decimal.TryParse(tbDisc.Text, out res);

            var val = bl.AddBillDetails(cid, DateTime.Now,Convert.ToDecimal(lblGTotal.Text), member, Convert.ToDecimal(lblCalDisc.Text) + res, dgvBilling.RowCount);
            if (val == 1)
                MessageBox.Show("Bill Details Added successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Failed to add New Bill Details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            ChangeState();
            Print();
        }
        /// <summary>
        /// Function to Calculate discount
        /// </summary>
        private void CalculateDiscount()
        {
            decimal discount = 0;
            bool newCustomer = false;
            bool exisitingCustomer = false;
            BusinessLayer.Interface.ICustomerDetails_BL bl = new BusinessLayer.CustomerDetails_BL();
            var dt = bl.SearchCustomer(tbCFName.Text.Trim(), tbCLName.Text.Trim(), tbCPhone.Text.Trim());

            var cid = bl.GetCustomerID(tbCPhone.Text.Trim());
            var cnt = bl.GetPurchaseCount(cid);
            var amt = bl.GetPurchaseCount(cid);

            if (rbGuest.Checked && rbYes.Checked)
            {
                discount = 5;
                newCustomer = true;
            }
            if (rbValid.Checked && rbYes.Checked || rbValid.Checked && rbNA.Checked)
            {
                discount = 5;
                exisitingCustomer = true;
            }


            //new customers
            if (newCustomer) discount = 5 + 2;
            if (newCustomer && Convert.ToInt32(lblTotal.Text) > 5000)
            {
                discount = discount - 2;
                discount = 5 + 3;
            }

            //existing customer

            if (exisitingCustomer && cnt > 5) discount = discount + 3;
            if (exisitingCustomer && amt > 6000) discount = discount + 5;
            if (exisitingCustomer && dt.DOB.Month == DateTime.Now.Month || exisitingCustomer && DateTime.Now.Year - Convert.ToInt32(dt.JoiningYear) >= 5)
                discount = 20;

            lblCalDisc.Text = discount.ToString();
        }
        /// <summary>
        /// Button Calulate Discount Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalc_Click(object sender, EventArgs e)
        {
            CalculateDiscount();
            decimal total = 0;
            for (int i = 0; i < dgvBilling.RowCount; i++)
            {
                total = total + Convert.ToDecimal(dgvBilling.Rows[i].Cells[3].Value.ToString());
            }

            lblTotal.Text = total.ToString();
        }
        /// <summary>
        /// Import Menu Item Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void importFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "xlsx files (*.xlsx)|*.xlsx|xls files (*.xls) | *.xls|csv files (*.csv)|*.csv";
                ofd.FilterIndex = 1;
                ofd.RestoreDirectory = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string path = ofd.FileName;
                    string ConnString = string.Empty;
                    string extension = Path.GetExtension(path);

                    if (extension == ".xls" || extension == ".xlsx")
                    {
                        string Excel03ConString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES'", path);
                        string Excel07ConString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES'", path);

                        if (extension == ".xls") ConnString = Excel03ConString;
                        if (extension == ".xlsx") ConnString = Excel07ConString;

                        DataTable Data = new DataTable();

                        using (var conn = new OleDbConnection(ConnString))
                        {
                            conn.Open();
                            OleDbCommand cmd = new OleDbCommand(@"SELECT * FROM [Sheet1$]", conn);
                            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                            adapter.Fill(Data);
                            conn.Close();
                        }
                        InsertDataIntoSQLServerUsingSQLBulkCopy(Data);
                    }
                    if (extension == ".csv")
                    {
                        var dt = GetDataTabletFromCSVFile(ofd.FileName);
                        InsertDataIntoSQLServerUsingSQLBulkCopy(dt);
                    }
                }
            }
        }
        /// <summary>
        /// Function to get Data table from CSV file
        /// </summary>
        /// <param name="csv_file_path"></param>
        /// <returns></returns>
        private DataTable GetDataTabletFromCSVFile(string csv_file_path)
        {
            DataTable csvData = new DataTable();
            try
            {
                using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colFields = csvReader.ReadFields();
                    foreach (string column in colFields)
                    {
                        DataColumn datecolumn = new DataColumn(column);
                        datecolumn.AllowDBNull = true;
                        csvData.Columns.Add(datecolumn);
                    }
                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        //Making empty value as null
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                        }
                        csvData.Rows.Add(fieldData);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return csvData;
        }
        /// <summary>
        /// Function to insert Bulk data into SQL Server
        /// </summary>
        /// <param name="FileData"></param>
        private void InsertDataIntoSQLServerUsingSQLBulkCopy(DataTable FileData)
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["bookstore"];
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(settings.ConnectionString))
            {
                bulkCopy.DestinationTableName = "CustomerDetails";
                bulkCopy.ColumnMappings.Add("CID", "CID");
                bulkCopy.ColumnMappings.Add("CFName", "CFName");
                bulkCopy.ColumnMappings.Add("CLName", "CLName");
                bulkCopy.ColumnMappings.Add("CAddress", "CAddress");
                bulkCopy.ColumnMappings.Add("CPhone", "CPhone");
                bulkCopy.ColumnMappings.Add("CDOB", "CDOB");
                bulkCopy.ColumnMappings.Add("CMem", "CMem");
                bulkCopy.ColumnMappings.Add("CMemJoinYear", "CMemJoinYear");
                bulkCopy.ColumnMappings.Add("IsDeleted", "IsDeleted");
                bulkCopy.ColumnMappings.Add("Reason", "Reason");
                try
                {
                    bulkCopy.WriteToServer(FileData);
                    MessageBox.Show("Data Imported Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fail to Import Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Function to print PDF
        /// </summary>
        private void Print()
        {
            //Create document  
            Document doc = new Document();
            //Create PDF Table  
            PdfPTable tableLayout = new PdfPTable(4);
            if (!Directory.Exists("c:\\Bills"))
            {
                Directory.CreateDirectory("c:\\Bills");
            }
            var fileName = "c:\\Bills" + "\\" + tbCFName.Text + "_" + tbCLName.Text + "_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString()+"_"+DateTime.Now.Hour.ToString()+"_"+DateTime.Now.Minute.ToString()+"_" + DateTime.Now.Second.ToString()+".pdf";
            //Create a PDF file in specific path  
            PdfWriter.GetInstance(doc, new FileStream(fileName, FileMode.Create));
            //Open the PDF document  
            doc.Open();
            var temp = "Customer Name: " + tbCFName.Text + " " + tbCLName.Text+"\nContact Number : "+ tbCPhone.Text;
            Paragraph p = new Paragraph(temp);
            doc.Add(p);
            //Add Content to PDF  
            doc.Add(Add_Content_To_PDF(tableLayout));
            temp = "Discount : "+ tbDisc.Text +"\nMembership Discount : " + lblCalDisc.Text+ "\nGrand Total: "+ lblGTotal.Text;
            p = new Paragraph(temp);
            doc.Add(p);
            // Closing the document  
            doc.Close();
        }
        /// <summary>
        /// Fucntion to Add content to PDF file
        /// </summary>
        /// <param name="tableLayout"></param>
        /// <returns></returns>
        private PdfPTable Add_Content_To_PDF(PdfPTable tableLayout)
        {
            float[] headers = { 80,20, 30,30 }; //Header Widths  
            tableLayout.SetWidths(headers); //Set the pdf headers  
            tableLayout.WidthPercentage = 80; //Set the PDF File witdh percentage  
                                              //Add Title to the PDF file at the top  
            tableLayout.AddCell(new PdfPCell(new Phrase("Twinkle Book Store", new Font(BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.EMBEDDED), 13, 1, BaseColor.BLUE)))
            {
                Colspan = 4,
                Border = 0,
                PaddingBottom = 20,
                HorizontalAlignment = Element.ALIGN_CENTER
            });
            //Add header  
            AddCellToHeader(tableLayout, "Item Description");
            AddCellToHeader(tableLayout, "Quantity");
            AddCellToHeader(tableLayout, "Rate");
            AddCellToHeader(tableLayout, "Total");
            //Add body  
            for (int i = 0; i < dgvBilling.RowCount; i++)
            {
                AddCellToBody(tableLayout, dgvBilling.Rows[i].Cells[0].Value.ToString());
                AddCellToBody(tableLayout, dgvBilling.Rows[i].Cells[1].Value.ToString());
                AddCellToBody(tableLayout, dgvBilling.Rows[i].Cells[2].Value.ToString());
                AddCellToBody(tableLayout, dgvBilling.Rows[i].Cells[3].Value.ToString());
            }

            return tableLayout;
        }
        /// <summary>
        ///  Method to add single cell to the header 
        /// </summary>
        /// <param name="tableLayout"></param>
        /// <param name="cellText"></param>
        private void AddCellToHeader(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.EMBEDDED) , 8, 1, BaseColor.WHITE)))
            {
                HorizontalAlignment = Element.ALIGN_CENTER,
                Padding = 5,
                BackgroundColor = BaseColor.WHITE
            });
        }
        /// <summary>
        /// Method to add single cell to the body 
        /// </summary>
        /// <param name="tableLayout"></param>
        /// <param name="cellText"></param>
        private void AddCellToBody(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.EMBEDDED), 8, 1, BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_CENTER,
                Padding = 5,
                BackgroundColor = BaseColor.WHITE
            });
        }
        /// <summary>
        /// OnCheck Changed Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCheckChanged_RbYes(object sender, EventArgs e)
        {
            if (rbYes.Checked)
                btnBill.Enabled = false;
            else
                btnBill.Enabled = true;
        }
    }
}
