
namespace FeatureApi.Web.Orders
{
    public class CreateOrderResult : CreateOrderCommand
    {
        public int Id { get; set; }
        public string FileNumber { get; set; }
    }
}