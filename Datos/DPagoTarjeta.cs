using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DPagoTarjeta
    {
        public void Registrar(Pago_Tarjeta pago)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Pago_Tarjeta.Add(pago);
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {

            }
        }
       
    }
}
