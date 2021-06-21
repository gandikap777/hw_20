using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace homework_20.Models
{
    public class OpenDeposit
    {
        [Required]
        [Display(Name = "Сумма пополнения")]
        public double Summ { get; set; }
        [Required]
        [Display(Name = "Аккаунт")]
        public int AccNumber { get; set; }

        [Display(Name = "Дата открытия")]
        public DateTime DateOpen { get; set; }
        
        [Display(Name = "Капитализация")]
        public bool Capitalization { get; set; }

        [Required]
        [Display(Name = "Ставка")]
        public int Rate { get; set; }

        [Required]
        [Display(Name = "Период")]
        public int Period { get; set; }

        [Display(Name = "Клиент")]
        public int IdClient { get; set; }
    }
}
