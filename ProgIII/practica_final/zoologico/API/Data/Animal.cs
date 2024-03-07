using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class Animal
    {
        [Key]
        public Guid Id { get; set; }
        public int PaisId { get; set; }
        public int ContinenteId { get; set; }
        public Guid ZooId { get; set;}
        public int FamiliaId { get; set; }

        public string Nombre { get; set; }
        public string NombreCientifico { get; set; }
        public string Sexo { get; set; }
        public int AnioDeNacimiento { get; set; }
        public bool PeligroDeExtincion { get; set; }

        [ForeignKey("PaisId")]
        public virtual Pais PaisIdNavegation { get; set; }
        [ForeignKey("ContinenteId")]
        public virtual Continente ContinenteIdNavegation { get; set; }
        [ForeignKey("FamiliaId")]
        public virtual Familia FamiliaIdNavegation { get; set; }
        [ForeignKey("ZooId")]
        public virtual Zoo ZooIdNavegation { get; set; }
    }
}