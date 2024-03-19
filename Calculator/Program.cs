using Calculator.Backend.Data;
using Calculator.Backend.Services;
using Calculator.Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<ICalculatorService, CalculatorService>();
builder.Services.AddTransient<IHistoryService, HistoryService>();

builder.Services.AddCors();


builder.Services.AddControllers();

builder.Services.AddDbContext<CalculatorDataContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("CalculatorDB")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(builder =>
{
    builder.AllowAnyOrigin();
    builder.AllowAnyHeader();
    builder.AllowAnyMethod();
});

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
