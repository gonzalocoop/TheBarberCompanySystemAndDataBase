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
    public partial class FormModificarCuenta : Form
    {
        private NCliente nCliente = new NCliente();
        string NombredeUsuario;
        public FormModificarCuenta(string NombredeUser)
        {
            this.NombredeUsuario = NombredeUser;
            InitializeComponent();

            MostrarClientes(nCliente.ListarCliente(NombredeUsuario));
        }
        private void MostrarClientes(List<Cliente> clientes)
        {
            dgCliente.DataSource = null;
            if (clientes.Count == 0)
            {
                return;
            }
            else
            {
                dgCliente.DataSource = clientes;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (tbNombre.Text == "" && tbEmail.Text == "" && tbContrasena.Text == "" && tbApellido.Text == "" && tbNumero.Text == "" && tbPreferencias.Text == "")
            {
                MessageBox.Show("Ingrese Algún Campo");
                return;
            }
            //Conversion de los tb a variables
            string Contraseña = tbContrasena.Text;
            string Nombre = tbNombre.Text;
            string Apellido = tbApellido.Text;
            string Email = tbEmail.Text;
            string Telefono = tbNumero.Text;
            string Preferencias = tbPreferencias.Text;
            

            //Modifcacion si se escribio algo
            if (tbNombre.Text != "")
            {
                nCliente.ModificarNombre(NombredeUsuario, Nombre);

            }
            if (tbContrasena.Text != "")
            {
                nCliente.ModificarContraseña(NombredeUsuario, Contraseña);

            }
            if (tbApellido.Text != "")
            {
                nCliente.ModificarApellido(NombredeUsuario, Apellido);

            }
            if (tbEmail.Text != "")
            {
                //Validacion de correo
                if (!tbEmail.Text.Contains("@"))
                {
                    MessageBox.Show("El email debe contener un '@'");
                    return;
                }
                nCliente.ModificarEmail(NombredeUsuario, Email);

            }
            if (tbNumero.Text != "")
            {
                //Intento de conversion a int del numero para validar que sea un numero
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
                if (tbNumero.Text.Length != 9)
                {
                    MessageBox.Show("Ingrese un número de 9 cifras");
                    return;
                }
                nCliente.ModificarTelefono(NombredeUsuario, Telefono);

            }
            if (tbPreferencias.Text != "")
            {
                nCliente.ModificarPreferencias(NombredeUsuario, Preferencias);

            }
            MessageBox.Show("Cambio Realizado Correctamente");
            MostrarClientes(nCliente.ListarCliente(NombredeUsuario));
            //tbUsuario.Text = "";
            tbNombre.Text = "";
            tbEmail.Text = "";
            tbContrasena.Text = "";
            tbApellido.Text = "";
            tbNumero.Text = "";
            tbPreferencias.Text = "";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            FormCuenta form = new FormCuenta(NombredeUsuario);
            form.Show();
        }

        private void btnAlergia_Click(object sender, EventArgs e)
        {
            FormRegistrarAlergia form = new FormRegistrarAlergia(NombredeUsuario);
            form.Show();
        }
    }
}
