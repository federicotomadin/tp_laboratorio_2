using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using EntidadesAbstractas;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Clases_Instanciables
{
   [Serializable]
  

    public class Universidad
    {

        #region Enumerador
        public enum EClases
        {
            Programacion=0,
            Laboratorio=1,
            Legislacion=2,
            SPD=3
        }
        #endregion

        #region Atributos
        public List<Alumno> _alumnos;
        public List<Jornada> _jornada;
        public List<Profesor> _profesores;
        #endregion


        #region Propiedades
        public List<Alumno> Alumno
        {

            get { return this._alumnos; }
            set { this._alumnos = value; }

        }

        public List<Jornada> Jornada
        {

            get { return this._jornada; }
            set { this._jornada = value; }
        }

        public List<Profesor> Profesor
        {
            get { return this._profesores; }
            set { this._profesores = value; }
        }


        public Jornada this[int indice]
        {
            get
            {
                if (indice < this._jornada.Count || indice > this._jornada.Count)
                    return this._jornada[indice];
                else
                    return null;
            }
        }
        #endregion

      

        #region Constructor
        public Universidad()
        {
            this._alumnos = new List<Alumno>();
            this._profesores = new List<Profesor>();
            this._jornada = new List<Jornada>();
        }
        #endregion


        #region Sobrecarga de Operadores

        public static bool operator ==(Universidad g, Alumno a)
        {
            if (!Object.ReferenceEquals(g, null) && !Object.ReferenceEquals(a, null))
            {
                foreach (Alumno item in g._alumnos)
                {
                    if (item == a) return true;
                }
            }
            return false;
        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }


        public static bool operator ==(Universidad g, Profesor i)
        {
            if (!Object.ReferenceEquals(g, null) && !Object.ReferenceEquals(i, null))
            {
                foreach (Profesor item in g._profesores)
                {
                    if (item == i)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);

        }


        public static Profesor operator ==(Universidad g, Universidad.EClases clase)
        {
            if (!Object.ReferenceEquals(g, null) && !Object.ReferenceEquals(g, null))
            {
                foreach (Profesor item in g._profesores)
                {
                    if (item == clase) return item;
                }
            }
         
                throw new Excepciones.SinProfesorException();
            
        }


        public static Profesor operator !=(Universidad g, Universidad.EClases clase)
        {


            foreach (Profesor item in g._profesores)
            {
                if (item != clase) return item;
            }

            throw new Exception();            
           
        }
        


        

        /// <summary>
        /// Agrega a la universidad los alumnos de una misma clase que cumplen ciertas caracteristicas y crea 
        /// una jornada con el profesor que puede dar esa clase.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase">Enumerador</param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Universidad.EClases clase)
        {
            if (!Object.ReferenceEquals(g, null))
            {
                switch (clase)
                {
                    case EClases.Programacion:
                        Jornada aux = new Jornada(clase, g == clase);
                        foreach (Alumno item in g._alumnos)
                        {
                            if (item == clase)
                                aux += item;
                        }
                        g._jornada.Add(aux);
                        return g;
                       
                    case EClases.Laboratorio:
                        Jornada aux2 = new Jornada(clase, g == clase);
                        foreach (Alumno item in g._alumnos)
                        {
                            if (item == clase)
                                aux2 += item;
                        }
                        g._jornada.Add(aux2);
                        return g;
                    case EClases.Legislacion:
                        Jornada aux3 = new Jornada(clase, g == clase);
                        foreach (Alumno item in g._alumnos)
                        {
                            if (item == clase)
                                aux3 += item;
                        }
                        g._jornada.Add(aux3);
                        return g;
                    case EClases.SPD:
                        Jornada aux4= new Jornada(clase, g == clase);
                        foreach (Alumno item in g._alumnos)
                        {
                            if (item == clase)
                                aux4 += item;
                        }
                        g._jornada.Add(aux4);
                        return g;
                }
               
            }
            return null;
        }

        /// <summary>
        /// Agrega un alumno a la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            foreach (Alumno item in g._alumnos)
            {
                if (item == a)    throw new Excepciones.AlumnoRepetidoException();
                    
               
            }
            g._alumnos.Add(a);
            return g;
        }

        /// <summary>
        /// Agrega un profesor a la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            foreach (Profesor item in g._profesores)
            {
                if (item == i) return g;
            }
            g._profesores.Add(i);
            return g;
        }
        #endregion



        #region Metodos
        /// <summary>
        /// Muestra los datos de la jornada
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA: ");
            foreach (Jornada item in uni._jornada)
            {
                sb.AppendLine(item.ToString());
            }


            return sb.ToString();


        }

        /// <summary>
        /// Hace publicos los datos del metodo MostrarDatos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }


        /// <summary>
        /// Guarda los datos de la universidad en un archivo XML
        /// </summary>
        /// <param name="gim"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad gim)
        {

            bool flag = false;

            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "Universidad.xml";
            Archivos.Xml<Universidad> xml = new Archivos.Xml<Universidad>();
            try
            {

                xml.guardar(ruta, gim);
                flag = true;
            }
            catch (Exception e)
            {
                throw new Excepciones.ArchivosException(e);

            }

            return flag;

        }

        /// <summary>
        /// Lee los datos de una universidad desde un archivo XML
        /// </summary>
        /// <param name="gim"></param>
        /// <returns></returns>
        public static bool Leer(out Universidad gim)
        {
            bool flag = false;
            Xml<Universidad> xml = new Xml<Universidad>();

            try
            {
                string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Universidad.xml";
                xml.leer(ruta, out gim);
                flag = true;
            }
            catch (Exception e)
            {
                throw new Excepciones.ArchivosException(e);
            }

            return flag;
        }
        #endregion





    }
}
