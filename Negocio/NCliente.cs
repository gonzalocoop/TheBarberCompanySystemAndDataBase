using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NCliente
    {
        private DCliente dCliente = new DCliente();

        public bool Registrar(Cliente cliente)
        {
            if (dCliente.Existe(cliente.Username))
            {
                return false;
            }
            else
            {
                dCliente.Registrar(cliente);
                return true;
            }
        }

        public List<Cliente> ListarTodo()
        {
            return dCliente.ListarTodo();
        }


        public List<Cliente> ListarCliente(string Username)
        {
            return dCliente.ListarCliente(Username);
        }

        public bool IniciarSesion(string Username, string Contrasena)
        {
            if (dCliente.IniciarSesion(Username, Contrasena))
            {
                return true;
            }
            else
            {

                return false;
            }
        }



  
        public void ModificarNombre(string Username, string Nombre)
        {
            dCliente.ModificarNombre(Username, Nombre);
        }
        public void ModificarContraseña(string Username, string Contraseña)
        {
            dCliente.ModificarContraseña(Username, Contraseña);
        }
        public void ModificarApellido(string Username, string Apellido)
        {
            dCliente.ModificarApellido(Username, Apellido);
        }
        public void ModificarEmail(string Username, string Email)
        {
            dCliente.ModificarEmail(Username, Email);
        }
        public void ModificarTelefono(string Username, string Telefono)
        {
            dCliente.ModificarTelefono(Username, Telefono);
        }
        public void ModificarPreferencias(string Username, string Preferencias)
        {
            dCliente.ModificarPreferencias(Username, Preferencias);
        }
    }
}
