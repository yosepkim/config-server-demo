using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConfigServerDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        { 
                ViewBag.Message = "Your application description page.";
                return View();
        }

        public ActionResult About()
        { 
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ConfigServerSettings()
        {
            var config = ApplicationConfig.Configuration;
            var section = config.GetSection("spring:cloud:config");

            if (section != null)
            {
                ViewBag.Enabled = section["enabled"];
                ViewBag.Environment = section["env"];
                ViewBag.FailFast = section["failFast"];
                ViewBag.Label = section["label"];
                ViewBag.Name = section["name"];
                ViewBag.Password = section["password"];
                ViewBag.Uri = section["uri"];
                ViewBag.Username = section["username"];
                ViewBag.ValidateCertificates = section["validate_certificates"];
            }
            else
            {

                ViewBag.Enabled = "Not Available";
                ViewBag.Environment = "Not Available";
                ViewBag.FailFast = "Not Available";
                ViewBag.Label = "Not Available";
                ViewBag.Name = "Not Available";
                ViewBag.Password = "Not Available";
                ViewBag.Uri = "Not Available";
                ViewBag.Username = "Not Available";
                ViewBag.ValidateCertificates = "Not Available";
            }
            return View();
        }
        public ActionResult Reload()
        {
            if (ApplicationConfig.Configuration != null)
            {
                ApplicationConfig.Configuration.Reload();
            }

            return View();
        }

        public ActionResult ConfigServerData()
        {

            var config = ApplicationConfig.Configuration;
            if (config != null)
            {
                ViewBag.OrgName = config["org_name"] ?? "Not returned";
                ViewBag.Author = config["author"] ?? "Not returned";
            }

            return View();
        }
    }
}