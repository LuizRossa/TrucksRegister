using System.Collections.Generic;

namespace TrucksRegister.Models
{
    public class TruckModel
    {
        public int Id { get; set; }
        public string Model { get; set; }

        public List<TruckModel> getAllTruckModels()
        {
            List<TruckModel> truckModels = new List<TruckModel>()
            {
                new TruckModel() { Id = 1, Model = "FH"},
                new TruckModel() { Id = 2, Model = "FM"}
            };
            return truckModels;
        }
    }
}
