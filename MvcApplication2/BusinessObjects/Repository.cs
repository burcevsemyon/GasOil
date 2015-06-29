using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using GasOil.DataModel;

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
    }
}