
using CarDealerAPI.Config;
using CarDealerAPI.Services;
using CarDealerAPI.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Para mostrar los errores de validación de manera personalizada

// Para mostrar los errores de validaciï¿½n de manera personalizada

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState
            .Where(x => x.Value?.Errors.Count > 0)
            .ToDictionary(
                kvp => kvp.Key,
               kvp => kvp.Value?.Errors.Select(e => e.ErrorMessage).ToArray() ?? new string[0]
            );
        return new BadRequestObjectResult(new ValidationErrorResponse(errors));
    };
});

// DB
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConcesionariaDB"));
});



// Services
builder.Services.AddScoped<AutoServices>();

// Mapper
// builder.Services.AddAutoMapper(typeof(Mapping)); no se porque no anda con esta linea
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<Mapping>());

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