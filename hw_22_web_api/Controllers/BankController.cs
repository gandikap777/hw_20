using HomeWork_13;
using HomeWork_13.Models;
using homework_20.Service;
using hw_22_web_api.Data;
using hw_22_web_api.Models.Repositories.Interfases;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace hw_22_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IApiRepository dataRepository;

        public BankController(IApiRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        /// <summary>
        /// Получение списка департаментов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetDepartments")]
        public IEnumerable<StructuralUnit> GetDepartments()
        {
            return dataRepository.GetDepartments();
        }

        /// <summary>
        /// Создание счета клиента
        /// </summary>
        /// <param name="acc"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Account/Create")]
        public ActionResult<BasicAccount> CreateAccount(BasicAccount acc)
        {
            dataRepository.SaveAccount(acc);

            return CreatedAtAction(nameof(GetAccount), new { id = acc.ID }, acc);
        }

        /// <summary>
        /// Получение счета по номеру
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Account/{id}")]
        public ActionResult<Account> GetAccount(int id)
        {
            Account acc = dataRepository.GetAccount(id);

            if (acc == null)           
            {               
                var message = string.Format("Account with id = {0} not found", id);
                return BadRequest(message);

            }

            return acc;
        }

        /// <summary>
        /// Получение клиентов департамента
        /// </summary>
        /// <param name="idDepartment"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{idDepartment}/Clients")]
        public IEnumerable<IClient> GetDepartmentClients(int idDepartment)
        {
            return dataRepository.GetDepartmentClient(idDepartment);
        }

        /// <summary>
        /// Добавление депозита
        /// </summary>
        /// <param name="dep"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Deposit/Create")]
        public ActionResult<BasicDeposit> CreateDeposit([FromBody] BasicDeposit dep)
        {

            dataRepository.SaveDeposit(dep);

            return CreatedAtAction(nameof(GetDeposit), new { id = dep.ID }, dep);
        }

        /// <summary>
        /// Получение депозита по номеру
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Deposit/{id}")]
        public ActionResult<Deposit> GetDeposit(int id)
        {
            Deposit dep = dataRepository.GetDeposit(id);

            if (dep == null)
            {
                var message = string.Format("Product with id = {0} not found", id);
                return BadRequest(message);

            }

            return dep;
        }

        /// <summary>
        /// Пополнение баланса счета
        /// </summary>
        /// <param name="id"></param>
        /// <param name="summ"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Account/{id}/IncreaseBalance/{summ}")]
        public ActionResult<BasicAccount> IncreaseBalance(int id, double summ)
        {
            return NotFound();

            IAccount acc = dataRepository.GetAccount(id);

            if (acc == null)
            {               
                var message = string.Format("Account with id = {0} not found", id);
                return BadRequest(message);

            }

            dataRepository.IncreaseBalance(acc, summ);


            return CreatedAtAction(nameof(GetAccount), new { id = acc.ID }, acc);
        }

        /// <summary>
        /// Измение баланса счета
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Account/ChangeBalance")]
        public ActionResult<BasicAccount> ChangeBalance([FromBody] ChangeBalanceBody body)
        {
            IAccount acc = dataRepository.GetAccount(body.id);

            if (acc == null)
            {

                var message = string.Format("Account with id = {0} not found", body.id);
                return BadRequest(message);

            }

            if (body.summ > 0) dataRepository.IncreaseBalance(acc, body.summ);
            else if (body.summ > dataRepository.GetAccountBalance(acc))
            {
                var message = string.Format("Account id = {0} not enough funds to write off", body.id);
                return BadRequest(message);
            }
            else dataRepository.IncreaseBalance(acc, body.summ);


            return CreatedAtAction(nameof(GetAccount), new { id = acc.ID }, acc);
        }


        /// <summary>
        /// Уменьшение баланса счета
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Account/DecreaseBalance")]
        public ActionResult<BasicAccount> DecreaseBalance([FromBody] ChangeBalanceBody body)
        {
            IAccount acc = dataRepository.GetAccount(body.id);

            if (acc == null)
            {

                var message = string.Format("Account with id = {0} not found", body.id);
                return BadRequest(message);

            }

            if (body.summ > dataRepository.GetAccountBalance(acc))
            {
                var message = string.Format("Account id = {0} not enough funds to write off", body.id);
                return BadRequest(message);
            }
            else dataRepository.DecreaseBalance(acc, body.summ);


            return CreatedAtAction(nameof(GetAccount), new { id = acc.ID }, acc);
        }

        /// <summary>
        /// Перевод между счетами
        /// </summary>
        /// <param name="fromid"></param>
        /// <param name="toid"></param>
        /// <param name="summ"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Transfer/{fromid}/{toid}/{summ}")]
        public ActionResult<BasicAccount> Transfer(int fromid, int toid, double summ)
        {

            return NotFound();

            IAccount accfrom = dataRepository.GetAccount(fromid);
            IAccount accto = dataRepository.GetAccount(toid);

            if (accfrom == null)
                return NotFound();

            dataRepository.Transfer(accfrom, accto, summ);

            return CreatedAtAction(nameof(GetAccount), new { id = accfrom.ID }, accfrom);
        }

        /// <summary>
        /// Перевод между счетами
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Balance/Transfer")]
        public ActionResult<BasicAccount> Transfer([FromBody] BalanceTransferBody body)
        {
            IAccount accfrom = dataRepository.GetAccount(body.fromid);
            IAccount accto = dataRepository.GetAccount(body.toid);

            if (accfrom == null)
            {

                var message = string.Format("Account with id = {0}  not found", body.fromid);
                return BadRequest(message);

            }

            if (accfrom == null)
            {

                var message = string.Format("Account with id = {0}  not found", body.toid);
                return BadRequest(message);

            }

            if (dataRepository.GetAccountBalance(accfrom)  < body.summ)
            {

                var message = string.Format("Account with id = {0}  not enough funds to write off", body.fromid);
                return BadRequest(message);

            }

            dataRepository.Transfer(accfrom, accto, body.summ);

            return CreatedAtAction(nameof(GetAccount), new { id = accfrom.ID }, accfrom);
        }



    }

    public class HttpResponseException : Exception
    {
        public HttpResponseException(HttpResponseMessage rec) { }
    }
}
