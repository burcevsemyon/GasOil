using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using GasOil.BL.MailService;
using GasOil.db;
using GasOil.db.Extensions;

namespace GasOil
{
    public class BaseController : Controller
    {
        protected bool IsAuthorized()
        {
            return !string.IsNullOrWhiteSpace((string)Session["login"]);
        }

        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);

            ViewBag.IsAuthorized = IsAuthorized();
        }

        public ActionResult Registration()
        {
            return View("Registration");
        }

        private bool IsMailAddressValid(string address)
        {
            bool res = true;
            try
            {
                new MailAddress(address);
            }
            catch
            {
                res = false;
            }
            return res;
        }

        [HttpPost]
        public void Register(string login, string password, string password2, string email)
        {
            string errorMessage = null;
            if (string.IsNullOrWhiteSpace(login))
            {
                errorMessage = "Логин не может быть пустой строкой";
            }
            else if (string.IsNullOrWhiteSpace(password))
            {
                errorMessage = "Пароль не может быть пустой строкой";
            }
            else if (password != password2)
            {
                errorMessage = "Пароли не совпадают";
            }
            else if (string.IsNullOrWhiteSpace(email))
            {
                errorMessage = "Email должен быть заполнен";
            }
            else if (!IsMailAddressValid(email))
            {
                errorMessage = "Неправильно заполнено поле email";
            }
            else
            {
                try
                {
                    using (var context = new dbEntities())
                    {
                        if (context.GetUserExists(login))
                        {
                            errorMessage = "Пользователь с таким логином уже зарегестрирован";
                        }
                        else
                        {
                            var regNum = Guid.NewGuid().ToString().Replace("-", "");

                            var request = new RegRequest
                            {
                                Login = login,
                                Password = password,
                                Email = email,
                                RegistrationNum = regNum,
                                ReqTimeTicks = DateTime.Now
                            };

                            context.RegRequests.AddObject(request);

                            context.SaveChanges();

                            string messageBody = string.Format("<html><body><p>At registration on a site <a href=\"http://\">www.upmytopic.com</a> you (or someone another) specified given email the address as yours.</p><p>For registration confirmation follow the link <a href=\"http://{0}/home/regconfirm/?regnum={1}\">Подтвердить регистрацию</a></p></body></html>", HttpContext.Request.Url.Authority, regNum);

                            var mailSender = new MailSender("smtp.gmail.com", 587, true, "burcevsemyon@gmail.com",
                                "Сервис регистрации пользователей", "burcevsemyon@gmail.com", "12zx34df56ty");

                            mailSender.SendMail(email, "", messageBody);
                        }
                    }
                }
                catch(Exception ex)
                {
                    errorMessage = "Произошла ошибка во время обращения к базе данных. Обратитесь в службу технической поддержки ";
                }
            }

            Session["REGISTRATION_ERROR_MSG"] = errorMessage;

            HttpContext.Response.Redirect(HttpContext.Request.UrlReferrer.ToString());
        }

        [HttpPost]
        public RedirectToRouteResult Login(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                Session["loginError"] = "Логин и пароль не могут быть пустыми";
            }
            else
            {
                try
                {
                    using (var context = new dbEntities())
                    {
                        var user = context.Users.FirstOrDefault(u => u.Login == login && u.Password == password);
                        if (user != null)
                        {
                            Session["login"] = user.Login;
                        }
                        else
                        {
                            Session["loginError"] = "Пользователей  с такими логином и паролем не зарегистрированно.";
                        }
                    }
                }
                catch (Exception)
                {
                    Session["loginError"] = "Ошибка при обращении к БД. Обратитесь в службу поддержки.";
                }
            }

            return RedirectToAction("Index");
        }

        public RedirectToRouteResult Logout()
        {
            Session["login"] = null;

            return RedirectToAction("Index");
        }
    }
}
