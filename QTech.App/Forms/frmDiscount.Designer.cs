namespace QTech.Forms
{
    partial class frmDiscount
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblName = new QTech.Component.ExLabel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.exPanel1 = new QTech.Component.Components.ExPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnChangeLog = new QTech.Component.ExButtonLoading();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new QTech.Component.ExButtonLoading();
            this.btnSave = new QTech.Component.ExButtonLoading();
            this.lblCategory = new QTech.Component.ExLabel();
            this.dgv1 = new QTech.Component.ExDataGridView();
            this.colOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProduct = new QTech.Component.ExSearchComboColumn();
            this.colPercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.lblNote = new QTech.Component.ExLabel();
            this.flowLayOutLabelRemoveAdd = new System.Windows.Forms.FlowLayoutPanel();
            this.lblRemove = new System.Windows.Forms.LinkLabel();
            this.lblAdd = new System.Windows.Forms.LinkLabel();
            this.cboDiscountType = new System.Windows.Forms.ComboBox();
            this.dtpFrom = new QTech.Component.ExDateTimePicker();
            this.exLabel2 = new QTech.Component.ExLabel();
            this.exLabel3 = new QTech.Component.ExLabel();
            this.dtpTo = new QTech.Component.ExDateTimePicker();
            this.dgv2 = new QTech.Component.ExDataGridView();
            this.colOrder2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFromTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPercent2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayOutLabelRemoveAdd2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblRemove2 = new System.Windows.Forms.LinkLabel();
            this.lblAdd2 = new System.Windows.Forms.LinkLabel();
            this.gbTotal_ = new System.Windows.Forms.GroupBox();
            this.gbProduct_ = new System.Windows.Forms.GroupBox();
            this.container.SuspendLayout();
            this.exPanel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.flowLayOutLabelRemoveAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
            this.flowLayOutLabelRemoveAdd2.SuspendLayout();
            this.gbTotal_.SuspendLayout();
            this.gbProduct_.SuspendLayout();
            this.SuspendLayout();
            // 
            // digheader
            // 
            this.digheader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(85)))), ((int)(((byte)(117)))));
            this.digheader.Size = new System.Drawing.Size(731, 20);
            // 
            // container
            // 
            this.container.Controls.Add(this.gbProduct_);
            this.container.Controls.Add(this.gbTotal_);
            this.container.Controls.Add(this.exLabel3);
            this.container.Controls.Add(this.dtpTo);
            this.container.Controls.Add(this.exLabel2);
            this.container.Controls.Add(this.dtpFrom);
            this.container.Controls.Add(this.cboDiscountType);
            this.container.Controls.Add(this.lblCategory);
            this.container.Controls.Add(this.exPanel1);
            this.container.Controls.Add(this.lblNote);
            this.container.Controls.Add(this.txtNote);
            this.container.Controls.Add(this.lblName);
            this.container.Controls.Add(this.txtName);
            this.container.Size = new System.Drawing.Size(731, 543);
            this.container.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.ForeColor = System.Drawing.SystemColors.Control;
            this.lblName.Location = new System.Drawing.Point(32, 24);
            this.lblName.Name = "lblName";
            this.lblName.Required = true;
            this.lblName.Size = new System.Drawing.Size(43, 19);
            this.lblName.TabIndex = 15;
            this.lblName.Text = "ឈ្មោះ";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(137, 19);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 28);
            this.txtName.TabIndex = 0;
            // 
            // exPanel1
            // 
            this.exPanel1.BackColor = System.Drawing.Color.Transparent;
            this.exPanel1.Controls.Add(this.flowLayoutPanel3);
            this.exPanel1.Controls.Add(this.flowLayoutPanel2);
            this.exPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.exPanel1.Location = new System.Drawing.Point(1, 506);
            this.exPanel1.Name = "exPanel1";
            this.exPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.exPanel1.Size = new System.Drawing.Size(729, 36);
            this.exPanel1.TabIndex = 25;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.btnChangeLog);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(2, 2);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(229, 32);
            this.flowLayoutPanel3.TabIndex = 3;
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
            this.btnChangeLog.Size = new System.Drawing.Size(86, 27);
            this.btnChangeLog.TabIndex = 0;
            this.btnChangeLog.Text = "ប្រវត្តកែប្រែ";
            this.btnChangeLog.UseVisualStyleBackColor = true;
            this.btnChangeLog.Click += new System.EventHandler(this.btnChangeLog_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnClose);
            this.flowLayoutPanel2.Controls.Add(this.btnSave);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(2, 2);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(725, 32);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Ivory;
            this.btnClose.DefaultImage = null;
            this.btnClose.Executing = false;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(624, 3);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnClose.ShortcutText = null;
            this.btnClose.Size = new System.Drawing.Size(99, 27);
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
            this.btnSave.Location = new System.Drawing.Point(521, 3);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnSave.ShortcutText = null;
            this.btnSave.Size = new System.Drawing.Size(99, 27);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "រក្សាទុក";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.ForeColor = System.Drawing.SystemColors.Control;
            this.lblCategory.Location = new System.Drawing.Point(32, 56);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Required = true;
            this.lblCategory.Size = new System.Drawing.Size(47, 19);
            this.lblCategory.TabIndex = 27;
            this.lblCategory.Text = "ប្រភេទ";
            // 
            // dgv1
            // 
            this.dgv1.AllowEnterToNextCell = false;
            this.dgv1.AllowRowNotFound = true;
            this.dgv1.AllowRowNumber = false;
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgv1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv1.BackgroundColor = System.Drawing.Color.White;
            this.dgv1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrder,
            this.colProduct,
            this.colPercent});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Fasthand", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(205)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv1.EnableHeadersVisualStyles = false;
            this.dgv1.Executing = false;
            this.dgv1.Location = new System.Drawing.Point(3, 37);
            this.dgv1.MultiSelect = false;
            this.dgv1.Name = "dgv1";
            this.dgv1.Paging = null;
            this.dgv1.ReadOnly = true;
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.RowTemplate.Height = 28;
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv1.Size = new System.Drawing.Size(270, 325);
            this.dgv1.TabIndex = 0;
            // 
            // colOrder
            // 
            this.colOrder.HeaderText = "Order";
            this.colOrder.Name = "colOrder";
            this.colOrder.ReadOnly = true;
            this.colOrder.Visible = false;
            // 
            // colProduct
            // 
            this.colProduct.Choose = null;
            this.colProduct.CustomSearchForm = null;
            this.colProduct.DataSourceFn = null;
            this.colProduct.FillWeight = 120F;
            this.colProduct.HeaderText = "ទំនិញ";
            this.colProduct.Name = "colProduct";
            this.colProduct.ReadOnly = true;
            this.colProduct.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colProduct.SearchParamFn = null;
            this.colProduct.ShowAll = false;
            this.colProduct.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colProduct.TextAll = null;
            this.colProduct.Width = 200;
            // 
            // colPercent
            // 
            this.colPercent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.colPercent.DefaultCellStyle = dataGridViewCellStyle2;
            this.colPercent.HeaderText = "ភារយ";
            this.colPercent.Name = "colPercent";
            this.colPercent.ReadOnly = true;
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(137, 82);
            this.txtNote.Margin = new System.Windows.Forms.Padding(2);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(569, 28);
            this.txtNote.TabIndex = 4;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.ForeColor = System.Drawing.SystemColors.Control;
            this.lblNote.Location = new System.Drawing.Point(32, 88);
            this.lblNote.Name = "lblNote";
            this.lblNote.Required = false;
            this.lblNote.Size = new System.Drawing.Size(42, 19);
            this.lblNote.TabIndex = 24;
            this.lblNote.Text = "ចំណាំ";
            // 
            // flowLayOutLabelRemoveAdd
            // 
            this.flowLayOutLabelRemoveAdd.Controls.Add(this.lblRemove);
            this.flowLayOutLabelRemoveAdd.Controls.Add(this.lblAdd);
            this.flowLayOutLabelRemoveAdd.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayOutLabelRemoveAdd.Location = new System.Drawing.Point(178, 15);
            this.flowLayOutLabelRemoveAdd.Name = "flowLayOutLabelRemoveAdd";
            this.flowLayOutLabelRemoveAdd.Size = new System.Drawing.Size(95, 19);
            this.flowLayOutLabelRemoveAdd.TabIndex = 37;
            // 
            // lblRemove
            // 
            this.lblRemove.AutoSize = true;
            this.lblRemove.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblRemove.Location = new System.Drawing.Point(60, 0);
            this.lblRemove.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblRemove.Name = "lblRemove";
            this.lblRemove.Size = new System.Drawing.Size(32, 19);
            this.lblRemove.TabIndex = 1;
            this.lblRemove.TabStop = true;
            this.lblRemove.Text = "លុប";
            this.lblRemove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblRemove_LinkClicked);
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblAdd.Location = new System.Drawing.Point(17, 0);
            this.lblAdd.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(43, 19);
            this.lblAdd.TabIndex = 0;
            this.lblAdd.TabStop = true;
            this.lblAdd.Text = "បន្ថែម";
            this.lblAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAdd_LinkClicked);
            // 
            // cboDiscountType
            // 
            this.cboDiscountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDiscountType.FormattingEnabled = true;
            this.cboDiscountType.Location = new System.Drawing.Point(137, 51);
            this.cboDiscountType.Name = "cboDiscountType";
            this.cboDiscountType.Size = new System.Drawing.Size(199, 27);
            this.cboDiscountType.TabIndex = 1;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(507, 19);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(200, 28);
            this.dtpFrom.TabIndex = 2;
            // 
            // exLabel2
            // 
            this.exLabel2.AutoSize = true;
            this.exLabel2.ForeColor = System.Drawing.SystemColors.Control;
            this.exLabel2.Location = new System.Drawing.Point(404, 24);
            this.exLabel2.Name = "exLabel2";
            this.exLabel2.Required = true;
            this.exLabel2.Size = new System.Drawing.Size(45, 19);
            this.exLabel2.TabIndex = 40;
            this.exLabel2.Text = "ចាប់ពី";
            // 
            // exLabel3
            // 
            this.exLabel3.AutoSize = true;
            this.exLabel3.ForeColor = System.Drawing.SystemColors.Control;
            this.exLabel3.Location = new System.Drawing.Point(404, 56);
            this.exLabel3.Name = "exLabel3";
            this.exLabel3.Required = true;
            this.exLabel3.Size = new System.Drawing.Size(34, 19);
            this.exLabel3.TabIndex = 42;
            this.exLabel3.Text = "ដល់";
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(507, 51);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(200, 28);
            this.dtpTo.TabIndex = 3;
            // 
            // dgv2
            // 
            this.dgv2.AllowEnterToNextCell = false;
            this.dgv2.AllowRowNotFound = true;
            this.dgv2.AllowRowNumber = false;
            this.dgv2.AllowUserToAddRows = false;
            this.dgv2.AllowUserToDeleteRows = false;
            this.dgv2.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgv2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv2.BackgroundColor = System.Drawing.Color.White;
            this.dgv2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrder2,
            this.colFromTotal,
            this.colToTotal,
            this.colPercent2});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Fasthand", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(205)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv2.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgv2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv2.EnableHeadersVisualStyles = false;
            this.dgv2.Executing = false;
            this.dgv2.Location = new System.Drawing.Point(3, 34);
            this.dgv2.MultiSelect = false;
            this.dgv2.Name = "dgv2";
            this.dgv2.Paging = null;
            this.dgv2.ReadOnly = true;
            this.dgv2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv2.RowHeadersVisible = false;
            this.dgv2.RowTemplate.Height = 28;
            this.dgv2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv2.Size = new System.Drawing.Size(379, 328);
            this.dgv2.TabIndex = 0;
            // 
            // colOrder2
            // 
            this.colOrder2.HeaderText = "Order";
            this.colOrder2.Name = "colOrder2";
            this.colOrder2.ReadOnly = true;
            this.colOrder2.Visible = false;
            // 
            // colFromTotal
            // 
            this.colFromTotal.HeaderText = "តម្លៃសរុបចាប់ពី";
            this.colFromTotal.Name = "colFromTotal";
            this.colFromTotal.ReadOnly = true;
            this.colFromTotal.Width = 150;
            // 
            // colToTotal
            // 
            this.colToTotal.HeaderText = "ដល់";
            this.colToTotal.Name = "colToTotal";
            this.colToTotal.ReadOnly = true;
            this.colToTotal.Width = 150;
            // 
            // colPercent2
            // 
            this.colPercent2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.colPercent2.DefaultCellStyle = dataGridViewCellStyle5;
            this.colPercent2.HeaderText = "ភារយ";
            this.colPercent2.Name = "colPercent2";
            this.colPercent2.ReadOnly = true;
            // 
            // flowLayOutLabelRemoveAdd2
            // 
            this.flowLayOutLabelRemoveAdd2.Controls.Add(this.lblRemove2);
            this.flowLayOutLabelRemoveAdd2.Controls.Add(this.lblAdd2);
            this.flowLayOutLabelRemoveAdd2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayOutLabelRemoveAdd2.Location = new System.Drawing.Point(284, 15);
            this.flowLayOutLabelRemoveAdd2.Name = "flowLayOutLabelRemoveAdd2";
            this.flowLayOutLabelRemoveAdd2.Size = new System.Drawing.Size(95, 19);
            this.flowLayOutLabelRemoveAdd2.TabIndex = 45;
            // 
            // lblRemove2
            // 
            this.lblRemove2.AutoSize = true;
            this.lblRemove2.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblRemove2.Location = new System.Drawing.Point(60, 0);
            this.lblRemove2.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblRemove2.Name = "lblRemove2";
            this.lblRemove2.Size = new System.Drawing.Size(32, 19);
            this.lblRemove2.TabIndex = 1;
            this.lblRemove2.TabStop = true;
            this.lblRemove2.Text = "លុប";
            this.lblRemove2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblRemove2_LinkClicked);
            // 
            // lblAdd2
            // 
            this.lblAdd2.AutoSize = true;
            this.lblAdd2.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblAdd2.Location = new System.Drawing.Point(17, 0);
            this.lblAdd2.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblAdd2.Name = "lblAdd2";
            this.lblAdd2.Size = new System.Drawing.Size(43, 19);
            this.lblAdd2.TabIndex = 0;
            this.lblAdd2.TabStop = true;
            this.lblAdd2.Text = "បន្ថែម";
            this.lblAdd2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAdd2_LinkClicked);
            // 
            // gbTotal_
            // 
            this.gbTotal_.Controls.Add(this.dgv2);
            this.gbTotal_.Controls.Add(this.flowLayOutLabelRemoveAdd2);
            this.gbTotal_.Location = new System.Drawing.Point(321, 121);
            this.gbTotal_.Name = "gbTotal_";
            this.gbTotal_.Size = new System.Drawing.Size(385, 365);
            this.gbTotal_.TabIndex = 46;
            this.gbTotal_.TabStop = false;
            this.gbTotal_.Text = "បញ្ចុះតម្លៃតាមតម្លៃទិញសរុប";
            // 
            // gbProduct_
            // 
            this.gbProduct_.Controls.Add(this.dgv1);
            this.gbProduct_.Controls.Add(this.flowLayOutLabelRemoveAdd);
            this.gbProduct_.Location = new System.Drawing.Point(26, 121);
            this.gbProduct_.Name = "gbProduct_";
            this.gbProduct_.Size = new System.Drawing.Size(276, 365);
            this.gbProduct_.TabIndex = 47;
            this.gbProduct_.TabStop = false;
            this.gbProduct_.Text = "បញ្ចុះតម្លៃតាមមុខទំនិញ";
            // 
            // frmDiscount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 563);
            this.Font = new System.Drawing.Font("Fasthand", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmDiscount";
            this.Text = "frmEmployee";
            this.container.ResumeLayout(false);
            this.container.PerformLayout();
            this.exPanel1.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.flowLayOutLabelRemoveAdd.ResumeLayout(false);
            this.flowLayOutLabelRemoveAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            this.flowLayOutLabelRemoveAdd2.ResumeLayout(false);
            this.flowLayOutLabelRemoveAdd2.PerformLayout();
            this.gbTotal_.ResumeLayout(false);
            this.gbProduct_.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Component.ExLabel lblName;
        private System.Windows.Forms.TextBox txtName;
        private Component.Components.ExPanel exPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private Component.ExButtonLoading btnClose;
        private Component.ExButtonLoading btnSave;
        private Component.ExLabel lblCategory;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private Component.ExButtonLoading btnChangeLog;
        private Component.ExDataGridView dgv1;
        private Component.ExLabel lblNote;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.FlowLayoutPanel flowLayOutLabelRemoveAdd;
        private System.Windows.Forms.LinkLabel lblRemove;
        private System.Windows.Forms.LinkLabel lblAdd;
        private System.Windows.Forms.ComboBox cboDiscountType;
        private Component.ExLabel exLabel3;
        private Component.ExDateTimePicker dtpTo;
        private Component.ExLabel exLabel2;
        private Component.ExDateTimePicker dtpFrom;
        private Component.ExDataGridView dgv2;
        private System.Windows.Forms.FlowLayoutPanel flowLayOutLabelRemoveAdd2;
        private System.Windows.Forms.LinkLabel lblRemove2;
        private System.Windows.Forms.LinkLabel lblAdd2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrder2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFromTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPercent2;
        private System.Windows.Forms.GroupBox gbTotal_;
        private System.Windows.Forms.GroupBox gbProduct_;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrder;
        private Component.ExSearchComboColumn colProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPercent;
    }
}