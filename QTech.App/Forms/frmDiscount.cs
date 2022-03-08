using EasyServer.Domain.Helpers;
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
            pnlbackground.BackColor = Color.Gray;
        }
        public GeneralProcess Flag { get; set; }

        public void BindAsync()
        {
            cboCategory.DataSourceFn = p => CategoryLogic.Instance.SearchAsync(p).ToDropDownItemModelList();
            cboCategory.SearchParamFn = () => new CategorySearch();

            colScale.SearchParamFn = () => new ScaleSearch() { };
            colScale.DataSourceFn = p => ScaleLogic.Instance.SearchAsync(p).OrderByDescending(x => x.RowDate)
            .Where(x=>!AddedScaleIds().Contains(x.Id)).ToDropDownItemModelList();

        }
        private List<int> AddedScaleIds()
        {
            var scaleIds = new List<int>();
            dgv.EndEdit();
            foreach (DataGridViewRow row in dgv.Rows.OfType<DataGridViewRow>().Where(x => !x.IsNewRow))
            {
                var scaleId = Parse.ToInt(row?.Cells[colScale.Name]?.Value?.ToString() ?? "0");
                scaleIds.Add(scaleId);
            }

            return scaleIds;
        }
        public void InitEvent()
        {
            this.MaximizeBox = false;
            this.Text = Flag.GetTextDialog(Base.Properties.Resources.Discount);
            txtName.RegisterPrimaryInputWith(txtNote, txtName);
            this.SetEnabled(Flag != GeneralProcess.Remove && Flag != GeneralProcess.View);
            txtName.RegisterKeyEnterNextControlWith(cboCategory, txtNote);
            picFood.Click += btnAddPic__Click;
            txtName.RegisterKeyEnterNextControlWith(cboCategory, txtNote);

            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.RegisterEnglishInputColumns(colSalePrice);
            dgv.AllowRowNotFound = false;
            dgv.AllowUserToAddRows = dgv.AllowUserToDeleteRows = true;
            dgv.EditMode = DataGridViewEditMode.EditOnEnter;
            dgv.EditingControlShowing += dgv_EditingControlShowing;
            this.SetEnabled(Flag != GeneralProcess.Remove && Flag != GeneralProcess.View);
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }
        private void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.RegisterEnglishInput();
        }
        public bool InValid()
        {
            if (!txtName.IsValidRequired(lblName.Text)
                | !cboCategory.IsValidRequired(lblCategory.Text)
               )
            {
                return true;
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

            //List<DiscountPrice> DiscountPrices = null;
            //List<Scale> Scales = null;
            //var _result = await this.RunAsync(() =>
            //{
            //    DiscountPrices = DiscountPriceLogic.Instance.SearchAsync(new DiscountPriceSearch { DiscountId = Model.Id });
            //    Scales = ScaleLogic.Instance.SearchAsync(new ScaleSearch());
            //    var result = CategoryLogic.Instance.FindAsync(Model.CategoryId);
            //    return result;
            //}
            //);
            //cboCategory.SetValue(_result);
            //picFood.ImageSource = Model?.Photo;

            ////dgv.BeginEdit(true);
            //if (DiscountPrices?.Any() ?? false)
            //{
            //    Model.DiscountPrices = DiscountPrices;
            //    DiscountPrices.ForEach(x =>
            //    {
            //        var row = newRow(false);
            //        row.Cells[colId.Name].Value = x.Id;
            //        row.Cells[colSalePrice.Name].Value = x.SalePrice;

            //        if (Scales?.Any() ?? false)
            //        {
            //            var scale = Scales.FirstOrDefault(f => f.Id == x.ScaleId);
            //            var _scale = new List<DropDownItemModel>()
            //        {
            //                    new DropDownItemModel
            //                    {
            //                        Id = scale.Id,
            //                        Code = scale.Name,
            //                        Name = scale.Name,
            //                        DisplayText = scale.Name,
            //                        ItemObject = scale,
            //                    }
            //        };
            //            row.Cells[colScale.Name].Value = _scale;
            //        }
                    
            //    });
            //}
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
            Model.Name = txtName.Text;
            Model.Note = txtNote.Text;
            var selectedCat = cboCategory.SelectedObject.ItemObject as Category;
           
            

            //dgv.EndEdit();
            //foreach (DataGridViewRow row in dgv.Rows.OfType<DataGridViewRow>().Where(x => !x.IsNewRow))
            //{
            //    var pp = new DiscountPrice();

            //    pp.Active = true;
            //    pp.Id = Parse.ToInt(row?.Cells[colId.Name]?.Value?.ToString() ?? "0");
            //    pp.DiscountId = Model.Id;
            //    pp.ScaleId = Parse.ToInt(row?.Cells[colScale.Name]?.Value?.ToString() ?? "0");
            //    pp.SalePrice = Parse.ToDecimal(row?.Cells[colSalePrice.Name]?.Value?.ToString() ?? "0");
            //    var temp = Model.DiscountPrices.FirstOrDefault(x => x.Id == pp.Id);
            //    if (temp !=null && temp.Id != 0)
            //    {
            //        Model.DiscountPrices[Model.DiscountPrices.IndexOf(temp)] = pp;
            //    }
            //    else
            //    {
            //        Model.DiscountPrices.Add(pp);
            //    }

            //}
          
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void btnAddPic__Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image|*.jpg;*.jpeg;*.png;";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var ByteSource = File.ReadAllBytes(dialog.FileName);
                picFood.ImageSource = ByteSource;
                picFood.ImagePath = dialog.FileName;
            }
        }
        private void btnRemovePic_Click(object sender, EventArgs e)
        {
            picFood.SetPlaceHolder();
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
            var rows = dgv.Rows.OfType<DataGridViewRow>().Where(x => x.Index != dgv.RowCount - 1);
            if (rows?.Any() != true)
            {
                MsgBox.ShowInformation(string.Format(BaseReource.MsgPleaseInputDataInTable_, BaseReource.SalePrice));
                return false;
            }

            foreach (DataGridViewRow row in rows)
            {
                var cells = row.Cells.OfType<DataGridViewCell>().Where(x =>
                x.ColumnIndex == row.Cells[colScale.Name].ColumnIndex
                || x.ColumnIndex == row.Cells[colSalePrice.Name].ColumnIndex).ToList();
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

        private void lblAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!dgv.CurrentCell?.IsInEditMode ?? true)
            {
                if (dgv.Rows.OfType<DataGridViewRow>().Where(x => x.IsNewRow).Count() == 1 && dgv.CurrentCell == null)
                {
                    dgv.Rows.Clear();
                }
                var index = dgv.Rows[dgv.NewRowIndex].Cells[colScale.Name];
                dgv.CurrentCell = index;
                dgv.BeginEdit(true);
            }
        }

        private void lblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var row = dgv.SelectedRows[0];
            var idValue = row.Cells[colId.Name].Value;
            int ppId = int.Parse(idValue.ToString());
            if (ppId != 0)
            {
                //var canRemove = await dgv.RunAsync(() => DiscountPriceLogic.Instance.CanRemoveAsync(ppId));
                //if (!canRemove)
                //{
                //    MsgBox.ShowWarning(BaseReource.Scale + BaseReource.MsgDataCurrentlyInUsed,
                //   GeneralProcess.Remove.GetTextDialog(BaseReource.Site));
                //    return;
                //}
            }

            //if (dgv?.SelectedRows?.Count > 0)
            //{
            //    if (row.Cells[colScale.Name].Value == null &&
            //     row.Cells[colSalePrice.Name].Value == null)
            //    {
            //        return;
            //    }

            //    if (idValue == null)
            //    {
            //        dgv.Rows.Remove(dgv.CurrentRow);
            //        return;
            //    }

            //    Model.DiscountPrices.ForEach(x =>
            //    {
            //        if (x.Id == int.Parse(idValue.ToString()))
            //        {
            //            x.Active = false;
            //        }
            //    }
            //    );
            //    if (!row.IsNewRow)
            //    {
            //        dgv.Rows.Remove(row);
            //        dgv.EndEdit();
            //    }
            //}
        }
    }
}
