using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PortalGames.Models
{
    [Table("CreditCard")]
    public class CreditCard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CVV { get; set; }
        public int MM { get; set; }
        public int YY { get; set; }
        public string Number { get; set; }
        public decimal Sum { get; set; }
    }
}
