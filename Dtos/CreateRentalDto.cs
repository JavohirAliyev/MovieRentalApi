namespace MovieRentalApi.Dtos
{
    public class CreateRentalDto
    {
        public DateTime RentedAt { get; set; } = DateTime.Now;
        public DateTime? ReturnedAt { get; set; }
    }
}
