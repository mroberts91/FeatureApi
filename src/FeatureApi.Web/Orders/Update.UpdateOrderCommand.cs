using System;

namespace FeatureApi.Web.Orders
{
    public class UpdateOrderCommand
    {
        public int Id { get; set; }
        public string FileNumber { get; set; }
        public double PolicyCoverageAmount { get; set; }
        public DateTime PolicyExpiration { get; set; }
        public string PropertyAddress { get; set; }
        public string PropertyCity { get; set; }
        public string PropertyState { get; set; }
        public string PropertyZipCode { get; set; }
        public double PropertyLotSize { get; set; }
    }
}