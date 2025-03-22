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
    public partial class FormPagoOnline : Form
    {
        int pagoo;
        
        string NombredeUsuario;
        NPagoTarjeta nPagoTarjeta = new NPagoTarjeta();
        NPago nPago = new NPago();
        public FormPagoOnline(String NombreUser, int pago)
        {
            this.NombredeUsuario = NombreUser;
            this.pagoo = pago;
            InitializeComponent();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            nPago.EliminarPago(pagoo);
            this.Close();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            //Validacion de que no este vacio
            if (cbTipo.Text == "" || tbCVV.Text == "" || tbNumero.Text == "" || tbTitular.Text == "")
            {
                MessageBox.Show("Ingrese Todos los Campos");
                return;
            }


            //Intento de conversio del cvv a numero, int no porque tiene 16 digitos
            int cvv = 0;
            try
            {
                cvv = int.Parse(tbCVV.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ingrese los campos numéricos correctamente");
                return;
            }
            //Validacion de los tamaños
            if (tbCVV.Text.Length != 4 && tbCVV.Text.Length != 3)
            {
                MessageBox.Show("Ingrese una clave de 3 o 4 cifras");
                return;
            }
            if (tbNumero.Text.Length !=16)
            {
                MessageBox.Show("Ingrese una número de tarjeta de 16 Cifras");
                return;
            }


            // Creación del objeto
            Pago_Tarjeta pago = new Pago_Tarjeta()
            {

                Tipo_Tarjeta = cbTipo.Text,

                Numero_Tarjeta = tbNumero.Text,
                Codigo_Autorizacion = tbCVV.Text,
                Nombre_Cliente = tbTitular.Text,
                Pago_id = pagoo
            };
            // Registro
            nPagoTarjeta.Registrar(pago);
            MessageBox.Show("Pago Registrado. Gracias por confiar en The Barber Company");
            
            FormCuenta form = new FormCuenta(NombredeUsuario);
            form.Show();
        }
    }
}
