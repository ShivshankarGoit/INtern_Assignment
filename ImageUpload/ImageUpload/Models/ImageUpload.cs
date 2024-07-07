using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ImageUpload.Models
{
    public  class ImageUpload
    {

        [Required]
        [Display(Name = "Upload File")]
        public HttpPostedFileBase File { get; set; }
    }
}