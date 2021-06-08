using HomeWork_13;
using hw_22_web_api.Models.Repositories.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hw_22_web_api.Models.Repositories.EntityFramework
{
    public class EFApiRepository : IApiRepository
    {
        private ContextAPI context;

        public EFApiRepository(ContextAPI context)
        {
            this.context = context;
        }
        

        IEnumerable<StructuralUnit> IApiRepository.GetDepartments()
        {
            return context.StructuralUnits.ToList();
        }
    }
}
