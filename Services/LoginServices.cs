using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_CS_Agenda.Controllers;
using Proyecto_CS_Agenda.Models;

namespace Proyecto_CS_Agenda.Services
{
    public class LoginServices
    {
        private readonly UsuarioController _usuarioController;
        private readonly RolSistemaController _rolSistemaController;
        private readonly HashingManagerService _hashingService;

        public LoginServices(UsuarioController usuarioController, RolSistemaController rolSistemaController, HashingManagerService hashingService)
        {
            _usuarioController = usuarioController;
            _rolSistemaController = rolSistemaController;
            _hashingService = hashingService;
        }

        public Usuario ValidarCredenciales(string username, string password)
        {
            var usuario = _usuarioController.ObtenerTodosUsuarios().FirstOrDefault(u => u.Username == username);

            if (usuario != null && _hashingService.VerifyPassword(password, usuario.Password))
            {
                return usuario;
            }
            else
            {
                // Credenciales inválidas
                Console.WriteLine("Error: Verifica tu nombre de usuario y contraseña.");
                return null;
            }
        }


        public string ValidarRolUsuario(string userId)
        {
            var usuario = _usuarioController.ObtenerUsuarioPorId(userId);

            if (usuario != null)
            {
                var rolSistema = _rolSistemaController.ObtenerRolPorId(usuario.SystemRolId);

                if (rolSistema != null)
                {
                    return rolSistema.Nombre; 
                }
                else
                {
                    Console.WriteLine("Error: El rol del usuario no existe.");
                    return null;
                }
            }
            else
            {
                Console.WriteLine("Error: Usuario no encontrado.");
                return null;
            }
        }
    }
}
