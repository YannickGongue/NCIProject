using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using NCIProject.Models;


namespace NCIProject.Controllers
{
    public class StudentController : Controller
    {
      
      // GET: Student
      public ActionResult Index()
      {
           DataTable dtFillTable;
           dtFillTable = new DataTable();
           SqlDataAdapter sdaTable;

          using (SqlConnection sqlCon = new SqlConnection(clSetting.connectionString()))
          {
             sqlCon.Open();
             String strSelectQuery = "SELECT * FROM TBL_STUDENT ";                                
             sdaTable = new SqlDataAdapter(strSelectQuery, sqlCon);
              
             sdaTable.Fill(dtFillTable);
          }
        
          return View(dtFillTable);
      }

      [HttpGet]
      public ActionResult ProfilTocreate()
      {
         return View();
      }
      [HttpPost]
      public RedirectResult ProfilTocreate(StudentModel Student)
      {
         using (SqlConnection sqlCon = new SqlConnection(clSetting.connectionString()))
         {
            sqlCon.Open();

            String strInsertQuery ="INSERT INTO TBL_STUDENT (Firstname,Lastname,ID_student,Supervisor_ID,Stream_ID,Course_ID)" +
                                   "VALUES(@firstname,@lastname,@student_iD,@supervisor_ID,@course_ID,@stream_ID)";

            SqlCommand sqlcmdManager = new SqlCommand(strInsertQuery, sqlCon);

            sqlcmdManager.Parameters.AddWithValue("@firstname", Student.Firstname);
            sqlcmdManager.Parameters.AddWithValue("@lastname", Student.Lastname);
            sqlcmdManager.Parameters.AddWithValue("@student_iD", Student.Matrikelnummer);          
            sqlcmdManager.Parameters.AddWithValue("@supervisor_ID", Student.Supervisor_ID);
            sqlcmdManager.Parameters.AddWithValue("@stream_ID", Student.Stream_ID);
            sqlcmdManager.Parameters.AddWithValue("@course_ID", Student.Course_ID);
 
            sqlcmdManager.ExecuteNonQuery();

            ViewBag.Message = " your profil is created and you can add a Submission";
         }

         return Redirect("/Submission/AddSubmission");
      }

         
      public ActionResult logout()
      {
         return View();
      }
   } 
}