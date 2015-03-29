using System.Collections.Generic;
using GasOil.db;

namespace GasOil.Models
{
    public class EditProductsPageModel
    {
        public Product Product { get; set; }
        public List<ProductsGroup> ProductsGroups { get; set; }
        public List<UnitOfMeasurement> UnitOfMeasurements { get; set; }
    }
}