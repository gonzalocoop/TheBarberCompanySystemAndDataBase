using Datos;
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
    public partial class FormRegistrarse : Form
    {
        private NCliente nCliente = new NCliente();
        public FormRegistrarse()
        {
            InitializeComponent();


        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //Validacion de que no este vacia
            if (tbUsuario.Text == "" || tbNombre.Text == "" || tbEmail.Text == "" || tbContrasena.Text == "" || tbApellido.Text == "" || tbNumero.Text == "")
            {
                MessageBox.Show("Ingrese Todos los Campos");
                return;
            }
            //Validacion de Tamaño
            if (tbUsuario.Text.Length > 15)
            {
                MessageBox.Show("Nombre de Usuario muy Grande");
                return;
            }
            //Validacion de correo
            if (!tbEmail.Text.Contains("@"))
            {
                MessageBox.Show("El email debe contener un '@'");
                return;
            }
            //Validacion de que sea numero
            int numero = 0;
            try
            {
                numero = int.Parse(tbNumero.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ingrese una Valoración Numérica Valida en Teléfono");
                return;
            }
            //Validacion de Tamaño
            if (tbNumero.Text.Length != 9)
            {
                MessageBox.Show("Ingrese un número de 9 cifras");
                return;
            }

            // Creación del objeto
            Cliente cliente = new Cliente()
            {
                Username = tbUsuario.Text,
                Contrasena = tbContrasena.Text,
                Nombre = tbNombre.Text,
                Apellido = tbApellido.Text,
                Email = tbEmail.Text,
                Telefono = tbNumero.Text,
                Preferencias = tbPreferencias.Text,

                
            };

            // Registro
            bool registrado = nCliente.Registrar(cliente);
            if (!registrado)
            {
                MessageBox.Show("Nombre de usuario ya existente");
                return;
            }
            MessageBox.Show("Cuenta Creada Correctamente");
            string NombredeUsuario = tbUsuario.Text;
            FormCuenta form = new FormCuenta(NombredeUsuario);
            tbUsuario.Text = "";
            tbNombre.Text = "";
            tbEmail.Text = "";
            tbContrasena.Text = "";
            tbApellido.Text = "";
            tbNumero.Text = "";
            form.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
