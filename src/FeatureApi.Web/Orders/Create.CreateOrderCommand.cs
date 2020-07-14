using System;

namespace FeatureApi.Web.Orders
{
    public class CreateOrderCommand
    {
        public double PolicyCoverageAmount { get; set; }
        public DateTime PolicyExpiration { get; set; }
        public string PropertyAddress { get; set; }
        public string PropertyCity { get; set; }
        public string PropertyState { get; set; }
        public string PropertyZipCode { get; set; }
        public double PropertyLotSize { get; set; }
    }
}