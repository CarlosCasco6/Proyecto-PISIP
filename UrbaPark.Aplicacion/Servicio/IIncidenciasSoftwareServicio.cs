using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using UrbaPark.Aplicacion.DTO.DOTs;
using UrbaPark.Infraestructura.AccesoDatos;

namespace UrbaPark.Aplicacion.Servicio
{
    [ServiceContract]
    public interface IIncidenciasSoftwareServicio
    {
        [OperationContract]
        Task IncidenciasSoftwareAddAsync(incidencias_software TEntity); //insertar
        [OperationContract]
        Task IncidenciasSoftwareUpdateAsync(incidencias_software Entity);//actualizar
        [OperationContract]
        Task IncidenciasSoftwareDeleteAsync(int id);//eliminar por ID
        [OperationContract]
        Task<IEnumerable<incidencias_software>> IncidenciasSoftwareGetAllAsync();//listar todo
        [OperationContract]
        Task<incidencias_software> IncidenciasSoftwareGetByIdAsync(int id);//buscar por ID
        [OperationContract]
        Task<List<IncidenciasNoResueltasPorParqueaderoDOT>> ObtenerIncidenciasNoResueltasPorParqueadero(); // Listar incidencias no resueltas por parqueadero
    }
}
