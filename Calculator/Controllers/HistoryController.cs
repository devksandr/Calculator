using Microsoft.AspNetCore.Mvc;
using Calculator.Backend.Services.Interfaces;
using Calculator.Backend.Services;

namespace Calculator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoryController : ControllerBase
    {
        IHistoryService HistoryService { get; }
        public HistoryController(IHistoryService historyService)
        {
            HistoryService = historyService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var historiesDTO = HistoryService.GetAll();
            return Ok(historiesDTO);
        }
    }
}
