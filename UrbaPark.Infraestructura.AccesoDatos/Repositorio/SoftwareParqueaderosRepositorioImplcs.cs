using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbaPark.Dominio.Modelo.Abstracciones;

namespace UrbaPark.Infraestructura.AccesoDatos.Repositorio
{
    public class SoftwareParqueaderosRepositorioImplcs : RepositorioImpl<software_parqueaderos>, ISoftwareParqueaderosRepositorio
    {
        private readonly urbaparkDBContext _urbaParkdbContext;
        public SoftwareParqueaderosRepositorioImplcs(urbaparkDBContext dbContex) : base(dbContex)
        {
            _urbaParkdbContext = dbContex;
        }
    }
}
