using Negocio;
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
    public partial class FormIniciarSesion : Form
    {
        private NCliente nCliente = new NCliente();
        public FormIniciarSesion()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            //Verificacion de que no este vacio
            if (tbNombre.Text == "" || tbContrasena.Text == "")
            {
                MessageBox.Show("Ingrese Todos los Campos");
                return;
            }
            string NombredeUsuario = tbNombre.Text;
            string Contraseña = tbContrasena.Text;
            //Validacion de si existe un usuario
            bool iniciado = nCliente.IniciarSesion(NombredeUsuario, Contraseña);
            if (!iniciado)
            {
                MessageBox.Show("Usuario y/o Contraseña Incorrecta");
                return;
            }
            MessageBox.Show("Sesión Iniciada Correctamente");

            FormCuenta form = new FormCuenta(NombredeUsuario);
            form.Show();

            tbNombre.Text = "";
            tbContrasena.Text = "";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
