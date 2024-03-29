using Calculator.Backend.Data;
using Calculator.Backend.Loggers;
using Calculator.Backend.Services;
using Calculator.Backend.Services.Interfaces;
using Calculator.Backend.HealthCheckers;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

InitLogger(builder);
InitServices(builder);

var app = builder.Build();

app.UseCors(builder =>
{
    builder.AllowAnyOrigin();
    builder.AllowAnyHeader();
    builder.AllowAnyMethod();
});
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapHealthChecks(
    pattern: "/ping",
    options: new HealthCheckOptions
    {
        ResponseWriter = HealthCheckResponse.WriteResponse
    });
app.Run();

void InitLogger(WebApplicationBuilder builder)
{
    string loggerFileName = "logger.txt";
    string loggerDirPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
    string loggerFullPath = Path.Combine(loggerDirPath, loggerFileName);

    builder.Logging.AddFile(loggerFullPath);
}

void InitServices(WebApplicationBuilder builder)
{
    string dbConnectionString = builder.Configuration.GetConnectionString("CalculatorDB");

    builder.Services.AddTransient<IOperationService, OperationService>();
    builder.Services.AddTransient<IHistoryService, HistoryService>();
    builder.Services.AddHealthChecks()
        .AddNpgSql(dbConnectionString);
    builder.Services.AddCors();
    builder.Services.AddControllers();
    builder.Services.AddDbContext<CalculatorDataContext>(
        o => o.UseNpgsql(dbConnectionString));
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}