namespace MovieRentalApi.Models;

[Flags]
public enum Genre
{
    None = 0,
    Action = 1,
    Comedy = 2,
    Drama = 4,
    Horror = 8,
    SciFi = 16,
    Documentary = 32,
    Genre = 64
}