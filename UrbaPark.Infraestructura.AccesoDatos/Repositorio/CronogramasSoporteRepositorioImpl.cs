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
    public class CronogramasSoporteRepositorioImpl : RepositorioImpl<cronogramas_soporte>, ICronogramasSoporteRepositorio
    {
        private readonly urbaparkDBContext _urbaParkdbContext;
        public CronogramasSoporteRepositorioImpl(urbaparkDBContext dBContex) : base(dBContex)
        {
           this._urbaParkdbContext = dBContex;
        }


        public async Task<List<CronogramaParqueaderosDOT>> ListarCronogramaSoportePorParqueadero()
        {
            try
            {
                var resultado = await(from cronograma in _urbaParkdbContext.cronogramas_soporte
                                      join parqueadero in _urbaParkdbContext.parqueaderos on cronograma.id_parqueadero equals parqueadero.id_parqueadero
                                      group cronograma by parqueadero.nombre into grupo
                                      select new CronogramaParqueaderosDOT
                                      {
                                          NombreParqueadero = grupo.Key,
                                          CronogramaPorParqueadero = grupo.Select(c => c.id_cronograma).ToList(),
                                      }).ToListAsync();
                return resultado;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar cronograma  por parqueadero" + ex.Message);
            }
        }

       
    }
}
