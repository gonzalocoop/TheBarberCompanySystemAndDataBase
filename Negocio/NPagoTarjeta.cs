﻿using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NPagoTarjeta
    {
        private DPagoTarjeta dPagoOnline = new DPagoTarjeta();
        public void Registrar(Pago_Tarjeta pago)
        {
            dPagoOnline.Registrar(pago);
        }

       
    }
}
