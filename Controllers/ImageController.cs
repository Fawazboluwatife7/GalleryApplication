using GalleryApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace GalleryApp.Controllers
{
    public class ImageController : Controller
    {
        private readonly DataContext _context;
        public ImageController(DataContext dataContext)
        {
            _context = dataContext;
        }

        public IActionResult Index()
        {
            
            return View();
        }
    }
}
