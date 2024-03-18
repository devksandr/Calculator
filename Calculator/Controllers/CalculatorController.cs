using Calculator.Services;
using Calculator.Models;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        ICalculatorService CalculatorService { get; }
        public CalculatorController(ICalculatorService calculatorService)
        {
            CalculatorService = calculatorService;
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
            return result;
        }

    }
}
