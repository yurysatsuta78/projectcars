using Microsoft.EntityFrameworkCore;
using projectcars;
using projectcars.Interfaces.Repositories;
using projectcars.Interfaces.Services;
using projectcars.Interfaces.UnitsOfWork;
using projectcars.Repositories;
using projectcars.Services;
using projectcars.UnitsOfWork;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

// Add services to the container.

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddScoped<ICarsImageUOW, CarsImageUOW>();
services.AddScoped<IBrandImageUOW, BrandImageUOW>();
services.AddScoped<IGenerationImageUOW, GenerationImageUOW>();

services.AddScoped<ICarsRepository, CarsRepository>();
services.AddScoped<IBrandsRepository, BrandsRepository>();
services.AddScoped<IModelsRepository, ModelsRepository>();
services.AddScoped<IGenerationsRepository, GenerationsRepository>();
services.AddScoped<IImagesRepository, ImagesRepository>();

services.AddScoped<IImagesService, ImagesService>();
services.AddScoped<IGoogleDriveService, GoogleDriveService>();
services.AddScoped<CarsService>();
services.AddScoped<BrandsService>();
services.AddScoped<ModelsService>();
services.AddScoped<GenerationsService>();

services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});

services.AddAutoMapper(typeof(DBMappings));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
