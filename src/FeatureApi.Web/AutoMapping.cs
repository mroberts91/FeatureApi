using AutoMapper;
using FeatureApi.Core.Orders;
using FeatureApi.Web.Orders;

namespace FeatureApi.Web
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            // Command Mappings
            CreateMap<Order, CreateOrderCommand>().ReverseMap();
            CreateMap<Order, UpdateOrderCommand>().ReverseMap();

            // Result Mappings
            CreateMap<Order, CreateOrderResult>();
            CreateMap<Order, OrderResult>();
            CreateMap<Order, UpdatedOrderResult>();
            CreateMap<Order, DeletedOrderResult>();
            CreateMap<Order, OrderListResult>();
        }
    }
}
