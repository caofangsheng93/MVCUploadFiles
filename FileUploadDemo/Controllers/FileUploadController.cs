using FileUploadDemo.Filters;
using FileUploadDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileUploadDemo.Controllers
{
    public class FileUploadController : Controller
    {

        // GET: Gallery
        public ActionResult Index()
        {
            var context = new UploadFilesEntities();

            var model = context.Galleries.Select(c => new GalleryViewModel
            {
                Id = c.Id,
                Title = c.Title,
                IsActive = c.IsActive,
                DateCreated = c.DateCreated,
                DateUpdated = c.DateUpdated
            }).Where(c => c.IsActive).ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [UploadFile]
        public ActionResult Create([Bind(Include = "Title,IsActive")]GalleryViewModel model,
            List<FileInformation> wahaha)
        {
            if (wahaha.Count == 0)
            {
                ModelState.AddModelError("", "Please upload a file");
            }
            if (ModelState.IsValid)
            {
                var file = wahaha.FirstOrDefault();
               // var file = uploadedFiles.FirstOrDefault();
                if (file != null)
                {
                    var context = new UploadFilesEntities();

                    var gallery = new Gallery()
                    {
                        Title = model.Title,
                        BinaryData = file.BinaryData,
                        MimeType = file.ContentType,
                        FileName = file.FileName,
                        IsActive = true,
                        DateCreated = DateTime.UtcNow,
                        DateUpdated = DateTime.UtcNow

                    };
                    context.Galleries.Add(gallery);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        public ActionResult GetFile(int id)
        {
            var context = new UploadFilesEntities();
            var fileInfo = context.Galleries.Find(id);
            return File(fileInfo.BinaryData, fileInfo.MimeType);
        }
    }
}