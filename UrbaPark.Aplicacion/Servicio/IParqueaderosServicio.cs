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
    public interface IParqueaderosServicio
    {
        [OperationContract]
        Task ParqueaderosAddAsync(parqueaderos TEntity); //insertar
        [OperationContract]
        Task ParqueaderosUpdateAsync(parqueaderos Entity);//actualizar
        [OperationContract]
        Task ParqueaderosDeleteAsync(int id);//eliminar por ID
        [OperationContract]
        Task<IEnumerable<parqueaderos>> ParqueaderosGetAllAsync();//listar todo
        [OperationContract]
        Task<parqueaderos> ParqueaderosGetByIdAsync(int id);//buscar por ID
    }
}
