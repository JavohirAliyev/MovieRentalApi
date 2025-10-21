using System.ComponentModel.DataAnnotations;
namespace MovieRentalApi.Dtos
{
    public class CreateCustomerDto
    {
        [Required]
        public string FirstName { get; set; } = string.Empty!;
        public string LastName { get; set; } = string.Empty!;
        [Required]
        public int Age { get; set; }
        public bool IsMale { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; } = string.Empty!;
    }
}
