using System.ComponentModel.DataAnnotations;

namespace CarsViewer.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="This filed is requeired")]
        [StringLength(10)]
        [RegularExpression(@"^[^0-9]+$", ErrorMessage = "This is not valid car brand")]
        [UpperCase]
        public string Cars { get; set; }

        [Required(ErrorMessage = "This filed is requeired")]
        [StringLength(10)]
        [RegularExpression(@"^[^0-9]+$", ErrorMessage = "This is not valid color")]     
        [UpperCase]
        public string Color { get; set; }
    }
}