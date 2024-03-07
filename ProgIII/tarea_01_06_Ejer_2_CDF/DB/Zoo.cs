using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB;

public class Zoo
{
    [Key]
    public Guid Id { get; set; }
    public Guid CiudadId {get; set;}
    public Guid PaisId {get; set;}

    public string Nombre { get; set; }
    public double TamanioEnM2 {get; set;}
    public double PresupuestoAnual {get; set;}

    [ForeignKey("CiudadId")]
    public virtual Ciudad Ciudad {get; set;}
    [ForeignKey("PaisId")]
    public virtual Pais Pais {get; set;}
    public virtual ICollection<Animal> Animales {get; set;}
}
