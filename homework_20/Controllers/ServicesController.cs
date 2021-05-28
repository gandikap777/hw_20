using homework_20.Models;
using homework_20.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework_20.Controllers
{
    public class ServicesController : Controller
    {
        private readonly DataManager dataManager;

        public ServicesController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index(Guid id)
        {
            var serviceTypes = ServiceType.GetServiceTypes();
            ViewBag.ServiceTypes = serviceTypes;
            if (id != default)
            {
                return View("Show", dataManager.ServiceItems.GetServiceItemById(id));
            }

            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageServices");
            return View(dataManager.ServiceItems.GetServiceItems());
        }

        //[HttpPost]
        public ActionResult ServiceTypeSearch(string type)
        {
            var Services = dataManager.ServiceItems.GetServiceItems(type);

            return View("Index", Services);
        }
    }
}
