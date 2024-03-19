using Microsoft.AspNetCore.Mvc;
using Calculator.Backend.Services.Interfaces;

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
    }
}
