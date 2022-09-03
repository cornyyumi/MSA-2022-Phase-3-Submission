using System.Text.Json.Serialization;
using MSA_Phase_3.Domain.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddScoped<IProjRepo, ProjRepo>();
builder.Services.AddDbContext<ProjDbContext>(
    options => options.UseSqlite(builder.Configuration["DataConnection"]));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient("weatherman", configureClient: client =>
{
    client.BaseAddress = new Uri(@"https://api.openweathermap.org");
});

builder.Services.AddHttpClient("OpenLib", configureClient: client =>
{
    client.BaseAddress = new Uri(@"https://openlibrary.org");
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
