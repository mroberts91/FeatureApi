
namespace FeatureApi.Core.Orders
{
    public class Order : BaseEntity
    {
        public string FileNumber { get; set; }
        public Property Property { get; set; }
        public Policy Policy { get; set; }
    }
}
