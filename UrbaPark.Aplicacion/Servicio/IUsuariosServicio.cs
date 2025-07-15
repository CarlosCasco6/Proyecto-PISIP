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
    public interface IUsuariosServicio
    {
        [OperationContract]
        Task UsuariosAddAsync(usuarios TEntity); //insertar
        [OperationContract]
        Task UsuariosUpdateAsync(usuarios Entity);//actualizar
        [OperationContract]
        Task UsuariosDeleteAsync(int id);//eliminar por ID
        [OperationContract]
        Task<IEnumerable<usuarios>> UsuariosGetAllAsync();//listar todo
        [OperationContract]
        Task<usuarios> UsuariosGetByIdAsync(int id);//buscar por ID

    }
}
