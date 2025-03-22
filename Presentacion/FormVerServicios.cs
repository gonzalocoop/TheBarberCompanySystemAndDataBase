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
    public partial class FormVerServicios : Form
    {
        private NDescripcionCita nDescripcionCita = new NDescripcionCita();
        private NPago nPago = new NPago();
        private NCita nCita = new NCita();
        string NombredeUsuario;
        int IdCita;
        int Metodoo;
        public FormVerServicios(String NombreUser, int citaa, int metodo)
        {
            this.NombredeUsuario = NombreUser;
            this.IdCita = citaa;
            this.Metodoo = metodo;
            InitializeComponent();

            MostrarServicios(nDescripcionCita.ListarTodo( IdCita));
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            FormVerCitas form = new FormVerCitas(NombredeUsuario);
            form.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
           

            // Validar
            if (dgServicios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione Servicio a Eliminar");
                return;
            }
            //Mensaje dependiendo del metodo de pago
            if (Metodoo == 4)
            {
                MessageBox.Show("No se pueden eliminar servicios de una cita ya pagada con plin");
                return;
            }
            if (Metodoo == 3)
            {
                MessageBox.Show("No se pueden eliminar servicios de una cita ya pagada con yape");
                return;
            }
            if (Metodoo == 2)
            {
                MessageBox.Show("No se pueden eliminar servicios de una cita ya pagada con tarjeta");
                return;
            }
            MessageBox.Show("Servicio Eliminado");
            //Segunda columna de la primera fila elegida
            String IdString = dgServicios.SelectedRows[0].Cells[1].Value.ToString();
            int IdServicio = int.Parse(IdString);
            

            //Creacion de una variable double que guardara lo que se restara
            double MontoRestar = 0;
            //Segunda columna de la primera fila elegida
            String idTipo = dgServicios.SelectedRows[0].Cells[1].Value.ToString();
            int idT = int.Parse(idTipo);
            // Eliminar
            nDescripcionCita.Eliminar(IdCita, IdServicio);
            //El monto a restar depende del id del tipo de servicio a eliminar
            if (idT == 1) MontoRestar = 35.00;
            if (idT == 2) MontoRestar = 21.50;
            if (idT == 3) MontoRestar = 21.00;
            if (idT == 4) MontoRestar = 25.00;
            if (idT == 5) MontoRestar = 30.00;
            if (idT == 6) MontoRestar = 40.00;
            if (idT == 7) MontoRestar = 40.00;
            if (idT == 8) MontoRestar = 20.00;
            if (idT == 9) MontoRestar = 21.00;
            //Conversion de double a decimal
            decimal MontoFinal = (decimal)MontoRestar;
            //Reduccion de monto del pago
            nPago.ModificarMonto(IdCita, MontoFinal);
            //Reduccion del monto de la cita
            nCita.ReducirMonto(IdCita, MontoFinal);

            // Mostrar
            MostrarServicios(nDescripcionCita.ListarTodo( IdCita));
           
        }
    }
}
