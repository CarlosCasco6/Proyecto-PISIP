using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbaPark.Dominio.Modelo.Abstracciones;

namespace UrbaPark.Infraestructura.AccesoDatos.Repositorio
{
    public class TecnicosSoftwareRepositorioImpl : RepositorioImpl<tecnicos_software>, ITecnicosSoftwareRepositorio
    {
        private readonly urbaparkDBContext _urbaParkdbContext;
        public TecnicosSoftwareRepositorioImpl(urbaparkDBContext dbContex) : base(dbContex)
        {
            _urbaParkdbContext = dbContex;
        }
    }
}
