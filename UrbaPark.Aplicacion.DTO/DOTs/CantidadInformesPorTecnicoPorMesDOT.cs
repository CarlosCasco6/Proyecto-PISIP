using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbaPark.Aplicacion.DTO.DOTs
{
    public class CantidadInformesPorTecnicoPorMesDOT
    {
        public string NombreTecnico { get; set; }
        public int Mes { get; set; } // 1 a 12
        public int Anio { get; set; }
        public int CantidadInformes { get; set; }

    }
}
