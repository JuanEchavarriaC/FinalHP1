using System;
using System.Drawing;
using System.Windows.Forms;

namespace FinalHP1
{
    public partial class Form1 : Form
    {
        private Biblioteca biblioteca;

        public Form1()
        {
            InitializeComponent();
            biblioteca = new Biblioteca();
            SetPlaceholder(textBoxMaterialId, "ID del material");
            SetPlaceholder(textBoxTitulo, "Título del material");
            SetPlaceholder(textBoxNombre, "Nombre");
            SetPlaceholder(textBoxCedula, "Cédula");
        }

        private void SetPlaceholder(TextBox textBox, string placeholderText)
        {
            textBox.Text = placeholderText;
            textBox.ForeColor = Color.Gray;

            textBox.Enter += (sender, e) =>
            {
                if (textBox.Text == placeholderText)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholderText;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }

        private void btnRegistrarMaterial_Click(object sender, EventArgs e)
        {
            try
            {
                string id = textBoxMaterialId.Text;
                string titulo = textBoxTitulo.Text;
                DateTime fechaRegistro = dateTimePickerFechaRegistro.Value;
                int cantidadRegistrada = (int)numericUpDownCantidad.Value;

                if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(titulo))
                {
                    MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Error");
                    return;
                }

                biblioteca.RegistrarMaterial(id, titulo, fechaRegistro, cantidadRegistrada);
                MessageBox.Show("Material registrado exitosamente.", "Éxito");

                textBoxMaterialId.Clear();
                textBoxTitulo.Clear();
                dateTimePickerFechaRegistro.Value = DateTime.Now;
                numericUpDownCantidad.Value = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el material: {ex.Message}", "Error");
            }
        }

        private void btnRegistrarPersona_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = textBoxNombre.Text;
                string cedula = textBoxCedula.Text;
                string rol = comboBoxRol.SelectedItem?.ToString();

                if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(cedula) || string.IsNullOrWhiteSpace(rol))
                {
                    MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Error");
                    return;
                }

                if (!int.TryParse(cedula, out _))
                {
                    MessageBox.Show("La cédula debe ser un número.", "Error");
                    return;
                }

                biblioteca.RegistrarPersona(nombre, cedula, rol);
                MessageBox.Show("Persona registrada exitosamente.", "Éxito");

                textBoxNombre.Clear();
                textBoxCedula.Clear();
                comboBoxRol.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar la persona: {ex.Message}", "Error");
            }
        }

        private void btnEliminarPersona_Click(object sender, EventArgs e)
        {
            try
            {
                string cedula = textBoxCedula.Text;

                if (string.IsNullOrWhiteSpace(cedula))
                {
                    MessageBox.Show("Por favor, ingrese la cédula de la persona.", "Error");
                    return;
                }

                if (!int.TryParse(cedula, out _))
                {
                    MessageBox.Show("La cédula debe ser un número.", "Error");
                    return;
                }

                biblioteca.EliminarPersona(cedula);
                MessageBox.Show("Persona eliminada exitosamente.", "Éxito");

                textBoxCedula.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la persona: {ex.Message}", "Error");
            }
        }

        private void btnConsultarHistorial_Click(object sender, EventArgs e)
        {
            var movimientos = biblioteca.ConsultarHistorial();
            dataGridViewHistorial.Rows.Clear();

            foreach (var movimiento in movimientos)
            {
                dataGridViewHistorial.Rows.Add(movimiento.IdMaterial, movimiento.CedulaPersona, movimiento.FechaMovimiento, movimiento.TipoMovimiento);
            }
        }

        private void btnIncremenarCantidad_Click(object sender, EventArgs e)
        {
            try
            {
                string id = textBoxMaterialId.Text;
                int cantidad = (int)numericUpDownCantidad.Value;

                if (string.IsNullOrWhiteSpace(id))
                {
                    MessageBox.Show("Por favor, ingrese el ID del material.", "Error");
                    return;
                }

                biblioteca.IncrementarCantidadMaterial(id, cantidad);
                MessageBox.Show("Cantidad incrementada exitosamente.", "Éxito");

                textBoxMaterialId.Clear();
                numericUpDownCantidad.Value = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al incrementar la cantidad: {ex.Message}", "Error");
            }
        }

        private void btnRegistrarPrestamo_Click(object sender, EventArgs e)
        {
            try
            {
                string idMaterial = textBoxMaterialId.Text;
                string cedulaPersona = textBoxCedula.Text;

                if (string.IsNullOrWhiteSpace(idMaterial) || string.IsNullOrWhiteSpace(cedulaPersona))
                {
                    MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Error");
                    return;
                }

                biblioteca.RegistrarPrestamo(idMaterial, cedulaPersona);
                MessageBox.Show("Préstamo registrado exitosamente.", "Éxito");

                textBoxMaterialId.Clear();
                textBoxCedula.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el préstamo: {ex.Message}", "Error");
            }
        }

        private void btnRegistrarDevolucion_Click(object sender, EventArgs e)
        {
            try
            {
                string idMaterial = textBoxMaterialId.Text;
                string cedulaPersona = textBoxCedula.Text;

                if (string.IsNullOrWhiteSpace(idMaterial) || string.IsNullOrWhiteSpace(cedulaPersona))
                {
                    MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Error");
                    return;
                }

                biblioteca.RegistrarDevolucion(idMaterial, cedulaPersona);
                MessageBox.Show("Devolución registrada exitosamente.", "Éxito");

                textBoxMaterialId.Clear();
                textBoxCedula.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar la devolución: {ex.Message}", "Error");
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            biblioteca.GuardarDatos();
            base.OnFormClosing(e);
        }
    }
}