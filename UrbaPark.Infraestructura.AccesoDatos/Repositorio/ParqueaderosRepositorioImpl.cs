using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbaPark.Dominio.Modelo.Abstracciones;

namespace UrbaPark.Infraestructura.AccesoDatos.Repositorio
{
    public class ParqueaderosRepositorioImpl : RepositorioImpl<parqueaderos>, IParqueaderosRepositorio
    {
        private readonly urbaparkDBContext _urbaParkdbContext;
        public ParqueaderosRepositorioImpl(urbaparkDBContext dbContex) : base(dbContex)
        {
            _urbaParkdbContext = dbContex;  
        }
    }
}
