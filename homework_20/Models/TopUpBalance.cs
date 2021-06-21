using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace homework_20.Models
{
    public class TopUpBalance
    {
        [Required]
        [Display(Name = "Сумма пополнения")]
        public double Summ { get; set; }

        [Display(Name = "Аккаунт")]
        public int AccNumber { get; set; }
    }
}
