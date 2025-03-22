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
    public partial class FormRegistrarCitas : Form
    {
        private int id = -1;
        string NombredeUsuario;
        private NCita nCita = new NCita();
        private static int ultimoNumeroCita = 1;
        public FormRegistrarCitas(String NombredeUser)
        {
            InitializeComponent();
            this.NombredeUsuario = NombredeUser;

        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            //Validar que no este vacia
            if (cbContacto.Text == "" || cbFecha.Text == "" || cbMetodoPago.Text == "" || cbSede.Text == "" || dtHora.Text == "")
            {
                MessageBox.Show("Ingrese Todos los Campos");
                return;
            }
            //Deteccion de id dependiendo de lo elegido en el combo box
            if (cbMetodoPago.Text == "Efectivo")
            {
                id = 1;
            }
            if (cbMetodoPago.Text == "Tarjeta de crédito/débito")
            {
                id = 2;
            }
            if (cbMetodoPago.Text == "Yape")
            {
                id = 3;
            }
            if (cbMetodoPago.Text == "Plin")
            {
                id = 4;
            }
            //Conversion de los .Text de Fecha y Hora a DateTime
            DateTime fecha = DateTime.Parse(cbFecha.Text);
            DateTime hora = DateTime.Parse(dtHora.Text);
            //Conversion de DateTime a Time para fecha y que solo guarde fecha, gracias a TimeSpan
            TimeSpan soloHora = new TimeSpan(hora.Hour, hora.Minute, hora.Second);


            // Creación del objeto
            Cita cita = new Cita()
            {

                Fecha = fecha,
                Sede = cbSede.Text,
                Hora_Inicio = soloHora,
                Codigo_Metodo_Pago = id,
                Precio_Final = 0,
                Metodo_Contacto = cbContacto.Text,
                Cliente_Username = NombredeUsuario

            };
          


            // Registrar
            bool registrado = nCita.Registrar( cita);
            if (!registrado)
            {
                MessageBox.Show("Código Repetido");
                return;
            }




            //Conseguir el id autogenerado de la cita creada
            int IdCita = cita.Id;
            
            FormDescripcionCita form = new FormDescripcionCita(NombredeUsuario, IdCita, id);
            form.Show();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
