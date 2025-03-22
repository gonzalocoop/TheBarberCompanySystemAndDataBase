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
    public partial class FormModificarCita : Form
    {
        string NombredeUsuario;
        int IdCita;
        private NCita nCita = new NCita();
        public FormModificarCita(String NombreUser, int citaa)
        {
            this.NombredeUsuario = NombreUser;
            this.IdCita = citaa;
            InitializeComponent();

            MostrarCitas(nCita.ListarCita(NombredeUsuario, IdCita));
        }
        private void MostrarCitas(List<Cita> citas)
        {
            dgCitas.DataSource = null;
            if (citas.Count == 0)
            {
                return;
            }
            else
            {
                dgCitas.DataSource = citas;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Verificacion de que no este vacio
            if (dtFecha.Text == "" && cbMetodo.Text == "" && dtHora.Text == "")
            {
                MessageBox.Show("Ingrese Algún Campo");
                return;
            }
            //Conversion de la fecha y hora a datetime
            DateTime Fecha = DateTime.Parse(dtFecha.Text);
            DateTime Hora= DateTime.Parse(dtHora.Text);
            //Conversion de la hora a solo hora (Time o TimeSpan)
            TimeSpan soloHora = new TimeSpan(Hora.Hour, Hora.Minute, Hora.Second);
            string Metodo = cbMetodo.Text;

            //Modificaciones si se detecto que se escribio algo
            if (dtFecha.Text != "")
            {
                nCita.ModificarFecha(IdCita, Fecha);

            }
            if (dtHora.Text != "")
            {
                nCita.ModificarHora(IdCita, soloHora);

            }
            if (cbMetodo.Text != "")
            {
                nCita.ModificarContacto(IdCita, Metodo);

            }

            MessageBox.Show("Modificación Realizada Correctamente");
            MostrarCitas(nCita.ListarCita(NombredeUsuario, IdCita));

            cbMetodo.Text = "";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
