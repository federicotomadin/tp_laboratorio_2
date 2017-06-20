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
        // Delegado del evento
        public delegate void EventRaise(string mensaje);
        // Evento del tipo del delegado
        public event EventRaise EventoQueGenera;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tiempo">Tiempo en Milisegundos</param>
        public Evento(int tiempo)
        {
            this.tiempo = tiempo;
        }

        /// <summary>
        /// Generará un evento en el tiempo dado en el constructor
        /// </summary>
        public void esteMetodoGeneraEvento()
        {
            // Duermo el programa durante el tiempo dado
            System.Threading.Thread.Sleep(tiempo);
            // Lanzo el evento
            EventoQueGenera(String.Format("Evento lanzado a los {0} milisegundos",tiempo));
        }
    }
}
