using Microsoft.AspNetCore.Mvc;
using Calculator.Backend.Services.Interfaces;
using Calculator.Backend.Data.Models.ServiceModels.History;
using Calculator.Backend.Data.Enums;
using Calculator.Backend.Data.Models.DTO;

namespace Calculator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OperationController : ControllerBase
    {
        IOperationService CalculatorService { get; }
        IHistoryService HistoryService { get; }

        public OperationController(IOperationService calculatorService, IHistoryService historyService)
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
        public float Sum([FromBody] OperationParamsDTO paramsDTO)
        {
            var result = CalculatorService.Sum(paramsDTO.Param1, paramsDTO.Param2);

            var addHistoryServiceModel = new AddHistoryServiceModel
            {
                Param1 = paramsDTO.Param1,
                Param2 = paramsDTO.Param2,
                Result = result,
                OperationType = OperationType.Sum
            };
            HistoryService.Add(addHistoryServiceModel);

            return result;
        }

    }
}
