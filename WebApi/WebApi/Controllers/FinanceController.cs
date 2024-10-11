using Libs.Helps;
using Libs.Repositories;
using Libs.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("v6/api/Finance")]
    [ApiController]
    public class FinanceController : ControllerBase
    {
        private FinanceService _fi;
        public FinanceController(FinanceService financialRepository)
        {
            _fi = financialRepository;  
        }

        [HttpGet]
        public async Task<IActionResult> GetFinancialAsync([FromQuery] QueryStatistical query) {
            try
            {
                var result = await _fi.GetStatistical(query);
                return Ok(new { status = true, message = "Get successed" , data=result }); 
            } catch (Exception ex) {
                return Ok (new {status = false , message = ex.Message});
             }
        }
    }
}
