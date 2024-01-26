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
            var _rolContactoCtrl = new RolContactoController(new ConstSoft_agendaContext());
            try
            {
                var roles = _rolContactoCtrl.ObtenerTodosRolesContacto();

                dgvListSystemRol.DataSource = roles;

                // Ocultar la columna de usuarios 
                if (dgvListSystemRol.Columns.Contains("Contactos"))
                {
                    dgvListSystemRol.Columns["Contactos"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}");
            }
        }

        private void btnAddRol_Click(object sender, EventArgs e)
        {
            var _rolContactoCtrl = new RolContactoController(new ConstSoft_agendaContext());
            try
            {
                string nombreRol = txtbContactRolName.Text;
                string descripcionRol = txtbContactRolDesc.Text;
                string estadoRol = cbContactRolState.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(estadoRol))
                {
                    MessageBox.Show("Por favor, selecciona un estado para el rol.");
                    return;
                }

                // Crear un nuevo objeto RolSistema con los valores obtenidos
                RolContacto nuevoRol = new RolContacto { Nombre = nombreRol, Descripcion= descripcionRol, Estado = estadoRol };
                _rolContactoCtrl.AgregarRolContacto(nuevoRol);
                CargarDatosDataGridView();

                MessageBox.Show("Rol agregado exitosamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el rol: {ex.Message}");
            }
        }

        private void btnDeleteRol_Click(object sender, EventArgs e)
        {
            var _rolContactoCtrl = new RolContactoController(new ConstSoft_agendaContext());
            if (dgvListSystemRol.SelectedRows.Count > 0)
            {
                // Obtener el valor de la celda correspondiente al Id (asumiendo que la columna Id tiene el nombre "Id")
                int idToDelete = Convert.ToInt32(dgvListSystemRol.SelectedRows[0].Cells["Id"].Value);

                _rolContactoCtrl.EliminarRolContacto(idToDelete);
                CargarDatosDataGridView();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un rol antes de hacer clic en 'Eliminar'.");
            }
        }

        private void AbrirVentanaEdicion(RolContacto rol)
        {

           EditRolContactoView formEdicion = new EditRolContactoView(rol);
           DialogResult result = formEdicion.ShowDialog();


           if (result == DialogResult.OK)
           {
                CargarDatosDataGridView();
           }
        }

        private void btnEditRol_Click(object sender, EventArgs e)
        {
            if (dgvListSystemRol.SelectedRows.Count > 0)
            {
                // Obtener el objeto RolSistema seleccionado
                RolContacto rolSeleccionado = dgvListSystemRol.SelectedRows[0].DataBoundItem as RolContacto;

                // Verificar si se obtuvo el objeto correctamente
                if (rolSeleccionado != null)
                {
                    // Abrir la ventana de edición y pasar el objeto como parámetro
                    AbrirVentanaEdicion(rolSeleccionado);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un rol antes de hacer clic en 'Editar'.");
            }
        }


    }
}
