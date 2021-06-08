using HomeWork_13;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hw_22_web_api.Models.Repositories.Interfases
{
    public interface IApiRepository
    {
        IEnumerable<StructuralUnit> GetDepartments();


    }
}
