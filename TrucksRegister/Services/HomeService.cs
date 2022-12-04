using System.Collections.Generic;
using System.Threading.Tasks;
using TrucksRegister.Interfaces;
using TrucksRegister.Models;

namespace TrucksRegister.Services
{
    public class HomeService : IHomeService
    {
        private readonly IHomeRepository _homeRepository;
        public HomeService(IHomeRepository  homeRepository) 
        { 
            _homeRepository = homeRepository;   
        }

        public List<string> GetAll() { return new List<string>() { "teste"};}

        public async Task<List<Trucks>> GetAllTrucks()
        {
            var v = await _homeRepository.GetAllTrucks();

            return v;
        }
    }
}
