using System.Collections.Generic;
using GasOil.DataModel;

namespace GasOil.Models
{
    public class EditProductsPageModel
    {
        public ProductModel Product { get; set; }
        public List<ProductsGroup> ProductsGroups { get; set; }
        public List<UnitOfMeasurement> UnitOfMeasurements { get; set; }
    }
}