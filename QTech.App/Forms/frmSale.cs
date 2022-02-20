
using FastMember;
using QTech.Base;
using QTech.Base.BaseReport;
using QTech.Base.Enums;
using QTech.Base.Helpers;
using QTech.Base.Models;
using QTech.Base.SearchModels;
using QTech.Component;
using QTech.Component.Helpers;
using QTech.Db.Logics;
using QTech.ReportModels;
using QTech.Reports;
using Storm.CC.Report.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseReource = QTech.Base.Properties.Resources;
using EasyServer.Domain.Helpers;
using EDomain = EasyServer.Domain;

namespace QTech.Forms
{
    public partial class frmSale : ExDialog, IDialog
    {
        public Sale Model { get; set; }
        private decimal Total;
        //private List<RepoInvoice> invoices;
        //private List<RepoInvoiceDetail> invoiceDetails;
        private List<Category> categories;
        private List<Product> products;
        private List<ProductPrice> productPrices;
        public GeneralProcess Flag { get; set; }
        public frmSale(Sale model, GeneralProcess flag)
        {
            InitializeComponent();
            this.Model = model;
            this.Flag = flag;
            ResourceHelper.Register(QTech.Base.Properties.Resources.ResourceManager);
            this.ApplyResource();
            Read();
            Bind();
            this.SetTheme(this.Controls, null);
            InitEvent();
        }
        public void Bind()
        {
            cboCustomer.DataSourceFn = p => CustomerLogic.Instance.SearchAsync(p).OrderByDescending(x => x.RowDate).ToDropDownItemModelList();
            cboCustomer.SearchParamFn = () => new CustomerSearch();
            colProductId.DataSourceFn = p => ProductLogic.Instance.SearchAsync(p).OrderByDescending(x => x.RowDate).ToDropDownItemModelList();
            colProductId.SearchParamFn = () => new ProductSearch();
            colScale_.DataSourceFn = p => ScaleLogic.Instance.SearchAsync(p).OrderByDescending(x => x.RowDate).ToDropDownItemModelList();
            colScale_.SearchParamFn = () => new ScaleSearch() {
                ProductId = Parse.ToInt(dgv.CurrentRow.Cells[colProductId.Name].Value?.ToString() ?? "-1")
            };
        }
        public void InitEvent()
        {
            this.Text = Flag.GetTextDialog(Base.Properties.Resources.Sales);
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            txtInvoiceNo.RegisterEnglishInputWith(txtInvoiceNo1, txtCustomer, txtPhone);
            dgv.RegisterEnglishInputColumns(colQauntity);
            dgv.AllowRowNotFound = false;
            dgv.AllowUserToAddRows = dgv.AllowUserToDeleteRows = true;
            dgv.EditMode = DataGridViewEditMode.EditOnEnter;
            dgv.EditingControlShowing += dgv_EditingControlShowing;
            this.SetEnabled(Flag != GeneralProcess.Remove && Flag != GeneralProcess.View);
            dgv.EditingControlShowing += Dgv_EditingControlShowing;
            dgv.MouseClick += Dgv_MouseClick;
            dgv.EditColumnIcon(colProductId, colQauntity, colUnitPrice, colScale_);

            txtTotal.ReadOnly = true;
            cboCustomer.SelectedIndexChanged += CboCustomer_SelectedIndexChanged;
            this.Load += FrmSale_Load;
            this.MaximizeBox = true;
            lblPhone.Anchor = _lblSaleDate.Anchor = dtpSaleDate_.Anchor = txtPhone.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            txtNote2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtInvoiceNo.ReadOnly = txtInvoiceNo1.ReadOnly = true;

            if (Flag != GeneralProcess.Add)
            {
                tabMain.Controls.Remove(Model.SaleType == SaleType.Company ? tabGeneral_ : tabCustomer_);
            }
        }
        private void Dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.RowCount == 0)
            {
                return;
            }
            dgv.EndEdit();
            var unitPrice = Parse.ToDecimal(dgv.CurrentRow?.Cells[colUnitPrice.Name]?.Value?.ToString() ?? "0");
            var qty = Parse.ToDecimal(dgv.CurrentRow?.Cells[colQauntity.Name]?.Value?.ToString() ?? "0");
            if (unitPrice == 0 || qty == 0)
            {
                return;
            }

