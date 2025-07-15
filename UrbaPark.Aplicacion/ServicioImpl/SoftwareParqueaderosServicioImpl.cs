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
    public class SoftwareParqueaderosServicioImpl : ISoftwareParqueaderosServicio
    {
        private readonly ISoftwareParqueaderosRepositorio _softwareParqueaderosRepositorio;
        private readonly urbaparkDBContext _dbContext;

        public SoftwareParqueaderosServicioImpl(urbaparkDBContext urbaparkDBContext)
        {
            this._dbContext = urbaparkDBContext;

            this._softwareParqueaderosRepositorio = new SoftwareParqueaderosRepositorioImplcs(_dbContext);
        }

        public async Task SoftwareParqueaderosAddAsync(software_parqueaderos TEntity)
        {
            await _softwareParqueaderosRepositorio.AddAsync(TEntity);
        }

        public async Task SoftwareParqueaderosDeleteAsync(int id)
        {
            await _softwareParqueaderosRepositorio.DeleteAsync(id);
        }

        public async Task<IEnumerable<software_parqueaderos>> SoftwareParqueaderosGetAllAsync()
        {
            return await _softwareParqueaderosRepositorio.GetAllAsync();
        }

        public async Task<software_parqueaderos> SoftwareParqueaderosGetByIdAsync(int id)
        {
            return await _softwareParqueaderosRepositorio.GetByIdAsync(id);
        }

        public async Task SoftwareParqueaderosUpdateAsync(software_parqueaderos Entity)
        {
            await _softwareParqueaderosRepositorio.UpdateAsync(Entity);
        }
    }
}
