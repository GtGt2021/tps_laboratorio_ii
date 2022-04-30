namespace Entidades
{
    public class Calculadora
    {
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double resultado = 0;
            switch (operador)
            {
                case '+':
                    resultado = num1 + num2;
                    break;
                case '-':
                    resultado = num1 - num2;
                    break;
                case '/':
                    resultado = num1 / num2;
                    break;
                case 'X':
                    resultado = num1 * num2;
                    break;
            }
            return resultado;
        }


        private static char ValidarOperador(char Operador)
        {
            if (Operador == '-' || Operador == '/' || Operador == '*')
                return Operador;
            return '+';
        }

    }
}
