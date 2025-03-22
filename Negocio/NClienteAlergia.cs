using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NClienteAlergia
    {
        private DClienteAlergia dClienteAlergia = new DClienteAlergia();
        public bool Registrar(string ClienteUsername, Alergia_Cliente alergia)
        {
            //Logica
            if (alergia.Nombre == "Tintes para el cabello: Parafenilendiamina")
            {
                alergia.Producto_Alergia_Id = 1;

            }
            if (alergia.Nombre == "Productos de cuidado de la piel: Fragancias")
            {
                alergia.Producto_Alergia_Id = 2;

            }
            if (alergia.Nombre == "Cera para el cabello: Fragancias sintéticas")
            {
                alergia.Producto_Alergia_Id = 3;

            }
            if (alergia.Nombre == "Productos para el cuidado de la barba: Lanolina")
            {
                alergia.Producto_Alergia_Id = 4;

            }
            if (alergia.Nombre == "Champú y acondicionador: Lauril sulfato de sodio")
            {
                alergia.Producto_Alergia_Id = 5;

            }
            if (alergia.Nombre == "Gel de afeitar: Fragancias y alcoholes")
            {
                alergia.Producto_Alergia_Id = 6;

            }
            if (alergia.Nombre == "Loción para después del afeitado: Fragancias")
            {
                alergia.Producto_Alergia_Id = 7;

            }
            if (alergia.Nombre == "Otro/s (Explicar el día de la cita)")
            {
                alergia.Producto_Alergia_Id = 8;

            }

            if (dClienteAlergia.Existe(ClienteUsername, alergia.Producto_Alergia_Id))
            {
                return false;
            }
            else
            {

                dClienteAlergia.Registrar( alergia);
                return true;
            }
        }

        public List<Alergia_Cliente> ListarTodo(String ClienteUsername)
        {
            return dClienteAlergia.ListarTodo(ClienteUsername);
        }

        public void Eliminar(String ClienteUsername, int IdAlergia)
        {
            dClienteAlergia.Eliminar(ClienteUsername, IdAlergia);
        }
    }
}
