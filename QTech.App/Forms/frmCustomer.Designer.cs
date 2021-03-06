namespace QTech.Forms
{
    partial class frmCustomer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomer));
            this.lblName = new QTech.Component.ExLabel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblPhone = new QTech.Component.ExLabel();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblNote = new QTech.Component.ExLabel();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.exPanel1 = new QTech.Component.Components.ExPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new QTech.Component.ExButtonLoading();
            this.btnSave = new QTech.Component.ExButtonLoading();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.tabSetPrice = new System.Windows.Forms.TabPage();
            this.exLabel1 = new QTech.Component.ExLabel();
            this.dgvGoods = new QTech.Component.ExDataGridView();
            this.colProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGoodName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSalePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnChangeLog = new QTech.Component.ExButtonLoading();
            this.container.SuspendLayout();
            this.exPanel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tabSetPrice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoods)).BeginInit();
            this.SuspendLayout();
            // 
            // digheader
            // 
            this.digheader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.digheader.Size = new System.Drawing.Size(384, 20);
            // 
            // container
            // 
            this.container.Controls.Add(this.tabMain);
            this.container.Controls.Add(this.exPanel1);
            this.container.Size = new System.Drawing.Size(384, 422);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(26, 18);
            this.lblName.Name = "lblName";
            this.lblName.Required = true;
            this.lblName.Size = new System.Drawing.Size(83, 19);
            this.lblName.TabIndex = 15;
            this.lblName.Text = "ឈ្មោះក្រុមហ៊ុន";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(145, 14);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 27);
            this.txtName.TabIndex = 0;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(26, 49);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Required = true;
            this.lblPhone.Size = new System.Drawing.Size(68, 19);
            this.lblPhone.TabIndex = 22;
            this.lblPhone.Text = "លេខទូរស័ព្ទ";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(145, 45);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(2);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(200, 27);
            this.txtPhone.TabIndex = 1;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(26, 79);
            this.lblNote.Name = "lblNote";
            this.lblNote.Required = false;
            this.lblNote.Size = new System.Drawing.Size(41, 19);
            this.lblNote.TabIndex = 24;
            this.lblNote.Text = "ចំណាំ";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(145, 76);
            this.txtNote.Margin = new System.Windows.Forms.Padding(2);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(200, 46);
            this.txtNote.TabIndex = 2;
            // 
            // exPanel1
            // 
            this.exPanel1.BackColor = System.Drawing.Color.Transparent;
            this.exPanel1.Controls.Add(this.flowLayoutPanel3);
            this.exPanel1.Controls.Add(this.flowLayoutPanel2);
            this.exPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.exPanel1.Location = new System.Drawing.Point(1, 385);
            this.exPanel1.Name = "exPanel1";
            this.exPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.exPanel1.Size = new System.Drawing.Size(382, 36);
            this.exPanel1.TabIndex = 25;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.btnChangeLog);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(2, 2);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(200, 32);
            this.flowLayoutPanel3.TabIndex = 2;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnClose);
            this.flowLayoutPanel2.Controls.Add(this.btnSave);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(215, 2);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(165, 32);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Ivory;
            this.btnClose.DefaultImage = null;
            this.btnClose.Executing = false;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(88, 3);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnClose.ShortcutText = null;
            this.btnClose.Size = new System.Drawing.Size(75, 27);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "បិទ";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Ivory;
            this.btnSave.DefaultImage = null;
            this.btnSave.Executing = false;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(9, 3);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnSave.ShortcutText = null;
            this.btnSave.Size = new System.Drawing.Size(75, 27);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "រក្សាទុក";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "ឈ្មោះគំរោង";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "លេខទូរស័ព្ទ";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabGeneral);
            this.tabMain.Controls.Add(this.tabSetPrice);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(1, 1);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(382, 384);
            this.tabMain.TabIndex = 0;
            // 
            // tabGeneral
            // 
            this.tabGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.tabGeneral.Controls.Add(this.lblName);
            this.tabGeneral.Controls.Add(this.txtName);
            this.tabGeneral.Controls.Add(this.lblNote);
            this.tabGeneral.Controls.Add(this.txtNote);
            this.tabGeneral.Controls.Add(this.lblPhone);
            this.tabGeneral.Controls.Add(this.txtPhone);
            this.tabGeneral.Location = new System.Drawing.Point(4, 28);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(374, 352);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "ព័ត៍មានទូទៅ";
            // 
            // tabSetPrice
            // 
            this.tabSetPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.tabSetPrice.Controls.Add(this.exLabel1);
            this.tabSetPrice.Controls.Add(this.dgvGoods);
            this.tabSetPrice.Location = new System.Drawing.Point(4, 28);
            this.tabSetPrice.Name = "tabSetPrice";
            this.tabSetPrice.Padding = new System.Windows.Forms.Padding(3);
            this.tabSetPrice.Size = new System.Drawing.Size(437, 238);
            this.tabSetPrice.TabIndex = 1;
            this.tabSetPrice.Text = "កំណត់តម្លៃទំនិញ";
            // 
            // exLabel1
            // 
            this.exLabel1.AutoSize = true;
            this.exLabel1.Font = new System.Drawing.Font("Khmer OS System", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.exLabel1.Location = new System.Drawing.Point(25, 20);
            this.exLabel1.Name = "exLabel1";
            this.exLabel1.Required = false;
            this.exLabel1.Size = new System.Drawing.Size(74, 19);
            this.exLabel1.TabIndex = 18;
            this.exLabel1.Text = "ទំនិញលម្អិត";
            // 
            // dgvGoods
            // 
            this.dgvGoods.AllowEnterToNextCell = false;
            this.dgvGoods.AllowRowNotFound = true;
            this.dgvGoods.AllowRowNumber = false;
            this.dgvGoods.AllowUserToAddRows = false;
            this.dgvGoods.AllowUserToDeleteRows = false;
            this.dgvGoods.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvGoods.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGoods.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.dgvGoods.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvGoods.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Ivory;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Khmer OS System", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGoods.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvGoods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGoods.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductId,
            this.colIdd,
            this.colGoodName,
            this.colCategory_,
            this.colSalePrice});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Khmer OS System", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(205)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGoods.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvGoods.EnableHeadersVisualStyles = false;
            this.dgvGoods.Executing = false;
            this.dgvGoods.Font = new System.Drawing.Font("Khmer OS System", 8F);
            this.dgvGoods.Location = new System.Drawing.Point(27, 42);
            this.dgvGoods.MultiSelect = false;
            this.dgvGoods.Name = "dgvGoods";
            this.dgvGoods.Paging = null;
            this.dgvGoods.ReadOnly = true;
            this.dgvGoods.RowHeadersVisible = false;
            this.dgvGoods.RowTemplate.Height = 28;
            this.dgvGoods.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGoods.Size = new System.Drawing.Size(323, 285);
            this.dgvGoods.TabIndex = 17;
            // 
            // colProductId
            // 
            this.colProductId.HeaderText = "colProductId";
            this.colProductId.Name = "colProductId";
            this.colProductId.ReadOnly = true;
            this.colProductId.Visible = false;
            // 
            // colIdd
            // 
            this.colIdd.HeaderText = "colIdd";
            this.colIdd.Name = "colIdd";
            this.colIdd.ReadOnly = true;
            this.colIdd.Visible = false;
            // 
            // colGoodName
            // 
            this.colGoodName.HeaderText = "colGoodName";
            this.colGoodName.Name = "colGoodName";
            this.colGoodName.ReadOnly = true;
            this.colGoodName.Width = 140;
            // 
            // colCategory_
            // 
            this.colCategory_.HeaderText = "ប្រភេទ";
            this.colCategory_.Name = "colCategory_";
            this.colCategory_.ReadOnly = true;
            // 
            // colSalePrice
            // 
            this.colSalePrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSalePrice.HeaderText = "colSalePrice";
            this.colSalePrice.Name = "colSalePrice";
            this.colSalePrice.ReadOnly = true;
            // 
            // btnChangeLog
            // 
            this.btnChangeLog.BackColor = System.Drawing.Color.Ivory;
            this.btnChangeLog.DefaultImage = null;
            this.btnChangeLog.Executing = false;
            this.btnChangeLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeLog.Font = new System.Drawing.Font("Khmer OS Battambang", 8F);
            this.btnChangeLog.ForeColor = System.Drawing.Color.Black;
            this.btnChangeLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChangeLog.Location = new System.Drawing.Point(2, 3);
            this.btnChangeLog.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.btnChangeLog.Name = "btnChangeLog";
            this.btnChangeLog.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnChangeLog.ShortcutText = "E";
            this.btnChangeLog.Size = new System.Drawing.Size(75, 27);
            this.btnChangeLog.TabIndex = 6;
            this.btnChangeLog.Text = "ប្រវត្តកែប្រែ";
            this.btnChangeLog.UseVisualStyleBackColor = true;
            this.btnChangeLog.Click += new System.EventHandler(this.btnChangeLog_Click);
            // 
            // frmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 442);
            this.Font = new System.Drawing.Font("Khmer OS System", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmCustomer";
            this.Text = "frmEmployee";
            this.container.ResumeLayout(false);
            this.exPanel1.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.tabSetPrice.ResumeLayout(false);
            this.tabSetPrice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoods)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Component.ExLabel lblName;
        private System.Windows.Forms.TextBox txtName;
        private Component.ExLabel lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private Component.ExLabel lblNote;
        private System.Windows.Forms.TextBox txtNote;
        private Component.Components.ExPanel exPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private Component.ExButtonLoading btnClose;
        private Component.ExButtonLoading btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabSetPrice;
        private Component.ExDataGridView dgvGoods;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGoodName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory_;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSalePrice;
        private Component.ExLabel exLabel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private Component.ExButtonLoading btnChangeLog;
    }
}