using GalleryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace GalleryApp.Data
{
    public class DataContext : DbContext
    {
         public DbSet<ImageModel> images {  get; set; }
        public DataContext( DbContextOptions<DataContext> options) : base (options)
        {
            
        }
    }
}
