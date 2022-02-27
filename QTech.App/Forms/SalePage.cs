﻿using QTech.Base;
using QTech.Base.BaseModels;
using QTech.Base.Enums;
using QTech.Base.Helpers;
using QTech.Base.Models;
using QTech.Base.SearchModels;
using QTech.Component;
using QTech.Db.Logics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseResource = QTech.Base.Properties.Resources;


namespace QTech.Forms
{
    public partial class SalePage : ExPage, IPage
    {
        public Sale Model { get; set; }
        private GeneralProcess flag = GeneralProcess.None;
        SaleSearchKey saleSearchKey = SaleSearchKey.None;
        List<User> Employees = null;
        List<Customer> Customers = null;

        public SalePage()
        {
            InitializeComponent();
            BindData();
            this.SetTheme(this.Controls, null);

            InitEvent();
        }
        private  void BindData()
        {
            txtSearch.RegisterEnglishInput();
            txtSearch.RegisterKeyArrowDown(dgv);
            txtSearch.QuickSearch += txtSearch_QuickSearch;
            txtSearch.PatternChanged += txtSearch_PatternChanged;
            registerSearchMenu();
            cboPayStatus.SetDataSource<PayStatus>();
            cboImport.SetDataSource<ImportPrice>();

        }
        private void InitEvent()
        {
            this.Text = BaseResource.Sales;
            cboPayStatus.SelectedIndexChanged += CboPayStatus_SelectedIndexChanged;
            cboImport.SelectedIndexChanged += CboPayStatus_SelectedIndexChanged;
            btnAdd.Visible = ShareValue.IsAuthorized(AuthKey.Sale_Sale_Add);
            btnRemove.Visible = ShareValue.IsAuthorized(AuthKey.Sale_Sale_Remove);
            btnUpdate.Visible = ShareValue.IsAuthorized(AuthKey.Sale_Sale_Update);

            cboImport.SelectedIndex = cboImport.FindStringExact(BaseResource.ImportPrice_All);
            btnAdd.Click += BtnAdd_Click;
            dgv.RowPostPaint += Dgv_RowPostPaint;
            this.Load += SalePage_Load;

            flowLayoutPanel2.Dock = DockStyle.Fill;
            pagination.BackGroundColor = ShareValue.CurrentTheme.PanelColor;
            pagination.DataSourceChanged += Pagination_DataSourceChanged;
            pagination.Paging = 20;
        }

        private void Pagination_DataSourceChanged(object sender, EventArgs e)
        {
            Reload();
        }

        private async void SalePage_Load(object sender, EventArgs e)
        {
            var isDone = await dgv.RunAsync(() =>
            {
                Employees = UserLogic.Instance.SearchAsync(new EmployeeSearch());
                Customers = CustomerLogic.Instance.SearchAsync(new CustomerSearch());

                return true;
            });
        }

        private void Dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgv.Rows[e.RowIndex].Cells[colRow_.Name].Value = (e.RowIndex + 1).ToString();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddNew();
        }

