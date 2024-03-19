using Calculator.Backend.Data;
using Calculator.Backend.Services.Interfaces;

namespace Calculator.Backend.Services
{
    public class OperationService : IOperationService
    {
        public CalculatorDataContext DbContext { get; set; }
        public OperationService(CalculatorDataContext dbContext)
        {
            DbContext = dbContext;
        }

        public float Sum(float a, float b) => a + b;
    }
}
