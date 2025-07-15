using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbaPark.Dominio.Modelo.Abstracciones;

namespace UrbaPark.Infraestructura.AccesoDatos.Repositorio
{
    public class CronogramasTecnicosRepositorioImpl : RepositorioImpl<rel_cronogramas_tecnicos>, ICronogramaTecnicosRepositorio
    {
        private readonly urbaparkDBContext _urbaParkdbContext;
        public CronogramasTecnicosRepositorioImpl(urbaparkDBContext dbContex) : base(dbContex)
        {
            _urbaParkdbContext = dbContex;
        }
    }
}
