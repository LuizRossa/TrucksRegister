using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrucksRegister.Models;

namespace TrucksRegister.Interfaces
{
    public interface IHomeService
    {
        List<string> GetAll();
        Task<List<Trucks>> GetAllTrucks();
    }
}
