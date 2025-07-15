using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UrbaPark.Aplicacion.DTO.DOTs;
using UrbaPark.Dominio.Modelo.Abstracciones;

namespace UrbaPark.Infraestructura.AccesoDatos.Repositorio
{
    public class InformesSoftwareRepositorioImpl : RepositorioImpl<informes_software>, IInformesSoftwareRepositorio
    {
        private readonly urbaparkDBContext _urbaParkdbContext;
        public InformesSoftwareRepositorioImpl(urbaparkDBContext dbContex) : base(dbContex)
        {
            _urbaParkdbContext = dbContex;
        }
        public async Task<List<InformesPorTecnicoDOT>> ObtenerInformesPorTecnico()
        {
            try
            {
                var resultado = await (
                from informe in _urbaParkdbContext.informes_software
                join tecnico in _urbaParkdbContext.tecnicos_software
                on informe.id_tecnico equals tecnico.id_tecnico
                group informe by tecnico.nombre into grupo
                select new InformesPorTecnicoDOT
                {
                    NombreTecnico = grupo.Key,
                    ModulosReportados = grupo.Select(i => i.modulo_afectado).Distinct().ToList()
                }).ToListAsync();

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar informes por técnico: " + ex.Message);
            }
        }

        public async Task<List<CantidadInformesPorTecnicoPorMesDOT>> ObtenerCantidadInformesPorTecnicoPorMes()
        {
            try
            {
                var resultado = await (
                    from informe in _urbaParkdbContext.informes_software
                    join tecnico in _urbaParkdbContext.tecnicos_software
                        on informe.id_tecnico equals tecnico.id_tecnico
                    group informe by new
                    {
                        tecnico.nombre,
                        Mes = informe.fecha.Month,
                        Anio = informe.fecha.Year
                    } into grupo
                    select new CantidadInformesPorTecnicoPorMesDOT
                    {
                        NombreTecnico = grupo.Key.nombre,
                        Mes = grupo.Key.Mes,
                        Anio = grupo.Key.Anio,
                        CantidadInformes = grupo.Count()
                    }).ToListAsync();

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al calcular informes por técnico/mes: " + ex.Message);
            }
        }



    }
}
    


