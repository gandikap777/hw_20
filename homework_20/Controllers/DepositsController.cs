using homework_20.Models;
using homework_20.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace homework_20.Controllers
{
    public class DepositsController : Controller
    {
        private readonly DataManager dataManager;
        private readonly UserManager<User> usrMngr;

        public DepositsController(DataManager dataManager, UserManager<User> usrMngr)
        {
            this.dataManager = dataManager;
            this.usrMngr = usrMngr;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageDeposits");
            
            User user = await usrMngr.GetUserAsync(User);

            return View(dataManager.Deposits.GetDeposits((int)user.idClient));
        }

        [HttpGet]
        [Authorize]
        public IActionResult OpenDeposit()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> OpenDeposit(OpenDeposit model)
        {
            User user = await usrMngr.GetUserAsync(User);

            WebRequest request = WebRequest.Create("https://localhost:44391/api/Bank/Deposit/Create");
            request.Method = "POST"; // для отправки используется метод Post
            // устанавливаем тип содержимого - параметр ContentType
            request.ContentType = "application/json";


            string accstring = JsonConvert.SerializeObject(new
            {
                DateOpen = DateTime.Now,
                IdClient = (int)user.idClient,
                Period = model.Period,
                Capitalization = model.Capitalization,
                Rate = model.Rate,
                Summ = model.Summ,
            });
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(accstring);

            // Устанавливаем заголовок Content-Length запроса - свойство ContentLength
            request.ContentLength = byteArray.Length;

            //записываем данные в поток запроса
            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            WebResponse response = await request.GetResponseAsync();

            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageAccounts");

            return View("Index", dataManager.Deposits.GetDeposits((int)user.idClient));
        }
    }
}
