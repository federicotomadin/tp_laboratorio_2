using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;
using System.Xml;
using System.Xml.Serialization;

namespace Clases_Instanciables
{
    [Serializable]
   
    public class Jornada
    {

        #region Atributos
        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;
        #endregion

        #region Propiedades
        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }

        }

        public Profesor Instructor
        {
            get { return _instructor; }
            set { _instructor = value; }

        }

        public Universidad.EClases Clase
        {
            get { return _clase; }
            set { _clase = value; }
        }
        #endregion

        #region Constructores
        private Jornada()
       {
           this._alumnos = new List<Alumno>();
          
       }


       public Jornada(Universidad.EClases clase, Profesor instructor):this()
       {
           this._clase = clase;
           this._instructor = instructor;
           
       }
        #endregion

        #region Sobrecarga de Operadores
        public static bool operator ==(Jornada j, Alumno a)
       {
           foreach (Alumno item in j._alumnos)
           {
               if (item == j._clase) return true;
           }
           return false;
                 
       }


       public static bool operator !=(Jornada j, Alumno a)
       {
           return !(j == a);

       }

       public static Jornada operator +(Jornada j, Alumno a)
       {
         
               foreach (Alumno item in j._alumnos)
               {
                   if (item == a) return j;
               }
               
           
           j._alumnos.Add(a);
           return j;
           
       }
        #endregion


        #region Metodos

        /// <summary>
        /// Muestra los datos de la jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
       {
           StringBuilder sb = new StringBuilder();

          
           sb.Append("CLASE DE " +  this._clase + " POR " + this._instructor);

           foreach (Alumno item in this._alumnos)
           {
               sb.Append(item.ToString());
           }
           sb.AppendLine("<------------------------------------------------>");
         

           return sb.ToString();
       }


        /// <summary>
        /// Guarda en un archivo de texto los datos de la jornada
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
       public static bool Guardar(Jornada jornada)
       {
        
           string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\jornada.txt";
           Texto text = new Texto();


           if (text.guardar(ruta, jornada.ToString()))
               return true;


           else return false;
             
            

       }

        /// <summary>
        /// Lee de un archivo de texto los datos de la jornada
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
       public static bool Leer(out string datos)
       {
           String ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Jornada.txt";
           Texto text = new Texto();

            if(text.leer(ruta, out datos))
               return true;
           

          return false;
        

       }

        #endregion






    }
}
