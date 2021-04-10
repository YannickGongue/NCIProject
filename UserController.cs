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
    public class UserController : Controller
    {

      StudentController student = new StudentController();

    
      // GET: User
      public ActionResult Index()
      {
            return View("login");
      }

      [HttpGet]
      public ActionResult register()
      {
         return View(new UserAccount());
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult register(UserAccount account)
      {
         
         if (ModelState.IsValid)
         {
            if (GetData(account).Rows.Count == 0)
            {
               account.Password = GetMD5(account.Password);

               using (SqlConnection sqlCon = new SqlConnection(clSetting.connectionString()))
               {
                  sqlCon.Open();

                  String strInsertQuery = "INSERT INTO TBL_USER (Username,UserID,Student_ID,Email,Password)" +
                                          "VALUES(@UserName,@UserID,@Student_ID,@Email,@Password)";
                  SqlCommand sqlcmdManager = new SqlCommand(strInsertQuery, sqlCon);
                  sqlcmdManager.Parameters.AddWithValue("@UserName", account.Username);
                  sqlcmdManager.Parameters.AddWithValue("@UserID", account.User_ID);
                  sqlcmdManager.Parameters.AddWithValue("@Student_ID", account.Student_ID);
                  sqlcmdManager.Parameters.AddWithValue("@Password", account.Password);
                  sqlcmdManager.Parameters.AddWithValue("@Email", account.Email);
                  UserRole(account);
                  sqlcmdManager.ExecuteNonQuery();
               }
               return RedirectToAction("login");
            }
            else
            {
               ViewBag.error = "register failed : this User already exist";
               return View(account);
            }
         }
         return View();
      }

      [HttpGet]
      public ActionResult login()
      {
         return View();
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public RedirectResult login(UserAccount User)
      {
         if (User.Email == null && User.Password == null && User.Username == null)
         {
            ViewBag.error = "Empty felder, you must enter a username, Email and Password";
            return Redirect("/user/Index");
         }
         else
         {
            if (GetData(User).Rows.Count > 0)
            {
               if(Role(User) == "0")
               {
                  return Redirect("/Admin/Index");
               }
               else
               {
                  if (Data(User).Rows.Count > 0)
                  {
                     return Redirect("/Submission/AddSubmission");
                  }
                  else
                  {
                     return Redirect("/student/ProfilTocreate");
                  }
               }             
            }
            else
            {
               ViewBag.error = "Login failed, may be your username or Email or Password are false";
               return Redirect("/user/Index"); ;
            }
         }

      }
      public ActionResult Cancel()
      {
         Session.Clear();
         return RedirectToAction("login");
      }


      public string GetMD5(string str)
      {
         MD5 md5 = new MD5CryptoServiceProvider();
         byte[] fromData = Encoding.UTF8.GetBytes(str);
         byte[] targetData = md5.ComputeHash(fromData);
         string byte2String = null;

         for (int i = 0; i < targetData.Length; i++)
         {
            byte2String += targetData[i].ToString("x2");
         }
         return byte2String;
      }

      public DataTable GetData(UserAccount User)
      {
         DataTable dtFillTable;
         dtFillTable = new DataTable();
         SqlDataAdapter sdaTable;

         using (SqlConnection sqlCon = new SqlConnection(clSetting.connectionString()))
         {
            sqlCon.Open();
            String strSelectQuery = "SELECT Username,Email,Password FROM TBL_USER " +
                                    "WHERE Username = @Username AND Email = @Email AND Password = @Password ";
            sdaTable = new SqlDataAdapter(strSelectQuery, sqlCon);
            sdaTable.SelectCommand.Parameters.AddWithValue("@Username", User.Username);
            sdaTable.SelectCommand.Parameters.AddWithValue("@Password", GetMD5(User.Password));
            sdaTable.SelectCommand.Parameters.AddWithValue("@Email", User.Email);

            sdaTable.Fill(dtFillTable);
         }
         return dtFillTable;
      }

      public DataTable Data(UserAccount User)
      {
         DataTable dtTable;
         dtTable = new DataTable();
         SqlDataAdapter sdaTable;

         using (SqlConnection sqlCon = new SqlConnection(clSetting.connectionString()))
         {
            sqlCon.Open();
            String strSelectQuery = "SELECT ID_Student FROM TBL_STUDENT " +
                                    "WHERE ID_Student = @student_ID";
            sdaTable = new SqlDataAdapter(strSelectQuery, sqlCon);
            sdaTable.SelectCommand.Parameters.AddWithValue("@student_ID", User.Student_ID);

            sdaTable.Fill(dtTable);
         }
         return dtTable;
      }

      public void UserRole(UserAccount user)
      {
         using (SqlConnection sqlCon = new SqlConnection(clSetting.connectionString()))
         {
            sqlCon.Open();

            String strInsertQuery = "INSERT INTO TBL_AspNetUserRole (ID_User,Role_ID)" +
                                    "VALUES(@UserID,@Role_ID)";
            SqlCommand sqlcmdManager = new SqlCommand(strInsertQuery, sqlCon);
            sqlcmdManager.Parameters.AddWithValue("@UserID", user.User_ID);
            sqlcmdManager.Parameters.AddWithValue("@Role_ID", user.Student_ID);         
            sqlcmdManager.ExecuteNonQuery();
         }
      }

      public string Role(UserAccount user)
      {
         object userwert;
         DataTable dtRoleTable;
         dtRoleTable = new DataTable();
         SqlDataAdapter sdaTable;

         using (SqlConnection sqlCon = new SqlConnection(clSetting.connectionString()))
         {
            sqlCon.Open();
            String strSelectQuery = "SELECT Role_ID FROM TBL_AspNetUserRole" +
                                    " WHERE ID_User = @UserId";
            sdaTable = new SqlDataAdapter(strSelectQuery, sqlCon);
            sdaTable.SelectCommand.Parameters.AddWithValue("@UserId", user.User_ID);          
            sdaTable.Fill(dtRoleTable);

           userwert= dtRoleTable.Rows[0][0];
            
         }
         return Convert.ToString(userwert);
      }

   }
}