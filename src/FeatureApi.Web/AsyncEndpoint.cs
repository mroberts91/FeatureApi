using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FeatureApi.Web.Base
{
    [ApiController]
    public abstract class AsyncEndpoint<TCommand, TResponse> : AsyncEndpoint
    {
        public abstract Task<ActionResult<TResponse>> HandleAsync(TCommand command);
    }

    [ApiController]
    public abstract class AsyncEndpoint<TResponse> : AsyncEndpoint
    {
        public abstract Task<ActionResult<TResponse>> HandleAsync();
    }
    
	[ApiController]
	public abstract class AsyncEndpoint : ControllerBase
	{ }
}
