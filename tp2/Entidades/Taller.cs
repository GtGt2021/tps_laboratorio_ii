using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{


    public sealed class Taller
    {
        public enum ETipo
        {
            Ciclomotor, Sedan, SUV, Todos
        }

        List<Vehiculo> vehiculos;
        int espacioDisponible;

        private Taller()
        {
            this.vehiculos = new List<Vehiculo>();
        }

        public Taller(int espacioDisponible) : this()
        {
            this.espacioDisponible = espacioDisponible;
        }


        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Taller.Listar(this, ETipo.Todos);
        }

        

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="taller">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Listar(Taller t, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat($"Tenemos {t.vehiculos.Count} lugares ocupados de un total de {t.espacioDisponible} disponibles");
            sb.AppendLine("");

            foreach (Vehiculo v in t.vehiculos)
            {
                
                switch (tipo)
                {
                    case ETipo.SUV:
                        if (v is Suv)                        
                        sb.AppendLine(v.Mostrar());
                        break;
                    case ETipo.Ciclomotor:
                        if (v is Ciclomotor)
                        sb.AppendLine(v.Mostrar());
                        break;
                    case ETipo.Sedan:
                        if (v is Sedan)
                        sb.AppendLine(v.Mostrar());
                        break;
                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="taller">Objeto donde se agregará el elemento</param>
        /// <param name="vehiculo">Objeto a agregar</param>
        /// <returns></returns>
        public static Taller operator +(Taller taller, Vehiculo vehiculo)
        {

            if (taller.vehiculos.Contains(vehiculo) || taller.vehiculos.Count >= taller.espacioDisponible)
            {
                return taller;
            }
            taller.vehiculos.Add(vehiculo);

            return taller;
        }


        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="taller">Objeto donde se quitará el elemento</param>
        /// <param name="vehiculo">Objeto a quitar</param>
        /// <returns></returns>
        public static Taller operator -(Taller taller, Vehiculo vehiculo)
        {
            if (taller.vehiculos.Contains(vehiculo))
            {
                taller.vehiculos.Remove(vehiculo);
            }
            return taller;
        }

    }
}
