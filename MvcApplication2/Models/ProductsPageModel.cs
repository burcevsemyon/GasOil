using System.Collections.Generic;
using GasOil.db;

namespace GasOil.Models
{
    public class ProductModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string UnitOfMeasurement { get; set; }
    }

    public class ProductsPageModel
    {
        public List<ProductModel> Products { get; set; }
        public List<ProductsGroup> ProductsGroups { get; set; }
    }
}