            dgv.CurrentRow.Cells[colTotal.Name].Value = (unitPrice * qty).ToString();
            CalculateTotal();
            dgv.BeginEdit(true);
        }
        private async void FrmSale_Load(object sender, EventArgs e)
        {
            var dummy = await this.RunAsync(() =>
            {
                categories = CategoryLogic.Instance.SearchAsync(new CategorySearch());
                products = ProductLogic.Instance.SearchAsync(new ProductSearch());
                productPrices = ProductPriceLogic.Instance.SearchAsync(new ProductPriceSearch());

                return products;
            });
        }
        private void Dgv_MouseClick(object sender, MouseEventArgs e)
        {
            if (tabMain.SelectedTab.Equals(tabGeneral_) && Flag != GeneralProcess.View)
            {
                dgv.ReadOnly = false;
            }
        }
        private void Dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (tabMain.SelectedTab.Equals(tabCustomer_))
            {
                if (string.IsNullOrEmpty(cboCustomer.Text))
                {
                    cboCustomer.ShowDropDown();
                }
                //if (dgv.CurrentRow.Index > 0)
                //{
                //    dgv.ReadOnly = true;
                //}
                //else
                //{
                //    dgv.ReadOnly = false;
                //}
            }
        }
        private bool firstLoad = true;
        private async void CboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            colTotal.ReadOnly = true;
            e.Control.RegisterEnglishInput();
            if (e.Control is ExSearchCombo cbo)
            {
                cbo.SelectedIndexChanged += Cbo_SelectedIndexChanged;
            }

            if (e.Control is TextBox txt)
            {
                txt.KeyPress += (o, ee) => { txt.validCurrency(sender, ee); };
                if (dgv.CurrentCell.ColumnIndex == colQauntity.Index)
                {
                    txt.Leave += txtQauntity_Leave;
                }
                else if (dgv.CurrentCell.ColumnIndex == colUnitPrice.Index)
                {
                    txt.Leave += Txt_Leave;
                }
            }
            dgv.CellValueChanged += Dgv_CellValueChanged;
        }
        private void Txt_Leave(object sender, EventArgs e)
        {
            txtQauntity_Leave(sender, e);
        }
        private void CalculateTotal()
        {
            Total = 0;
            foreach (DataGridViewRow row in dgv.Rows.OfType<DataGridViewRow>().Where(x => !x.IsNewRow))
            {
                if (string.IsNullOrEmpty(row.Cells[colTotal.Name]?.Value?.ToString() ?? "")) continue;
                Total += decimal.Parse(row.Cells[colTotal.Name]?.Value?.ToString());
            }

            txtTotal.Text = Total.ToString();
        }
        private void txtQauntity_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(dgv.CurrentCell.Value?.ToString() ?? ""))
            {
                return;
            }
            var unitPrice = decimal.Parse(dgv.CurrentRow?.Cells[colUnitPrice.Name].Value?.ToString() ?? "0");
            var qty = Parse.ToDecimal(dgv.CurrentRow?.Cells[colQauntity.Name]?.Value?.ToString() ?? "0");
            dgv.CurrentRow.Cells[colTotal.Name].Value = (unitPrice * qty).ToString();
            CalculateTotal();
            if (sender is TextBox txt)
            {
                txt.Leave -= txtQauntity_Leave;
            }
        }
        private  void Cbo_SelectedIndexChanged(object sender, EventArgs e)
            {
            if (!cboCustomer.IsSelected() && tabMain.SelectedTab.Equals(tabCustomer_))
            {
                return;
            }

            if (!string.IsNullOrEmpty(dgv.CurrentCell.Value?.ToString() ?? "") ||
                dgv.CurrentCell.ColumnIndex == colProductId.Index ||
                dgv.CurrentCell.ColumnIndex == colScale_.Index)
            {
                var _productId = int.Parse(dgv.CurrentRow.Cells[colProductId.Name].Value?.ToString());
                var _scaleId = int.Parse(dgv.CurrentRow.Cells[colScale_.Name].Value?.ToString());
                if (_productId != 0 && _scaleId != 0)
                {
                    dgv.CurrentRow.Cells[colUnitPrice.Name].Value = productPrices?.FirstOrDefault(x => x.ProductId == _productId && x.ScaleId == _scaleId)?.SalePrice;
                }
            }

        }
        DataGridViewCell Err = null;

        public bool InValid()
        {
            if (tabMain.SelectedTab.Equals(tabCustomer_))
            {
                if (!cboCustomer.IsSelected()
                    | !txtInvoiceNo.IsValidRequired(lblInvoiceNo.Text))
                {
                    return true;
                }
            }
            else
            {
                if (!txtCustomer.IsValidRequired(lblCustomer1.Text) | !txtInvoiceNo1.IsValidRequired(lblInvoiceNo1.Text))
                {
                    return true;
                }
            }

            if (!validSaleDetail())
            {
                return true;
            }

            return false;
        }
        private bool validSaleDetail()
        {
            var invalidCell = false;
            var rows = dgv.Rows.OfType<DataGridViewRow>().Where(x => x.Index != dgv.RowCount - 1);
            if (rows?.Any() != true)
            {
                MsgBox.ShowInformation(string.Format(BaseReource.MsgPleaseInputDataInTable_, BaseReource.SaleDetail));
                return false;
            }

            foreach (DataGridViewRow row in rows)
            {
                var cells = row.Cells.OfType<DataGridViewCell>().Where(x =>
                x.ColumnIndex == row.Cells[colProductId.Name].ColumnIndex || x.ColumnIndex == row.Cells[colQauntity.Name].ColumnIndex
                || x.ColumnIndex == row.Cells[colUnitPrice.Name].ColumnIndex).ToList();
                cells.ForEach(x =>
                {
                    if (x.Value == null)
                    {
                        x.ErrorText = BaseReource.MsgPleaseInputValue;
                        invalidCell = true;
                    }
                    else
                    {
                        x.ErrorText = string.Empty;
                    }
                });
            }
            if (invalidCell)
            {
                return false;
            }

            return true;
        }
        public async void Read()
        {
            if (Flag == GeneralProcess.Add)
            {
                txtInvoiceNo.Text = txtInvoiceNo1.Text = "លេខវិក័យប័ត្រថ្មី";
                return;
            }

            Customer cus = null;
            List<Product> products = null;
            List<Employee> drivers = null;
            var saleDetails = await this.RunAsync(() =>
            {
                return new List<SaleDetail>(); ;
            });

            //Read Sale
            if (Model?.SaleType == SaleType.Company)
            {
                txtInvoiceNo.Text = Model.InvoiceNo;
                txtTotal.Text = Model.Total.ToString();
            }
            else
            {
                txtTotal.Text = Model.Total.ToString();
                txtCustomer.Text = Model.CustomerName;
                txtInvoiceNo1.Text = Model.InvoiceNo;
                txtPhone.Text = Model.Phone;
                dtpSaleDate_.Value = Model.SaleDate;
            }

            //Read SaleDetail
            if (saleDetails?.Any() ?? false)
            {
                Model.SaleDetails = saleDetails;
                saleDetails.ForEach(x =>
                {
                    var row = newRow(false);
                    row.Cells[colId.Name].Value = x.Id;
                    row.Cells[colSaleId.Name].Value = Model.Id;
                    row.Cells[colQauntity.Name].Value = x.Quantity;
                    row.Cells[colTotal.Name].Value = x.Total;
                    var product = products?.FirstOrDefault(y => y.Id == x.ProductId) ?? new Product();
                    row.Cells[colTotal.Name].Value = x.Total;

                    if (products?.Any() ?? false)
                    {
                        var pro = products?.FirstOrDefault(f => f.Id == x.ProductId);
                        var lsProdut = new List<DropDownItemModel>()
                    {
                                new DropDownItemModel
                                {
                                    Id = pro.Id,
                                    Code = pro.Name,
                                    Name = pro.Name,
                                    DisplayText = pro.Name,
                                    ItemObject = pro,
                                }
                    };
                        row.Cells[colProductId.Name].Value = lsProdut;
                    }
                });
            }
        }
        private DataGridViewRow newRow(bool isFocus = false)
        {
            var row = dgv.Rows[dgv.Rows.Add()];
            row.Cells[colId.Name].Value = 0;
            if (isFocus)
            {
                dgv.Focus();
            }
            return row;
        }
        public async void Save()
        {
            if (Flag == GeneralProcess.View)
            {
                Close();
            }

            if (InValid()) { return; }
            Write();

            //check existing invoiceno
            if (tabMain.SelectedTab.Equals(tabCustomer_))
            {
                var existedInvoiceNo = SaleLogic.Instance.IsExistedInvoiceNo(Model);
                if (existedInvoiceNo)
                {
                    txtInvoiceNo.ShowValidation(string.Format(EDomain.Resources.MsgFieldExists, lblInvoiceNo.Text), TabAlignment.Left);
                    return;
                }
            }
            else
            {
                var existedInvoiceNo = SaleLogic.Instance.IsExistedInvoiceNo(Model);
                if (existedInvoiceNo)
                {
                    txtInvoiceNo1.ShowValidation(string.Format(EDomain.Resources.MsgFieldExists, lblInvoiceNo.Text), TabAlignment.Right);
                    return;
                }
            }

            var result = await btnSave.RunAsync(() =>
            {
                if (Flag == GeneralProcess.Add)
                {
                    return SaleLogic.Instance.AddAsync(Model);
                }
                else if (Flag == GeneralProcess.Update)
                {
                    return SaleLogic.Instance.UpdateAsync(Model);
                }
                else if (Flag == GeneralProcess.Remove)
                {
                    return SaleLogic.Instance.RemoveAsync(Model);
                }

                return null;
            });
            if (result != null)
            {
                Model = result;
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
        public void ViewChangeLog()
        {
            AuditTrailDialog.ShowChangeLog(Model);
        }
        public void Write()
        {
            if (tabMain.SelectedTab.Equals(tabCustomer_))
            {
                var customer = cboCustomer.SelectedObject.ItemObject as Customer;
                Model.InvoiceNo = txtInvoiceNo.Text;
                Model.SaleType = SaleType.Company;
                Model.SaleDate = dtpSaleDate.Value;
            }
            else
            {
                Model.CustomerName = txtCustomer.Text;
                Model.Phone = txtPhone.Text;
                Model.SaleType = SaleType.General;
                Model.InvoiceNo = txtInvoiceNo1.Text;
                Model.SaleDate = dtpSaleDate_.Value;
            }

            Model.Total = Parse.ToDecimal(!string.IsNullOrEmpty(txtTotal.Text) ? txtTotal.Text : "0");

            if (Model.SaleDetails == null)
            {
                Model.SaleDetails = new List<SaleDetail>();
            }

            dgv.EndEdit();
            foreach (DataGridViewRow row in dgv.Rows.OfType<DataGridViewRow>().Where(x => !x.IsNewRow))
            {
                var saleDetail = new SaleDetail();

                saleDetail.Active = true;
                saleDetail.Id = Parse.ToInt(row?.Cells[colId.Name]?.Value?.ToString() ?? "0");
                saleDetail.SaleId = Model.Id;
                saleDetail.ProductId = Parse.ToInt(row.Cells[colProductId.Name].Value?.ToString() ?? "0");
                saleDetail.Total = Parse.ToDecimal(row.Cells[colTotal.Name].Value?.ToString() ?? "0");

                //ImportTotal & Profit
                var otherPay = Parse.ToDecimal(txtExpense.Text);

                if (Flag == GeneralProcess.Update)
                {
                    var _saleDetail = Model.SaleDetails?.FirstOrDefault(x => x.Id == saleDetail.Id);
                    if (_saleDetail != null)
                    {
                        Model.SaleDetails[Model.SaleDetails.IndexOf(_saleDetail)] = saleDetail;
                    }
                    else
                    {
                        Model.SaleDetails.Add(saleDetail);
                    }
                }
                else
                {
                    Model.SaleDetails.Add(saleDetail);
                }
            }
        }
        private void WriteInvoice()
        {
            //invoiceDetails = new List<RepoInvoiceDetail>();
            //invoices = new List<RepoInvoice>();
            //var invoice = new RepoInvoice();

            //if (tabMain.SelectedTab.Equals(tabCustomer_))
            //{
            //    invoice.PurchaseOrderNo = cboPurchaseOrderNo.Text;
            //    invoice.InvoiceNo = Model.InvoiceNo = txtInvoiceNo.Text;
            //    var customer = cboCustomer.SelectedObject.ItemObject as Customer;
            //    var site = cboSite?.SelectedObject?.ItemObject as Site;
            //    var purchaseOrder = cboPurchaseOrderNo.SelectedObject?.ItemObject as PurchaseOrder;
            //    Model.PurchaseOrderId = purchaseOrder == null ? 0 : purchaseOrder.Id;
            //    invoice.Site = site?.Name;
            //    invoice.Customer = customer.Name;
            //}
            //else
            //{
            //    invoice.InvoiceNo = txtInvoiceNo1.Text;
            //    invoice.Customer = txtCustomer.Text;
            //}

            //invoice.Total = String.Format("{0:C}", Model.Total);
            //invoice.SaleId = Model.Id;
            //invoices.Add(invoice);

            //dgv.EndEdit();
            //foreach (DataGridViewRow row in dgv.Rows.OfType<DataGridViewRow>().Where(x => !x.IsNewRow))
            //{
            //    var invoiceDt = new RepoInvoiceDetail();

            //    var proId = int.Parse(row.Cells[colProductId.Name].Value.ToString());
            //    var _pro = ProductLogic.Instance.FindAsync(proId);
            //    invoiceDt.Product = _pro.Name;
            //    invoiceDt.Qauntity = Parse.ToDecimal(row.Cells[colQauntity.Name].Value.ToString());
            //    var unitP = decimal.Parse(row.Cells[colUnitPrice.Name].Value.ToString());
            //    var totalP = decimal.Parse(row.Cells[colTotal.Name].Value.ToString());
            //    invoiceDt.UnitPrice = String.Format("{0:C}", unitP);
            //    invoiceDt.Total = String.Format("{0:C}", totalP);
            //    invoiceDetails.Add(invoiceDt);
            //}
        }
        private void lblAdd_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dgv.RowCount > 0)
            {
                if (!string.IsNullOrEmpty(dgv.CurrentRow?.Cells[colProductId.Name]?.Value?.ToString()))
                {
                    return;
                }
            }
            if (tabMain.SelectedTab.Equals(tabGeneral_) && Flag != GeneralProcess.View)
            {
                dgv.ReadOnly = false;
            }
            else
            {
                var row = dgv.Rows[dgv.RowCount - 1];
                if (row != null)
                {
                    dgv.Focus();
                    dgv.CurrentCell = row.Cells[colProductId.Name];
                }
            }
        }
        private void lblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dgv.SelectedRows.Count == 0 || dgv.SelectedRows[0] == null || dgv.CurrentRow.Cells[colProductId.Name].Value == null)
            {
                return;
            }

            var row = dgv.SelectedRows[0];
            var idValue = row.Cells[colId.Name].Value;
            if (idValue == null)
            {
                dgv.Rows.Remove(row);
                return;
            }
            Model.SaleDetails.ForEach(x =>
            {
                if (x.Id == int.Parse(idValue.ToString()))
                {
                    x.Active = false;
                }
            });
            if (!row.IsNewRow)
            {
                dgv.Rows.Remove(row);
                CalculateTotal();
                dgv.EndEdit();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private async void btnPrint_Click(object sender, EventArgs e)
        {
            //if (InValid()) return;
            //WriteInvoice();
            //DataTable Invoice = new DataTable("Invoice");
            //using (var reader = ObjectReader.Create(invoices))
            //{
            //    Invoice.Load(reader);
            //}
            //DataTable InvoiceDetail = new DataTable("InvoiceDetail");
            //using (var reader = ObjectReader.Create(invoiceDetails))
            //{
            //    InvoiceDetail.Load(reader);
            //}
            //var Invoices = new List<DataTable>();
            //Invoices.Add(Invoice);
            //Invoices.Add(InvoiceDetail);

            //var report = await btnPrint.RunAsync(() =>
            //{
            //    var r = ReportHelper.Instance.Load(nameof(ReportInvoice), Invoices);
            //    r.SummaryInfo.ReportTitle = nameof(ReportInvoice);
            //    return r;
            //});

            //if (report != null)
            //{
            //    var dig = new DialogReportViewer(report);
            //    dig.Text = QTech.Base.Properties.Resources.Invoice;
            //    dig.ShowDialog();
            //}
        }
        private void dgv_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            var cell = dgv.CurrentCell;
            if (cell.Value != null)
            {
                cell.ErrorText = string.Empty;
            }
        }
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            try
            {
                int icolumn = dgv.CurrentCell.ColumnIndex;
                int irow = dgv.CurrentCell.RowIndex;

                if (keyData == Keys.Enter)
                {
                    if (icolumn == dgv.Columns.Count - 1)
                    {
                        dgv.CurrentCell = dgv[0, irow + 1];
                    }
                    else
                    {
                        dgv.CurrentCell = dgv[icolumn + 1, irow];
                    }
                    return true;
                }
                else
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            catch (Exception)
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }

        }

        private void btnChangeLog_Click(object sender, EventArgs e)
        {
            ViewChangeLog();
        }

        public void BindAsync()
        {
            throw new NotImplementedException();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dgv.RowCount > 0)
            {
                if (!string.IsNullOrEmpty(dgv.CurrentRow?.Cells[colProductId.Name]?.Value?.ToString()))
                {
                    return;
                }
            }
            if (tabMain.SelectedTab.Equals(tabGeneral_) && Flag != GeneralProcess.View)
            {
                dgv.ReadOnly = false;
            }
            
            if (dgv.RowCount == 0 || !string.IsNullOrEmpty(dgv.Rows[dgv.RowCount - 1].Cells[colProductId.Name].Value?.ToString()))
            {
                var row = newRow(true);
            }
            else
            {
                var row = dgv.Rows[dgv.RowCount - 1];
                if (row != null)
                {
                    dgv.Focus();
                    dgv.CurrentCell = row.Cells[colProductId.Name];
                }
            }
        }

    }
}
