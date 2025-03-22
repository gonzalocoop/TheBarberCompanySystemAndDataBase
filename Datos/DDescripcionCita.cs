using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DDescripcionCita
    {


        public bool Existe( int IdCita, int IdServicio)
        {
            bool bul = false;
            try
            {
                using (var context = new BDEFEntities())
                {

                    bul = context.Descripcion_Cita.Any(a => a.Cita_Id.Equals(IdCita) && a.Tipo_Servicio_Id.Equals(IdServicio));
                }
                return bul;
            }
            catch (Exception ex)
            {
                return bul;
            }
        }

       



        public void Registrar(Descripcion_Cita servicio)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Descripcion_Cita.Add(servicio);

                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {

            }
        }

       

        public List<Descripcion_Cita> ListarTodo( int IdCita)
        {
            List<Descripcion_Cita> servicios = new List<Descripcion_Cita>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    servicios = context.Descripcion_Cita.Where(a => a.Cita_Id.Equals(IdCita)).ToList();
                }
                return servicios;
            }
            catch (Exception ex)
            {
                return servicios;
            }
        }


       

        public void Eliminar(int IdCita, int IdServicio)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    Descripcion_Cita servicioTemp = context.Descripcion_Cita.FirstOrDefault(c => c.Cita_Id == IdCita && c.Tipo_Servicio_Id == IdServicio);
                    context.Descripcion_Cita.Remove(servicioTemp);
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {

            }
        }


        public void EliminarTodo(int IdCita)
        {
            try
            {
                List<Descripcion_Cita> descripciones = new List<Descripcion_Cita>();
                using (var context = new BDEFEntities())
                {
                    descripciones = context.Descripcion_Cita.Where(c => c.Cita_Id == IdCita).ToList();
                    context.Descripcion_Cita.RemoveRange(descripciones);
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {

            }
        }

       


        public double MontoTotal (int IdCita)
        {
            List<Descripcion_Cita> servicios = new List<Descripcion_Cita>();
            double monto = 0;
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    servicios = context.Descripcion_Cita.Where(a => a.Cita_Id.Equals(IdCita)).ToList();
                    foreach(Descripcion_Cita servicio in servicios)
                    {
                        if (servicio.Tipo_Servicio_Id == 1) monto += 35.00;
                        if (servicio.Tipo_Servicio_Id == 2) monto += 21.50;
                        if (servicio.Tipo_Servicio_Id == 3) monto += 21.00;
                        if (servicio.Tipo_Servicio_Id == 4) monto += 25.00;
                        if (servicio.Tipo_Servicio_Id == 5) monto += 30.00;
                        if (servicio.Tipo_Servicio_Id == 6) monto += 40.00;
                        if (servicio.Tipo_Servicio_Id == 7) monto += 40.00;
                        if (servicio.Tipo_Servicio_Id == 8) monto += 20.00;
                        if (servicio.Tipo_Servicio_Id == 9) monto += 21.00;
                    }
                }
                return monto;
            }
            catch (Exception ex)
            {
                return monto;
            }
        }

        public double MontoActual(int IdCita,int IdTipo)
        {
            Descripcion_Cita servicio;
            double monto = 0;
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    servicio = context.Descripcion_Cita.FirstOrDefault(a => a.Cita_Id.Equals(IdCita)&& a.Tipo_Servicio_Id.Equals(IdTipo));
                    
                    if (servicio.Tipo_Servicio_Id == 1) monto += 35.00;
                    if (servicio.Tipo_Servicio_Id == 2) monto += 21.50;
                    if (servicio.Tipo_Servicio_Id == 3) monto += 21.00;
                    if (servicio.Tipo_Servicio_Id == 4) monto += 25.00;
                    if (servicio.Tipo_Servicio_Id == 5) monto += 30.00;
                    if (servicio.Tipo_Servicio_Id == 6) monto += 40.00;
                    if (servicio.Tipo_Servicio_Id == 7) monto += 40.00;
                    if (servicio.Tipo_Servicio_Id == 8) monto += 20.00;
                    if (servicio.Tipo_Servicio_Id == 9) monto += 21.00;
                    
                }
                return monto;
            }
            catch (Exception ex)
            {
                return monto;
            }
        }
    }
}
