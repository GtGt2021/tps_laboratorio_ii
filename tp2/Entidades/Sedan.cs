using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Entidades
{

    public class Sedan : Vehiculo
    {

        /// <summary>
        /// Tipo Auto
        /// </summary>
        public enum ETipo
        {
            CuatroPuertas, CincoPuertas
        }

        ETipo tipo;

        /// <summary>
        /// Por defecto, TIPO será CuatroPuertas
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color) : base(chasis, marca, color)
        {
            this.tipo = ETipo.CuatroPuertas;
        }


        /// <summary>
        /// Contructor que recibe todos los parametros del Auto
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        /// <param name="tipo"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo) : this(marca, chasis, color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Sedan son 'Mediano'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get { return ETamanio.Mediano; }
        }


        /// <summary>
        /// sobreescribimos metodo Mostrar llamamos al metodo Base y cargamos los datos adicionales 
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendLine(base.Mostrar());
            sb.Append($"TAMAÑO : {this.Tamanio}");
            sb.AppendFormat($"TIPO : {this.tipo}\n");
            sb.AppendLine("");
            sb.AppendLine("---------------------");
            return sb.ToString();
        }

    }
}
