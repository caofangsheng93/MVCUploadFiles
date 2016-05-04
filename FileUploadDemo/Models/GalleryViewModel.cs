using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FileUploadDemo.Models
{
    public class GalleryViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter The Title")]
        public string Title { get; set; }
        [Display(Name = "Active")]
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public byte[] BinaryData { get; set; }
        public string MimeType { get; set; }
    }
}