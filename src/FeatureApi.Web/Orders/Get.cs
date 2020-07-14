using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
using FeatureApi.Core.Interfaces;
using FeatureApi.Web.Base;
using FeatureApi.Core.Orders;
using Microsoft.Extensions.FileProviders;

namespace FeatureApi.Web.Orders
{
    public class Get : AsyncEndpoint<int, OrderResult>
    {
        private readonly IAsyncRepository<Order> _repository;
        private readonly IMapper _mapper;

        public Get(IAsyncRepository<Order> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("/orders/{id}")]
        
		[SwaggerOperation(
			Summary = "Get a specific Order",
			Description = "Get a specific Order",
			OperationId = "Order.Get",
			Tags = new[] { "OrderEndpoint" })
		]
        public override async Task<ActionResult<OrderResult>> HandleAsync(int id)
        {
            var order = await _repository.GetByIdAsync(id);
            if (order is null) return NotFound();
            var result = _mapper.Map<OrderResult>(order);
            return Ok(result);
        }
    }
}