using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Gestión_RH
{
    public partial class frmEmpleados : Form
    {
        private EmpleadoDAO empleadoDAO = new EmpleadoDAO();
        public frmEmpleados()
        {
            InitializeComponent();
        }

        private void frmEmpleados_Load(object sender, EventArgs e)
        {
           
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtIdEmpleado.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return false;
            }

            if (!int.TryParse(txtIdEmpleado.Text, out _))
            {
                MessageBox.Show("El ID del empleado debe ser un número válido.");
                return false;
            }
            if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Por favor, ingrese un correo electrónico válido.");
                return false;
            }
            return true;
        }

        private void LimpiarCampos()
        {
            txtIdEmpleado.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtDireccion.Clear();
            txtEmail.Clear();

            txtIdEmpleado.Focus();
        }

        private void CargarEmpleados()
        {
            try
            {
                DataTable dt = empleadoDAO.Listar();
                dgvEmpleados.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los empleados: " + ex.Message);
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            CargarEmpleados();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            int id = int.Parse(txtIdEmpleado.Text);

            if (empleadoDAO.ExisteEmpleado(id))
            {
                MessageBox.Show("El empleado ya existe.");
                return;
            }

            Empleado emp = new Empleado
            {
                idEmpleado = id,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Direccion = txtDireccion.Text,
                Email = txtEmail.Text
            };

            if (empleadoDAO.Agregar(emp))
                MessageBox.Show("Empleado agregado correctamente.");

            CargarEmpleados();
            LimpiarCampos();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;
            Empleado emp = new Empleado
            {
                idEmpleado = int.Parse(txtIdEmpleado.Text),
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Direccion = txtDireccion.Text,
                Email = txtEmail.Text
            };
            if (empleadoDAO.Actualizar(emp))
                MessageBox.Show("Empleado actualizado correctamente.");
            CargarEmpleados();
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdEmpleado.Text) || !int.TryParse(txtIdEmpleado.Text, out int id))
            {
                MessageBox.Show("Por favor, ingrese un ID de empleado válido para eliminar.");
                return;
            }
            if (!empleadoDAO.ExisteEmpleado(id))
            {
                MessageBox.Show("El empleado no existe.");
                return;
            }
            if (empleadoDAO.Eliminar(id))
                MessageBox.Show("Empleado eliminado correctamente.");
            CargarEmpleados();
            LimpiarCampos();
        }

        private void dgvEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtIdEmpleado.Text = dgvEmpleados.Rows[e.RowIndex].Cells["id_empleado"].Value.ToString();
                txtNombre.Text = dgvEmpleados.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
                txtApellido.Text = dgvEmpleados.Rows[e.RowIndex].Cells["apellido"].Value.ToString();
                txtDireccion.Text = dgvEmpleados.Rows[e.RowIndex].Cells["direccion"].Value.ToString();
                txtEmail.Text = dgvEmpleados.Rows[e.RowIndex].Cells["email"].Value.ToString();
            }
        }

        
    }
}
