namespace BookStore.PresentationLayer
{
    partial class frmAddtoBill
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddtoBill));
            this.tbItem = new System.Windows.Forms.TextBox();
            this.tbRate = new System.Windows.Forms.TextBox();
            this.tbQty = new System.Windows.Forms.TextBox();
            this.tbTotal = new System.Windows.Forms.TextBox();
            this.btnAddtoBill = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbItem
            // 
            this.tbItem.Location = new System.Drawing.Point(93, 33);
            this.tbItem.Name = "tbItem";
            this.tbItem.Size = new System.Drawing.Size(270, 20);
            this.tbItem.TabIndex = 0;
            // 
            // tbRate
            // 
            this.tbRate.Location = new System.Drawing.Point(93, 87);
            this.tbRate.Name = "tbRate";
            this.tbRate.ReadOnly = true;
            this.tbRate.Size = new System.Drawing.Size(270, 20);
            this.tbRate.TabIndex = 1;
            this.tbRate.TextChanged += new System.EventHandler(this.OnTextChanged_Rate);
            // 
            // tbQty
            // 
            this.tbQty.Location = new System.Drawing.Point(93, 146);
            this.tbQty.Name = "tbQty";
            this.tbQty.Size = new System.Drawing.Size(270, 20);
            this.tbQty.TabIndex = 2;
            this.tbQty.TextChanged += new System.EventHandler(this.OnTextChanged_Qty);
            // 
            // tbTotal
            // 
            this.tbTotal.Location = new System.Drawing.Point(93, 202);
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.ReadOnly = true;
            this.tbTotal.Size = new System.Drawing.Size(270, 20);
            this.tbTotal.TabIndex = 3;
            this.tbTotal.TextChanged += new System.EventHandler(this.OnTextChanged_Total);
            // 
            // btnAddtoBill
            // 
            this.btnAddtoBill.Enabled = false;
            this.btnAddtoBill.Location = new System.Drawing.Point(145, 258);
            this.btnAddtoBill.Name = "btnAddtoBill";
            this.btnAddtoBill.Size = new System.Drawing.Size(99, 23);
            this.btnAddtoBill.TabIndex = 4;
            this.btnAddtoBill.Text = "Add/Edit to Bill";
            this.btnAddtoBill.UseVisualStyleBackColor = true;
            this.btnAddtoBill.Click += new System.EventHandler(this.btnAddtoBill_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Item Details : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Rate : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Quantity : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Total : ";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(288, 59);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Search Item";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmAddtoBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 312);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddtoBill);
            this.Controls.Add(this.tbTotal);
            this.Controls.Add(this.tbQty);
            this.Controls.Add(this.tbRate);
            this.Controls.Add(this.tbItem);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAddtoBill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Items to Bill";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbItem;
        private System.Windows.Forms.TextBox tbRate;
        private System.Windows.Forms.TextBox tbQty;
        private System.Windows.Forms.TextBox tbTotal;
        private System.Windows.Forms.Button btnAddtoBill;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSearch;
    }
}