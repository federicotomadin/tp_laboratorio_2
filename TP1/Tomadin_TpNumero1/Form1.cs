using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tomadin_TpNumero1
{
    public partial class FrmCalculadora : Form
    {
    
     
       

       /// <summary>
       /// Instancio objetos de tipo Calculadora y Numero
       /// </summary>

        Calculadora calcular = new Calculadora();
        Numero valores = new Numero();
        Numero valores2 = new Numero();

       


        public FrmCalculadora()
        {
            InitializeComponent();
        }

       
        /// <summary>
        /// Metodo que setea los valores por defecto de las casillas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            string textoOperador="";

            Calculadora.Limpiar(valores, valores2, textoOperador);

            txtNumero1.Text = valores.getNumero().ToString();
            txtNumero2.Text = valores2.getNumero().ToString();           
            lblResultado.Text = "0";

        }

       /// <summary>
       /// Funcion que llama al metodo operar de la clase calculadora
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado = calcular.operar(valores, valores2, cmbOperador.Text);
            lblResultado.Text = resultado.ToString();          
             
        }

        private void FrmCalculadora_Load(object sender, EventArgs e)
        {
            this.Text = "Calculadora";
        }

        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {
            valores.setNumero(txtNumero1.Text);
        }

        private void txtNumero2_TextChanged(object sender, EventArgs e)
        {
            valores2.setNumero(txtNumero2.Text);
        }
    }
}
