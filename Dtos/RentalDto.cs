using System.ComponentModel.DataAnnotations;
namespace MovieRentalApi.Dtos
{
    public class RentalDto
    {
        public int Id { get; set; }
        [Required]
        public DateTime RentedAt { get; set; } = DateTime.Now;
        [Required]
        public DateTime? ReturnedAt { get; set; }
    }
}
