using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbaPark.Aplicacion.DTO.DOTs
{
    public class InformesPorTecnicoDOT
    {
        public string NombreTecnico { get; set; }
        public List<string> ModulosReportados { get; set; } // o IDs, según lo que quieras mostrar

    }
}
