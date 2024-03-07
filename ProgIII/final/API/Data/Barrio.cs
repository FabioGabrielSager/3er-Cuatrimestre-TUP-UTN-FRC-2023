using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class Barrio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}
        public string Nombre {get; set;}
        public int CiudadId {get; set;}

        [ForeignKey("CiudadId")]
        public virtual Ciudad CiudadIdNavegation {get; set;}
    }
}