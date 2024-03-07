using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clases.Resultados
{
    public class ResultadoBase
    {
        public int StatusCode { get; set; }
        public bool Ok { get; set; } = false;
        public string Error{ get; set; } = "";
        public string MensajeInfo { get; set; } = "";

        public void SetError(string error){
            Ok = false;
            Error = error;
            StatusCode = 500;
        }
    }
}