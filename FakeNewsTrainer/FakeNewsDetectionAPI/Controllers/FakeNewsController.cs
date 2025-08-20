using FakeNewsDetectionAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FakeNewsDetectionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FakeNewsController : ControllerBase
    {
        private readonly PredictionService _service;

        public FakeNewsController(PredictionService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Predict([FromBody] NewsData data)
        {
            var result = _service.Predict(data);
            return Ok(result);
        }
    }

}
