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
    public class TecnicosSoftwareServicoImpl : ITecnicosSoftwareServicio
    {
        private readonly ITecnicosSoftwareRepositorio _tecnicosSoftwareRepositorio;
        private readonly urbaparkDBContext _dbContext;

        public TecnicosSoftwareServicoImpl(urbaparkDBContext urbaparkDBContext)
        {
            _dbContext = urbaparkDBContext;

            _tecnicosSoftwareRepositorio = new TecnicosSoftwareRepositorioImpl(_dbContext);
        }

        public async Task TecnicosSoftwareAddAsync(tecnicos_software TEntity)
        {
            await _tecnicosSoftwareRepositorio.AddAsync(TEntity);
        }

        public async Task TecnicosSoftwareDeleteAsync(int id)
        {
            await _tecnicosSoftwareRepositorio.DeleteAsync(id);
        }

        public async Task<IEnumerable<tecnicos_software>> TecnicosSoftwareGetAllAsync()
        {
            return await _tecnicosSoftwareRepositorio.GetAllAsync();
        }

        public async Task<tecnicos_software> TecnicosSoftwareGetByIdAsync(int id)
        {
            return await _tecnicosSoftwareRepositorio.GetByIdAsync(id);
        }

        public async Task TecnicosSoftwareUpdateAsync(tecnicos_software Entity)
        {
            await _tecnicosSoftwareRepositorio.UpdateAsync(Entity);
        }
    }
}
