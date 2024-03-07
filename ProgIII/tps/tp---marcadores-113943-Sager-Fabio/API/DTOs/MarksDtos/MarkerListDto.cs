using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.MarksDtos
{
    public class MarkerListDto : BaseResponse
    {
        public List<MarkerDto> LitadoMarcadores { get; set; }
    }
}