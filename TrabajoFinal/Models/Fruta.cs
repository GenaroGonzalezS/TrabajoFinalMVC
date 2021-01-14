using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace TrabajoFinal.Models
{
    public class Fruta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        [DataType(DataType.Date)]
        public DateTime Caducidad { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
    }
}
