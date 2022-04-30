using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ciclomotor : Vehiculo
    {
        /// <summary>
        /// Constructor Clase
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color) : base(chasis, marca, color)
        {           
        }

        
        /// <summary>
        /// Ciclomotor son 'Chico'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get { return (ETamanio.Chico); }
        }


        /// <summary>
        /// sobreescribimos metodo Mostrar llamamos al metodo Base y cargamos los datos adicionales 
        /// </summary>
        /// <returns></returns>
        public sealed override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CICLOMOTOR");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"TAMAÑO : {this.Tamanio}");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
