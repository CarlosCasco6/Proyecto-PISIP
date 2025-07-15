using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UrbaPark.Aplicacion.DTO.DOTs;
using UrbaPark.Dominio.Modelo.Abstracciones;

namespace UrbaPark.Infraestructura.AccesoDatos.Repositorio
{
    public class IncidenciasSoftwareRepositorioImpl : RepositorioImpl<incidencias_software>, IIncidenciasSoftwareRepositorio
    {
        private readonly urbaparkDBContext _urbaParkdbContext;
        public IncidenciasSoftwareRepositorioImpl(urbaparkDBContext dbContex) : base(dbContex)
        {
            _urbaParkdbContext = dbContex;  
        }

        public async Task<List<IncidenciasNoResueltasPorParqueaderoDOT>> ObtenerIncidenciasNoResueltasPorParqueadero()
        {
            try
            {
                var resultado = await (
    from incidencia in _urbaParkdbContext.incidencias_software
    join informe in _urbaParkdbContext.informes_software
        on incidencia.id_informe equals informe.id_informe
    join software in _urbaParkdbContext.software_parqueaderos
        on informe.id_software equals software.id_software
    join parqueadero in _urbaParkdbContext.parqueaderos
        on software.id_parqueadero equals parqueadero.id_parqueadero
    where !_urbaParkdbContext.soluciones_aplicadas
        .Any(sol => sol.id_incidencia == incidencia.id_incidencia)
    group informe by parqueadero.nombre into grupo
    select new IncidenciasNoResueltasPorParqueaderoDOT
    {
        NombreParqueadero = grupo.Key,
        ModulosAfectados = grupo.Select(i => i.modulo_afectado).Distinct().ToList()
    }).ToListAsync();






                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener incidencias no resueltas por parqueadero: " + ex.Message);
            }
        }


    }
}
