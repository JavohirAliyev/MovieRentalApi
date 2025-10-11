namespace MovieRentalApi.Dtos
{
    public class UpdateMovieDto
    {
        public string Title { get; set; } = string.Empty!;
        public string Genre { get; set; } = string.Empty!;
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; } = 0.0m;
    }
}
