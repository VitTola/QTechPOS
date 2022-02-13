namespace QTech.Forms
{
    partial class frmSale
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.flowLayOutLabelRemoveAdd = new System.Windows.Forms.FlowLayoutPanel();
            this.lblRemove = new System.Windows.Forms.LinkLabel();
            this.lblAdd = new System.Windows.Forms.LinkLabel();
            this.dgv = new QTech.Component.ExDataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSaleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductId = new QTech.Component.ExSearchComboColumn();
            this.colScale_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQauntity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exLabel2 = new QTech.Component.ExLabel();
            this.exPanel1 = new QTech.Component.Components.ExPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPrint = new QTech.Component.ExButtonLoading();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new QTech.Component.ExButtonLoading();
            this.btnSave = new QTech.Component.ExButtonLoading();
            this.lblInvoiceNo = new QTech.Component.ExLabel();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.lblCustomer_ = new QTech.Component.ExLabel();
            this.lblTotalAmount = new QTech.Component.ExLabel();
            this.cboCustomer = new QTech.Component.ExSearchCombo();
            this.pnlExpect = new System.Windows.Forms.Panel();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblCur2 = new System.Windows.Forms.Label();
            this.lblExpense_ = new QTech.Component.ExLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtExpense = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabCustomer_ = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.exLabel3 = new QTech.Component.ExLabel();
            this.dtpSaleDate = new QTech.Component.ExDateTimePicker();
            this.lblSaleDate_ = new QTech.Component.ExLabel();
            this.tabGeneral_ = new System.Windows.Forms.TabPage();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.exLabel4 = new QTech.Component.ExLabel();
            this.exLabel1 = new QTech.Component.ExLabel();
            this.dtpSaleDate_ = new QTech.Component.ExDateTimePicker();
            this.lblPhone = new QTech.Component.ExLabel();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtInvoiceNo1 = new System.Windows.Forms.TextBox();
            this.lblInvoiceNo1 = new QTech.Component.ExLabel();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.lblCustomer1 = new QTech.Component.ExLabel();
            this.container.SuspendLayout();
            this.flowLayOutLabelRemoveAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.exPanel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.pnlExpect.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabCustomer_.SuspendLayout();
            this.tabGeneral_.SuspendLayout();
            this.SuspendLayout();
            // 
            // digheader
            // 
            this.digheader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.digheader.Margin = new System.Windows.Forms.Padding(4);
            this.digheader.Size = new System.Drawing.Size(877, 20);
            // 
            // container
            // 
            this.container.Controls.Add(this.tabMain);
            this.container.Controls.Add(this.panel1);
            this.container.Controls.Add(this.lblExpense_);
            this.container.Controls.Add(this.pnlExpect);
            this.container.Controls.Add(this.lblTotalAmount);
            this.container.Controls.Add(this.exPanel1);
            this.container.Controls.Add(this.exLabel2);
            this.container.Controls.Add(this.dgv);
            this.container.Controls.Add(this.flowLayOutLabelRemoveAdd);
            this.container.Size = new System.Drawing.Size(877, 746);
            // 
            // flowLayOutLabelRemoveAdd
            // 
            this.flowLayOutLabelRemoveAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayOutLabelRemoveAdd.Controls.Add(this.lblRemove);
            this.flowLayOutLabelRemoveAdd.Controls.Add(this.lblAdd);
            this.flowLayOutLabelRemoveAdd.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayOutLabelRemoveAdd.Location = new System.Drawing.Point(703, 231);
            this.flowLayOutLabelRemoveAdd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.flowLayOutLabelRemoveAdd.Name = "flowLayOutLabelRemoveAdd";
            this.flowLayOutLabelRemoveAdd.Size = new System.Drawing.Size(132, 19);
            this.flowLayOutLabelRemoveAdd.TabIndex = 3;
            // 
            // lblRemove
            // 
            this.lblRemove.AutoSize = true;
            this.lblRemove.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblRemove.Location = new System.Drawing.Point(96, 0);
            this.lblRemove.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.lblRemove.Name = "lblRemove";
            this.lblRemove.Size = new System.Drawing.Size(32, 19);
            this.lblRemove.TabIndex = 1;
            this.lblRemove.TabStop = true;
            this.lblRemove.Text = "លុប";
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblAdd.Location = new System.Drawing.Point(53, 0);
            this.lblAdd.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(43, 19);
            this.lblAdd.TabIndex = 0;
            this.lblAdd.TabStop = true;
            this.lblAdd.Text = "បន្ថែម";
            // 
            // dgv
            // 
            this.dgv.AllowEnterToNextCell = false;
            this.dgv.AllowRowNotFound = true;
            this.dgv.AllowRowNumber = false;
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Khmer OS System", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colSaleId,
            this.colProductId,
            this.colScale_,
            this.colQauntity,
            this.colUnitPrice,
            this.colTotal});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Khmer OS System", 8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(205)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.Executing = false;
            this.dgv.Font = new System.Drawing.Font("Khmer OS System", 8F);
            this.dgv.Location = new System.Drawing.Point(40, 259);
            this.dgv.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.Paging = null;
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 28;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(795, 438);
            this.dgv.TabIndex = 0;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colSaleId
            // 
            this.colSaleId.HeaderText = "SaleId";
            this.colSaleId.Name = "colSaleId";
            this.colSaleId.ReadOnly = true;
            this.colSaleId.Visible = false;
            // 
            // colProductId
            // 
            this.colProductId.Choose = null;
            this.colProductId.CustomSearchForm = null;
            this.colProductId.DataPropertyName = "ProductId";
            this.colProductId.DataSourceFn = null;
            this.colProductId.HeaderText = "ឈ្មោះទំនិញ";
            this.colProductId.Name = "colProductId";
            this.colProductId.ReadOnly = true;
            this.colProductId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colProductId.SearchParamFn = null;
            this.colProductId.ShowAll = false;
            this.colProductId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colProductId.TextAll = null;
            this.colProductId.Width = 250;
            // 
            // colScale_
            // 
            this.colScale_.HeaderText = "ខ្នាត";
            this.colScale_.Name = "colScale_";
            this.colScale_.ReadOnly = true;
            this.colScale_.Width = 200;
            // 
            // colQauntity
            // 
            this.colQauntity.DataPropertyName = "Qauntity";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colQauntity.DefaultCellStyle = dataGridViewCellStyle3;
            this.colQauntity.HeaderText = "បរិមាណ";
            this.colQauntity.Name = "colQauntity";
            this.colQauntity.ReadOnly = true;
            this.colQauntity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colQauntity.Width = 150;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.DataPropertyName = "UnitPrice";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.colUnitPrice.DefaultCellStyle = dataGridViewCellStyle4;
            this.colUnitPrice.HeaderText = "តម្ថៃឯកតា";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.ReadOnly = true;
            this.colUnitPrice.Width = 150;
            // 
            // colTotal
            // 
            this.colTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTotal.DataPropertyName = "Total";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colTotal.DefaultCellStyle = dataGridViewCellStyle5;
            this.colTotal.HeaderText = "សរុប";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            // 
            // exLabel2
            // 
            this.exLabel2.AutoSize = true;
            this.exLabel2.Font = new System.Drawing.Font("Fasthand", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.exLabel2.Location = new System.Drawing.Point(40, 231);
            this.exLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.exLabel2.Name = "exLabel2";
            this.exLabel2.Required = true;
            this.exLabel2.Size = new System.Drawing.Size(102, 19);
            this.exLabel2.TabIndex = 11;
            this.exLabel2.Text = "មុខទំនិញលម្អិត";
            // 
            // exPanel1
            // 
            this.exPanel1.BackColor = System.Drawing.Color.Transparent;
            this.exPanel1.Controls.Add(this.flowLayoutPanel3);
            this.exPanel1.Controls.Add(this.flowLayoutPanel2);
            this.exPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.exPanel1.Location = new System.Drawing.Point(1, 709);
            this.exPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.exPanel1.Name = "exPanel1";
            this.exPanel1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.exPanel1.Size = new System.Drawing.Size(875, 36);
            this.exPanel1.TabIndex = 17;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.btnPrint);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 2);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(701, 32);
            this.flowLayoutPanel3.TabIndex = 3;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Ivory;
            this.btnPrint.DefaultImage = null;
            this.btnPrint.Executing = false;
            this.btnPrint.Font = new System.Drawing.Font("Khmer OS System", 8F);
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(3, 3);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnPrint.ShortcutText = "P";
            this.btnPrint.Size = new System.Drawing.Size(119, 27);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "បោះពុម្ភ";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnClose);
            this.flowLayoutPanel2.Controls.Add(this.btnSave);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(265, 2);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(607, 32);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Ivory;
            this.btnClose.DefaultImage = null;
            this.btnClose.Executing = false;
            this.btnClose.Location = new System.Drawing.Point(504, 3);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnClose.ShortcutText = null;
            this.btnClose.Size = new System.Drawing.Size(100, 27);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "បិទ";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Ivory;
            this.btnSave.DefaultImage = null;
            this.btnSave.Executing = false;
            this.btnSave.Location = new System.Drawing.Point(398, 3);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnSave.ShortcutText = null;
            this.btnSave.Size = new System.Drawing.Size(100, 27);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "រក្សាទុក";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.AutoSize = true;
            this.lblInvoiceNo.Location = new System.Drawing.Point(38, 30);
            this.lblInvoiceNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.Required = false;
            this.lblInvoiceNo.Size = new System.Drawing.Size(88, 19);
            this.lblInvoiceNo.TabIndex = 19;
            this.lblInvoiceNo.Text = "លេខវិក្កយបត្រ";
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Location = new System.Drawing.Point(197, 26);
            this.txtInvoiceNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.ReadOnly = true;
            this.txtInvoiceNo.Size = new System.Drawing.Size(200, 28);
            this.txtInvoiceNo.TabIndex = 3;
            // 
            // lblCustomer_
            // 
            this.lblCustomer_.AutoSize = true;
            this.lblCustomer_.Location = new System.Drawing.Point(38, 62);
            this.lblCustomer_.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomer_.Name = "lblCustomer_";
            this.lblCustomer_.Required = true;
            this.lblCustomer_.Size = new System.Drawing.Size(59, 19);
            this.lblCustomer_.TabIndex = 22;
            this.lblCustomer_.Text = "អតិថិជន";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Fasthand", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(476, 672);
            this.lblTotalAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Required = false;
            this.lblTotalAmount.Size = new System.Drawing.Size(91, 19);
            this.lblTotalAmount.TabIndex = 24;
            this.lblTotalAmount.Text = "សរុបទឹកប្រាក់";
            // 
            // cboCustomer
            // 
            this.cboCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(250)))));
            this.cboCustomer.Choose = "";
            this.cboCustomer.CustomSearchForm = null;
            this.cboCustomer.DataSourceFn = null;
            this.cboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.IsGirdViewColumn = false;
            this.cboCustomer.LoadAll = true;
            this.cboCustomer.Location = new System.Drawing.Point(197, 58);
            this.cboCustomer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.SearchParamFn = null;
            this.cboCustomer.SelectedItems = null;
            this.cboCustomer.SelectedObject = null;
            this.cboCustomer.ShowAll = false;
            this.cboCustomer.Size = new System.Drawing.Size(200, 27);
            this.cboCustomer.TabIndex = 0;
            this.cboCustomer.TextAll = "";
            // 
            // pnlExpect
            // 
            this.pnlExpect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlExpect.BackColor = System.Drawing.SystemColors.Control;
            this.pnlExpect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlExpect.Controls.Add(this.txtTotal);
            this.pnlExpect.Controls.Add(this.lblCur2);
            this.pnlExpect.Location = new System.Drawing.Point(635, 668);
            this.pnlExpect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlExpect.Name = "pnlExpect";
            this.pnlExpect.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.pnlExpect.Size = new System.Drawing.Size(200, 27);
            this.pnlExpect.TabIndex = 29;
            // 
            // txtTotal
            // 
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(0, 2);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(154, 19);
            this.txtTotal.TabIndex = 0;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCur2
            // 
            this.lblCur2.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblCur2.Location = new System.Drawing.Point(154, 2);
            this.lblCur2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCur2.Name = "lblCur2";
            this.lblCur2.Size = new System.Drawing.Size(44, 23);
            this.lblCur2.TabIndex = 1;
            this.lblCur2.Text = "USD";
            this.lblCur2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblExpense_
            // 
            this.lblExpense_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblExpense_.AutoSize = true;
            this.lblExpense_.Location = new System.Drawing.Point(44, 672);
            this.lblExpense_.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExpense_.Name = "lblExpense_";
            this.lblExpense_.Required = false;
            this.lblExpense_.Size = new System.Drawing.Size(91, 19);
            this.lblExpense_.TabIndex = 31;
            this.lblExpense_.Text = "ចំណាយផ្សេងៗ";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtExpense);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(203, 668);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panel1.Size = new System.Drawing.Size(200, 27);
            this.panel1.TabIndex = 30;
            // 
            // txtExpense
            // 
            this.txtExpense.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtExpense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtExpense.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExpense.Location = new System.Drawing.Point(0, 2);
            this.txtExpense.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.txtExpense.Name = "txtExpense";
            this.txtExpense.Size = new System.Drawing.Size(154, 19);
            this.txtExpense.TabIndex = 0;
            this.txtExpense.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(154, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "USD";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabCustomer_);
            this.tabMain.Controls.Add(this.tabGeneral_);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabMain.Location = new System.Drawing.Point(1, 1);
            this.tabMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(875, 201);
            this.tabMain.TabIndex = 0;
            // 
            // tabCustomer_
            // 
            this.tabCustomer_.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.tabCustomer_.Controls.Add(this.textBox1);
            this.tabCustomer_.Controls.Add(this.exLabel3);
            this.tabCustomer_.Controls.Add(this.dtpSaleDate);
            this.tabCustomer_.Controls.Add(this.lblSaleDate_);
            this.tabCustomer_.Controls.Add(this.cboCustomer);
            this.tabCustomer_.Controls.Add(this.txtInvoiceNo);
            this.tabCustomer_.Controls.Add(this.lblInvoiceNo);
            this.tabCustomer_.Controls.Add(this.lblCustomer_);
            this.tabCustomer_.Location = new System.Drawing.Point(4, 28);
            this.tabCustomer_.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabCustomer_.Name = "tabCustomer_";
            this.tabCustomer_.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabCustomer_.Size = new System.Drawing.Size(867, 169);
            this.tabCustomer_.TabIndex = 0;
            this.tabCustomer_.Text = "អតិថិជនប្រចាំ";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(197, 90);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(633, 60);
            this.textBox1.TabIndex = 47;
            // 
            // exLabel3
            // 
            this.exLabel3.AutoSize = true;
            this.exLabel3.Location = new System.Drawing.Point(38, 94);
            this.exLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.exLabel3.Name = "exLabel3";
            this.exLabel3.Required = false;
            this.exLabel3.Size = new System.Drawing.Size(42, 19);
            this.exLabel3.TabIndex = 48;
            this.exLabel3.Text = "ចំណាំ";
            // 
            // dtpSaleDate
            // 
            this.dtpSaleDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpSaleDate.Location = new System.Drawing.Point(630, 22);
            this.dtpSaleDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtpSaleDate.Name = "dtpSaleDate";
            this.dtpSaleDate.Size = new System.Drawing.Size(200, 28);
            this.dtpSaleDate.TabIndex = 45;
            // 
            // lblSaleDate_
            // 
            this.lblSaleDate_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSaleDate_.AutoSize = true;
            this.lblSaleDate_.Location = new System.Drawing.Point(471, 26);
            this.lblSaleDate_.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSaleDate_.Name = "lblSaleDate_";
            this.lblSaleDate_.Required = true;
            this.lblSaleDate_.Size = new System.Drawing.Size(48, 19);
            this.lblSaleDate_.TabIndex = 46;
            this.lblSaleDate_.Text = "ថ្ងៃលក់";
            // 
            // tabGeneral_
            // 
            this.tabGeneral_.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.tabGeneral_.Controls.Add(this.textBox2);
            this.tabGeneral_.Controls.Add(this.exLabel4);
            this.tabGeneral_.Controls.Add(this.exLabel1);
            this.tabGeneral_.Controls.Add(this.dtpSaleDate_);
            this.tabGeneral_.Controls.Add(this.lblPhone);
            this.tabGeneral_.Controls.Add(this.txtPhone);
            this.tabGeneral_.Controls.Add(this.txtInvoiceNo1);
            this.tabGeneral_.Controls.Add(this.lblInvoiceNo1);
            this.tabGeneral_.Controls.Add(this.txtCustomer);
            this.tabGeneral_.Controls.Add(this.lblCustomer1);
            this.tabGeneral_.Location = new System.Drawing.Point(4, 28);
            this.tabGeneral_.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabGeneral_.Name = "tabGeneral_";
            this.tabGeneral_.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabGeneral_.Size = new System.Drawing.Size(867, 169);
            this.tabGeneral_.TabIndex = 1;
            this.tabGeneral_.Text = "អតិថិជនទូទៅ";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(199, 86);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(1490, 60);
            this.textBox2.TabIndex = 49;
            // 
            // exLabel4
            // 
            this.exLabel4.AutoSize = true;
            this.exLabel4.Location = new System.Drawing.Point(40, 90);
            this.exLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.exLabel4.Name = "exLabel4";
            this.exLabel4.Required = false;
            this.exLabel4.Size = new System.Drawing.Size(42, 19);
            this.exLabel4.TabIndex = 50;
            this.exLabel4.Text = "ចំណាំ";
            // 
            // exLabel1
            // 
            this.exLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exLabel1.AutoSize = true;
            this.exLabel1.Location = new System.Drawing.Point(1374, 27);
            this.exLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.exLabel1.Name = "exLabel1";
            this.exLabel1.Required = true;
            this.exLabel1.Size = new System.Drawing.Size(48, 19);
            this.exLabel1.TabIndex = 47;
            this.exLabel1.Text = "ថ្ងៃលក់";
            // 
            // dtpSaleDate_
            // 
            this.dtpSaleDate_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpSaleDate_.Location = new System.Drawing.Point(1490, 22);
            this.dtpSaleDate_.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtpSaleDate_.Name = "dtpSaleDate_";
            this.dtpSaleDate_.Size = new System.Drawing.Size(200, 28);
            this.dtpSaleDate_.TabIndex = 46;
            // 
            // lblPhone
            // 
            this.lblPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(1374, 58);
            this.lblPhone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Required = true;
            this.lblPhone.Size = new System.Drawing.Size(69, 19);
            this.lblPhone.TabIndex = 25;
            this.lblPhone.Text = "លេខទូស័ព្ទ";
            // 
            // txtPhone
            // 
            this.txtPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhone.Location = new System.Drawing.Point(1490, 53);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(200, 28);
            this.txtPhone.TabIndex = 24;
            // 
            // txtInvoiceNo1
            // 
            this.txtInvoiceNo1.Location = new System.Drawing.Point(199, 22);
            this.txtInvoiceNo1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtInvoiceNo1.Name = "txtInvoiceNo1";
            this.txtInvoiceNo1.Size = new System.Drawing.Size(200, 28);
            this.txtInvoiceNo1.TabIndex = 22;
            // 
            // lblInvoiceNo1
            // 
            this.lblInvoiceNo1.AutoSize = true;
            this.lblInvoiceNo1.Location = new System.Drawing.Point(40, 27);
            this.lblInvoiceNo1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInvoiceNo1.Name = "lblInvoiceNo1";
            this.lblInvoiceNo1.Required = true;
            this.lblInvoiceNo1.Size = new System.Drawing.Size(88, 19);
            this.lblInvoiceNo1.TabIndex = 23;
            this.lblInvoiceNo1.Text = "លេខវិក្កយបត្រ";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(199, 53);
            this.txtCustomer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(200, 28);
            this.txtCustomer.TabIndex = 20;
            // 
            // lblCustomer1
            // 
            this.lblCustomer1.AutoSize = true;
            this.lblCustomer1.Location = new System.Drawing.Point(40, 58);
            this.lblCustomer1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomer1.Name = "lblCustomer1";
            this.lblCustomer1.Required = true;
            this.lblCustomer1.Size = new System.Drawing.Size(90, 19);
            this.lblCustomer1.TabIndex = 21;
            this.lblCustomer1.Text = "ឈ្មោះអតិថិជន";
            // 
            // frmSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 766);
            this.Font = new System.Drawing.Font("Fasthand", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmSale";
            this.Text = "frmEmployeePay";
            this.container.ResumeLayout(false);
            this.container.PerformLayout();
            this.flowLayOutLabelRemoveAdd.ResumeLayout(false);
            this.flowLayOutLabelRemoveAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.exPanel1.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.pnlExpect.ResumeLayout(false);
            this.pnlExpect.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabCustomer_.ResumeLayout(false);
            this.tabCustomer_.PerformLayout();
            this.tabGeneral_.ResumeLayout(false);
            this.tabGeneral_.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    
        private Component.ExDataGridView dgv;
        private System.Windows.Forms.FlowLayoutPanel flowLayOutLabelRemoveAdd;
        private System.Windows.Forms.LinkLabel lblRemove;
        private System.Windows.Forms.LinkLabel lblAdd;
        private Component.ExLabel exLabel2;
        private Component.Components.ExPanel exPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private Component.ExButtonLoading btnClose;
        private Component.ExButtonLoading btnSave;
        private Component.ExLabel lblInvoiceNo;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private Component.ExLabel lblCustomer_;
        private Component.ExLabel lblTotalAmount;
        private Component.ExSearchCombo cboCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.Panel pnlExpect;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblCur2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private Component.ExButtonLoading btnPrint;
        private Component.ExLabel lblExpense_;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtExpense;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabCustomer_;
        private System.Windows.Forms.TabPage tabGeneral_;
        private System.Windows.Forms.TextBox txtInvoiceNo1;
        private Component.ExLabel lblInvoiceNo1;
        private System.Windows.Forms.TextBox txtCustomer;
        private Component.ExLabel lblCustomer1;
        private System.Windows.Forms.TextBox txtPhone;
        private Component.ExLabel lblPhone;
        private Component.ExDateTimePicker dtpSaleDate;
        private Component.ExLabel lblSaleDate_;
        private Component.ExDateTimePicker dtpSaleDate_;
        private Component.ExLabel exLabel1;
        private System.Windows.Forms.TextBox textBox1;
        private Component.ExLabel exLabel3;
        private System.Windows.Forms.TextBox textBox2;
        private Component.ExLabel exLabel4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaleId;
        private Component.ExSearchComboColumn colProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScale_;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQauntity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
    }
}