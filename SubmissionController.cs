using NCIProject.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NCIProject.DBModel;

namespace NCIProject.Controllers
{
    public class SubmissionController : Controller
    {
        // GET: Submission
       public ActionResult Index()
       {
         return View();
       }

      [HttpGet]
      public ActionResult AddSubmission()
      {
         return View();
      }

      [HttpPost]
      public ActionResult AddSubmission(Submission sub)
      {
         FileController file = new FileController();

         file.FileUpload(sub.File_ID);

         
         using (SqlConnection sqlCon = new SqlConnection(clSetting.connectionString()))
            {
               
               string strInsertQuery = "INSERT INTO TBL_SUBMISSION (ID_Student,Linkedlin_URL,Short_Desc,Long_Desc,Tech,ID_File,Projekt_Title) " +
                                       "VALUES (@student,@linkedlin,@short_Desc,@long_Desc,@tech,@projektTitle,@File)";
               sqlCon.Open();
               SqlCommand sqlcmdManager_1 = new SqlCommand(strInsertQuery, sqlCon);
               sqlcmdManager_1.Parameters.AddWithValue("@student", sub.Student_ID);
               sqlcmdManager_1.Parameters.AddWithValue("@linkedlin", sub.Linkedlin);
               sqlcmdManager_1.Parameters.AddWithValue("@short_Desc",sub.Shortdesc);
               sqlcmdManager_1.Parameters.AddWithValue("@long_Desc", sub.Longdesc);
               sqlcmdManager_1.Parameters.AddWithValue("@tech", sub.Tech);
               sqlcmdManager_1.Parameters.AddWithValue("@File", sub.File_ID);
               sqlcmdManager_1.Parameters.AddWithValue("@projektTitle", sub.Projektfile);
              
                 
                sqlcmdManager_1.ExecuteNonQuery();
       
      
               sqlCon.Close();
              
            }
         return View();
      }
                        

      [HttpGet]
        public ActionResult Edit()
        {
         return View();
        }
        
        [HttpPost]
        public ActionResult Edit( Submission sbstudent)
        {
         return View();
        }
   }
}