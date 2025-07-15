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
    public interface ICronogramasSoporteServicio
    {
        [OperationContract]
        Task CronogramaSoporteAddAsync(cronogramas_soporte TEntity); //insertar
        [OperationContract]
        Task CronogramaSoporteUpdateAsync(cronogramas_soporte Entity);//actualizar
        [OperationContract]
        Task CronogramaSoporteDeleteAsync(int id);//eliminar por ID
        [OperationContract]
        Task<IEnumerable<cronogramas_soporte>> CronogramaSoporteGetAllAsync();//listar todo
        [OperationContract]
        Task<cronogramas_soporte> CronogramaSoporteGetByIdAsync(int id);//buscar por ID
        [OperationContract]
        Task<List<CronogramaParqueaderosDOT>> ListarCronogramaSoportePorParqueadero();//listar cronograma por parqueadero
       

    }
}
