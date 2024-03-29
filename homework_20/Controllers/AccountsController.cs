﻿using homework_20.Models;
using homework_20.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace homework_20.Controllers
{
    public class AccountsController : Controller
    {
        private readonly DataManager dataManager;
        private readonly UserManager<User> usrMngr;
        private readonly IConfiguration configuration;

        public AccountsController(DataManager dataManager, UserManager<User> usrMngr, IConfiguration configuration)
        {
            this.dataManager = dataManager;
            this.usrMngr = usrMngr;
            this.configuration = configuration;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageAccounts");
            
            User user = await usrMngr.GetUserAsync(User);
            var acc = dataManager.Accounts.GetAccounts((int)user.idClient);

            return View(acc);
        }


        [HttpGet]
        [Authorize]
        public ActionResult OpenAccount()
        {
            User user = usrMngr.Users.FirstOrDefault(x => x.Id == usrMngr.GetUserId(User));

            WebRequest request = WebRequest.Create($"{configuration["Project: WebApiUrl"]}/api/Bank/Account/Create");
            request.Method = "POST"; // для отправки используется метод Post
            // устанавливаем тип содержимого - параметр ContentType
            request.ContentType = "application/json";
            
            string accstring = JsonConvert.SerializeObject(new
            {
                IdClient = user.idClient,
                Balance = 0,
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

                ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageAccounts");
                ViewBag.Text = "Счет успешно откыт!";
                return View("Result");
            }
            catch (WebException e)
            {
                var encoding = ASCIIEncoding.ASCII;
                using (var reader = new System.IO.StreamReader(e.Response.GetResponseStream(), encoding))
                {
                    string responseText = reader.ReadToEnd();
                    ViewBag.Text = $"Не удалось открыть счет. Ошибка: {responseText}";
                    return View("Result");
                }

            }
            
        }


        [HttpGet]
        [Authorize]
        public IActionResult TopUpBalance()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult TopUpBalance(TopUpBalance model)
        {
            User user = usrMngr.Users.FirstOrDefault(x=>x.Id == usrMngr.GetUserId(User));

            WebRequest request = WebRequest.Create($"{configuration["Project: WebApiUrl"]}/api/Bank/Account/ChangeBalance");
            request.Method = "POST"; // для отправки используется метод Post
            // устанавливаем тип содержимого - параметр ContentType
            request.ContentType = "application/json";


            string accstring = JsonConvert.SerializeObject(new
            {
                id = model.AccNumber,
                summ = model.Summ,
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

                ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageAccounts");
                ViewBag.Text = "Счет успешно пополнен!";
                return View("Result");
            }
            catch (WebException e)
            {
                var encoding = ASCIIEncoding.ASCII;
                using (var reader = new System.IO.StreamReader(e.Response.GetResponseStream(), encoding))
                {
                    string responseText = reader.ReadToEnd();
                    ViewBag.Text = $"Не удалось пополнить счет. Ошибка: {responseText}";
                    return View("Result");
                }                
            }
            
        }

        [HttpGet]
        [Authorize]
        public IActionResult Transfer()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Transfer(Transfer model)
        {
            User user = usrMngr.Users.FirstOrDefault(x => x.Id == usrMngr.GetUserId(User));

            WebRequest request = WebRequest.Create($"{configuration["Project: WebApiUrl"]}/api/Bank/Balance/Transfer");
            request.Method = "POST"; // для отправки используется метод Post
            // устанавливаем тип содержимого - параметр ContentType
            request.ContentType = "application/json";


            string accstring = JsonConvert.SerializeObject(new
            {
                fromid = model.AccNumberFrom,
                toid = model.AccNumberTo,
                summ = model.Summ,
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

                ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageAccounts");
                ViewBag.Text = "Успешно выполнен перевод!";
                return View("Result");
            }
            catch (WebException e)
            {
                var encoding = ASCIIEncoding.ASCII;
                using (var reader = new System.IO.StreamReader(e.Response.GetResponseStream(), encoding))
                {
                    string responseText = reader.ReadToEnd();
                    ViewBag.Text = $"Не удалось выполнить перевод. Ошибка: {responseText}";
                    return View("Result");
                }


            }
        }

        
    }
}

