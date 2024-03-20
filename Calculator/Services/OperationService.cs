using Calculator.Backend.Data;
using Calculator.Backend.Data.Models.DTO;
using Calculator.Backend.Data.Models.Entities;
using Calculator.Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Calculator.Backend.Services
{
    public class OperationService : IOperationService
    {
        public CalculatorDataContext DbContext { get; set; }
        public OperationService(CalculatorDataContext dbContext)
        {
            DbContext = dbContext;
        }

        public List<OperationDTO> GetAllOperations()
        {
            var operationsDTO = new List<OperationDTO>();
            var operations = DbContext.Operations.ToList(); // Check DB connection
            operations.ForEach(o => operationsDTO.Add(new OperationDTO
            {
                Name = o.Name
            }));
            return operationsDTO;
        }

        public float Sum(float a, float b) => a + b;

    }
}
