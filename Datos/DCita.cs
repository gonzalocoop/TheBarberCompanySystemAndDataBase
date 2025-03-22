using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DCita
    {

       
        public bool Existe(int IdCita)
        {
            bool bul = false;
            try
            {
                using (var context = new BDEFEntities())
                {

                    bul = context.Cita.Any(a => a.Id.Equals(IdCita));
                }
                return bul;
            }
            catch (Exception ex)
            {
                return bul;
            }
        }
      

        public void Registrar(Cita cita)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Cita.Add(cita);
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {

            }
        }



        public List<Cita> ListarTodo(String ClienteUsername)
        {

            List<Cita> citas = new List<Cita>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    citas = context.Cita.Where(a => a.Cliente_Username.Equals(ClienteUsername)).ToList();
                }
                return citas;
            }
            catch (Exception ex)
            {
                return citas;
            }
        }

       


        public void Eliminar(String ClienteUsername, int IdCita)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    Cita citaTemp = context.Cita.FirstOrDefault(c => c.Cliente_Username == ClienteUsername && c.Id == IdCita);
                    context.Cita.Remove(citaTemp);
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {

            }
        }


       
        public List<Cita> ListarCita(String ClienteUsername, int IdCita)
        {
            List<Cita> citas = new List<Cita>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    citas = context.Cita.Where(a => a.Cliente_Username.Equals(ClienteUsername) && a.Id.Equals(IdCita)).ToList();
                }
                return citas;
            }
            catch (Exception ex)
            {
                return citas;
            }
        }



       



        public void ModificarFecha( int IdCita, DateTime Fecha)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    Cita citaTemp = context.Cita.Find(IdCita);
                    citaTemp.Fecha = Fecha;
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {

            }

        }

        public void ModificarHora(int IdCita, TimeSpan Hora)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    Cita citaTemp = context.Cita.Find(IdCita);
                    citaTemp.Hora_Inicio = Hora;
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {

            }

        }

        public void ModificarContacto( int IdCita, String Contacto)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    Cita citaTemp = context.Cita.Find(IdCita);
                    citaTemp.Metodo_Contacto = Contacto;
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {

            }

        }


        public void ModificarPrecio(int IdCita, decimal precio)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    Cita citaTemp = context.Cita.Find(IdCita);
                    citaTemp.Precio_Final = precio;
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {

            }

        }


        public void ReducirMonto(int IdCita, decimal precio)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    Cita citatemp = context.Cita.Find(IdCita);
                    citatemp.Precio_Final = citatemp.Precio_Final - precio;
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
                    List<Cita> citas = context.Cita.Where(c => c.Precio_Final < 10m && c.Codigo_Metodo_Pago==1).ToList();
                    context.Cita.RemoveRange(citas);
                    context.SaveChanges();
                }


            }
            catch (Exception ex)
            {

            }
        }

       
    }
}
