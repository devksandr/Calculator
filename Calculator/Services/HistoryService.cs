using Calculator.Backend.Data;
using Calculator.Backend.Data.Models.Entities;
using Calculator.Backend.Data.Models.ServiceModels.History;
using Calculator.Backend.Services.Interfaces;

namespace Calculator.Backend.Services
{
    public class HistoryService : IHistoryService
    {

        public CalculatorDataContext DbContext { get; set; }
        public ILogger<HistoryService> Logger { get; set; }

        public HistoryService(CalculatorDataContext dbContext, ILogger<HistoryService> logger)
        {
            DbContext = dbContext;
            Logger = logger;
        }

        public void GetAll()
        {
            throw new NotImplementedException();
        }

        public void Add(AddHistoryServiceModel addHistoryServiceModel)
        {
            string operationName = addHistoryServiceModel.OperationType.ToString();
            var operation = DbContext.Operations.FirstOrDefault(o => o.Name == operationName);
            if (operation is null)
            {
                string logMessage = $"Operation with name {operationName} not found. Can't Add data to History table";
                Logger.LogError(logMessage);
                return;
            }

            var history = new History
            {
                Param1 = addHistoryServiceModel.Param1,
                Param2 = addHistoryServiceModel.Param2,
                Result = addHistoryServiceModel.Result,
                OperationId = operation.Id
            };

            DbContext.Histories.Add(history);
            DbContext.SaveChanges();
        }
    }
}
