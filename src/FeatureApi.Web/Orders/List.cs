using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
using FeatureApi.Core.Interfaces;
using FeatureApi.Web.Base;
using FeatureApi.Core.Orders;

namespace FeatureApi.Web.Orders
{
    public class List : AsyncEndpoint
    {
        private readonly IAsyncRepository<Order> _repository;
        private readonly IMapper _mapper;

        public List(IAsyncRepository<Order> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("/orders")]
		[SwaggerOperation(
			Summary = "List all Orders",
			Description = "List all Orders",
			OperationId = "Orders.List",
			Tags = new[] { "OrderEndpoint" })
		]
        public async Task<ActionResult> HandleAsync([FromQuery] int page = 1, int perPage = 10)
        {
            var result = (await _repository.ListAllAsync(perPage, page))
                .Select(i => _mapper.Map<OrderListResult>(i));

            return Ok(result);
        }
    }
}