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
    public partial class FormVerPagos : Form
    {
        private NPago nPago= new NPago();
        int IdCita;
        public FormVerPagos(int cita)
        {
            this.IdCita = cita;
            InitializeComponent();
            MostrarPago(nPago.ListarTodo(IdCita));
            
        }
        private void MostrarPago(List<Pago> pagos)
        {
            dgPagos.DataSource = null;
            if (pagos.Count == 0)
            {
                return;
            }
            else
            {
                dgPagos.DataSource = pagos;
            }

        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
