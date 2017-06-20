using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using System.Xml;
using System.Xml.Serialization;

namespace Clases_Instanciables
{
    [Serializable]
   


    public sealed class Profesor:Universitario
    {
        #region Atributos
        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random _random;
        #endregion

        #region Constructores
        static Profesor()
        {
            Profesor._random = new Random();
        }

        public Queue<Universidad.EClases> Clases
        {
            get { return this._clasesDelDia; }
        }


        public Profesor()
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
        }


        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this.RandomClases();
            this.RandomClases();
           
           
        }
        #endregion


        #region Sobrecarga de Operadores
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
          
                foreach(Universidad.EClases item in i._clasesDelDia)
                {
                    if (item == clase) return true;
                }

            

            return false;
        }



        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        /// <summary>
        /// Metodo que asigna una clase al azar
        /// </summary>
        private void RandomClases()
        {
                       
          this._clasesDelDia.Enqueue((Universidad.EClases)_random.Next(0,3));
        
                              
        }
        #endregion


        #region Metodos

        /// <summary>
        /// Muestra los datos del profesor y las clases que puede dar
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
           

            return sb.ToString();
        }

        /// <summary>
        /// Metodo  que devuelve las clases qeu puede dar el profesor segun el random
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            if (this._clasesDelDia != null)
            {
                sb.AppendLine("CLASES DEL DIA ");


                foreach (Universidad.EClases item in _clasesDelDia)
                {
                    sb.AppendLine(item.ToString());
                }
            }

            return sb.ToString();
           
        }

        /// <summary>
        /// Hace publicos los datos del metodo Mostrar Datos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion





    }
}
