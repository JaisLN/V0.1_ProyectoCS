using Proyecto_CS_Agenda.Controllers;
using Proyecto_CS_Agenda.Models;
using Proyecto_CS_Agenda.Services;
using Proyecto_CS_Agenda.Views;

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
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginView());


           
              

                /*nuevoUsuarioCtrl.AgregarUsuario(new Usuario
                {
                    Id = "1",
                    Username = "admin",
                    Password = hashingService.HashPassword("admin"),
                    Cedula = "1234567890",
                    Nombres = "Juan",
                    Apellidos = "Root",
                    SystemRolId = "1",
                    ContactId = "1"
                });*/


      

        }

     }
}