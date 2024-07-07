using FileUploadPurpose.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileUploadPurpose.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            
            return View();
        }
         
        public ActionResult   Upload() 
        {

            return View("Upload");
        }


        [HttpPost]

        public ActionResult Upload(Employee employee )
        {
            try
            {
                // Handle file upload logic here
                if (employee.Files != null && employee.Files.ContentLength > 0)
                {
                    string fileExtension = Path.GetExtension(employee.Files.FileName);
                    string[] allowedExtensions = { ".pdf", ".doc", ".docx" };

                    if (allowedExtensions.Contains(fileExtension))
                    {
                        var maxFileSize = 5 * 1024 * 1024; // 5MB
                        if (employee.Files.ContentLength > maxFileSize)
                        {
                            ViewBag.Message = "File size exceeds the maximum limit of 5MB.";
                            return View();
                        }


                        // Save the file to the server or perform any other necessary operations
                        var fileName = Path.GetFileName(employee.Files.FileName);
                        var path = Path.Combine(Server.MapPath("~/App_Data/Uploads"), fileName);
                        employee.Files.SaveAs(path);

                        // Display success message
                        ViewBag.Message = "File uploaded successfully!";
                    }
                    else
                    {
                        ViewBag.Message = "Only pdf, doc and docx files are allowed.";

                    }
                }
                else
                {
                    // Display error message
                    ViewBag.Message = "Please select a file to upload.";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            return View();
        }
    }
}