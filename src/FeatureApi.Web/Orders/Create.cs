using AutoMapper;
using FeatureApi.Core.Interfaces;
using FeatureApi.Core.Orders;
using FeatureApi.Web.Base;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace FeatureApi.Web.Orders
{
    public class Create : AsyncEndpoint<CreateOrderCommand, CreateOrderResult>
    {
        private readonly IAsyncRepository<Order> _repository;
        private readonly IMapper _mapper;
        private readonly IFileNumberGenerator _fileNumber;

        public Create(IAsyncRepository<Order> repository, IMapper mapper, IFileNumberGenerator fileNumberGenerator)
        {
            _repository = repository;
            _mapper = mapper;
            _fileNumber = fileNumberGenerator;
        }

        [HttpPost("/orders")]
        [SwaggerOperation(
            Summary = "Creates a new Order",
            Description = "Creates a new Order",
            OperationId = "Order.Create",
            Tags = new[] { "OrderEndpoint" })
        ]
        public override async Task<ActionResult<CreateOrderResult>> HandleAsync([FromBody]CreateOrderCommand request)
        {
            var order = new Order();
            _mapper.Map(request, order);
            order.FileNumber = _fileNumber.Generate();
            await _repository.AddAsync(order);

            var result = _mapper.Map<CreateOrderResult>(order);
            return Ok(result);
        }
    }
}