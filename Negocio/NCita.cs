using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NCita
    {
        private DCita dCita = new DCita();

        public bool Registrar( Cita cita)
        {
            if (dCita.Existe(cita.Id))
            {
                return false;
            }
            else
            {


                dCita.Registrar( cita);
                return true;
            }
        }

        public List<Cita> ListarTodo(String ClienteUsername)
        {
            return dCita.ListarTodo(ClienteUsername);
        }


        public void Eliminar(String ClienteUsername, int IdCita)
        {
            dCita.Eliminar(ClienteUsername, IdCita);
        }

        public List<Cita> ListarCita(String ClienteUsername, int IdCita)
        {

            return dCita.ListarCita(ClienteUsername, IdCita);
        }

        public void ModificarFecha( int IdCita, DateTime Fecha)
        {
            dCita.ModificarFecha( IdCita, Fecha);

        }

        public void ModificarHora(int IdCita, TimeSpan Hora)
        {
            dCita.ModificarHora(IdCita, Hora);

        }

        public void ModificarContacto(int IdCita, String Contacto)
        {
            dCita.ModificarContacto( IdCita, Contacto);

        }

        public void ModificarPrecio(int IdCita, decimal precio)
        {
            dCita.ModificarPrecio(IdCita, precio);
        }

        public void ReducirMonto(int IdCita, decimal precio)
        {
            dCita.ReducirMonto(IdCita, precio);

        }

        public void EliminarCero()
        {
            dCita.EliminarCero();
        }
    }
}
