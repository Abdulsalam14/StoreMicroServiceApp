
using Microsoft.EntityFrameworkCore;
using SearchService.DataContext;
using SearchService.Repository;
using SearchService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.WebHost.UseUrls("https://*:10603;");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ISearchRepository, SearchRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

var con = builder.Configuration.GetConnectionString("myconn");
builder.Services.AddDbContext<BarcodeContext>(opt =>
{
    opt.UseSqlServer(con);
});

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
