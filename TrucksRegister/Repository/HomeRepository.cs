using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrucksRegister.Interfaces;
using TrucksRegister.Models;

namespace TrucksRegister.Repository
{
    public class HomeRepository : IHomeRepository
    {
        private readonly TrucksContext _context;

        public HomeRepository (TrucksContext context)
        {
            _context = context;
        }   

        public async Task<List<Trucks>> GetAllTrucks()
        {
            return await _context.Trucks.ToListAsync();
        }
    }
}
