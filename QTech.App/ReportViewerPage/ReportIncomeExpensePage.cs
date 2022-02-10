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
using QTech.Component.Interfaces;
using System.Data;
using FastMember;
using QTech.ReportModels;
using Storm.CC.Report.Helpers;
using QTech.Component.Helpers;
using QTech.Base.Enums;
using QTech.Base.Models;
using System.Data.SqlClient;
using QTech.Reports;

namespace QTech.ReportViewerPage
{
    public partial class ReportIncomeExpensePage : ExPage
    {
        public ReportIncomeExpensePage()
        {
            InitializeComponent();
            Bind();
            this.SetTheme(this.Controls, null);
            InitEvent();
        }
        private void Bind()
        {
            var maxDate = DateTime.Now;
            dtpPeroid.CustomDateRang = CustomDateRang.None;
            var peroids = ExReportDatePicker.GetPeroids(maxDate);
            var customPeroid = ExReportDatePicker.GetPeriod(dtpPeroid.CustomDateRang, maxDate);
            dtpPeroid.SetMaxDate(maxDate);
            dtpPeroid.Items.AddRange(peroids.ToArray());
            dtpPeroid.Items.Add(customPeroid);
            dtpPeroid.SetSelectePeroid(DatePeroid.Today);

            cboMiscellaneousType.SetDataSource<MiscellaneousType>();
        }
        private void InitEvent()
        {
        }
        private async void CboMiscellaneousType_SelectedIndexChanged(object sender, EventArgs e)
        {
            await Search();
        }
        public async void Reload()
        {
            await Search();
        }
        public async Task Search()
        {
            await View();
        }
        public async Task View()
         {
            if (inValid() || btnView.Executing)
            {
                return;
            }
            var D1 = dtpPeroid.SelectedPeroid.FromDate.Date;
            var D2 = dtpPeroid.SelectedPeroid.ToDate;
            var MiscellaneousType = (int)cboMiscellaneousType.SelectedValue;
            
            var IncomeExpense = await btnView.RunAsync(() =>
            {
                var result = ReportLogic.Instance.ExecuteDynamicReport("ReportIncomeExpense",
                        new SqlParameter{ ParameterName="D1", Value=D1},
                        new SqlParameter{ ParameterName="D2", Value=D2},
                        new SqlParameter{ ParameterName= "MiscellaneousType", Value= MiscellaneousType }
                    
                    );
                return result;
            });
            IncomeExpense.TableName = "IncomeExpense";

            var reportHeader = new Dictionary<string, object>()
            {
                { "D1" , dtpPeroid.SelectedPeroid.FromDate.Date.ToString(FormatHelper.DateTime[FormatHelper.DateTimeType.ShortDate]) },
                { "D2" , dtpPeroid.SelectedPeroid.ToDate.Date.ToString(FormatHelper.DateTime[FormatHelper.DateTimeType.ShortDate]) },
            };
            
            var incomeExpensesDts = new List<DataTable>();
            incomeExpensesDts.Add(IncomeExpense);

            var report = await btnView.RunAsync(() =>
            {
                var r = ReportHelper.Instance.Load(nameof(ReportGeneralInOut), incomeExpensesDts, reportHeader);
                r.SummaryInfo.ReportTitle = BaseResource.IncomeOutcome;
                return r;
            });

            if (report != null)
            {
                viewer.View(report);
            }
        }
        private bool inValid()
        {
            if (!dtpPeroid.IsSelected())
            {
                return true;
            }
            return false;
        }
        private void dig_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.O))
            {
                 View();
                return true;
            }
            else if (keyData == Keys.F3)
            {
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            View();
        }
    }
}
