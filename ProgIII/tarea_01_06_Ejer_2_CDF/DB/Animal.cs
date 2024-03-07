using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DB
{
    public class Animal
    {
        [Key]
        public Guid Id { get; set; }
        public Guid FamiliaId { get; set; }
        
        public string Nombre { get; set; }
        public string NombreCientifico { get; set; }
        public bool PeligroDeExtinsion {get; set; }

        [ForeignKey("FamiliaId")]
        public virtual Familia Familia { get; set; }

        public virtual ICollection<Zoo> Zoo { get; set; }

    }
}