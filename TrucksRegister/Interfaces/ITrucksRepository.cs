using System.Collections.Generic;
using System.Threading.Tasks;
using TrucksRegister.Models;

namespace TrucksRegister.Interfaces
{
    public interface ITrucksRepository
    {
        Task<List<Trucks>> GetAllTrucks();
        Task<Trucks> GetTrucksFirtsOrDefault(int? id);
        void NewTruck(Trucks truck);
        Task SaveChanges();
        Task<Trucks> Find(int? id);
        void UpdateTruck(Trucks truck);
        Task RemoveTruck(Trucks truck);
        bool ExistTruck(int id);
    }
}
