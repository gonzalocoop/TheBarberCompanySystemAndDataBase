using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DCliente
    {


        public void Registrar(Cliente cliente)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Cliente.Add(cliente);
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {

            }
        }



        public void Eliminar(int username)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    Cliente clienteTemp = context.Cliente.Find(username);
                    context.Cliente.Remove(clienteTemp);
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {

            }
        }

        public List<Cliente> ListarTodo()
        {
            List<Cliente> clientes = new List<Cliente>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    clientes = context.Cliente.ToList();
                }
                return clientes;
            }
            catch (Exception ex)
            {
                return clientes;
            }
        }

        public bool Existe(string Username)
        {
            bool bul = false;
            try
            {
                using (var context = new BDEFEntities())
                {

                    bul = context.Cliente.Any(a => a.Username.Equals(Username));
                }
                return bul;
            }
            catch (Exception ex)
            {
                return bul;
            }
        }



        public List<Cliente> ListarCliente(string Username)
        {
            List<Cliente> clientes = new List<Cliente>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    clientes = context.Cliente.Where(clie => clie.Username.Equals(Username)).ToList();
                }
                return clientes;
            }
            catch (Exception ex)
            {
                return clientes;
            }
        }



        public bool IniciarSesion(string Username, string Contrasena)
        {
            bool bul = false;
            try
            {
                using (var context = new BDEFEntities())
                {

                    bul = context.Cliente.Any(a => a.Username.Equals(Username) && a.Contrasena.Equals(Contrasena));
                }
                return bul;
            }
            catch (Exception ex)
            {
                return bul;
            }
        }

       
        public String Modificar(string username, Cliente cliente)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    Cliente clienteTemp = context.Cliente.Find(username);
                    clienteTemp.Username = cliente.Username;
                    clienteTemp.Contrasena = cliente.Contrasena;
                    clienteTemp.Nombre = cliente.Nombre;
                    clienteTemp.Apellido = cliente.Apellido;
                    clienteTemp.Email = cliente.Email;
                    clienteTemp.Telefono = cliente.Telefono;
                    clienteTemp.Preferencias = cliente.Preferencias;
                    context.SaveChanges();
                }
                return "Modificado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

       
        public void ModificarNombre(string username, string Nombre)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    Cliente clienteTemp = context.Cliente.Find(username);
                    clienteTemp.Nombre = Nombre;
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {

            }
        }

        public void ModificarContraseña(string username, string Contraseña)
        {

            try
            {
                using (var context = new BDEFEntities())
                {
                    Cliente clienteTemp = context.Cliente.Find(username);
                    clienteTemp.Contrasena = Contraseña;
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {

            }

        }

        public void ModificarApellido(string username, string Apellido)
        {

            try
            {
                using (var context = new BDEFEntities())
                {
                    Cliente clienteTemp = context.Cliente.Find(username);
                    clienteTemp.Apellido = Apellido;
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {

            }

        }

        public void ModificarEmail(string username, string Email)
        {

            try
            {
                using (var context = new BDEFEntities())
                {
                    Cliente clienteTemp = context.Cliente.Find(username);
                    clienteTemp.Email = Email;
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {

            }

        }


        public void ModificarTelefono(string username, string Telefono)
        {

            try
            {
                using (var context = new BDEFEntities())
                {
                    Cliente clienteTemp = context.Cliente.Find(username);
                    clienteTemp.Telefono = Telefono;
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {

            }

        }

        public void ModificarPreferencias(string username, string Preferencias)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    Cliente clienteTemp = context.Cliente.Find(username);
                    clienteTemp.Preferencias = Preferencias;
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {

            }

        }


    }
}
