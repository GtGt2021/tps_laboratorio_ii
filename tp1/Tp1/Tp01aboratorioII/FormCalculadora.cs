using Entidades;
using System;
using System.Windows.Forms;

namespace Tp01aboratorioII
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// evento boton convertir a binario llama a la funcion estatica decimalbinario toma valor del resultado, lo muestra alli mismo y lo agrega al lstbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (!(txtResultado.Text == "0" || txtResultado.Text == "Valor Invalido"))
            {
                string numeroAConvertir = txtResultado.Text;
                txtResultado.Text = Operando.DecimalBinario(txtResultado.Text);
                if (txtResultado.Text != "Valor Invalido")
                {
                    double numeroAbs = Math.Abs(Convert.ToDouble(numeroAConvertir));
                    lstOperacionesRealizadas.Items.Add($"{numeroAbs} " +
                    $"= {txtResultado.Text} ");
                }
            }

        }
        /// <summary>
        /// evento boton Operar llama al metodo operar() y recibe el valor de la + - * / un double y muestro el resultado y lo agrega a la lstbox 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(txtOperando1.Text) && string.IsNullOrEmpty(txtOperando2.Text)))
            {
                string operador = cmbOperador.Text;
                if (operador == "")
                {
                    operador = "+";
                    cmbOperador.SelectedIndex = 1;
                }
                double resultadoOperacion = Operar(txtOperando1.Text, txtOperando2.Text, operador);
                txtResultado.Text = resultadoOperacion.ToString();
                
                lstOperacionesRealizadas.Items.Add($"{txtOperando1.Text} " +
                    $"{(string)cmbOperador.Text} {txtOperando2.Text} = {txtResultado.Text} ");
            }

        }

        /// <summary>
        /// llama a los metodos sobrecargados de la calculadora realiza los calculos y devuelve el resultado
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns>double resultado del calculo</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Operando op1 = new Operando(numero1);
            Operando op2 = new Operando(numero2);
            char oper = char.Parse(operador);
            double resultadoOperacion = Calculadora.Operar(op1, op2, oper);
            return resultadoOperacion;
        }

        private void FrmCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar(sender, e);
        }


        /// <summary>
        /// realiza la limpieza de todos los campos Exepto la del operador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Limpiar(object sender, EventArgs e)
        {
            txtOperando1.Clear();
            txtResultado.Text = "0";
            txtOperando2.Clear();
            lstOperacionesRealizadas.Items.Clear();
            //cmbOperador.SelectedIndex = 0;

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// da mensaje para confirmar el cierre o no de la app
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            string message = "¿Salir?";
            string title = "Cerrar Calculadora";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);

            if (result != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// evento que convierte numero de binario a decimal "de ser posible"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text != "0")
            {
                string numeroAConvertir = txtResultado.Text;
                txtResultado.Text = Operando.BinarioDecimal(txtResultado.Text);
                if (txtResultado.Text != "Valor Invalido")
                {
                    lstOperacionesRealizadas.Items.Add($"{numeroAConvertir} " +
                    $"= {txtResultado.Text} ");
                }
            }

        }
    }
}
