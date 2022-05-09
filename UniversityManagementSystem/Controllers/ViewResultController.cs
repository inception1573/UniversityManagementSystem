using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security.DataHandler;
using Microsoft.Reporting.WebForms;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Report;
namespace UniversityManagementSystem.Controllers
{
    public class ViewResultController : Controller
    {
        EnrollCourseManager manager = new EnrollCourseManager();
        StudentResultManager resultManager = new StudentResultManager();
        public ActionResult Index()
        {
            ViewBag.studentRegnos = manager.GetAllStudentRegNo();
            return View();
        }
        [HttpPost]
        public ActionResult Index(int StudentId)
        {
            ViewBag.studentRegnos = manager.GetAllStudentRegNo();
            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;
            //DataSet dsGrpSum, dsActPlan, dsProfitDetails,
            //    dsProfitSum, dsSumHeader, dsDetailsHeader, dsBudCom = null;

            ReportViewer viewer = new ReportViewer();
            string path = Path.Combine(Server.MapPath("~/Report/"), "StudentResultReport.rdlc");
            if (System.IO.File.Exists(path))
            {
                viewer.LocalReport.ReportPath = path;
            }
            else
            {
                return View();
            }
            DataTable tb= resultManager.GetData(StudentId);
            ReportDataSource rds = new ReportDataSource("DataSet1", tb);
           
            viewer.LocalReport.Refresh();
            viewer.LocalReport.ReportPath = "Report/StudentResultReport.rdlc"; //This is your rdlc name.
           // viewer.LocalReport.SetParameters(param);
            viewer.LocalReport.DataSources.Add(rds); // Add  datasource here         
            byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
            // byte[] bytes = viewer.LocalReport.Render("Excel", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
            // Now that you have all the bytes representing the PDF report, buffer it and send it to the client.          
            // System.Web.HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename= filename" + "." + extension);
            Response.OutputStream.Write(bytes, 0, bytes.Length); // create the file  
            Response.Flush(); // send it to the client to download  
            Response.End();
            return View();
        }

        public JsonResult StudentInfoWithEnrollCourse(int studentId)
        {
            var studentEnrollCourse = resultManager.GetStudentResult(studentId);
            return Json(studentEnrollCourse, JsonRequestBehavior.AllowGet);
        }
    }
}