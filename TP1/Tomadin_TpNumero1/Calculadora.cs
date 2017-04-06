using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomadin_TpNumero1
{
  public   class Calculadora
    {
        /// <summary>
        /// Metodo publico que realiza la operacion segun el operador pasado como parametro
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador">Podra se + - * /</param>
        /// <returns></returns>
        public double operar(Numero numero1, Numero numero2, string operador)
        {
            double resultado;

            switch (operador)
            {
                case "+": resultado = (numero1.getNumero() + numero2.getNumero());
                    break;
                case "-": resultado = (numero1.getNumero() - numero2.getNumero());
                    break;
                case "*": resultado = (numero1.getNumero() * numero2.getNumero());
                    break;
                case "/": if (numero2.getNumero() == 0)
                    {
                        resultado = 0;

                    }
                    else
                    {
                        resultado = numero1.getNumero() / numero2.getNumero();
                    }
                   break;
                default:  resultado = numero1.getNumero() + numero2.getNumero();
                   break;
            }
            return resultado;
        }

        
      /// <summary>
      /// Funcion que valida el operador ingresado por el usuario
      /// </summary>
      /// <param name="operador"></param>
      /// <returns></returns>
        public string ValidarOperador(string operador)
        {
            if (operador != "+" && operador != "-" && operador != "*" && operador != "/")
            {
                operador = "+";
            }

            return operador;
        }


         /// <summary>
         /// Funcion para limpiar los valores contenidos en las variables
         /// </summary>
         /// <param name="uno"></param>
         /// <param name="dos"></param>
         /// <param name="operador"></param>
        public static void Limpiar(Numero uno, Numero dos, string operador)
        {
            uno.setNumero("");
            dos.setNumero("");
            operador = "";
        }
     
    }
}
