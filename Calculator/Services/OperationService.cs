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

        public List<OperationDTO> GetAllOperations()
        {
            var operationsDTO = new List<OperationDTO>();

            if (!DbContext.Database.CanConnect())
            {
                string logMessage = $"Can't connect to database";
                Logger.LogWarning(logMessage);
                return operationsDTO;
            }

            var operations = DbContext.Operations.ToList();
            operations.ForEach(o => operationsDTO.Add(new OperationDTO
            {
                Name = o.Name,
                Alias = o.Alias,
                Sign = o.Sign
            }));
            return operationsDTO;
        }

        public float Calculate(OperationParamsDTO paramsDTO) => paramsDTO.OperationType switch
        {
            OperationType.Sum => Sum(paramsDTO.Param1, paramsDTO.Param2),
            OperationType.Diff => Diff(paramsDTO.Param1, paramsDTO.Param2)
        };

        private float Sum(float a, float b) => a + b;
        private float Diff(float a, float b) => a - b;
    }
}
