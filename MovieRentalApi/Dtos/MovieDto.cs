using System.ComponentModel.DataAnnotations;
namespace MovieRentalApi.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty!;
        [Required]
        public List<string> Genre { get; set; } = [];
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; } = 0.0m;
    }
}