        private async void CboPayStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            await Search();
        }
        private void txtSearch_PatternChanged(object sender, EventArgs e)
        {
            saleSearchKey = (SaleSearchKey)txtSearch.SelectedPattern;
        }
        private async void txtSearch_QuickSearch(object sender, EventArgs e)
        {
            await Search();
        }
        public async void AddNew()
        {
            Model = new Sale();
            Model.SaleDetails = new List<SaleDetail>();
            flag = GeneralProcess.Add;
            var dig = new frmSale(Model, flag);
            if (dig.ShowDialog() == DialogResult.OK)
            {
                await Search();
                dgv.RowSelected(colId.Name, dig.Model.Id);
            }
        }
        public async void EditAsync()
        {
            if (dgv.SelectedRows.Count == 0)
            {
                return;
            }

            var id = (int)dgv.SelectedRows[0].Cells[colId.Name].Value;
            Model = await btnUpdate.RunAsync(() => SaleLogic.Instance.FindAsync(id));
            if (Model.PayStatus != PayStatus.NotYetPaid)
            {
                MsgBox.ShowWarning(BaseResource.MsgSaleCanEdit,
                    GeneralProcess.Remove.GetTextDialog(BaseResource.Sales));
                return;
            }

            Model = await btnUpdate.RunAsync(() => SaleLogic.Instance.FindAsync(id));
            if (Model == null)
            {
                return;
            }

            flag = GeneralProcess.Update;
            var dig = new frmSale(Model, flag);

            if (dig.ShowDialog() == DialogResult.OK)
            {
                await Search();
                dgv.RowSelected(colId.Name, dig.Model.Id);
            }
        }
        public async void Reload()
        {
            await Search();
        }
        public async void Remove()
        {
            if (dgv.SelectedRows.Count == 0)
            {
                return;
            }

            var id = (int)dgv.SelectedRows[0].Cells[colId.Name].Value;
            var canRemove = await btnRemove.RunAsync(() => SaleLogic.Instance.CanRemoveAsync(id));
            if (canRemove == false)
            {
                MsgBox.ShowWarning(EasyServer.Domain.Resources.RowCannotBeRemoved,
                    GeneralProcess.Remove.GetTextDialog(BaseResource.Sales));
                return;
            }

            Model = await btnRemove.RunAsync(() => SaleLogic.Instance.FindAsync(id));
            if (Model == null)
            {
                return;
            }

            var dig = new frmSale(Model, GeneralProcess.Remove);
            if (dig.ShowDialog() == DialogResult.OK)
            {
                await Search();
            }
        }
        public async Task Search()
        {
            var _payStatus = (PayStatus)cboPayStatus.SelectedValue;
            var _importPrice = (ImportPrice)cboImport.SelectedValue;
            var search = new SaleSearch()
            {
                saleSearchKey = this.saleSearchKey,
                Search = txtSearch.Text,
                payStatus = _payStatus,
                ImportPrice = _importPrice,
            };
            pagination.DataSourceFn = await dgv.RunAsync(() => SaleLogic.Instance.Search(search));
            pagination.RefreshCurrentPage(isLoadEvent:false);
            if (pagination.DataSource == null)
            {
                return;
            }

            List<Sale> sales = pagination.DataSource.Cast<Sale>().ToList();
            dgv.Rows.Clear();
            sales.ForEach(x =>
            {
                var row = newRow(false);
                row.Cells[colId.Name].Value = x.Id;
                row.Cells[colInvoiceNo.Name].Value = x.InvoiceNo;
                row.Cells[colTotal.Name].Value = x.Total;
                row.Cells[colSaleDate.Name].Value = x.SaleDate.ToString("dd-MMM-yyyy hh:mm");
                row.Cells[colIsPaid.Name].Value = x.PayStatus;
                row.Cells[colRowDate.Name].Value = x.RowDate;
                row.Cells[colPaidAmount.Name].Value = x.PaymentRecieve;
                row.Cells[colBalance.Name].Value = x.PaymentLeft;
                row.Cells[colSaler.Name].Value = Employees?.FirstOrDefault(y => y.Id == x.EmployeeId)?.Name;
                row.Cells[colCustomer.Name].Value = Customers?.FirstOrDefault(y => y.Id == x.CustomerId)?.Name ?? x.CustomerName;

                var cell = row.Cells[colStatus.Name];
                if (x.PayStatus == PayStatus.Paid)
                {
                    row.Cells[colStatus.Name].Value = BaseResource.IsPaid;
                    cell.Style.ForeColor = Color.Red;
                }
                else if (x.PayStatus == PayStatus.WaitPayment)
                {
                    row.Cells[colStatus.Name].Value = BaseResource.PayStatus_WaitPayment;
                    cell.Style.ForeColor = Color.Orange;
                }
                else
                {
                    row.Cells[colStatus.Name].Value = BaseResource.NotYetPaid;
                    cell.Style.ForeColor = Color.Green;
                }
            });
            dgv.Sort(dgv.Columns[colRowDate.Name], ListSortDirection.Descending);
            if (dgv.RowCount > 0) dgv.Rows[0].Selected = true;

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
        public async void View()
        {
            if (dgv.SelectedRows.Count == 0)
            {
                return;
            }

            var id = (int)dgv.SelectedRows[0].Cells[colId.Name].Value;

            Model = await btnUpdate.RunAsync(() => SaleLogic.Instance.FindAsync(id));

            if (Model == null)
            {
                return;
            }

            var dig = new frmSale(Model, GeneralProcess.View);
            dig.ShowDialog();
        }
        private void registerSearchMenu()
        {
            txtSearch.AddMenuPattern(
                SaleSearchKey.PurchaseOrderNo.ToString(),
                SaleSearchKey.PurchaseOrderNo,
                BaseResource.PurchaseOrderNo_img,
                BaseResource.PurchaseOrderNo,
                Constants.KeyShortcut[SaleSearchKey.PurchaseOrderNo],
                (s, e) =>
                {
                    InputLanguage.CurrentInputLanguage = UI.English;
                    txtSearch.ReadOnly = false;
                });
            txtSearch.AddMenuPattern(
             SaleSearchKey.InvoiceNo.ToString(),
             SaleSearchKey.InvoiceNo,
             BaseResource.InvoiceNo_img,
             BaseResource.InvoiceNo,
             Constants.KeyShortcut[SaleSearchKey.InvoiceNo],
             (s, e) =>
             {
                 InputLanguage.CurrentInputLanguage = UI.English;
                 txtSearch.ReadOnly = false;
             });
            txtSearch.AddMenuPattern(
             SaleSearchKey.CompanyName.ToString(),
             SaleSearchKey.CompanyName,
             BaseResource.customer2,
             BaseResource.Customer,
             Constants.KeyShortcut[SaleSearchKey.CompanyName],
             (s, e) =>
             {
                 InputLanguage.CurrentInputLanguage = UI.English;
                 txtSearch.ReadOnly = false;
             });
            txtSearch.AddMenuPattern(
             SaleSearchKey.SiteName.ToString(),
             SaleSearchKey.SiteName,
             BaseResource.home,
             BaseResource.Site,
             Constants.KeyShortcut[SaleSearchKey.SiteName],
             (s, e) =>
             {
                 InputLanguage.CurrentInputLanguage = UI.English;
                 txtSearch.ReadOnly = false;
             });

            InputLanguage.CurrentInputLanguage = UI.English;
            txtSearch.ShowMenuPattern(SaleSearchKey.PurchaseOrderNo);
            // changeDataVisible();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Constants.KeyShortcut[SaleSearchKey.PurchaseOrderNo])
            {
                InputLanguage.CurrentInputLanguage = UI.English;
                txtSearch.ReadOnly = false;
                txtSearch.ShowMenuPattern(SaleSearchKey.PurchaseOrderNo);
                return true;
            }
            else if (keyData == Constants.KeyShortcut[SaleSearchKey.InvoiceNo])
            {
                InputLanguage.CurrentInputLanguage = UI.English;
                txtSearch.ReadOnly = false;
                txtSearch.ShowMenuPattern(SaleSearchKey.InvoiceNo);
                return true;
            }
            else if (keyData == Constants.KeyShortcut[SaleSearchKey.CompanyName])
            {
                InputLanguage.CurrentInputLanguage = UI.English;
                txtSearch.ReadOnly = false;
                txtSearch.ShowMenuPattern(SaleSearchKey.CompanyName);
                return true;
            }
            else if (keyData == Constants.KeyShortcut[SaleSearchKey.SiteName])
            {
                InputLanguage.CurrentInputLanguage = UI.English;
                txtSearch.ReadOnly = false;
                txtSearch.ShowMenuPattern(SaleSearchKey.SiteName);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            EditAsync();
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            Remove();
        }
        private void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //dgv.Rows[e.RowIndex].Cells[colRow.Name].Value = (e.RowIndex + 1).ToString();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
