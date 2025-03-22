using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NDescripcionCita
    {
        private DDescripcionCita dDescripcionCita = new DDescripcionCita();

        public bool Registrar(int IdCita, Descripcion_Cita servicio)
        {
            //Logica
            if (servicio.Nombre_Servicio == "Corte de cabello")
            {
                servicio.Tipo_Servicio_Id = 1;

            }

            if (servicio.Nombre_Servicio == "Afeitado clásico (con navaja)")
            {
                servicio.Tipo_Servicio_Id = 2;

            }

            if (servicio.Nombre_Servicio == "Recorte y arreglo de barba")
            {
                servicio.Tipo_Servicio_Id = 3;

            }

            if (servicio.Nombre_Servicio == "Diseño de barba")
            {
                servicio.Tipo_Servicio_Id = 4;

            }

            if (servicio.Nombre_Servicio == "Tratamientos capilares (hidratación, reparación)")
            {
                servicio.Tipo_Servicio_Id = 5;

            }

            if (servicio.Nombre_Servicio == "Tinte para barba y/o cabello")
            {
                servicio.Tipo_Servicio_Id = 6;

            }

            if (servicio.Nombre_Servicio == "Peinado y estilismo")
            {
                servicio.Tipo_Servicio_Id = 7;

            }

            if (servicio.Nombre_Servicio == "Depilación facial (cejas, orejas, nariz)")
            {
                servicio.Tipo_Servicio_Id = 8;

            }

            if (servicio.Nombre_Servicio == "Tratamientos para cuero cabelludo")
            {
                servicio.Tipo_Servicio_Id = 9;

            }



            if (dDescripcionCita.Existe( IdCita, servicio.Tipo_Servicio_Id))
            {
                return false;
            }
            else
            {


                dDescripcionCita.Registrar(servicio);
                return true;
            }
        }

        public List<Descripcion_Cita> ListarTodo(int IdCita)
        {
            return dDescripcionCita.ListarTodo( IdCita);
        }

        public void Eliminar(int IdCita, int IdServicio)
        {
            dDescripcionCita.Eliminar( IdCita, IdServicio);
        }

        public void EliminarTodo(int IdCita)
        {
            dDescripcionCita.EliminarTodo(IdCita);
        }

        public double MontoTotal(int IdCita)
        {
            return dDescripcionCita.MontoTotal(IdCita);
        }

        public double MontoActual(int IdCita, int IdTipo)
        {
            return dDescripcionCita.MontoActual(IdCita, IdTipo);
        }
    }
}
