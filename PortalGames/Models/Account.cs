using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PortalGames.Models
{
    [Table("Account")]
    public class Account
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите свой Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Введите свой Пароль")]
        public string Password { get; set; }
        [Range(0.01, double.MaxValue)]
        [DisplayName("Сумма пополнения")]
        public decimal Sum { get; set; }
        public string Nickname { get; set; }
        public string Role { get; set; }
    }
}
