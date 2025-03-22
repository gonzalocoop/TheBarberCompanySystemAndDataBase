using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormCuenta : Form
    {
        string NombredeUsuario;
        public FormCuenta(string NombredeUsuario)
        {
            InitializeComponent();
            this.NombredeUsuario = NombredeUsuario;

            lbUsername.Text = NombredeUsuario;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            FormInicio form = new FormInicio();
            form.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            FormModificarCuenta form = new FormModificarCuenta(NombredeUsuario);
            form.Show();
        }

        private void buttonRealizarCitas_Click(object sender, EventArgs e)
        {
            FormRegistrarCitas form = new FormRegistrarCitas(NombredeUsuario);
            form.Show();
        }

        private void buttonVerCitas_Click(object sender, EventArgs e)
        {
            FormVerCitas form = new FormVerCitas(NombredeUsuario);
            form.Show();
        }
    }
}
