using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo_Eventos
{
    public class Evento
    {
        int tiempo;
        public delegate void EventRaise(string mensaje);
        public event EventRaise EventoQueGenera;

        public Evento(int tiempo)
        {
            this.tiempo = tiempo;
        }

        
    }
}
