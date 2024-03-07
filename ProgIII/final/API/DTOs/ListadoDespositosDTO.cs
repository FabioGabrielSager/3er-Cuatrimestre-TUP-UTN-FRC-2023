using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class ListadoDespositosDTO : RespuestaBase
    {  
       public List<DepositoStandard> Depositos { get; set; } 
    }
}