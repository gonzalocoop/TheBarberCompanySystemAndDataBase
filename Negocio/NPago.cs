using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NPago
    {
        private DPago dPago = new DPago();
        public void Registrar( Pago pago)
        {
            dPago.Registrar( pago);
        }

        public List<Pago> ListarTodo(int Citaid)
        {
            return dPago.ListarTodo(Citaid);
        }

        public void Eliminar(int Citaid)
        {
            dPago.Eliminar(Citaid);
        }

        public void ModificarMonto(int IdCita, decimal precio)
        {
            dPago.ModificarMonto(IdCita, precio);

        }


        public void EliminarCero()
        {
            dPago.EliminarCero();
        }


        public void EliminarPago(int pagoid)
        {
            dPago.EliminarPago(pagoid);
        }
    }
}
