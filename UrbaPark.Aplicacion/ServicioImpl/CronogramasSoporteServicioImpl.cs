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
    public class CronogramasSoporteServicioImpl : ICronogramasSoporteServicio
    {
        private readonly ICronogramasSoporteRepositorio _cronogramasSoporteRepositorio;
        private readonly urbaparkDBContext _dbContext;

        public CronogramasSoporteServicioImpl(urbaparkDBContext urbaParkDBContext)
        {
            this._dbContext = urbaParkDBContext;
           this._cronogramasSoporteRepositorio = new CronogramasSoporteRepositorioImpl(_dbContext);
        }

        public async Task CronogramaSoporteAddAsync(cronogramas_soporte TEntity)
        {
            await _cronogramasSoporteRepositorio.AddAsync(TEntity);
        }

        public async Task CronogramaSoporteDeleteAsync(int id)
        {
            await _cronogramasSoporteRepositorio.DeleteAsync(id);
        }

        public async Task<IEnumerable<cronogramas_soporte>> CronogramaSoporteGetAllAsync()
        {
            return await _cronogramasSoporteRepositorio.GetAllAsync();
        }

        public async Task<cronogramas_soporte> CronogramaSoporteGetByIdAsync(int id)
        {
            return await _cronogramasSoporteRepositorio.GetByIdAsync(id);
        }

        public async Task CronogramaSoporteUpdateAsync(cronogramas_soporte entity)
        {
            await _cronogramasSoporteRepositorio.UpdateAsync(entity);
        }

       

        public Task<List<CronogramaParqueaderosDOT>> ListarCronogramaSoportePorParqueadero()
        {
            return _cronogramasSoporteRepositorio.ListarCronogramaSoportePorParqueadero();
        }


    }
}
