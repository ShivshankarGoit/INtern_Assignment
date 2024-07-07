using fileUplood.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fileUplood.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(File_Path file)
        {
            try
            {
                // Check if a file is selected and has content
                if (file != null && file.ContentLength > 0)
                {
                    // Get the file extension
                    string fileExtension = Path.GetExtension(file.FileName);
                    string[] allowedExtensions = { ".pdf", ".doc", ".docx" };

                    // Check if the file extension is allowed
                    if (allowedExtensions.Contains(fileExtension))
                    {
                        // Define the maximum file size (5MB)
                        var maxFileSize = 5 * 1024 * 1024; // 5MB
                        if (file.ContentLength > maxFileSize)
                        {
                            ViewBag.Message = "File size exceeds the maximum limit of 5MB.";
                            return View();
                        }

                        // Save the file to the server
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/App_Data/Uploads"), fileName);
                        file.SaveAs(path);

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