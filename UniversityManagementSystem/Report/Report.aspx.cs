using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using UniversityManagementSystem.BLL;

namespace UniversityManagementSystem.Report
{
    public partial class Report : System.Web.UI.Page
    {
        StudentResultManager manager=new StudentResultManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void ShowReport(int studentId)
        {
            //reset
            rptViewer.Reset();
            //datasourse
            DataTable dt = manager.GetData(studentId);
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            rptViewer.LocalReport.DataSources.Add(rds);
            rptViewer.LocalReport.ReportPath = "StudentResultReport.rdlc";
            //refresh
            rptViewer.LocalReport.Refresh();
        }
    }
}