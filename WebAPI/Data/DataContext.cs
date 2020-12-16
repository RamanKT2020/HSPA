using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class DataContext: DbContext
    {
      //public DataContext() {} // you get a different error with this
      //https://www.youtube.com/watch?v=j1e6Z-7QNpk&lc=Ugz3TZMlrg6t67COxnh4AaABAg.9G5_T2ViJlC9HK8dkiyOea
      public DataContext(DbContextOptions<DataContext> options) : base(options) { }  

      public DbSet<City> Cities { get; set; }
    }
}