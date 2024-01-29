using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_CS_Agenda.Services
{
    public class HashingManagerService
    {
        // Método para generar el hash de una contraseña
        public string HashPassword(string password)
        {
            // Ajusta el factor de trabajo según sea necesario (puedes experimentar con este valor)
            return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt(12));
        }

        // Método para verificar si la contraseña ingresada coincide con el hash almacenado
        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}