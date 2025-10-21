namespace MovieRentalApi.Dtos
{
    public class UpdateMovieDto
    {
        public string Title { get; set; } = string.Empty!;
        public List<string> Genre { get; set; } = new List<string>();
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; } = 0.0m;
    }
}
