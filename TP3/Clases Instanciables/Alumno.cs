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


   public sealed class Alumno:Universitario
    {
        #region Enumerador
        public enum EEstadoCuenta
       { Becado,AlDia,Deudor}
        #endregion

        #region Atributos
        private EEstadoCuenta _estadoCuenta;
       private Universidad.EClases _claseQueToma;
        #endregion


        #region Constructores
        public Alumno()
       { }


       public Alumno(int id, string nombre, string apellido, string dni, Universitario.ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
           : base(id,nombre,apellido,dni,nacionalidad)
       {
           this._claseQueToma = claseQueToma;
       }

       public Alumno(int id, string nombre, string apellido, string dni, Universitario.ENacionalidad nacionalidad, Universidad.EClases claseQueToma,EEstadoCuenta estadoCuenta)
           :this(id, nombre, apellido, dni, nacionalidad,claseQueToma)
       {
           this._estadoCuenta = estadoCuenta;
       }
        #endregion

        #region Sobrecarga de operadores
        public static bool operator ==(Alumno a, Universidad.EClases clase)
       {
           
               if (a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor)
               {
                   return true;
               }
           
           return false;
           
          
       }

       public static bool operator !=(Alumno a, Universidad.EClases clase)
       {
           return !(a == clase);
       }
        #endregion

        #region Metodos
        /// <summary>
        /// retorna las clases qut toma el alumno
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
       {
           return "TOMA CLASE DE " + this._claseQueToma;
       }

        /// <summary>
        /// Muestra los datos del alumno, de universitario y de persona.
        /// </summary>
        /// <returns></returns>
       protected override string MostrarDatos()
       {
           StringBuilder sb = new StringBuilder();

           sb.AppendLine("ALUMNOS: ");
           sb.AppendLine(base.MostrarDatos());
           if (this._estadoCuenta == EEstadoCuenta.AlDia)
           { sb.AppendLine("ESTADO DE CUENTA: " + "Cuota al día"); }
          
           else sb.AppendLine("ESTADO DE CUENTA " + this._estadoCuenta);
           sb.AppendLine(this.ParticiparEnClase());
           

           return sb.ToString();
       }

        /// <summary>
        /// Hce publicos los datos del metodo MostrarDatos
        /// </summary>
        /// <returns></returns>
       public override string ToString()
       {
           return this.MostrarDatos();
       }
        #endregion

    }
}
