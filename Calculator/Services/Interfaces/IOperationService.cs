using Calculator.Backend.Data.Models.DTO;

namespace Calculator.Backend.Services.Interfaces
{
    public interface IOperationService
    {
        public List<OperationDTO> GetAllOperations();
        public float Calculate(OperationParamsDTO paramsDTO);
    }
}
