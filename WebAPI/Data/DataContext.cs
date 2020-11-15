using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class DataContext: DbContext
    {
      //public DataContext() {} // you get a different error with this
      public DataContext(DbContextOptions<DataContext> options) : base(options) { }  

      public DbSet<City> Cities { get; set; }
    }
}