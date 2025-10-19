namespace MovieRentalApi.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty!;
        public List<string> Genre { get; set; } = [];
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; } = 0.0m;
    }
}
