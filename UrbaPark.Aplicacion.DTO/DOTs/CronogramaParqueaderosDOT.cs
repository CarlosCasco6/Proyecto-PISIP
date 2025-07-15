using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbaPark.Aplicacion.DTO.DOTs
{
    public class CronogramaParqueaderosDOT
    {
        public string NombreParqueadero { get; set; }
     
       public int IdParqueadero { get; set; }
        public List<int> CronogramaPorParqueadero { get; set; } // Lista de nombres o IDs de parqueaderos asociados
        public DateTime FechaCreacion { get; set; }
        public DateTime Fechafin { get; set; }

    }
}
