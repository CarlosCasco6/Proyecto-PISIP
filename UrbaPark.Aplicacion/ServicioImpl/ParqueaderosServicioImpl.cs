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
    public class ParqueaderosServicioImpl : IParqueaderosServicio
    {
        private readonly IParqueaderosRepositorio _parqueaderosRepositorio;
        private readonly urbaparkDBContext _dbContext;
        public ParqueaderosServicioImpl(urbaparkDBContext urbaparkDBContext)
        {
            _dbContext = urbaparkDBContext;

            _parqueaderosRepositorio = new ParqueaderosRepositorioImpl(_dbContext);
        }

        public async Task ParqueaderosAddAsync(parqueaderos TEntity)
        {
            await _parqueaderosRepositorio.AddAsync(TEntity);
        }

        public async Task ParqueaderosDeleteAsync(int id)
        {
            await _parqueaderosRepositorio.DeleteAsync(id);
        }

        public async Task<IEnumerable<parqueaderos>> ParqueaderosGetAllAsync()
        {
            return await _parqueaderosRepositorio.GetAllAsync();
        }

        public async Task<parqueaderos> ParqueaderosGetByIdAsync(int id)
        {
            return await _parqueaderosRepositorio.GetByIdAsync(id);
        }

        public async Task ParqueaderosUpdateAsync(parqueaderos Entity)
        {
            await _parqueaderosRepositorio.UpdateAsync(Entity);
        }
    }
}
