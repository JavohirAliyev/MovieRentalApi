namespace MovieRentalApi.Dtos
{
    public class UpdateRentalDto
    {
        public DateTime RentedAt { get; set; } = DateTime.Now;
        public DateTime? ReturnedAt { get; set; }
    
    }
}