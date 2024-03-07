using System.Net;

namespace EjemploCQRS.Dtos
{
    public class RespuestaBase
    {
        public string Error { get; set; }
        public bool Exito { get; set; }
        public HttpStatusCode Codigo { get; set; }
    }
}
