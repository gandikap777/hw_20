using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace homework_20.Models
{
    public class Transfer
    {
        [Required]
        [Display(Name = "Сумма перевода")]
        public double Summ { get; set; }

        [Display(Name = "Аккаунт списания")]
        public int AccNumberFrom { get; set; }
        [Display(Name = "Аккаунт пополнения")]
        public int AccNumberTo { get; set; }
    }
}
