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
            if (operationsDTO is null) 
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }

            return Ok(operationsDTO);
        }

        [HttpPost]
        public IActionResult Calculate([FromBody] OperationParamsDTO paramsDTO)
        {
            if (paramsDTO.OperationType == OperationType.Undefined)
            {
                return BadRequest();
            }

            var calculationResult = OperationService.Calculate(paramsDTO);
            var addHistoryServiceModel = new AddHistoryServiceModel
            {
                Param1 = paramsDTO.Param1,
                Param2 = paramsDTO.Param2,
                Result = calculationResult,
                OperationType = paramsDTO.OperationType
            };

            var saveHistoryResult = HistoryService.Add(addHistoryServiceModel);
            if (!saveHistoryResult)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }

            return Ok(calculationResult);
        }

    }
}
