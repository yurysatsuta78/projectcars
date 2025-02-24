using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using projectcars;
using projectcars.Interfaces.Auth;
using projectcars.Interfaces.Repositories;
using projectcars.Interfaces.Services;
using projectcars.Interfaces.UnitsOfWork;
using projectcars.MiddleWare;
using projectcars.Repositories;
using projectcars.Services;
using projectcars.UnitsOfWork;
using SixLabors.ImageSharp;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

// Add services to the container.

services.AddApiAuthentication(builder.Configuration);

services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));

services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:5173");
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowCredentials();
    });
});

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
services.AddScoped<ICitiesRepository, CitiesRepository>();
services.AddScoped<IRegionsRepository, RegionsRepository>();
services.AddScoped<IUsersRepository, UsersRepository>();

services.AddScoped<IGoogleDriveService, GoogleDriveService>();
services.AddScoped<IJwtProvider, JwtProvider>();
services.AddScoped<IPasswordHasher, PasswordHasher>();
services.AddScoped<CarsService>();
services.AddScoped<BrandsService>();
services.AddScoped<ModelsService>();
services.AddScoped<GenerationsService>();
services.AddScoped<CitiesService>();
services.AddScoped<RegionsService>();
services.AddScoped<UsersService>();

services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});

services.Configure<FormOptions>(options => 
{

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

app.UseStaticFiles();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.UseWhen(context => context.Request.Path.StartsWithSegments("/Cars/create"), 
    builder => 
    {
        var serviceScopeFactory = app.Services.GetService<IServiceScopeFactory>();
        var scope = serviceScopeFactory?.CreateScope();
        var repository = scope?.ServiceProvider.GetService<IGenerationsRepository>();
        builder.UseMiddleware<CarCreateValidator>(repository);
    });
//app.UseMiddleware<CarCreateValidator>(app.Services.GetService<IServiceScopeFactory>().CreateScope().ServiceProvider.GetService<IGenerationsRepository>());

app.MapControllers();

app.Run();
