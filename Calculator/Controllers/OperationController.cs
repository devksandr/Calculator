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
        IOperationService OperationService { get; }
        IHistoryService HistoryService { get; }

        public OperationController(IOperationService calculatorService, IHistoryService historyService)
        {
            OperationService = calculatorService;
            HistoryService = historyService;
        }

        [HttpGet]
        public IActionResult GetAllOperations()
        {
            var operationsDTO = OperationService.GetAllOperations();
            return Ok(operationsDTO);
        }

        [HttpPost]
        public IActionResult Calculate([FromBody] OperationParamsDTO paramsDTO)
        {
            if (paramsDTO.OperationType == OperationType.Undefined)
            {
                return BadRequest();
            }

            var result = OperationService.Calculate(paramsDTO);

            var addHistoryServiceModel = new AddHistoryServiceModel
            {
                Param1 = paramsDTO.Param1,
                Param2 = paramsDTO.Param2,
                Result = result,
                OperationType = paramsDTO.OperationType
            };
            HistoryService.Add(addHistoryServiceModel);

            return Ok(result);
        }

    }
}
