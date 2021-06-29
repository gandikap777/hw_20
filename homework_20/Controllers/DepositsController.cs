using HomeWork_13.Models;
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
using System.Text;
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
        public async Task<IActionResult> OpenDeposit()
        {
            User user = await usrMngr.GetUserAsync(User);

            IClient client = dataManager.Clients.GetClientById((int)user.idClient);

            ViewBag.Rates = DepositRate.GetDepositRate(client);
            ViewBag.Periods = DepositPeriod.GetDepositPeriod(client);
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> OpenDeposit(OpenDeposit model)
        {
            User user = await usrMngr.GetUserAsync(User);

            IAccount acc = dataManager.Accounts.GetAccountById(model.AccNumber);

            if (acc == null)
            {
                ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageDeposits");
                ViewBag.Text = string.Format("Не удалось открыть депозит. Ошибка: Account with id = {0} not found!", model.AccNumber);
                return View("Result");
            }

            if (acc.Balance < model.Summ)
            {
                ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageDeposits");
                ViewBag.Text = string.Format("Не удалось открыть депозит. Ошибка: Account with id = {0} not enough funds to write off!", model.AccNumber);
                return View("Result");
            }


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

            try
            {
                WebResponse response = request.GetResponse();

                request = WebRequest.Create("https://localhost:44391/api/Bank/Account/DecreaseBalance");
                request.Method = "POST"; // для отправки используется метод Post
                                         // устанавливаем тип содержимого - параметр ContentType
                request.ContentType = "application/json";


                accstring = JsonConvert.SerializeObject(new
                {
                    id = model.AccNumber,
                    summ = model.Summ,
                });
                byteArray = System.Text.Encoding.UTF8.GetBytes(accstring);

                // Устанавливаем заголовок Content-Length запроса - свойство ContentLength
                request.ContentLength = byteArray.Length;

                //записываем данные в поток запроса
                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }

                request.GetResponse();

                ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageDeposits");
                ViewBag.Text = "Депозит успешно открыт!";
                return View("Result");
            }
            catch (WebException e)
            {
                var encoding = ASCIIEncoding.ASCII;
                using (var reader = new StreamReader(e.Response.GetResponseStream(), encoding))
                {
                    string responseText = reader.ReadToEnd();
                    ViewBag.Text = $"Не удалось открыть депозит. Ошибка: {responseText}";
                    return View("Result");
                }

            }
        }
    }
}
