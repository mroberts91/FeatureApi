using FeatureApi.Core.Interfaces;
using System;

namespace FeatureApi.Core.Orders
{
    public class FileNumberGenerator : IFileNumberGenerator
    {
        public string Generate()
        {
            var random = new Random().Next(10000, 99999);
            var year = DateTime.Now.Year;
            return $"{year}{random}";
        }
    }
}
