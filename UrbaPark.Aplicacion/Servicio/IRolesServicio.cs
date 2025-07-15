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
    public interface IRolesServicio
    {
        [OperationContract]
        Task RolesAddAsync(roles TEntity); //insertar
        [OperationContract]
        Task RolesUpdateAsync(roles Entity);//actualizar
        [OperationContract]
        Task RolesDeleteAsync(int id);//eliminar por ID
        [OperationContract]
        Task<IEnumerable<roles>> RolesGetAllAsync();//listar todo
        [OperationContract]
        Task<roles> RolesGetByIdAsync(int id);//buscar por ID
        
    }
}
