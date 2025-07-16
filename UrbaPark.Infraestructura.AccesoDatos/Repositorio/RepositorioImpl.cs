using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UrbaPark.Dominio.Modelo.Abstracciones;

namespace UrbaPark.Infraestructura.AccesoDatos.Repositorio
{
    public class RepositorioImpl<T> : IRepositorio<T> where T : class
    {
        private readonly urbaparkDBContext _dbContex;
        private readonly DbSet<T> _dbSet;

        //contructor

        public RepositorioImpl(urbaparkDBContext dbContex)
        {
            _dbContex = dbContex;
            _dbSet = dbContex.Set<T>();
        }


        public async Task AddAsync(T TEntity)
        {
            try
            {
                await _dbSet.AddAsync(TEntity);
                await _dbContex.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error: No se pudo insertar Datos " + e.Message);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var entity = await GetByIdAsync(id);
                _dbSet.Remove(entity);
                await _dbContex.SaveChangesAsync();            }
            catch (Exception e)
            {
                throw new Exception("Error: No se pudo eliminar Datos " + e.Message);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {

                return await _dbSet.ToListAsync();

            }
            catch (Exception e)
            {
                throw new Exception("Error: No se pudo listar Datos " + e.Message);
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                return await _dbSet.FindAsync(id);
            }
            catch (Exception e)
            {
                throw new Exception("Error: No se pudo buscar por id los Datos " + e.Message);
            }
        }

        public async Task UpdateAsync(T Entity)
        {
            try
            {
                _dbSet.Update(Entity);
                await _dbContex.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error: No se pudo actualizar Datos " + e.Message);
            }
        }


    }
}
