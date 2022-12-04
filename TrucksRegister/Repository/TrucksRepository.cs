using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrucksRegister.Interfaces;
using TrucksRegister.Models;

namespace TrucksRegister.Repository
{
    public class TrucksRepository : ITrucksRepository
    {
        private readonly TrucksContext _context;

        public TrucksRepository(TrucksContext context)
        {
            _context = context; 
        }

        public async Task<List<Trucks>> GetAllTrucks()
        {
            return await _context.Trucks.ToListAsync();
        }

        public async Task<Trucks> GetTrucksFirtsOrDefault(int? id)
        {
            var result = await _context.Trucks.FirstOrDefaultAsync(m => m.Id == id);

            if (result == null)
            {
                throw new Exception("id nulo ou inexistente");
            }
            else
            {
                return result;
            }
        }

        public void NewTruck(Trucks truck)
        {
             _context.Trucks.Add(truck);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Trucks> Find(int? id)
        {
            var result = await _context.Trucks.FindAsync(id);

            if (result == null)
            {
                throw new Exception("id nulo ou inexistente");
            }
            else
            {
                return result;
            }
        }

        public void UpdateTruck(Trucks truck)
        {
            _context.Update(truck);
        }

        public async Task RemoveTruck(Trucks truck)
        {
           _context.Trucks.Remove(truck);
        }

        public bool ExistTruck(int id)
        {
            return _context.Trucks.Any(e => e.Id == id);
        }
    }
}
