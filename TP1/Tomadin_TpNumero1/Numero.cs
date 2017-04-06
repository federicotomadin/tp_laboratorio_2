using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomadin_TpNumero1
{
   public class Numero
    {
       /// <summary>
       /// variable donde almaceno el numero
       /// </summary>
        double _numero;
      
       /// <summary>
       /// Constructor por defecto, inicializo con 0
       /// </summary>
        public Numero() 
        {
            this._numero = 0;
        
        }

        public Numero(double numero)
        {
             this._numero = numero;

        }

        /// <summary>
        /// constructor sobrecarcado que recibe la variable numero de tipo string 
        /// </summary>
        /// <param name="numero"></param>
        public Numero(string numero)
        {
            this.setNumero(numero);

        }
        /// <summary>
        /// Funcion de tipo setter, que valida el numero ingresado y si es correcto lo escribe en la variable.
        /// </summary>
        /// <param name="numero"></param>
        public void setNumero(string numero)
        {
                          
            this._numero = this.validarNumero(numero);
            
        }

        /// <summary>
        /// funcion que valida si el numero ingresado es un numero y no cualquier otro caracter
        /// </summary>
        /// <param name="numeroString"></param>
        /// <returns></returns>
        public double validarNumero(string numeroString)
        {
            double numero;

            if (Double.TryParse(numeroString, out  numero))
            {
                return numero;
            }

            else

                return 0;
        }

       /// <summary>
       /// Metodo que retorna la variable de la clase
       /// </summary>
       /// <returns></returns>
        public double getNumero()
        {
            return this._numero;
        }
    }
}
