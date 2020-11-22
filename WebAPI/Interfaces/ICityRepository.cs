using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface ICityRepository
    {
         Task<IEnumerable<City>> GetCitiesAsync();

         //Not asynchronous because the method is adding City to memory only
         void AddCity(City city);

         void DeleteCity(int cityId);

        //This should be in UnitOfWork
        //  Task<bool> SaveAsync();
    }
}