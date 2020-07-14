using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FeatureApi.Web.Error
{
    [ApiController]
    public class Error : ControllerBase
    {
        [HttpPost, Route("/error")]
        [SwaggerOperation(
            Summary = "Handles unhandled internal exceptions",
            Description = "Internal Server Error Handler",
            OperationId = "Error",
            Tags = new[] { "ErrorEndpoint" })
        ]
        public IActionResult Handle() => Problem();
    }
}
