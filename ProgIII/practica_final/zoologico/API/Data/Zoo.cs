using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class Zoo
    {
        [Key]
        public Guid Id { get; set; }
        public int CiudadId { get; set; }
        public int PaisId { get; set; }

        public string Nombre { get; set; }
        public double PresupuestoAnual { get; set; }
        public double TamanioEnM2 { get; set; }
        
        [ForeignKey("PaisId")]
        public virtual Pais IdPaisZooNavegation { get; set; }
        [ForeignKey("CiudadId")]
        public virtual Ciudad IdCiudadZooNavegation { get; set; }

        public virtual ICollection<Animal> Animales { get; set; }
        
    }
}