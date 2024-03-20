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
        public List<OperationDTO> GetAllOperations()
        {
            var operationsDTO = OperationService.GetAllOperations();
            return operationsDTO;
        }

        [HttpPost]
        public float Sum([FromBody] OperationParamsDTO paramsDTO)
        {
            var result = OperationService.Sum(paramsDTO.Param1, paramsDTO.Param2);

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
