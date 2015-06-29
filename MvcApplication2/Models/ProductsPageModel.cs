using System.Collections.Generic;
using GasOil.DataModel;

namespace GasOil.Models
{
    public class ProductsPageModel
    {
        public List<ProductModel> Products { get; set; }
        public List<ProductsGroup> ProductsGroups { get; set; }
    }
}