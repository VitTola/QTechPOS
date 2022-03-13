using QTech.Base;
using QTech.Component;
using QTech.Db.Logics;
using System;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseResource = QTech.Base.Properties.Resources;
using QTech.Base.Helpers;
using QTech.Base.SearchModels;
using System.Collections.Generic;
using System.Drawing;
using QTech.Base.Models;
using QTech.Base.Enums;

namespace QTech.Forms
{
    public partial class DiscountPage : ExPage, IPage
    {
        public DiscountPage()
        {
            InitializeComponent();
            Bind();
            InitEvent();
            this.SetTheme(this.Controls, null);
        }
        public Discount Model { get; set; }

        private void Bind()
        {
        }
        private void InitEvent()
        {
            dgv.RowTemplate.Height = 28;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            btnAdd.Visible = ShareValue.IsAuthorized(AuthKey.Sale_Discount_Add);
            btnRemove.Visible = ShareValue.IsAuthorized(AuthKey.Sale_Discount_Remove);
            btnUpdate.Visible = ShareValue.IsAuthorized(AuthKey.Sale_Discount_Update);

            txtSearch.RegisterPrimaryInput();
            txtSearch.RegisterKeyArrowDown(dgv);
            txtSearch.QuickSearch += txtSearch_QuickSearch;

            dgv.RowPostPaint += (s, e) => dgv.Rows[e.RowIndex].Cells[colRow_.Name].Value = (e.RowIndex + 1).ToString();
            pagination.DataSourceChanged += (s, e) => LoadData();
            pagination.BackGroundColor = ShareValue.CurrentTheme.PanelColor;
            pagination.Paging = 25;
        }
        private async void txtSearch_QuickSearch(object sender, EventArgs e)
        {
            await Search();
        }
        public async void AddNew()
        {
            Model = new Discount();
            var dig = new frmDiscount(Model, GeneralProcess.Add);
            if (dig.ShowDialog() == DialogResult.OK)
            {
                await Search();
            }
        }
        public async void EditAsync()
        {
            if (dgv.SelectedRows.Count == 0)
            {
                return;
            }

            var id = (int)dgv.SelectedRows[0].Cells[colId.Name].Value;

            Model = await btnUpdate.RunAsync(() => DiscountLogic.Instance.FindAsync(id));
            if (Model == null)
            {
                return;
            }

            var dig = new frmDiscount(Model, GeneralProcess.Update);

            if (dig.ShowDialog() == DialogResult.OK)
            {
                await Search();
                dgv.RowSelected(colId.Name, dig.Model.Id);
            }
        }
        public async void Reload()
        {
            dgv.AllowRowNotFound = true;
            dgv.ColumnHeadersHeight = 28;

            await Search();
        }
        public async void Remove()
        {
            if (dgv.SelectedRows.Count == 0)
            {
                return;
            }

            var id = (int)dgv.CurrentRow.Cells[colId.Name].Value;
            var canRemove = await btnRemove.RunAsync(() => DiscountLogic.Instance.CanRemoveAsync(id));
            if (canRemove == false)
            {
                MsgBox.ShowWarning(EasyServer.Domain.Resources.RowCannotBeRemoved,
                    GeneralProcess.Remove.GetTextDialog(BaseResource.Discount));
                return;
            }

            Model = await btnRemove.RunAsync(() => DiscountLogic.Instance.FindAsync(id));
            if (Model == null)
            {
                return;
            }

            var dig = new frmDiscount(Model, GeneralProcess.Remove);
            if (dig.ShowDialog() == DialogResult.OK)
            {
                await Search();
            }
        }
        public async Task Search()
        {
            var search = new DiscountSearch()
            {
                Search = txtSearch.Text,
            };

            pagination.DataSourceFn = await dgv.RunAsync(() => DiscountLogic.Instance.Search(search));
            if (pagination.DataSource == null)
            {
                return;
            }
            LoadData();
        }
        private void LoadData()
        {
            List<Discount> discounts = pagination.DataSource.Cast<Discount>().ToList();
            dgv.Rows.Clear();
            discounts.OrderByDescending(x => x.RowDate).ToList().ForEach(x =>
              {
                  var row = newRow(false);
                  row.Cells[colId.Name].Value = x.Id;
                  row.Cells[colName.Name].Value = x.Name;
                  row.Cells[colFromDate.Name].Value = x.StartDate.ToString("dd-MMM-yyyy"); ;
                  row.Cells[colToDate.Name].Value = x.ToDate.ToString("dd-MMM-yyyy");
                  row.Cells[colDiscountType.Name].Value = x.DiscountType == DiscountType.ByProduct ? BaseResource.DiscountType_ByProduct :
                  BaseResource.DiscountType_ByTotal;
                  row.Cells[colNote.Name].Value = x.Note;
              });
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
            Model = await btnUpdate.RunAsync(() => DiscountLogic.Instance.FindAsync(id));

            if (Model == null)
            {
                return;
            }

            var dig = new frmDiscount(Model, GeneralProcess.View);
            dig.ShowDialog();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNew();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            EditAsync();
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            Remove();
        }
        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            View();
        }
    }
}
