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
    public class InformesSoftwareServicioImpl : IInformesSoftwareServicio
    {
        private readonly IInformesSoftwareRepositorio _informeSoftwareRepositorio;
        private readonly urbaparkDBContext _dbContext;
        public InformesSoftwareServicioImpl(urbaparkDBContext urbaparkDBContext)
        {
            _dbContext = urbaparkDBContext;
            _informeSoftwareRepositorio = new InformesSoftwareRepositorioImpl(_dbContext);
        }

        public async Task InformesSoftwareAddAsync(informes_software TEntity)
        {
            await _informeSoftwareRepositorio.AddAsync(TEntity);
        }

        public  async Task InformesSoftwareDeleteAsync(int id)
        {
            await _informeSoftwareRepositorio.DeleteAsync(id);
        }

        public async Task<IEnumerable<informes_software>> InformesSoftwareGetAllAsync()
        {
            return await _informeSoftwareRepositorio.GetAllAsync();
        }

        public async Task<informes_software> InformesSoftwareGetByIdAsync(int id)
        {
            return await _informeSoftwareRepositorio.GetByIdAsync(id);
        }

        public async Task InformesSoftwareUpdateAsync(informes_software Entity)
        {
            await _informeSoftwareRepositorio.UpdateAsync(Entity);
        }

        public async Task<List<CantidadInformesPorTecnicoPorMesDOT>> ObtenerCantidadInformesPorTecnicoPorMes()
        {
            return await _informeSoftwareRepositorio.ObtenerCantidadInformesPorTecnicoPorMes();
        }

        public async Task<List<InformesPorTecnicoDOT>> ObtenerInformesPorTecnico()
        {
            return await _informeSoftwareRepositorio.ObtenerInformesPorTecnico();
        }
    }
}
