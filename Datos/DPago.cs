using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DPago
    {
        public void Registrar( Pago pago)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Pago.Add(pago);
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {

            }
        }

        public List<Pago> ListarTodo(int Citaid)
        {
            List<Pago> pagos = new List<Pago>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    pagos = context.Pago.Where(a => a.Cita_Id.Equals(Citaid)).ToList();
                }
                return pagos;
            }
            catch (Exception ex)
            {
                return pagos;
            }
        }

        public void Eliminar(int Citaid)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    Pago pago = context.Pago.FirstOrDefault(c => c.Cita_Id == Citaid);
                    context.Pago.Remove(pago);
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {

            }
        }


        public void ModificarMonto(int IdCita, decimal precio)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    Pago pagotemp = context.Pago.FirstOrDefault(C=>C.Cita_Id==IdCita);
                    pagotemp.Monto_Total = pagotemp.Monto_Total  - precio;
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {

            }

        }


        public void EliminarCero()
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    List<Pago> pagos = context.Pago.Where(c => c.Monto_Total <10m&&c.Tipo_Pago=="Efectivo").ToList();
                    context.Pago.RemoveRange(pagos);
                    context.SaveChanges();
                }

               
            }
            catch (Exception ex)
            {
               
            }
        }

        public void EliminarPago(int pagoid)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    Pago pago = context.Pago.FirstOrDefault(c => c.Id == pagoid);
                    context.Pago.Remove(pago);
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {

            }
        }

    }
}
