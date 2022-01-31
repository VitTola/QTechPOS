using EasyServer.Domain.SearchModels;
using QTech.Base;
using QTech.Base.Enums;
using QTech.Base.Models;
using QTech.Base.OutFaceModels;
using QTech.Base.SearchModels;
using QTech.Component;
using QTech.ReportModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseResource = QTech.Base.Properties.Resources;
namespace QTech.Db.Logics
{
    public class ReportLogic : DbLogic<Sale, ReportLogic>
    {
        public  DataTable ExecuteDynamicReport(string Sql, params SqlParameter[] parameters)
        {
            var sb = new StringBuilder();
            var dt = new System.Data.DataTable();
            var cn = _db.Database.Connection;
            using (var cmd = cn.CreateCommand())
            {
                if (cn.State == System.Data.ConnectionState.Closed) { cn.Open(); }
                cmd.CommandText = Sql;
                var timeout = _db.Database.Connection.ConnectionTimeout;
                if (timeout == 0)
                {
                    cmd.CommandTimeout = (int)timeout;
                }
                //if (parameters.Any())
                //{
                //    cmd.Parameters.AddRange(parameters);
                //}
                dt.Load( cmd.ExecuteReader());
            }
            if (cn.State == System.Data.ConnectionState.Open) { cn.Close(); }

            return dt;
        }
    }
}
