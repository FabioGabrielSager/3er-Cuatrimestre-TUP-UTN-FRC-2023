using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DB
{
    public class Pais
    {
        [Key]
        public Guid Id { get; set; }
        public string Nombre { get; set; }
    }
}