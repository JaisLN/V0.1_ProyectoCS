using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_CS_Agenda.Controllers;
using Proyecto_CS_Agenda.Models;


namespace Proyecto_CS_Agenda.Services
{
    public class LoginService
    {
        private readonly UsuarioController _usuarioController;
        private readonly RolSistemaController _rolSistemaController;
        private readonly HashingManagerService _hashingService;

        public LoginService(UsuarioController usuarioController, RolSistemaController rolSistemaController, HashingManagerService hashingService)
        {
            _usuarioController = usuarioController;
            _rolSistemaController = rolSistemaController;
            _hashingService = hashingService;
        }

        public Usuario ValidarCredenciales(string us, string ps)
        {
            var usuario = _usuarioController.ObtenerUsuarioporUsername(us);


            if (usuario != null && _hashingService.VerifyPassword(ps, usuario.Password))
            {
                return usuario;
            }
            else
            {
                // Credenciales inválidas
                System.Diagnostics.Debug.WriteLine("Error validar credenciales: Verifica tu nombre de usuario y contraseña.");
                return null;
            }
        }


        public int ValidarRolUsuario(int userId)
        {
            var usuario = _usuarioController.ObtenerUsuarioPorId(userId);

            if (usuario != null)
            {
                var rolSistema = _rolSistemaController.ObtenerRolPorId(usuario.SystemRol);

                if (rolSistema != null)
                {
                    return rolSistema.Id; 
                }
                else
                {
                    Console.WriteLine("Error: El rol del usuario no existe.");
                    return 404;
                }
            }
            else
            {
                Console.WriteLine("Error: Usuario no encontrado.");
                return 405;
            }
        }
    }
}
