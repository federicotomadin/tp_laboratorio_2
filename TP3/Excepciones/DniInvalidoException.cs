using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException:Exception
    {
        private static string mensajeBase = "El dni es invalido";


        public DniInvalidoException()
            : base(mensajeBase)
        { }

        public DniInvalidoException(Exception e)
            : base(mensajeBase,e)
        { }

        public DniInvalidoException(string menssage)
            : base(mensajeBase + menssage)
        { }


        public DniInvalidoException(string message,Exception e)
            : base(mensajeBase + message + e)
        { }
    }
}
