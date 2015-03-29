using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CaptchaMvc.HtmlHelpers;
using GasOil.db;

namespace GasOil.Controllers
{
    public class RequestsController : BaseController
    {
        //
        // GET: /Requests/

        public ActionResult Index()
        {
            if (!IsAuthorized()) return View("Build");

            var model = new List<Request>();
            try
            {
                using (var context = new dbEntities())
                {
                    model = context.Requests.OrderByDescending(r => r.CreationTime).ToList();
                }
            }
            catch 
            {
            }

            return View("Show", model);
        }

        public ActionResult Build(int typeId)
        {
            ViewBag.SelectedCategoryId = typeId;

            try
            {
                using (var context = new dbEntities())
                {
                    ViewBag.RequestCategories = context.RequestCategories.ToList();
                }
            }
            catch (Exception)
            {
            }

            return View();
        }

        public RedirectToRouteResult Delete(int id)
        {
            try
            {
                using (var context = new dbEntities())
                {
                    var req = context.Requests.FirstOrDefault(r => r.Id == id);
                    if (req != null)
                    {
                        context.Requests.DeleteObject(req);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
            }

            return RedirectToAction("Show");
        }

        public ActionResult Show()
        {
            var model = new List<Request>();
            try
            {
                using (var context = new dbEntities())
                {
                    model = context.Requests.OrderByDescending(r => r.CreationTime).ToList();
                }
            }
            catch (Exception)
            {
            }

            return View("Show", model);
        }
        
        [HttpPost]
        public ActionResult Build(string fio, string phone, string message, int categoryId)
        {
            ViewBag.Success = false;
            ViewBag.fio = fio;
            ViewBag.phone = phone;
            ViewBag.message = message;

            if(string.IsNullOrWhiteSpace(fio))
            {
                ViewBag.ErrorMessage = "Поле \"ФИО\" должно быть заполнено";
            }
            else if (string.IsNullOrWhiteSpace(phone))
            {
                ViewBag.ErrorMessage = "Поле \"Номер телефона\" должно быть заполнено";
            }
            else if (string.IsNullOrWhiteSpace(message))
            {
                ViewBag.ErrorMessage = "Поле \"Текст сообщения\" должно быть заполнено";
            }
            else if (!this.IsCaptchaValid(""))
            {
                ViewBag.ErrorMessage = "Вы не заполнили или ввели неверный код с картинки";
            }

            if (ViewBag.ErrorMessage == null)
            {
                try
                {
                    using (var context = new dbEntities())
                    {
                        var request = new Request
                        {
                            PersonName = fio,
                            PersonPhone = phone,
                            Message = message,
                            CreationTime = DateTime.Now,
                            CategoryId = categoryId
                        };

                        context.Requests.AddObject(request);

                        context.SaveChanges();
                    }
                }
                catch (Exception)
                {
                }

                ViewBag.Success = true;
            }

            return View();
        }
    }
}
