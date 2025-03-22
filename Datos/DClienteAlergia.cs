using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DClienteAlergia
    {


        public bool Existe(String ClienteUsername, int Id)
        {
            bool bul = false;
            try
            {
                using (var context = new BDEFEntities())
                {

                    bul = context.Alergia_Cliente.Any(a => a.Producto_Alergia_Id.Equals(Id) && a.Cliente_Username.Equals(ClienteUsername));
                }
                return bul;
            }
            catch (Exception ex)
            {
                return bul;
            }
        }


        public void Registrar(Alergia_Cliente alergia)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Alergia_Cliente.Add(alergia);
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {

            }
        }
        
        


        public List<Alergia_Cliente> ListarTodo(String ClienteUsername)
        {
            List<Alergia_Cliente> alergias = new List<Alergia_Cliente>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    alergias = context.Alergia_Cliente.Where(a => a.Cliente_Username.Equals(ClienteUsername)).ToList();
                }
                return alergias;
            }
            catch (Exception ex)
            {
                return alergias;
            }
        }



        public void Eliminar(String ClienteUsername, int IdAlergia)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    Alergia_Cliente alergiaTemp = context.Alergia_Cliente.FirstOrDefault(c => c.Cliente_Username == ClienteUsername && c.Producto_Alergia_Id == IdAlergia);
                    context.Alergia_Cliente.Remove(alergiaTemp);
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {

            }
        }

       
    }
}
