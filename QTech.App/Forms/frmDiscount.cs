using EasyServer.Domain.Helpers;
using Newtonsoft.Json;
using QTech.Base.Enums;
using QTech.Base.Helpers;
using QTech.Base.Models;
using QTech.Base.SearchModels;
using QTech.Component;
using QTech.Component.Helpers;
using QTech.Db.Logics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseReource = QTech.Base.Properties.Resources;

namespace QTech.Forms
{
    public partial class frmDiscount : ExDialog, IDialog
    {
        public Discount Model { get; set; }
        public frmDiscount(Discount model, GeneralProcess flag)
        {
            InitializeComponent();

            this.Model = model;
            this.Flag = flag;

            Read();
            BindAsync();
            InitEvent();
            this.SetTheme(this.Controls, null);
            flowLayOutLabelRemoveAdd.BackColor = flowLayOutLabelRemoveAdd2.BackColor =
                ShareValue.CurrentTheme.FormBackGround;
            lblAdd.LinkColor = lblRemove.LinkColor = lblAdd2.LinkColor = lblRemove2.LinkColor
                = Color.FromArgb(0, 0, 255);
        }
        public GeneralProcess Flag { get; set; }

        public void BindAsync()
        {
            cboDiscountType.SetDataSource<DiscountType>();
            colProduct.SearchParamFn = () => new ProductSearch() { };
            colProduct.DataSourceFn = p => ProductLogic.Instance.SearchAsync(p).ToDropDownItemModelList();

        }
        public void InitEvent()
        {
            this.MaximizeBox = false;
            this.Text = Flag.GetTextDialog(Base.Properties.Resources.Discount);
            txtName.RegisterPrimaryInputWith(txtNote, txtName);
            this.SetEnabled(Flag != GeneralProcess.Remove && Flag != GeneralProcess.View);

            dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv1.RegisterEnglishInputColumns(colPercent);
            dgv1.AllowRowNotFound = false;
            dgv1.AllowUserToAddRows = dgv1.AllowUserToDeleteRows = true;
            dgv1.EditMode = DataGridViewEditMode.EditOnEnter;
            dgv1.EditingControlShowing += dgv_EditingControlShowing;
            this.SetEnabled(Flag != GeneralProcess.Remove && Flag != GeneralProcess.View);
            dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgv2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv2.RegisterEnglishInputColumns(colPercent2);
            dgv2.AllowRowNotFound = false;
            dgv2.AllowUserToAddRows = dgv1.AllowUserToDeleteRows = true;
            dgv2.EditMode = DataGridViewEditMode.EditOnEnter;
            dgv2.EditingControlShowing += dgv_EditingControlShowing;
            this.SetEnabled(Flag != GeneralProcess.Remove && Flag != GeneralProcess.View);
            dgv2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            cboDiscountType.SelectedIndexChanged += CboDiscountType_SelectedIndexChanged;
            cboDiscountType.SelectedIndex = cboDiscountType.FindString(BaseReource.DiscountType_ByProduct);

        }
        private void CboDiscountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var discountType = (DiscountType)(cboDiscountType.SelectedValue);
            gbTotal_.Enabled = !(gbProduct_.Enabled = discountType == DiscountType.ByProduct);
            if (gbTotal_.Enabled)
                dgv1.Rows.Clear();
            else
                dgv2.Rows.Clear();
        }
        private void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.RegisterEnglishInput();
        }
        public bool InValid()
        {
            if (!txtName.IsValidRequired(lblName.Text)
                | !cboDiscountType.IsValidRequired(lblCategory.Text)
               )
            {
                return true;
            }
            if (dtpFrom.Value > dtpTo.Value)
            {
                dtpTo.ShowValidation(BaseReource.MsgToDateGreaterThenFromDate, TabAlignment.Right);
            }

            if (!validDiscountPrice())
            {
                return true;
            }
            return false;
        }
        public async void Read()
        {
            if (Flag == GeneralProcess.Add)
            {
                return;
            }
            txtName.Text = Model.Name;
            txtNote.Text = Model.Note;
            dtpFrom.Value = Model.StartDate;
            dtpTo.Value = Model.ToDate;
            cboDiscountType.SelectedItem = Enum.GetName(typeof(DiscountType), (DiscountType)Model.DiscountType);

            if (Model.DiscountType == DiscountType.ByProduct)
            {
                var disountByProducts = JsonConvert.DeserializeObject<List<DiscountByProduct>>(Model.DiscountByProduct);
                var products = await this.RunAsync(() =>
                {
                    return ProductLogic.Instance.SearchAsync(new ProductSearch()) ?? new List<Product>();
                });
                if (disountByProducts?.Any() ?? false)
                {
                    disountByProducts.ForEach(x =>
                    {
                        var row = newRow(dgv1, false);
                        row.Cells[colOrder.Name].Value = x.Order;
                        row.Cells[colPercent.Name].Value = x.Percent;

                        if (products?.Any() ?? false)
                        {
                            var product = products.FirstOrDefault(f => f.Id == x.ProductId);
                            var _product = new List<DropDownItemModel>()
                            {
                                new DropDownItemModel
                                {
                                    Id = product.Id,
                                    Code = product.Name,
                                    Name = product.Name,
                                    DisplayText = product.Name,
                                    ItemObject = product,
                                }
                            };
                            row.Cells[colProduct.Name].Value = _product;
                        }
                    });
                }
            }
            else
            {
                var discountByTotals = JsonConvert.DeserializeObject<List<DiscountByTotal>>(Model.DiscountByTotal);
                var products = await this.RunAsync(() =>
                {
                    return ProductLogic.Instance.SearchAsync(new ProductSearch()) ?? new List<Product>();
                });
                dgv1.BeginEdit(true);
                if (discountByTotals?.Any() ?? false)
                {
                    discountByTotals.ForEach(x =>
                    {
                        var row = newRow(dgv2, false);
                        row.Cells[colOrder.Name].Value = x.Order;
                        row.Cells[colFromTotal.Name].Value = x.FromPrice;
                        row.Cells[colToTotal.Name].Value = x.ToPrice;
                        row.Cells[colPercent.Name].Value = x.Percent;
                    });
                }
            }
        }
        private DataGridViewRow newRow(DataGridView dgv, bool isFocus = false)
        {
            var row = dgv.Rows[dgv.Rows.Add()];
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

            var isExist = await btnSave.RunAsync(() => DiscountLogic.Instance.IsExistsAsync(Model));
            if (isExist == true)
            {
                txtName.IsExists(lblName.Text);
                return;
            }

            var result = await btnSave.RunAsync(() =>
            {
                if (Flag == GeneralProcess.Add)
                {
                    return DiscountLogic.Instance.AddAsync(Model);
                }
                else if (Flag == GeneralProcess.Update)
                {
                    return DiscountLogic.Instance.UpdateAsync(Model);
                }
                else if (Flag == GeneralProcess.Remove)
                {
                    return DiscountLogic.Instance.RemoveAsync(Model);
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
            int _order = 1;
            Model.Name = txtName.Text;
            Model.Note = txtNote.Text;
            Model.StartDate = dtpFrom.Value;
            Model.ToDate = dtpTo.Value;
            Model.DiscountType = (DiscountType)(cboDiscountType.SelectedValue);
            if (Model.DiscountType == DiscountType.ByProduct)
            {
                var discountByProducts = new List<DiscountByProduct>();
                dgv1.EndEdit();
                foreach (DataGridViewRow row in dgv1.Rows.OfType<DataGridViewRow>().Where(x => !x.IsNewRow))
                {
                    var dp = new DiscountByProduct();
                    dp.Order = _order++;
                    dp.ProductId = Parse.ToInt(row.Cells[colProduct.Name].Value?.ToString());
                    dp.Percent = Parse.ToDecimal(row.Cells[colPercent.Name].Value.ToString());
                    discountByProducts.Add(dp);
                }

                Model.DiscountByProduct = JsonConvert.SerializeObject(discountByProducts);
            }
            else
            {
                var disountByTotals = new List<DiscountByTotal>();
                dgv2.EndEdit();
                foreach (DataGridViewRow row in dgv2.Rows.OfType<DataGridViewRow>().Where(x => !x.IsNewRow))
                {
                    var dt = new DiscountByTotal();
                    dt.Order = _order++;
                    dt.FromPrice = Parse.ToDecimal(row.Cells[colFromTotal.Name].Value?.ToString());
                    dt.ToPrice = Parse.ToDecimal(row.Cells[colToTotal.Name].Value?.ToString());
                    dt.Percent = Parse.ToDecimal(row.Cells[colPercent.Name].Value.ToString());
                    disountByTotals.Add(dt);
                }
                Model.DiscountByProduct = JsonConvert.SerializeObject(disountByTotals);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.E))
            {
                btnChangeLog.PerformClick();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void btnChangeLog_Click(object sender, EventArgs e)
        {
            ViewChangeLog();
        }
        private bool validDiscountPrice()
        {
            var invalidCell = false;
            var disounttype = (DiscountType)(cboDiscountType.SelectedValue);
            if (disounttype == DiscountType.ByTotal)
            {
                var rows = dgv2.Rows.OfType<DataGridViewRow>().Where(x => x.Index != dgv1.RowCount - 1);
                if (rows?.Any() != true)
                {
                    MsgBox.ShowInformation(string.Format(BaseReource.MsgPleaseInputDataInTable_));
                    return false;
                }

                foreach (DataGridViewRow row in rows)
                {
                    var cells = row.Cells.OfType<DataGridViewCell>().Where(x =>
                    x.ColumnIndex == row.Cells[colPercent.Name].ColumnIndex
                    || x.ColumnIndex == row.Cells[colFromTotal.Name].ColumnIndex
                    || x.ColumnIndex == row.Cells[colToTotal.Name].ColumnIndex)
                        .ToList();
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
            }
            else if (disounttype == DiscountType.ByProduct)
            {
                var rows = dgv1.Rows.OfType<DataGridViewRow>().Where(x => x.Index != dgv1.RowCount - 1);
                if (rows?.Any() != true)
                {
                    MsgBox.ShowInformation(string.Format(BaseReource.MsgPleaseInputDataInTable_));
                    return false;
                }

                foreach (DataGridViewRow row in rows)
                {
                    var cells = row.Cells.OfType<DataGridViewCell>().Where(x =>
                    x.ColumnIndex == row.Cells[colPercent.Name].ColumnIndex
                    || x.ColumnIndex == row.Cells[colProduct.Name].ColumnIndex).ToList();
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
            }

            if (invalidCell)
            {
                return false;
            }

            return true;
        }
        private void lblAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!dgv1.CurrentCell?.IsInEditMode ?? true)
            {
                if (dgv1.Rows.OfType<DataGridViewRow>().Where(x => x.IsNewRow).Count() == 1 && dgv1.CurrentCell == null)
                {
                    dgv1.Rows.Clear();
                }
                var index = dgv1.Rows[dgv1.NewRowIndex].Cells[colProduct.Name];
                dgv1.CurrentCell = index;
                dgv1.BeginEdit(true);
            }
        }
        private void lblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var row = dgv1.SelectedRows[0];

            if (dgv1?.SelectedRows?.Count > 0)
            {
                //Model.DiscountPrices.ForEach(x =>
                //{
                //    if (x.Id == int.Parse(idValue.ToString()))
                //    {
                //        x.Active = false;
                //    }
                //}
                //);
                if (!row.IsNewRow)
                {
                    dgv1.Rows.Remove(row);
                    dgv1.EndEdit();
                }
            }
        }
        private void lblAdd2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!dgv2.CurrentCell?.IsInEditMode ?? true)
            {
                if (dgv2.Rows.OfType<DataGridViewRow>().Where(x => x.IsNewRow).Count() == 1 && dgv2.CurrentCell == null)
                {
                    dgv2.Rows.Clear();
                }
                var index = dgv2.Rows[dgv2.NewRowIndex].Cells[colFromTotal.Name];
                dgv2.CurrentCell = index;
                dgv2.BeginEdit(true);
            }
        }
        private void lblRemove2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var row = dgv2.SelectedRows[0];

            if (dgv2?.SelectedRows?.Count > 0)
            {
                //Model.DiscountPrices.ForEach(x =>
                //{
                //    if (x.Id == int.Parse(idValue.ToString()))
                //    {
                //        x.Active = false;
                //    }
                //}
                //);
                if (!row.IsNewRow)
                {
                    dgv2.Rows.Remove(row);
                    dgv2.EndEdit();
                }
            }
        }
    }
}
