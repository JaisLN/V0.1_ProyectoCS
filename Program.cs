using Proyecto_CS_Agenda.Controllers;
using Proyecto_CS_Agenda.Models;
using Proyecto_CS_Agenda.Services;

namespace Proyecto_CS_Agenda
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            /*ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());*/


            // Crear instancia de contexto de base de datos
            using (var dbContext = new p1ConstSoftContext())
            {
                var hashingService = new HashingManagerService();
                var nuevoRolContactoCtrl = new RolContactoController(dbContext);
                var nuevoUsuarioCtrl = new UsuarioController(dbContext);
                var nuevoContactoCtrl = new ContactoController(dbContext);




                /* nuevoRolContactoCtrl.AgregarRolContacto(new RolContacto
                 {
                     Id = "1",
                     Nombre = "Empleado",
                     Descripcion = "Emrpresa",
                     Estado = "Activo"

                 }) ;*/


                /*nuevoContactoCtrl.AgregarContacto(new Contacto 
                {

                    Id = "1",
                    NombreContact = "Administrador Juan",
                    Mail = "admin@mail.com",
                    Telf1 = "123456789",
                    Telf2 = "987654321",
                    Direccion = "Calle Principal",
                    RolId = "1"

                });*/

                nuevoUsuarioCtrl.AgregarUsuario(new Usuario
                {
                    Id = "1",
                    Username = "admin",
                    Password = hashingService.HashPassword("admin"),
                    Cedula = "1234567890",
                    Nombres = "Juan",
                    Apellidos = "Root",
                    SystemRolId = "1",
                    ContactId = "1"
                });


                dbContext.SaveChanges();


          
            }

        }

     }
}