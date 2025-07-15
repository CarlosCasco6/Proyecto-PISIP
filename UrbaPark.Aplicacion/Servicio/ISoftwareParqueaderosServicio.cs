using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using UrbaPark.Infraestructura.AccesoDatos;

namespace UrbaPark.Aplicacion.Servicio
{
    [ServiceContract]
    public interface ISoftwareParqueaderosServicio
    {
        [OperationContract]
        Task SoftwareParqueaderosAddAsync(software_parqueaderos TEntity); //insertar
        [OperationContract]
        Task SoftwareParqueaderosUpdateAsync(software_parqueaderos Entity);//actualizar
        [OperationContract]
        Task SoftwareParqueaderosDeleteAsync(int id);//eliminar por ID
        [OperationContract]
        Task<IEnumerable<software_parqueaderos>> SoftwareParqueaderosGetAllAsync();//listar todo
        [OperationContract]
        Task<software_parqueaderos> SoftwareParqueaderosGetByIdAsync(int id);//buscar por ID
    }
}
