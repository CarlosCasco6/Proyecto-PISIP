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
    public interface ICronogramasTecnicosServicio
    {
        [OperationContract]
        Task CronogramaTecnicosAddAsync(rel_cronogramas_tecnicos TEntity); //insertar
        [OperationContract]
        Task CronogramaTecnicosUpdateAsync(rel_cronogramas_tecnicos Entity);//actualizar
        [OperationContract]
        Task CronogramaTecnicosDeleteAsync(int id);//eliminar por ID
        [OperationContract]
        Task<IEnumerable<rel_cronogramas_tecnicos>> CronogramaTecnicosGetAllAsync();//listar todo
        [OperationContract]
        Task<rel_cronogramas_tecnicos> CronogramaTecnicosGetByIdAsync(int id);//buscar por ID
    }
}
