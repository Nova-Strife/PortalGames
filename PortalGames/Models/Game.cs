using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PortalGames.Models
{
    [Table("Game")]
    public class Game
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите название игры")]
        [DisplayName("Название ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите релиз игры")]
        [DisplayName("Дата релиза ")]
        public DateTime Release { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите жанр игры")]
        [DisplayName("Жанр ")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите режим игры")]
        [DisplayName("Режим ")]
        public string Mode { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите возрастное ограничение игры")]
        [DisplayName("Возрастной рейтинг ")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите цену игры")]
        [DisplayName("Цена ")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Пожалуйста, введите положительное значение для цены")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите описание игры")]
        [DisplayName("Описание ")]
        public string Description { get; set; }
        public string Url { get; set; }
    }
}
