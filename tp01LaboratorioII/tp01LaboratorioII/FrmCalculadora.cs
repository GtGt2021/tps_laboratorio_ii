using System;
using System.Windows.Forms;
    using Entidades;

namespace tp01LaboratorioII
{
    public partial class frmVista : Form
    {
        public frmVista()
        {

            InitializeComponent();
        }

        private void frmVista_Load(object sender, EventArgs e)
        {

        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            string message = "¿Salir?";
            string title = "Cerrar Calculadora";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            

        }

    }
}
