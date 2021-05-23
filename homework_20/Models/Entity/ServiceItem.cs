using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace homework_20.Models.Entity
{
    public class ServiceItem : EntityBase
    {
        [Required(ErrorMessage = "Заполните наименование услуги")]

        [Display(Name = "Наименование услуги")]
        public override string Tittle { get; set; }

        [Display(Name = "Описание услуги")] 
        public override string SubTittle { get; set; }
        
        [Display(Name = "Содержание услуги")]
        public override string Text { get; set; }


    }
}
