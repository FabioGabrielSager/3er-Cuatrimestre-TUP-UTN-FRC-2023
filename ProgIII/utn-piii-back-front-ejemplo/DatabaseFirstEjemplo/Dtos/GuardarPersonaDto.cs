namespace DatabaseFirstEjemplo.Dtos
{
    public class GuardarPersonaDto
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public long TipoDocumentoId { get; set; }
    }
}
