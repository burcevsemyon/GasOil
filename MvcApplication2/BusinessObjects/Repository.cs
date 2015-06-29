using System.Collections.Generic;
using System.Linq;

using GasOil.DataModel;
using GasOil.Models;

namespace MvcApplication2.BusinessObjects
{
    public class Repository
    {
        private readonly GasOilEntities _context;

        public Repository(GasOilEntities context)
        {
            _context = context;
        }

        public Product GetProduct(long productId)
        {
            return _context.Products.SingleOrDefault(p => p.Id == productId);
        }

        public List<Product> GetProductsByGroup(long? groupId)
        {
            return _context.Products.Where(p => p.GroupId == groupId).ToList();
        }

        public List<UnitOfMeasurement> GetUnitOfMeasurement()
        {
            return _context.UnitOfMeasurements.ToList();
        }
        public ProductModel GetProductModel(long productId)
        {
            return _context.Products.Where(p => p.Id == productId).Select(
                p => new ProductModel
            {
                ProductId = p.Id,
                Name = p.Name,
                UnitOfMeasurementId = p.UnitOfMeasurementId,
                UnitOfMeasurementName = p.UnitOfMeasurement != null ? p.UnitOfMeasurement.Name : null
            }).SingleOrDefault();
        }
    }
}