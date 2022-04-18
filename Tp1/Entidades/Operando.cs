using System;

namespace Entidades
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
            this.SetNumero = srtNumero;
        }

        /// <summary>
        /// setea el valor numero primero validando el mismo sino lo inicia en 0
        /// </summary>
        string SetNumero
        {
            set
            {
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
        public static string BinarioDecimal(string binario)
        {
            if (!EsBinario(binario))
            {
                return "Valor Invalido";
            }
            double pocision = 0;
            double resultado = 0;
            for (int i = binario.Length - 1; i >= 0; i--) 
            {
                if (binario[i] == '1') 
                {
                    resultado += Math.Pow(2, pocision); 
                }
                pocision++;
            }
            return resultado.ToString();
        }

        /// <summary>
        /// Convierte Numero Decimal a Binario
        /// </summary>
        /// <param name="binario">double (Numero Decimal) </param>
        /// <returns>Binario en string</returns>
        public static string DecimalBinario(double numero)
        {
            string binario = ""; 
            if (numero > long.MaxValue)
                return "Valor Invalido";
            long numeroEnt = Math.Abs((long)numero); 
            if (numeroEnt == 0)
                return "0";
            while (numeroEnt > 0) 
            {
                binario = (numeroEnt % 2).ToString() + binario;
                numeroEnt /= 2;
            }
            return binario;
        }


        /// <summary>
        /// Convierte Numero Decimal a Binario
        /// </summary>
        /// <param name="binario">string double (Numero Decimal) </param>
        /// <returns>Binario en string</returns>
        public static string DecimalBinario(string numero)
        {
            if (!double.TryParse(numero, out double numeroAParsear))
            {
                return "valor invalido";
            }// parseo el string a double para poder trabajarlo/*
            string binario = DecimalBinario(numeroAParsear);//reutilizo mi funcion Decimal a binario        
           
            return binario;
        }

        /// <summary>
        /// Validamos si la cadena Recibida es un binario
        /// </summary>
        /// <param name="bianrio">string (numero BInario)</param>
        /// <returns>false (no es binario) true (es binario) </returns>
        private static bool EsBinario(string binario)
        {
            for (int i = 0; i < binario.Length; i++) // recorro la cadena
            {
                if (binario[i] != '0' && binario[i] != '1') // es un caracter distinto a 0 y 1 entra al if y rompe retornando un false
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
        /// <returns>Retorna un double o retorna double.minvalue si n2=0</returns>
        public static double operator /(Operando n1, Operando n2)
        {
            if (n2.numero == 0)
                return double.MinValue;
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
