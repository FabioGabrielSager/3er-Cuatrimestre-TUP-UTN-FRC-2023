using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class Deposito
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int MetrosCuadrados { get; set; }
        public string calle { get; set; }
        public string numero { get; set; }
        public int BarrioId { get; set; }

        [ForeignKey("BarrioId")]
        public virtual Barrio BarrioIdNavegation { get; set; } 
    }
}