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
    public interface IInformesSoftwareServicio
    {

        [OperationContract]
        Task InformesSoftwareAddAsync(informes_software TEntity); //insertar
        [OperationContract]
        Task InformesSoftwareUpdateAsync(informes_software Entity);//actualizar
        [OperationContract]
        Task InformesSoftwareDeleteAsync(int id);//eliminar por ID
        [OperationContract]
        Task<IEnumerable<informes_software>> InformesSoftwareGetAllAsync();//listar todo
        [OperationContract]
        Task<informes_software> InformesSoftwareGetByIdAsync(int id);//buscar por ID
        [OperationContract]
        Task<List<InformesPorTecnicoDOT>> ObtenerInformesPorTecnico(); // Listar informes por técnico
        [OperationContract]
        Task<List<CantidadInformesPorTecnicoPorMesDOT>> ObtenerCantidadInformesPorTecnicoPorMes();
    }
}
