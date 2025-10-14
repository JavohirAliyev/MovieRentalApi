using Microsoft.EntityFrameworkCore;
using MovieRentalApi.Data;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<MovieRentalDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddOpenApi();

var app = builder.Build();

app.Run();

