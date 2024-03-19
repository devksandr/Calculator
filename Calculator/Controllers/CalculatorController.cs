using Calculator.Models;
using Microsoft.AspNetCore.Mvc;
using Calculator.Backend.Services.Interfaces;
using Calculator.Backend.Data.ServiceModels.History;
using Calculator.Backend.Data.Enums;

namespace Calculator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        ICalculatorService CalculatorService { get; }
        IHistoryService HistoryService { get; }

        public CalculatorController(ICalculatorService calculatorService, IHistoryService historyService)
        {
            CalculatorService = calculatorService;
            HistoryService = historyService;
        }

        [HttpGet]
        public string Test()
        {
            return "test";
        }

        [HttpPost]
        public float Sum([FromBody] CalculatorParamsModel param)
        {
            var result = CalculatorService.Sum(param.A, param.B);

            var addHistoryServiceModel = new AddHistoryServiceModel
            {
                Param1 = param.A,
                Param2 = param.B,
                Result = result,
                OperationType = OperationType.Sum
            };
            HistoryService.Add(addHistoryServiceModel);

            return result;
        }

    }
}
