using Calculator.Backend.Data.Models.DTO;
using Calculator.Backend.Data.Models.ServiceModels.History;

namespace Calculator.Backend.Services.Interfaces
{
    public interface IHistoryService
    {
        public List<HistoryDTO>? GetAll();
        public bool Add(AddHistoryServiceModel addHistoryServiceModel);
    }
}
