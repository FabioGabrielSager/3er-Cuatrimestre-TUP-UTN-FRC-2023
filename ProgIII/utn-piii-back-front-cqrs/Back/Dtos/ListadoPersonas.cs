namespace EjemploCQRS.Dtos
{
    public class ListadoPersonas : RespuestaBase
    {
        public List<PersonaDto> Personas { get; set; }
    }
}
