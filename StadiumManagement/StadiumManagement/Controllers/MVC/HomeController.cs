using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using StadiumManagement.Filters;
using StadiumManagement.Models;

namespace StadiumManagement.Controllers
{
    [Culture]
    public class HomeController : Controller
    {
        ControleContext db = new ControleContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChangeCulture(string lang)
        {
            string returnUrl = Request.UrlReferrer.AbsolutePath;
            // Список культур
            List<string> cultures = new List<string>() { "pt", "ru", "en", "de" };
            if (!cultures.Contains(lang))
            {
                lang = "pt";
            }
            // Сохраняем выбранную культуру в куки
            HttpCookie cookie = Request.Cookies["lang"];
            if (cookie != null)
                cookie.Value = lang;   // если куки уже установлено, то обновляем значение
            else
            {

                cookie = new HttpCookie("lang");
                cookie.HttpOnly = false;
                cookie.Value = lang;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return Redirect(returnUrl);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}