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
    public class UsuariosServicioImpl : IUsuariosServicio
    {
        private readonly IUsuariosRepositorio _usuariosRepositorio;
        private readonly urbaparkDBContext _dbContext;
        public UsuariosServicioImpl(urbaparkDBContext urbaparkDBContext)
        {
            this._dbContext = urbaparkDBContext;


            this._usuariosRepositorio = new UsuariosRepositorioImpl(_dbContext);


        }

        public async  Task UsuariosAddAsync(usuarios TEntity)
        {
            await _usuariosRepositorio.AddAsync(TEntity);
        }

        public async Task UsuariosDeleteAsync(int id)
        {
            await _usuariosRepositorio.DeleteAsync(id);
        }

        public async  Task<IEnumerable<usuarios>> UsuariosGetAllAsync()
        {
            return await _usuariosRepositorio.GetAllAsync();
        }

        public async Task<usuarios> UsuariosGetByIdAsync(int id)
        {
           return await _usuariosRepositorio.GetByIdAsync(id);
        }

        public async  Task UsuariosUpdateAsync(usuarios Entity)
        {
           await _usuariosRepositorio.UpdateAsync(Entity);
        }
    }

}