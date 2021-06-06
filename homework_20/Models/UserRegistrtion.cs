using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace homework_20.Service
{
    public class UserRegistration
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required, MaxLength(20)]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Required]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required, DataType(DataType.Date)]
        [Display(Name = "Дата рождения")]
        public string Birthday { get; set; }

        [Required, DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password), Compare(nameof(Password), ErrorMessage = "Пароли не совпадают")]
        [Display(Name = "Подтверждение пароля")]
        public string ConfirmPassword { get; set; }
    }
}
