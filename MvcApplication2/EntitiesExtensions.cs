using System.Linq;
using GasOil.DataModel;


namespace GasOil.db.Extensions
{
    public static class DBExtensions
    {
        public static bool GetUserExists(this GasOilEntities context, string login)
        {
            return context.Users.Any(u=>u.Login == login);
        }
    }

}