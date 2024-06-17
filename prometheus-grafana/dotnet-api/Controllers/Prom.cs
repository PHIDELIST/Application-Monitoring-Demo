using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic; // Ensure this is included
using api.Services.PrometheusService;
using Models;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrometheusController : ControllerBase
    {
        private readonly IPrometheusService _prometheusService;

        public PrometheusController(IPrometheusService prometheusService)
        {
            _prometheusService = prometheusService;
        }

        [HttpGet]
        public IEnumerable<Prom> Get()
        {
            return _prometheusService.GetProms();
        }
    }
}
