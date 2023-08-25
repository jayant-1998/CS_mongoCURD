using ProductsWithMongo.DAL.DBContexts;
using ProductsWithMongo.DAL.Repos.Implementations;
using ProductsWithMongo.DAL.Repos.Interfaces;
using ProductsWithMongo.Services.Implementations;
using ProductsWithMongo.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
        optional: true,
        reloadOnChange: true);

// Add services to the container.
builder.Services.Configure<ApplicationDBContext>(
builder.Configuration.GetSection("ProductDatabase"));

builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
