using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;


namespace EntidadesAbstractas
{
     

    public abstract class Universitario:Persona
    {

        #region Atributos
        protected int _legajo;
        #endregion


        #region Constructores
        public Universitario()
        { }


        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this._legajo = legajo;
        }
        #endregion


        #region Sobrecarga de Operadores
        public override bool Equals(object obj)
        {
            return (obj is Universitario);
        }


        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if (!Object.ReferenceEquals(pg1, null) && !Object.ReferenceEquals(pg2, null))
            {
                if (pg1.Equals(pg2))
                {
                    if (pg1._legajo == pg2._legajo || pg1.DNI==pg2.DNI) return true;
                }

            }
             return false;
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion

      
        #region Metodos
        /// <summary>
        /// Metodo abstracto que muestra a que clases participa el alumno
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Muestra los datos de persona y de Universitario
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("LEGAJO NUMERO: " + this._legajo);

            return sb.ToString();
        }
        #endregion
    }
}
