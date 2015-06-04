using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GasOil.DataModel;

namespace GasOil.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult RegConfirm(string regNum)
        {
            try
            {
                using (var context = new GasOilEntities())
                {
                    var request = context.RegRequests.FirstOrDefault(r => r.RegistrationNum == regNum);
                    if (request != null)
                    {
                        context.Users.Add(new User{ Login = request.Login, Password = request.Password, Email = request.Email, CreatedTime = DateTime.Now, RoleId = 2});
                    }

                    context.RegRequests.Add(request);

                    context.SaveChanges();
                }
            }
            catch
            {
            }

            return View();
        }

        public ActionResult Index()
        {   
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}
