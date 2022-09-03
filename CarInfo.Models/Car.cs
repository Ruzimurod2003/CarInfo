using System.ComponentModel.DataAnnotations;

namespace CarInfo.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        [Required]
        public string Produccer { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public long Price { get; set; }
    }
}
