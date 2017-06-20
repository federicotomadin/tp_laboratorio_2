using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;


namespace Archivos
{
  
   public class Xml<T>:IArchivo<T>
    {


        #region Metodos
        /// <summary>
        /// Metodo para guardar en formato XML
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool guardar(string archivo, T datos)
       {
           bool flag = false;
           try
           {
                  using (StreamWriter sw=new StreamWriter(archivo))
                  {
                   XmlSerializer serializar = new XmlSerializer(typeof(T));
                   serializar.Serialize(sw, datos);
                   flag = true;
                  }
               }
           
           catch (Exception e)
           {
               throw e;
           }
          return flag;

       }

        /// <summary>
        /// Metodo para leer de un archivo XML
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
       public bool leer(string archivo, out T datos)
       {
           bool flag = false;
           try
           {
               using (XmlTextReader xArchivo = new XmlTextReader(archivo))
               {
                   XmlSerializer deSserializar = new XmlSerializer(typeof(T));
                   datos = (T)deSserializar.Deserialize(xArchivo);
                   flag = true;
 
               }
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
