using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejemplo_Eventos
{
    public partial class frmEventos : Form
    {
        public frmEventos()
        {
            InitializeComponent();
        }

        private void btnEvento_Click(object sender, EventArgs e)
        {
            // Clase que generará un evento, con un tiempo de 4s
            Evento lanzaEvento = new Evento(4000);
            // Agrego el método local EventoGenerado al manejador de eventos del objeto lanzaEvento
            lanzaEvento.EventoQueGenera += EventoGenerado;
            // Ejecuto un método de la clase que generará un evento
            lanzaEvento.esteMetodoGeneraEvento();
        }

        private void EventoGenerado(string mensaje)
        {
            // Mensaje del evento.
            MessageBox.Show(mensaje);
        }
    }
}
