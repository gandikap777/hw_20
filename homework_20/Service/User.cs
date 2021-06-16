using HomeWork_13;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace homework_20.Service
{

    public class User : IdentityUser
    {
        public Nullable<int> idClient { get; set; }

    }
}
