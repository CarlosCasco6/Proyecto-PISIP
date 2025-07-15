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
    public interface ITecnicosSoftwareServicio 
    {
        [OperationContract]
        Task TecnicosSoftwareAddAsync(tecnicos_software TEntity); //insertar
        [OperationContract]
        Task TecnicosSoftwareUpdateAsync(tecnicos_software Entity);//actualizar
        [OperationContract]
        Task TecnicosSoftwareDeleteAsync(int id);//eliminar por ID
        [OperationContract]
        Task<IEnumerable<tecnicos_software>> TecnicosSoftwareGetAllAsync();//listar todo
        [OperationContract]
        Task<tecnicos_software> TecnicosSoftwareGetByIdAsync(int id);//buscar por ID
    }
}
