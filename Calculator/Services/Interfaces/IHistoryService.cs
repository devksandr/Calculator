using Calculator.Backend.Data.Models.ServiceModels.History;

namespace Calculator.Backend.Services.Interfaces
{
    public interface IHistoryService
    {
        public void GetAll();
        public void Add(AddHistoryServiceModel addHistoryServiceModel);
    }
}
