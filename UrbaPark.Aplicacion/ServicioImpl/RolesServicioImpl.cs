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
    public class RolesServicioImpl : IRolesServicio
    {
        private readonly IRolesRepositorio _rolesRepositorio;
        private readonly urbaparkDBContext _dbContext;

        public RolesServicioImpl(urbaparkDBContext urbaparkDBContext)
        {
            _dbContext = urbaparkDBContext;

            _rolesRepositorio = new RolesRepositorioImpl(_dbContext);
        }

        public async Task RolesAddAsync(roles TEntity)
        {
            await _rolesRepositorio.AddAsync(TEntity);
        }

        public async Task RolesDeleteAsync(int id)
        {
            await _rolesRepositorio.DeleteAsync(id);
        }

        public async  Task<IEnumerable<roles>> RolesGetAllAsync()
        {
           return await _rolesRepositorio.GetAllAsync();
        }

        public async Task<roles> RolesGetByIdAsync(int id)
        {
           return await _rolesRepositorio.GetByIdAsync(id);
        }

        public async  Task RolesUpdateAsync(roles Entity)
        {
            await _rolesRepositorio.UpdateAsync(Entity);
        }
    }
}
