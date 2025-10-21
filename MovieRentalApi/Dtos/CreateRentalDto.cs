using System.ComponentModel.DataAnnotations;
namespace MovieRentalApi.Dtos
{
    public class CreateRentalDto
    {
        [Required]
        public DateTime RentedAt { get; set; } = DateTime.Now;
        [Required]
        public DateTime? ReturnedAt { get; set; }
    }
}
