using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbaPark.Aplicacion.DTO.DOTs;
using UrbaPark.Infraestructura.AccesoDatos;

namespace UrbaPark.Dominio.Modelo.Abstracciones
{
    public interface IIncidenciasSoftwareRepositorio: IRepositorio<incidencias_software>    
    {
        Task<List<IncidenciasNoResueltasPorParqueaderoDOT>> ObtenerIncidenciasNoResueltasPorParqueadero();
    }
}
