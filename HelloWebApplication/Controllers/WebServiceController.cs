using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWebApplication.Controllers
{
    public class WebServiceController : Controller
    {
        // GET: WebService
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string message)
        {
            HelloWebService.HelloWebServiceSoapClient client = new HelloWebService.HelloWebServiceSoapClient();
            
            string name = Request["txtMessage"].ToString();
            ViewBag.Message = client.GetMessage(name);
            return View();
        }

    }
}