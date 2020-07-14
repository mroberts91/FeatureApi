using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
using FeatureApi.Core.Interfaces;
using FeatureApi.Web.Base;
using FeatureApi.Core.Orders;

namespace FeatureApi.Web.Orders
{
    public class Delete : AsyncEndpoint<int, DeletedOrderResult>
    {
        private readonly IAsyncRepository<Order> _repository;

        public Delete(IAsyncRepository<Order> repository)
        {
            _repository = repository;
        }

        [HttpDelete("/orders/{id}")]
		[SwaggerOperation(
			Summary = "Deletes an Order",
			Description = "Deletes an Order",
			OperationId = "Order.Delete",
			Tags = new[] { "OrderEndpoint" })
		]
        public override async Task<ActionResult<DeletedOrderResult>> HandleAsync(int id)
        {
            var order = await _repository.GetByIdAsync(id);
            if (order == null) return NotFound(id);
            await _repository.DeleteAsync(order);

            return Ok(new DeletedOrderResult { Id = id });
        }
    }
}