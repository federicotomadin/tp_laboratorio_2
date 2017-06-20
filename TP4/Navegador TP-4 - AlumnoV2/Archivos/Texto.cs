using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
       
           private String _archivo;
        /// <summary>
        /// Constructor publico donde se le pasa el valor a la variable de tip String _archivo.
        /// </summary>
        /// <param name="archivo"></param>
        public Texto(string archivo)
        {
            this._archivo = Environment.CurrentDirectory + "\\" + archivo;
        }

        /// <summary>
        /// Guarda los datos pasados por parametros en _archivo.
        /// </summary>
        /// <param name="datos">Tipo de dato String datos. datos a ser guardados</param>
        /// <returns>Devuelve un Booleando si pudo guardar los </returns>
        public bool guardar(string datos)
        {
            try
            {
                if (File.Exists(this._archivo))
                {
                    using (StreamWriter archivoTxt = new StreamWriter(this._archivo, true))
                    {
                        archivoTxt.WriteLine(datos);
                    }
                }
                else
                {
                    using (StreamWriter archivoTxt = new StreamWriter(this._archivo, false))
                    {
                        archivoTxt.WriteLine(datos);
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Lee un archivo y los guarda en una lista pasado por parametros.
        /// </summary>
        /// <param name="datos">out lista de tipo string donde se van a guardar los datos leidos</param>
        /// <returns>Devuelve true si pudo leer, o lanza una excepcion si no pudo.</returns>
        public bool leer(out List<string> datos)
        {
            String lineaLeida;
            datos = new List<string>();
            try
            {
                using(StreamReader archivoLeido = new StreamReader(this._archivo))
                {
                    while ((lineaLeida = archivoLeido.ReadLine()) != null)
                    {
                        datos.Add(lineaLeida);
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        
        }
    
        
    }
}
