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
    public interface ISolucionesAplicadasServicio
    {
        [OperationContract]
        Task SolucionesAplicadasAddAsync(soluciones_aplicadas TEntity); //insertar
        [OperationContract]
        Task SolucionesAplicadasUpdateAsync(soluciones_aplicadas Entity);//actualizar
        [OperationContract]
        Task SolucionesAplicadasDeleteAsync(int id);//eliminar por ID
        [OperationContract]
        Task<IEnumerable<soluciones_aplicadas>> SolucionesAplicadasGetAllAsync();//listar todo
        [OperationContract]
        Task<soluciones_aplicadas> SolucionesAplicadasGetByIdAsync(int id);//buscar por ID
    }
}
