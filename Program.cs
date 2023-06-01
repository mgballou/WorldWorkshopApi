using WorldWorkshopApi.Models;
using WorldWorkshopApi.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.Configure<WorldWorkshopDatabaseSettings>(
    builder.Configuration.GetSection("WorldWorkshopDatabase")
);

builder.Services.AddSingleton<WorldsService>();


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
