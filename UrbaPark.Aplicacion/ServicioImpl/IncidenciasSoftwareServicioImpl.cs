using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbaPark.Aplicacion.DTO.DOTs;
using UrbaPark.Aplicacion.Servicio;
using UrbaPark.Dominio.Modelo.Abstracciones;
using UrbaPark.Infraestructura.AccesoDatos;
using UrbaPark.Infraestructura.AccesoDatos.Repositorio;

namespace UrbaPark.Aplicacion.ServicioImpl
{
    public class IncidenciasSoftwareServicioImpl : IIncidenciasSoftwareServicio
    {
        private readonly IIncidenciasSoftwareRepositorio _incidenciasSoftwareRepositorio;
        private readonly urbaparkDBContext _dbContext;

        public IncidenciasSoftwareServicioImpl(urbaparkDBContext urbaparkDBContext)
        {
            _dbContext = urbaparkDBContext;
            _incidenciasSoftwareRepositorio = new IncidenciasSoftwareRepositorioImpl(_dbContext);
        }

        public async Task IncidenciasSoftwareAddAsync(incidencias_software TEntity)
        {
            await _incidenciasSoftwareRepositorio.AddAsync(TEntity);
        }

        public async  Task IncidenciasSoftwareDeleteAsync(int id)
        {
            await _incidenciasSoftwareRepositorio.DeleteAsync(id);
        }

        public async Task<IEnumerable<incidencias_software>> IncidenciasSoftwareGetAllAsync()
        {
            return await _incidenciasSoftwareRepositorio.GetAllAsync();
        }

        public async Task<incidencias_software> IncidenciasSoftwareGetByIdAsync(int id)
        {
            return await _incidenciasSoftwareRepositorio.GetByIdAsync(id);
        }

        public async  Task IncidenciasSoftwareUpdateAsync(incidencias_software Entity)
        {
            await _incidenciasSoftwareRepositorio.UpdateAsync(Entity);
        }

        public async Task<List<IncidenciasNoResueltasPorParqueaderoDOT>> ObtenerIncidenciasNoResueltasPorParqueadero()
        {
            return await _incidenciasSoftwareRepositorio.ObtenerIncidenciasNoResueltasPorParqueadero();
        }
    }
}
