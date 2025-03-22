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
    public partial class FormVerCitas : Form
    {
        string NombredeUsuario;
        private NCita nCita = new NCita();
        private NDescripcionCita nDescripcionCita = new NDescripcionCita();
        private NPago nPago = new NPago();
        public FormVerCitas(String NombreUser)
        {
            this.NombredeUsuario = NombreUser;
            InitializeComponent();
            EliminarCitaYPago();
            MostrarCitas(nCita.ListarTodo(NombredeUsuario));
            
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
        //Funcion para eliminar los pagos y ctias cuyos montos totales se haya reducido a cero al eliminar servicios
        //Primero se elimina Pago pues este depedene de Cita
        private void EliminarCitaYPago()
        {

            nPago.EliminarCero();
            nCita.EliminarCero();
        }


        private void btnVerDescripcion_Click(object sender, EventArgs e)
        {
            // Validación
            if (dgCitas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una Cita");
                return;
            }

            // Primera columna de la primera fila
            String codigoCitaString = dgCitas.SelectedRows[0].Cells[0].Value.ToString();
            //Septima columna de la primera fila
            String Metodo = dgCitas.SelectedRows[0].Cells[6].Value.ToString();
            //Conversion a int
            int met = int.Parse(Metodo);
            int IdCita = int.Parse(codigoCitaString);
            FormVerServicios form = new FormVerServicios(NombredeUsuario, IdCita, met);
            form.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            // Validación
            if (dgCitas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una Cita");
                return;
            }

            // Primera columna de la primera fila
            String codigoCitaString = dgCitas.SelectedRows[0].Cells[0].Value.ToString();
            //Conversion a int
            int IdCita = int.Parse(codigoCitaString);
            FormModificarCita form = new FormModificarCita(NombredeUsuario, IdCita);
            form.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Validar
            if (dgCitas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione Cita a Eliminar");
                return;
            }



            // Primera columna de la primera fila
            String IdString = dgCitas.SelectedRows[0].Cells[0].Value.ToString();
            //Septima columna de la primera fila
            String Metodo = dgCitas.SelectedRows[0].Cells[6].Value.ToString();
            //Conversion a int
            int met = int.Parse(Metodo);
            //Mensaje dependiendo del tipo de pago, solo se puede eliminar si es efectivo
            if (met == 4)
            {
                MessageBox.Show("No se puede eliminar una cita ya pagada con plin");
                return;
            }
            if (met == 3)
            {
                MessageBox.Show("No se puede eliminar una cita ya pagada con yape");
                return;
            }
            if (met == 2)
            {
                MessageBox.Show("No se puede eliminar una cita ya pagada con tarjeta");
                return;
            }
            int IdCita = int.Parse(IdString);
            // Eliminar, primero se elimina el pago, luego todas las descripciones y luego la cita, para evitar errores de dependencias
            nPago.Eliminar(IdCita);
            nDescripcionCita.EliminarTodo(IdCita);
            nCita.Eliminar(NombredeUsuario, IdCita);
            

            
            MessageBox.Show("Cita Eliminada Correctamente");
            // Mostrar
            MostrarCitas(nCita.ListarTodo(NombredeUsuario));
            //Eliminar el pago si este se redujo a cero
            nPago.EliminarCero();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            FormCuenta form = new FormCuenta(NombredeUsuario);
            form.Show();
        }

        private void btnVerPagos_Click(object sender, EventArgs e)
        {
            // Validar
            if (dgCitas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione Cita a Eliminar");
                return;
            }



            // Primera columna de la primera fila
            String IdString = dgCitas.SelectedRows[0].Cells[0].Value.ToString();
            //Conversion a int
            int IdCita = int.Parse(IdString);

            

            FormVerPagos form = new FormVerPagos(IdCita);
            form.Show();
        }
    }
}
