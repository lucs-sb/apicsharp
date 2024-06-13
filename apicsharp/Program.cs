using apicsharp.Infra;
using apicsharp.Model.Category;
using apicsharp.Model.Product;
using apicsharp.Model.Stock;
using apicsharp.Model.Supplier;
using apicsharp.Repository;
using apicsharp.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductService, ProductService>()
    .AddScoped<IProductRepository, ProductRepository>()
    .AddScoped<ICategoryService, CategoryService>()
    .AddScoped<ICategoryRepository, CategoryRepository>()
    .AddScoped<ISupplierService, SupplierService>()
    .AddScoped<ISupplierRepository, SupplierRepository>()
    .AddScoped<IStockService, StockService>()
    .AddScoped<IStockRepository, StockRepository>()
    .AddDbContext<DatabaseContext>(opt => opt.UseInMemoryDatabase("ApiCshap"));

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

static void Main() {}
