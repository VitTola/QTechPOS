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
    public partial class ScalePage : ExPage, IPage
    {
        public ScalePage()
        {
            InitializeComponent();
            Bind();
            InitEvent();
            this.SetTheme(this.Controls, null);
        }
        public Scale Model { get; set; }

        private void Bind()
        {
        }
        private void InitEvent()
        {
            dgv.RowTemplate.Height = 28;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            btnAdd.Visible = ShareValue.IsAuthorized(AuthKey.Product_Scale_Add);
            btnRemove.Visible = ShareValue.IsAuthorized(AuthKey.Product_Scale_Remove);
            btnUpdate.Visible = ShareValue.IsAuthorized(AuthKey.Product_Scale_Update);

            txtSearch.RegisterPrimaryInput();
            txtSearch.RegisterKeyArrowDown(dgv);
            txtSearch.QuickSearch += txtSearch_QuickSearch;
        }

        private async void txtSearch_QuickSearch(object sender, EventArgs e)
        {
            await Search();
        }  

        public async void AddNew()
        {
            Model = new Scale();
            var dig = new frmScale(Model, GeneralProcess.Add);
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

            Model = await btnUpdate.RunAsync(() => ScaleLogic.Instance.FindAsync(id));
            if (Model == null)
            {
                return;
            }

            var dig = new frmScale(Model, GeneralProcess.Update);

            if (dig.ShowDialog() == DialogResult.OK)
            {
                await Search();
                dgv.RowSelected(colId.Name, dig.Model.Id);
            }
        }

        public async void Reload()
        {
            dgv.AllowRowNotFound = true;
            dgv.AllowRowNumber = true;
            dgv.ColumnHeadersHeight= 28;

            await Search();
        }

        public async void Remove()
        {
            if (dgv.SelectedRows.Count == 0)
            {
                return;
            }

            var id = (int)dgv.CurrentRow.Cells[colId.Name].Value;
            var canRemove = await btnRemove.RunAsync(() => ScaleLogic.Instance.CanRemoveAsync(id));
            if (canRemove == false)
            {
                MsgBox.ShowWarning(EasyServer.Domain.Resources.RowCannotBeRemoved,
                    GeneralProcess.Remove.GetTextDialog(BaseResource.Scale));
                return;
            }

            Model = await btnRemove.RunAsync(() => ScaleLogic.Instance.FindAsync(id));
            if (Model == null)
            {
                return;
            }

            var dig = new frmScale(Model, GeneralProcess.Remove);
            if (dig.ShowDialog() == DialogResult.OK)
            {
                await Search();
            }
        }

        public async Task Search()
        {
            var search = new ScaleSearch()
            {
                Search = txtSearch.Text,
            };

            var result = await dgv.RunAsync(() => ScaleLogic.Instance.SearchAsync(search));
            if (result != null)
            {
                dgv.DataSource = result.OrderByDescending(x=>x.RowDate)._ToDataTable();
            }
        }
  
        public async void View()
        {
            if (dgv.SelectedRows.Count == 0)
            {
                return;
            }

            var id = (int)dgv.SelectedRows[0].Cells[colId.Name].Value;
            Model = await btnUpdate.RunAsync(() => ScaleLogic.Instance.FindAsync(id));

            if (Model == null)
            {
                return;
            }

            var dig = new frmScale(Model, GeneralProcess.View);
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
