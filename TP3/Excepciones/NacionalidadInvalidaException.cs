using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException:Exception
    {

        public NacionalidadInvalidaException()
            : base("La nacionalidad no coincide con el numero de DNI")
        { }


        public NacionalidadInvalidaException(string message)
            : base("La nacionalidad ingresada no coincide con el DNI" + message)
        { }
    }
}
