using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API.DTOS
{
    public class RespuestaBase
    {
        public string mensajeInfo { get; set; }
        public string error { get; set; }
        public HttpStatusCode httpStatusCode{ get; set; }
        public bool ok {get; set; }

    }
}