using GalleryApp.Data;
using GalleryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace GalleryApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _dataContext;

        public HomeController(ILogger<HomeController> logger,
             DataContext dataContext)
        {
            _logger = logger;
            _dataContext = dataContext;
             
        }

        public ActionResult Index()
        {
           

            return View();
        }


        public ActionResult ImageIndex()
        {

            var image= _dataContext.images.ToList();
           
            return View(image);
        }


        [HttpPost]
        public async Task<ActionResult> Upload(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                var fileName = Path.GetFileName(file.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                // Ensure the uploads folder exists
                Directory.CreateDirectory(uploadsFolder);

                // Save the file
                await using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Create an image model instance
                var image = new ImageModel
                {
                    ImageName = fileName,
                    ImagePath = filePath
                };

                // Save the image record to the database
               _dataContext.images.Add(image);
                await _dataContext.SaveChangesAsync();

                ViewBag.UploadMessage = "File uploaded and saved to database successfully!";
            }
            else
            {
                ViewBag.UploadMessage = "No file uploaded.";
            }

            // Redirect to the Index action to refresh the image list
            return RedirectToAction("ImageIndex");
        }

      


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
