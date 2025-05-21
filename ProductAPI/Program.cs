
using RepositoryLayer;
using ServicesLayer;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DBsettingConnection");

builder.Services.AddControllers();

builder.Services.AddScoped<IProductRepository> (provider => new ProductRepository(connectionString));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
       policy => policy.WithOrigins("http://localhost:3000")
                        .AllowAnyHeader()
                       .AllowAnyMethod());
});


var app = builder.Build();
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
