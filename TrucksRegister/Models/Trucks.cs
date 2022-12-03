using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace TrucksRegister.Models
{
    public class Trucks
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public int ManufacturingYear { get; set; }

        [Required]
        public int ModelYear { get; set; }
    }
}
