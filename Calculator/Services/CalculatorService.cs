using Calculator.Backend.Data;
using Calculator.Backend.Data.Entities;
using Calculator.Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Calculator.Backend.Services
{
    public class CalculatorService : ICalculatorService
    {
        public CalculatorDataContext DbContext { get; set; }
        public CalculatorService(CalculatorDataContext dbContext)
        {
            DbContext = dbContext;
        }

        public float Sum(float a, float b) => a + b;
    }
}
