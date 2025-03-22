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
    public partial class FormDescripcionCita : Form
    {
        int IdCita;
        int metodo;
        string NombredeUsuario;
        private NDescripcionCita nDescripcionCita = new NDescripcionCita();
        private NCita nCita = new NCita();
        private NPago npago = new NPago();
        decimal MontoAcumulado;
        public FormDescripcionCita(String NombreUser, int cita, int metodo)
        {
            InitializeComponent();
            this.metodo = metodo;
            this.IdCita = cita;
            this.NombredeUsuario = NombreUser;

            
        }
        private void MostrarServicios(List<Descripcion_Cita> servicios)
        {
            dgServicios.DataSource = null;
            if (servicios.Count == 0)
            {
                return;
            }
            else
            {
                dgServicios.DataSource = servicios;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //Verificacion de que no este vacio
            if (cbServicio.Text == "")
            {
                MessageBox.Show("Ingrese Servicio a Registrar");
                return;
            }
            // Creación del objeto
            Descripcion_Cita servicio = new Descripcion_Cita()
            {
                Cita_Id = IdCita,
                Tipo_Servicio_Id = 0,
                Nombre_Servicio = cbServicio.Text
            };
            // Registrar
            bool registrado = nDescripcionCita.Registrar( IdCita, servicio);
            if (!registrado)
            {
                MessageBox.Show("Código repetido");
                return;
            }
            //Conversion de double a decimal
            double montoD = 0;
            decimal MontoActual = 0;
            montoD = nDescripcionCita.MontoActual(servicio.Cita_Id,servicio.Tipo_Servicio_Id);
            MontoActual = (decimal)montoD;
            //Suma del label
            MontoAcumulado = MontoAcumulado + MontoActual;
            lbMonto.Text = MontoAcumulado.ToString();


            // Mostrar
            MostrarServicios(nDescripcionCita.ListarTodo( IdCita));
            MessageBox.Show("Servicio Registrado Correctamente");
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //Eliminar todas las descripciones de la cita
            nDescripcionCita.EliminarTodo(IdCita);
            //Eliminar la cita
            nCita.Eliminar(NombredeUsuario, IdCita);
            this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (dgServicios.Rows.Count == 0)
            {
                MessageBox.Show("Registre mínimo 1 servicio");
                return;
            }
            //Conversion de double a decimal
            double montoD = 0;
            decimal MontoFinal = 0;
            montoD = nDescripcionCita.MontoTotal(IdCita);
            MontoFinal = (decimal)montoD;
            //Ponerle el precio final a la cita
            nCita.ModificarPrecio(IdCita, MontoFinal);
            //Dependiendo del codigo pasará algo diferente
            //metodo 1 = Efectivo
            //metodo 2 = Tarjeta
            //metodo 3 = Yape
            //metodo 4 = Plin
            if (metodo == 4)
            {
                MessageBox.Show("Redirigiendo a Pago Plin");
                FormPagoPlin form = new FormPagoPlin(NombredeUsuario, IdCita, metodo);
                form.Show();
            }
            if (metodo == 3)
            {
                MessageBox.Show("Redirigiendo a Pago Yape");
                FormPagoYape form = new FormPagoYape(NombredeUsuario, IdCita, metodo);
                form.Show();
            }
            if (metodo == 2)
            {
                //Se crea el pago pero sin numero no clave pues no es yape o plin, pero se le creara un pago de tarjeta
                Pago pago = new Pago()
                {
                    Tipo_Pago = "Tarjeta de crédito/débito",
                    Monto_Total = MontoFinal,
                    Numero_Telefono = "",
                    Clave_Confirmacion = "",
                    Cita_Id = IdCita
                };
                npago.Registrar(pago);
                MessageBox.Show("Redirigiendo a Pago Online");
                FormPagoOnline form = new FormPagoOnline(NombredeUsuario, pago.Id);
                form.Show();
            }
            if (metodo == 1)
            {   // Se crea el pago pero sin numero no clave pues no es yape o plin
                Pago pago = new Pago()
                {
                    Tipo_Pago = "Efectivo",
                    Monto_Total = MontoFinal,

                    Numero_Telefono = "",
                    Clave_Confirmacion = "",
                    Cita_Id = IdCita
                };
                npago.Registrar(pago);
                MessageBox.Show("Cita Registrada Correctamente, el pago se deberá entregar en el local previa a la cita");
                FormCuenta form1 = new FormCuenta(NombredeUsuario);
                form1.Show();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Verificar q se haya elegido algo del datagrid
            if (dgServicios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione Servicio a Eliminar");
                return;
            }
            //Sacar los valores del datagrid
            String IdCitaa = dgServicios.SelectedRows[0].Cells[0].Value.ToString();
            String IdTipoString = dgServicios.SelectedRows[0].Cells[1].Value.ToString();
            //Conversion a int
            int Idcitaa = int.Parse(IdCitaa);
            int IdServicio = int.Parse(IdTipoString);
            //Conversion a decimal
            double montoDec = 0;
            decimal MontoActu = 0;
            montoDec = nDescripcionCita.MontoActual(Idcitaa, IdServicio);
            MontoActu = (decimal)montoDec;
            //Resta del label del total
            MontoAcumulado = MontoAcumulado - MontoActu;
            lbMonto.Text = MontoAcumulado.ToString();
            // Eliminar
            nDescripcionCita.Eliminar(IdCita, IdServicio);
            // Mostrar
            MostrarServicios(nDescripcionCita.ListarTodo(IdCita));
            MessageBox.Show("Servicio Eliminado Correctamente");
        }
    }
}
