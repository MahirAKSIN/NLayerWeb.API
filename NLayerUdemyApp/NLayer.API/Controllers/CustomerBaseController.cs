using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(CustomResposeDto<T> respose)
        {
            if (respose.StatusCode == 204)
                return new ObjectResult(null)
                {
                    StatusCode = respose.StatusCode

                };
            return new ObjectResult(respose)
            {
                StatusCode = respose.StatusCode
            };
        }
    }
}
