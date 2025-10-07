namespace MovieRentalApi.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty!;
        public string LastName { get; set; } = string.Empty!;
        public int Age { get; set; }
        public bool IsMale { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; } = string.Empty!;
    
    }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
}