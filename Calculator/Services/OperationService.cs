using Calculator.Backend.Data;
using Calculator.Backend.Data.Enums;
using Calculator.Backend.Data.Models.DTO;
using Calculator.Backend.Data.Models.Entities;
using Calculator.Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Calculator.Backend.Services
{
    public class OperationService : IOperationService
    {
        public CalculatorDataContext DbContext { get; set; }
        public ILogger<HistoryService> Logger { get; set; }

        public OperationService(CalculatorDataContext dbContext, ILogger<HistoryService> logger)
        {
            DbContext = dbContext;
            Logger = logger;
        }

        public List<OperationDTO>? GetAllOperations()
        {
            if (!DbContext.Database.CanConnect())
            {
                string logMessage = $"Can't connect to database";
                Logger.LogWarning(logMessage);
                return null;
            }

            var operationsDTO = new List<OperationDTO>();
            var operations = DbContext.Operations.ToList();
            operations.ForEach(o => operationsDTO.Add(new OperationDTO
            {
                Name = o.Name,
                Alias = o.Alias,
                Sign = o.Sign
            }));
            return operationsDTO;
        }

        public double Calculate(OperationParamsDTO paramsDTO) => paramsDTO.OperationType switch
        {
            OperationType.Sum => Sum(paramsDTO.Param1, paramsDTO.Param2),
            OperationType.Diff => Diff(paramsDTO.Param1, paramsDTO.Param2)
        };

        private double Sum(double a, double b) => a + b;
        private double Diff(double a, double b) => a - b;
    }
}
