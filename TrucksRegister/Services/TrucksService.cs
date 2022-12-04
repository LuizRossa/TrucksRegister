using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrucksRegister.Interfaces;
using TrucksRegister.Models;
using TrucksRegister.Repository;

namespace TrucksRegister.Services
{
    public class TrucksService : ITrucksService
    {
        private readonly ITrucksRepository _truckRepository;

        public TrucksService(ITrucksRepository truckRepository)
        {
            _truckRepository = truckRepository; 
        }

        public async Task<List<Trucks>> GetAllTrucks()
        {
            var v = await _truckRepository.GetAllTrucks();

            return v;
        }

        public async Task<Trucks> GetTrucksFirstOrDefault(int? id)
        {
            var result = await _truckRepository.GetTrucksFirtsOrDefault(id);
            
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
            _truckRepository.NewTruck(truck);   
        }

        public async Task SaveChanges()
        {
            await _truckRepository.SaveChanges();
        }

        public async Task<Trucks> FindById(int? id)
        {
            var result = await _truckRepository.Find(id);

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
            _truckRepository.UpdateTruck(truck);
        }

        public async Task RemoveTruck(Trucks truck)
        {
            _truckRepository.RemoveTruck(truck);
        }

        public bool ExistTruck(int id)
        {
            return _truckRepository.ExistTruck(id);
        }
    }
}
