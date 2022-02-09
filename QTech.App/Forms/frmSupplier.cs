﻿using QTech.Base;
using QTech.Base.Helpers;
using QTech.Base.Models;
using QTech.Component;
using QTech.Component.Helpers;
using QTech.Db.Logics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTech.Forms
{
    public partial class frmSupplier : ExDialog, IDialog
    {
        public Supplier Model { get; set; }

        public frmSupplier(Supplier model, GeneralProcess flag)
        {
            InitializeComponent();

            this.Model = model;
            this.Flag = flag;

            BindAsync();
            InitEvent();
            this.SetTheme(this.Controls, null);

        }
        public GeneralProcess Flag { get; set; }

        public void BindAsync()
        {
            colName.Visible = true;
            colName.Width = 100;

            Read();
        }
        public void InitEvent()
        {
            this.SetEnabled(Flag != GeneralProcess.Remove && Flag != GeneralProcess.View);
            this.MaximizeBox = false;
            this.Text = Flag.GetTextDialog(Base.Properties.Resources.Suppliers);
            txtNote.RegisterPrimaryInput();
            txtPhone.RegisterInputPhone();

        }
        public bool InValid()
        {
            if (!txtName.IsValidRequired(lblName.Text) 
              | txtPhone.IsValidRequired(lblPhone_.Text))
            {
                return true;
            }
            return false;
        }
        public void Read()
        {
            txtName.Text = Model.Name;
            txtPhone.Text = Model.Phone;
            txtNote.Text = Model.Note;
        }
        public async void Save()
        {
            if (Flag == GeneralProcess.View)
            {
                Close();
            }

            if (InValid()) { return; }
            Write();

            if (Flag == GeneralProcess.Add)
            {
                var isExist = await btnSave.RunAsync(() => SupplierLogic.Instance.IsExistsAsync(Model));
                if (isExist == true)
                {
                    txtName.IsExists(lblName.Text);
                    return;
                }
            }
          

            var result = await btnSave.RunAsync(() =>
            {
                if (Flag == GeneralProcess.Add)
                {
                    return SupplierLogic.Instance.AddAsync(Model);
                }
                else if (Flag == GeneralProcess.Update)
                {
                    return SupplierLogic.Instance.UpdateAsync(Model);
                }
                else if (Flag == GeneralProcess.Remove)
                {
                    return SupplierLogic.Instance.RemoveAsync(Model);
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
            Model.Phone = txtPhone.Text;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.E))
            {
                btnChangeLog.PerformClick();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void btnChangeLog_Click_1(object sender, EventArgs e)
        {
            ViewChangeLog();
        }
    }
}
