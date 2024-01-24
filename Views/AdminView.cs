using Proyecto_CS_Agenda.Controllers;
using Proyecto_CS_Agenda.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_CS_Agenda.Views
{
    public partial class AdminView : Form
    {
        public AdminView()
        {
            InitializeComponent();
            CargarDatosDataGridView();
        }

        private void CargarDatosDataGridView()
        {
            var _rolSistemaController = new RolSistemaController(new p1ConstSoftContext());
            try
            {
                // Obtiene los datos de la base de datos
                var roles = _rolSistemaController.ObtenerTodosRoles();

                // Asigna los datos al DataGridView
                dgvListSystemRol.DataSource = roles;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}");
            }
        }

        private void btnAddRol_Click(object sender, EventArgs e)
        {
            var _rolSistemaController = new RolSistemaController(new p1ConstSoftContext());
            try
            {
                string nombreRol = txtbSysRolName.Text;
                string estadoRol = cbSysRolState.SelectedItem?.ToString();

                // Validar que se haya seleccionado un estado
                if (string.IsNullOrEmpty(estadoRol))
                {
                    MessageBox.Show("Por favor, selecciona un estado para el rol.");
                    return;
                }

                // Crear un nuevo objeto RolSistema con los valores obtenidos
                RolSistema nuevoRol = new RolSistema {Nombre = nombreRol, Estado = estadoRol};
                MessageBox.Show($"{nuevoRol.Id} {nuevoRol.Nombre} {nuevoRol.Estado}");
                _rolSistemaController.AgregarRol(nuevoRol);
                CargarDatosDataGridView();

                MessageBox.Show("Rol agregado exitosamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el rol: {ex.Message}");
            }
        }
    }
}
