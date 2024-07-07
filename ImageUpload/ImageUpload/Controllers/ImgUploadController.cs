using ImageUpload.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageUpload.Controllers
{
    public class ImgUploadController : Controller
    {
        // GET: ImgUpload
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost] 
        [ValidateAntiForgeryToken]
        public ActionResult Upload(ImageUpload model)
        {
           

            if (ModelState.IsValid)
            {
                var file = model.File;

                if (file != null && file.ContentLength > 0)
                {
                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                    var extension = Path.GetExtension(file.FileName).ToLower();

                    if (allowedExtensions.Contains(extension))
                    {
                        if (file.ContentLength <= 5 * 1024 * 1024) // 5 MB limit
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var savePath = Path.Combine(Server.MapPath("~/wwwroot/Images"), fileName);
                            file.SaveAs(savePath);

                            model.Message = "Image uploaded successfully!";
                        }
                        else
                        {
                            model.Message = "File size exceeds the maximum limit of 5MB.";
                        }
                    }
                    else
                    {
                        model.Message = "Only .jpg, .jpeg, .png, and .gif files are allowed.";
                    }
                }
                else
                {
                    model.Message = "Please select an image to upload.";
                }
            }

            return View("Index", model);
        }

        public ActionResult ViewImages()
        {
            var imagesPath = Server.MapPath("~/wwwroot/Images");
            var imageFiles = Directory.GetFiles(imagesPath);

            return View(imageFiles);
        }
    }
}