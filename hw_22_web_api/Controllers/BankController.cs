using HomeWork_13;
using HomeWork_13.Models;
using hw_22_web_api.Data;
using hw_22_web_api.Models.Repositories.Interfases;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet]
        [Route("GetDepartments")]
        public IEnumerable<StructuralUnit> GetDepartments()
        {
            return dataRepository.GetDepartments();
        }

        [HttpPost]
        [Route("Account/Create")]
        public ActionResult<BasicAccount> CreateAccount(BasicAccount acc)
        {
            dataRepository.SaveAccount(acc);

            return CreatedAtAction(nameof(GetAccount), new { id = acc.ID }, acc);
        }

        [HttpGet]
        [Route("Account/{id}")]
        public ActionResult<Account> GetAccount(int id)
        {
            Account acc = dataRepository.GetAccount(id);

            if (acc == null) return NotFound();

            return acc;
        }

        [HttpGet]
        [Route("{id}/Clients")]
        public ActionResult<IEnumerable<IClient>> GetDepartmentClients(int idDepartment)
        {
            return dataRepository.GetDepartmentClient(idDepartment);
        }
    }
}
