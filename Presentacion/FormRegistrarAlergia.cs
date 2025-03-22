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
    public partial class FormRegistrarAlergia : Form
    {
        string NombredeUsuario;
        private NClienteAlergia nClienteAlergia = new NClienteAlergia();
        public FormRegistrarAlergia(string NombredeUser)
        {
            this.NombredeUsuario = NombredeUser;
            InitializeComponent();

            MostrarAlergias(nClienteAlergia.ListarTodo(NombredeUsuario));
        }
        private void MostrarAlergias(List<Alergia_Cliente> alergias)
        {
            dgAlergias.DataSource = null;
            if (alergias.Count == 0)
            {
                return;
            }
            else
            {
                dgAlergias.DataSource = alergias;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //Validar que no este vacio
            if (cbAlergia.Text == "")
            {
                MessageBox.Show("Ingrese Algún campo");
                return;
            }


            // Creación del objeto
            Alergia_Cliente alergia = new Alergia_Cliente()
            {
                Cliente_Username = NombredeUsuario,
                Producto_Alergia_Id = 0,
                Nombre = cbAlergia.Text
            };

            // Registrar
            bool registrado = nClienteAlergia.Registrar(NombredeUsuario, alergia);
            if (!registrado)
            {
                MessageBox.Show("Alergia ya Registrada");
                return;
            }
            MessageBox.Show("Alergia Registrada correctamente");
            // Mostrar
            MostrarAlergias(nClienteAlergia.ListarTodo(NombredeUsuario));
            cbAlergia.Text = "";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Validar
            if (dgAlergias.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione Alergia a Eliminar");
                return;
            }
            MessageBox.Show("Alergia Eliminada Correctamente");
            String IdString = dgAlergias.SelectedRows[0].Cells[0].Value.ToString();
            int Id = int.Parse(IdString);
            // Eliminar
            nClienteAlergia.Eliminar(NombredeUsuario, Id);

            // Mostrar
            MostrarAlergias(nClienteAlergia.ListarTodo(NombredeUsuario));
        }
    }
}
