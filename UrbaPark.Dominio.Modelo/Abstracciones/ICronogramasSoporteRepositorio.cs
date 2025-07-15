using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbaPark.Aplicacion.DTO.DOTs;
using UrbaPark.Infraestructura.AccesoDatos;

namespace UrbaPark.Dominio.Modelo.Abstracciones
{
    public interface ICronogramasSoporteRepositorio: IRepositorio<cronogramas_soporte>
    {
       
        Task<List<CronogramaParqueaderosDOT>> ListarCronogramaSoportePorParqueadero();

    }
}
