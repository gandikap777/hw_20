using homework_20.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework_20.Controllers
{
    public class DepositsController : Controller
    {
        private readonly DataManager dataManager;

        public DepositsController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index()
        {
            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageDeposits");
            return View(dataManager.Deposits.GetDeposits(1));
        }
    }
}
