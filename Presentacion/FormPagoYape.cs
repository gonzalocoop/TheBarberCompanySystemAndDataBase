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
    public partial class FormPagoYape : Form
    {
        int IdCita;

        string NombredeUsuario;
        int metodo;
        NPago nPago = new NPago();
        NDescripcionCita nDescripcionCita = new NDescripcionCita();
        public FormPagoYape(String NombreUser, int citaa, int metodo)
        {
            this.NombredeUsuario = NombreUser;
            this.IdCita = citaa;
            this.metodo = metodo;
            InitializeComponent();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            //Validacion de que no este vacio
            if (tbTelefono.Text == "" || tbClave.Text == "")
            {
                MessageBox.Show("Ingrese Todos los Campos");
                return;
            }
            //Intento  de conversion a int para validar que sean numeros
            int telefono = 0;
            int codigo = 0;
            try
            {
                telefono = int.Parse(tbTelefono.Text);
                codigo = int.Parse(tbClave.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ingrese los campos numéricos correctamente");
                return;
            }


            //Validar tamaño
            if (tbTelefono.Text.Length!=9)
            {
                MessageBox.Show("Ingrese un número de 9 cifras");
                return;
            }
            if (tbClave.Text.Length >6)
            {
                MessageBox.Show("Ingrese una Clave de Aprobación de Yape/Plin Adecuada de Menos de 6 Cifras");
                return;
            }




            //Conversion de double a decimal
            double montoD = 0;
            decimal MontoFinal = 0;
            //Conseguir monto total de la cita
            montoD = nDescripcionCita.MontoTotal(IdCita);
            MontoFinal = (decimal)montoD;


            // Creación del objeto
            Pago pago = new Pago()
            {

                Tipo_Pago = "Yape",

                Monto_Total = MontoFinal,
                Numero_Telefono = tbTelefono.Text,
                Clave_Confirmacion = tbClave.Text,
                Cita_Id = IdCita
            };
            // Registro
            nPago.Registrar( pago);
            MessageBox.Show("Pago Registrado. Gracias por confiar en The Barber Company");
            

            FormCuenta form = new FormCuenta(NombredeUsuario);
            form.Show();
        }
    }
}
