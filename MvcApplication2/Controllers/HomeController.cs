using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GasOil.db;

namespace GasOil.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult RegConfirm(string regNum)
        {
            try
            {
                using (var context = new dbEntities())
                {
                    var request = context.RegRequests.FirstOrDefault(r => r.RegistrationNum == regNum);
                    if (request != null)
                    {
                        context.Users.AddObject(new User{ Login = request.Login, Password = request.Password, Email = request.Email, CreatedTime = DateTime.Now, RoleId = 2});
                    }

                    context.RegRequests.DeleteObject(request);

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
            //try
            //{
            //    using (var context = new dbEntities())
            //    {
            //        var users = context.Users.Select(u => u).ToList();
            //        ViewBag.users = users;
            //    }
            //}
            //catch (Exception ex)
            //{

            //    ViewBag.ErrorMessage = ex.Message;
            //    while (ex.InnerException != null)
            //    {
            //        ViewBag.ErrorMessage += "\n";
            //        ViewBag.ErrorMessage += ex.InnerException.Message;
            //        ex = ex.InnerException;
            //    }
            //    ViewBag.StackTrace = ex.StackTrace;
            //}

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}
