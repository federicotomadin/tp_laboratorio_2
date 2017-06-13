using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto:IArchivo<string>
    {

        #region Metodos
        /// <summary>
        /// Metodo de clase tipada para guardar en formato texto
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool guardar(string archivo, string datos)
        {
            bool flag = false;
            try
            {
                using (StreamWriter sw = new StreamWriter(archivo, true))
                {
                    sw.Write(datos);
                }
                flag = true;

            }
            catch (Exception e)
            {

                throw e;
            }
            return flag;
        
        }

        /// <summary>
        /// Metodo para leer de un archivo de texto
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool leer(string archivo, out string datos)       
        {
            bool flag = false;
            try
            {
                using (StreamReader sr = new StreamReader(archivo))
                {
                    datos = sr.ReadToEnd();
                }

                flag = true;

            }
            catch (Exception e)
            {

                throw e;
            }
            return flag;
        }
        #endregion 
    }
}
