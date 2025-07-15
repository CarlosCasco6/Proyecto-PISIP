using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbaPark.Aplicacion.Servicio;
using UrbaPark.Dominio.Modelo.Abstracciones;
using UrbaPark.Infraestructura.AccesoDatos;
using UrbaPark.Infraestructura.AccesoDatos.Repositorio;

namespace UrbaPark.Aplicacion.ServicioImpl
{
    public class CronogramasTecnicosServicioImpl : ICronogramasTecnicosServicio
    {
        private readonly ICronogramaTecnicosRepositorio _cronogramaTecnicosRepositorio;
        private readonly urbaparkDBContext _dbContext;

        public CronogramasTecnicosServicioImpl(urbaparkDBContext urbaparkDBContext)
        {
            _dbContext = urbaparkDBContext;

            _cronogramaTecnicosRepositorio = new CronogramasTecnicosRepositorioImpl(_dbContext);
        }

        public async Task CronogramaTecnicosAddAsync(rel_cronogramas_tecnicos TEntity)
        {
            await _cronogramaTecnicosRepositorio.AddAsync(TEntity);
        }

        public async Task CronogramaTecnicosDeleteAsync(int id)
        {
            await _cronogramaTecnicosRepositorio.DeleteAsync(id);
        }

        public async Task<IEnumerable<rel_cronogramas_tecnicos>> CronogramaTecnicosGetAllAsync()
        {
            return await _cronogramaTecnicosRepositorio.GetAllAsync();
        }

        public async Task<rel_cronogramas_tecnicos> CronogramaTecnicosGetByIdAsync(int id)
        {
            return await _cronogramaTecnicosRepositorio.GetByIdAsync(id);
        }

        public async Task CronogramaTecnicosUpdateAsync(rel_cronogramas_tecnicos Entity)
        {
            await _cronogramaTecnicosRepositorio.UpdateAsync(Entity);
        }
    }
}
