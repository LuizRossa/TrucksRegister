using System.Collections.Generic;
using System.Threading.Tasks;
using TrucksRegister.Models;

namespace TrucksRegister.Interfaces
{
    public interface IHomeRepository
    {
        Task<List<Trucks>> GetAllTrucks();
    }
}
