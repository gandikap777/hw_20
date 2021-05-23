using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace homework_20.Models.Entity
{
    public abstract class EntityBase
    {
        protected EntityBase() => DateAdd = DateTime.Now;

        [Required]
        public Guid Id { get; set; }

        [Display(Name = "Заголовок")]
        public virtual string Tittle { get; set; }

        [Display(Name = "Описание")]
        public virtual string SubTittle { get; set; }

        [Display(Name = "Полное описание")]
        public virtual string Text { get; set; }

        [Display(Name = "Картинка")]
        public virtual string ImagePath { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateAdd { get; set; }

    }
}
