using Calculator.Backend.Data;
using Calculator.Backend.Data.Entities;
using Calculator.Backend.Data.ServiceModels.History;
using Calculator.Backend.Services.Interfaces;

namespace Calculator.Backend.Services
{
    public class HistoryService : IHistoryService
    {

        public CalculatorDataContext DbContext { get; set; }
        public HistoryService(CalculatorDataContext dbContext)
        {
            DbContext = dbContext;
        }

        public void GetAll()
        {
            throw new NotImplementedException();
        }

        public void Add(AddHistoryServiceModel addHistoryServiceModel)
        {
            var operation = DbContext.Operations.FirstOrDefault(o => o.Name == nameof(addHistoryServiceModel.OperationType));
            if (operation is not null)
            {
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
}
