using MedWebApiApp.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace MedWebApiApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderService _providerService;

        public ProviderController(IProviderService providerService)
        {
            _providerService = providerService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Provider>> GetProviders()
        {
            return Ok(_providerService.GetAllProviders());
        }

        [HttpGet("{number}")]
        public ActionResult<Provider> GetProvider(string number)
        {
            Provider provider = _providerService.GetProviderByNumber(number);
            if (provider == null)
                return NotFound();

            return Ok(provider);
        }
    }

}
