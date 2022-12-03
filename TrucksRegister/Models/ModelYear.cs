using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;

namespace TrucksRegister.Models
{
    public class ModelYear
    {
        public int Id { get; set; }
        public int Year { get; set; }

        public List<ModelYear> getAllModelYears() 
        { 
            List<ModelYear> modelYears = new List<ModelYear>() { 
                new ModelYear{ Id = 1, Year = DateTime.Today.Year},
                new ModelYear{ Id = 2, Year = DateTime.Today.Year + 1}
            };

            return modelYears;
        }
    }
}
