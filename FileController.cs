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
   public class FileController : Controller,IFile
   {
     
      // GET: File
      
      public void FileUpload( HttpPostedFileBase file)
      {
         if (file != null && file.ContentLength > 0)
            try
            {
               string path = Path.Combine(Server.MapPath("~/Image"),
                                          Path.GetFileName(file.FileName));
               file.SaveAs(path);
               ViewBag.Message = "File uploaded successfully";
            }
            catch (Exception ex)
            {
               ViewBag.Message = "ERROR:" + ex.Message.ToString();
            }
         else
         {
            ViewBag.Message = "You have not specified a file.";
         }
         
      }
   }
}
