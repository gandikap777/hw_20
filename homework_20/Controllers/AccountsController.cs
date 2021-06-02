using homework_20.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework_20.Controllers
{
    public class AccountsController : Controller
    {
        private readonly DataManager dataManager;

        public AccountsController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index()
        {
            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageAccounts");
            return View(dataManager.Accounts.GetAccounts(1));
        }
    }
}
