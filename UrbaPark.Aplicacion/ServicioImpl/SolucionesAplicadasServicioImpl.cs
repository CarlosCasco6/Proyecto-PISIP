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
    public class SolucionesAplicadasServicioImpl : ISolucionesAplicadasServicio
    {
        private readonly ISolucionesAplicadasRepositorio _solucionesAplicadasRepositorio;
        private readonly urbaparkDBContext _dbContext;

        public SolucionesAplicadasServicioImpl(urbaparkDBContext urbaparkDBContext )
        {
            _dbContext = urbaparkDBContext;

            _solucionesAplicadasRepositorio = new SolocionesAplicadasRepositorioImpl(_dbContext);
        }

        public async  Task SolucionesAplicadasAddAsync(soluciones_aplicadas TEntity)
        {
            await _solucionesAplicadasRepositorio.AddAsync(TEntity);
        }

        public async Task SolucionesAplicadasDeleteAsync(int id)
        {
            await _solucionesAplicadasRepositorio.DeleteAsync(id);
        }

        public async Task<IEnumerable<soluciones_aplicadas>> SolucionesAplicadasGetAllAsync()
        {
            return await _solucionesAplicadasRepositorio.GetAllAsync();
        }

        public async Task<soluciones_aplicadas> SolucionesAplicadasGetByIdAsync(int id)
        {
            return await _solucionesAplicadasRepositorio.GetByIdAsync(id);
        }

        public async Task SolucionesAplicadasUpdateAsync(soluciones_aplicadas Entity)
        {
            await _solucionesAplicadasRepositorio.UpdateAsync(Entity);
        }
    }
}
