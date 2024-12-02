using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Domain;
using Common;

namespace Presentation {
    public partial class ventana : Form1 {

        CPersona persona = new CPersona();
        bool editar = false;

        public ventana() {
            InitializeComponent();
            cargarGrilla();
        }

        private void cargarGrilla() {
            dtgDatos.DataSource = persona.Mostrar();
            resetTxtBoxs();
        }

        private void ventana_Load(object sender, EventArgs e) {
            cmbSexo.SelectedIndex = 1;
        }

        private void txtNombre_Enter(object sender, EventArgs e) {
            if (txtNombre.Text == "Nombre") {
                txtNombre.Text = "";
                txtNombre.ForeColor = Color.Black;
                lblNombre.Text = "Nombre";
            }
        }

        private void txtNombre_Leave(object sender, EventArgs e) {
            if (txtNombre.Text == "") {
                txtNombre.Text = "Nombre";
                txtNombre.ForeColor = Color.Silver;
                lblNombre.Text = "";
            }
        }

        private void txtApellido_Enter(object sender, EventArgs e) {
            if(txtApellido.Text == "Apellido") {
                txtApellido.Text = "";
                txtApellido.ForeColor = Color.Black;
                lblApellido.Text = "Apellido";
            }
        }

        private void txtApellido_Leave(object sender, EventArgs e) {
            if (txtApellido.Text == "") {
                txtApellido.Text = "Apellido";
                txtApellido.ForeColor = Color.Silver;
                lblApellido.Text = "";
            }
        }

        private void resetTxtBoxs() {
            txtNombre.Text = "Nombre";
            txtApellido.Text = "Apellido";
            txtID.Text = "ID";
            cmbSexo.SelectedIndex = 1;

            txtNombre.ForeColor = Color.Silver;
            txtApellido.ForeColor = Color.Silver;
            txtID.ForeColor = Color.Silver;
        }

        private void cambiarEstadoBotones() {
            btnGuardar.Enabled = !btnGuardar.Enabled;
            btnNuevo.Enabled = !btnNuevo.Enabled;
        }

        private DPersona seleccionarPersona() {
            int index = dtgDatos.CurrentRow.Index;
            DPersona p = new DPersona {
                ID = int.Parse(dtgDatos.Rows[index].Cells[0].Value.ToString()),
                Nombre = dtgDatos.Rows[index].Cells[1].Value.ToString(),
                Apellido = dtgDatos.Rows[index].Cells[2].Value.ToString(),
                Sexo = dtgDatos.Rows[index].Cells[3].Value.ToString()
            };
            return p;
        }

        private void btnNuevo_Click(object sender, EventArgs e) {
            cambiarEstadoBotones();
        }

        private void btnGuardar_Click(object sender, EventArgs e) {
            DPersona p = new DPersona {
                ID = txtID.Text == "ID" ? 0 : int.Parse(txtID.Text),
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Sexo = cmbSexo.Text
            };

            if (txtNombre.Text != "Nombre" && txtApellido.Text != "Apellido" && !editar) {

                if (persona.AgregarPersona(p)) {
                    MessageBox.Show($"La Persona {p.Nombre} {p.Apellido} se Guardo correctamente", "Tarea Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    resetTxtBoxs();
                    cambiarEstadoBotones();
                } else MessageBox.Show($"La Persona {p.Nombre} {p.Apellido} no se pudo guardar correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

               
            }

            if (editar) {
                if (persona.EditarPersona(p)) {
                    MessageBox.Show($"La Persona {p.Nombre} {p.Apellido} se Modifico correctamente", "Tarea Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else MessageBox.Show($"La Persona {p.Nombre} {p.Apellido} no se pudo modificar correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                editar = false;

                cambiarEstadoBotones();
            }

            cargarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e) {
            DPersona p = seleccionarPersona();
            if (persona.EliminarPersona(p.ID)) {
                MessageBox.Show($"La Persona {p.Nombre} {p.Apellido} se Elimino correctamente", "Tarea Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else MessageBox.Show($"La Persona {p.Nombre} {p.Apellido} no se pudo eliminar correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            cargarGrilla();
        }

        private void btnEditar_Click(object sender, EventArgs e) {
            DPersona p = seleccionarPersona();
            txtNombre.Text = p.Nombre;
            txtApellido.Text = p.Apellido;
            txtID.Text = p.ID.ToString();
            cmbSexo.Text = p.Sexo;
            editar = true;

            txtNombre.ForeColor = Color.Black;
            txtApellido.ForeColor = Color.Black;
            txtID.ForeColor = Color.Black;

            cambiarEstadoBotones();
        }
    }
}
