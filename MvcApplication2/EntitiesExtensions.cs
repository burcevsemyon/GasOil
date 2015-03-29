using System.Linq;
using GasOil.db;

namespace GasOil.db.Extensions
{
    public static class DBExtensions
    {
        public static bool GetUserExists(this dbEntities context, string login)
        {
            return context.Users.Any(u=>u.Login == login);
        }
    }

}