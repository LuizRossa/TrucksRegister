using System.Collections.Generic;
using System.Threading.Tasks;
using TrucksRegister.Models;

namespace TrucksRegister.Interfaces
{
    public interface ITrucksService
    {
        Task<List<Trucks>> GetAllTrucks();
        Task<Trucks> GetTrucksFirstOrDefault(int? id);
        void NewTruck(Trucks truck);
        Task SaveChanges();
        Task<Trucks> FindById(int? id);
        void UpdateTruck(Trucks truck);
        Task RemoveTruck(Trucks truck);
        bool ExistTruck(int id);
    }
}
