using HomeWork_13;
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
        public IEnumerable<StructuralUnit> GetDepartments()
        {
            return dataRepository.GetDepartments();
        }
    }
}
