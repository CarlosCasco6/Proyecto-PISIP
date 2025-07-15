using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbaPark.Aplicacion.DTO.DOTs;
using UrbaPark.Infraestructura.AccesoDatos;

namespace UrbaPark.Dominio.Modelo.Abstracciones
{
    public interface IInformesSoftwareRepositorio: IRepositorio<informes_software>
    {
        Task<List<InformesPorTecnicoDOT>> ObtenerInformesPorTecnico(); // Listar informes por técnico
        Task<List<CantidadInformesPorTecnicoPorMesDOT>> ObtenerCantidadInformesPorTecnicoPorMes(); // Listar cantidad de informes por técnico por mes
    }
}
