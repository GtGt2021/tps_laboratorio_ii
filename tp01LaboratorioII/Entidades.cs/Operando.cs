using System;

namespace Entidades.cs
{
    public class Operando
    {
        private double numero;

        public Operando()
        {
            this.numero = 0;
        }
        public Operando(double numero)
        {
            this.numero = numero;
        }
        public Operando(string srtNumero)
        {
            this.Numero = srtNumero;
        }
        

        string Numero
        {
            set {
                this.numero = ValidarOperando(value);
                }
        }

        /// <summary>
        /// valida y convierte numero de string a double
        /// </summary>
        /// <param name="strNumero"> Numero string</param>
        /// <returns>Devuelve un double si el parseo fue exitoso sino regresa un 0</returns>
        private double ValidarOperando(string strNumero)
        {
            if (double.TryParse(strNumero, out double numeroValidado))
                return numeroValidado;
            return 0;
        }

        
        /// <summary>
        /// Convierte Numero Binario en un Decimal
        /// </summary>
        /// <param name="binario">string (Numero Binario)</param>
        /// <returns>Decimal en string</returns>
        public string BinarioDecimal(string binario)
        {
            if(!EsBinario(binario))
            {
                return "Valor Invalido";
            }
            double pocision = 0;
            double resultado = 0;
            for (int i = binario.Length - 1; i >= 0; i--) // recorremos la cadena binario al revez
            {
                if (binario[i] == '1') // donde consigamos un 1 entramos
                {
                    resultado += Math.Pow(2, pocision); //elevamos el 2 a la potencia que nos indique pocision
                }
                pocision++; // le sumamos una a pocision para el siguiente giro
            }
            return resultado.ToString();
        }

        /// <summary>
        /// Convierte Numero Decimal a Binario
        /// </summary>
        /// <param name="binario">double (Numero Decimal) </param>
        /// <returns>Binario en string</returns>
        public string DecimalBinario(double numero)
        {
            string binario = ""; //creo string para devolver un binario
            int numeroEnt = (int)numero; // parseo el double a int para poder trabajarlo
            if(numeroEnt < 0)
            {
                numeroEnt *= -1;
            }
            while (numeroEnt > 0) //hago el bucle mientras el numeroEnt sea mayor que 0
            {
                binario = (numeroEnt%2).ToString() + binario; // tomo el resto de la division entre dos lo convierto en string y lo concateno al binario que la primera vez es vacio
                numeroEnt /= 2; // le doy el valor a Numero entere de la division entre 2
            }
            return binario;
        }


        /// <summary>
        /// Convierte Numero Decimal a Binario
        /// </summary>
        /// <param name="binario">string double (Numero Decimal) </param>
        /// <returns>Binario en string</returns>
        public string DecimalBinario(string numero)
        {
            string binario = ""; //creo string para devolver un binario
            if (!int.TryParse(numero, out int numeroEnt))
            {
                return "valor invalido";
            }// parseo el string a int para poder trabajarlo
            while (numeroEnt > 0) //hago el bucle mientras el numeroEnt sea mayor que 0
            {
                binario = (numeroEnt % 2).ToString() + binario; // tomo el resto de la division entre dos lo convierto en string y lo concateno al binario que la primera vez es vacio
                numeroEnt /= 2; // le doy el valor a Numero entere de la division entre 2
            }
            return binario;
        }

        /// <summary>
        /// Validamos si la cadena Recibida es un binario
        /// </summary>
        /// <param name="bianrio">string (numero BInario)</param>
        /// <returns>false (no es binario) true (es binario) </returns>
        private bool EsBinario(string binario)
        {
            for (int i = 0; i < binario.Length; i++) // recorro la cadena
            {
                if(binario[i]!='0' || binario[i] != '1') // es un caracter distinto a 0 o 1 entra al if y rompe retornando un false
                    return false;
            }
            return true;
        }



        /// <summary>
        /// Sobrecarga Operador - 
        /// </summary>
        /// <param name="n1">Objeto del Tipo Operando</param>
        /// <param name="n2">Objeto del Tipo Operando</param>
        /// <returns>Retorna un double</returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Sobrecarga Operador * 
        /// </summary>
        /// <param name="n1">Objeto del Tipo Operando</param>
        /// <param name="n2">Objeto del Tipo Operando</param>
        /// <returns>Retorna un double</returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }


        /// <summary>
        /// Sobrecarga Operador / 
        /// </summary>
        /// <param name="n1">Objeto del Tipo Operando</param>
        /// <param name="n2">Objeto del Tipo Operando</param>
        /// <returns>Retorna un double</returns>
        public static double operator /(Operando n1, Operando n2)
        {
            return n1.numero / n2.numero;
        }

        /// <summary>
        /// Sobrecarga Operador + 
        /// </summary>
        /// <param name="n1">Objeto del Tipo Operando</param>
        /// <param name="n2">Objeto del Tipo Operando</param>
        /// <returns>Retorna un double</returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

    }
}
