using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
using FeatureApi.Core.Interfaces;
using FeatureApi.Web.Base;
using FeatureApi.Web.Orders;
using FeatureApi.Core.Orders;

namespace FeatureApi.Web
{
    public class Update : AsyncEndpoint<UpdateOrderCommand, UpdatedOrderResult>
    {
        private readonly IAsyncRepository<Order> _repository;
        private readonly IMapper _mapper;

        public Update(IAsyncRepository<Order> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("/orders")]
		[SwaggerOperation(
			Summary = "Updates an existing Order",
			Description = "Updates an existing Order",
			OperationId = "Order.Update",
			Tags = new[] { "OrderEndpoint" })
		]
        public override async Task<ActionResult<UpdatedOrderResult>> HandleAsync(UpdateOrderCommand request)
        {
            var order = await _repository.GetByIdAsync(request.Id);
            _mapper.Map(request, order);
            await _repository.UpdateAsync(order);

            var result = _mapper.Map<UpdatedOrderResult>(order);
            return Ok(result);
        }
    }
}