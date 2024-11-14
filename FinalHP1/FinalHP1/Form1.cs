using FinalHP1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalHP1
{
    public partial class Form1 : Form
    {
        private Biblioteca biblioteca; // Declara la instancia de Biblioteca

        public Form1()
        {
            InitializeComponent();
            biblioteca = new Biblioteca(); // Instancia la lógica de biblioteca
        }

        private void btnRegistrarMaterial_Click(object sender, EventArgs e)
        {
            try
        {
        // Obtener los valores de los campos de entrada
        string id = textBoxMaterialId.Text;
        string titulo = textBoxTitulo.Text;
        DateTime fechaRegistro = dateTimePickerFechaRegistro.Value;
        int cantidadRegistrada = (int)numericUpDownCantidad.Value;

        // Validar que los campos necesarios no estén vacíos
        if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(titulo))
        {
            MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Error");
            return;
        }

        // Registrar el material en la biblioteca
        biblioteca.RegistrarMaterial(id, titulo, fechaRegistro, cantidadRegistrada);
        
        // Confirmación de éxito
        MessageBox.Show("Material registrado exitosamente.", "Éxito");

        // Limpiar los campos de entrada
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
                // Obtener los valores de los campos de entrada
                string nombre = textBoxNombre.Text;
                string cedula = textBoxCedula.Text;
                string rol = comboBoxRol.SelectedItem?.ToString(); // Verifica que se haya seleccionado un rol

                // Validar que los campos no estén vacíos
                if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(cedula) || string.IsNullOrWhiteSpace(rol))
                {
                    MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Error");
                    return;
                }

                // Registrar la persona en la biblioteca
                biblioteca.RegistrarPersona(nombre, cedula, rol);

                // Confirmación de éxito
                MessageBox.Show("Persona registrada exitosamente.", "Éxito");

                // Limpiar los campos de entrada
                textBoxNombre.Clear();
                textBoxCedula.Clear();
                comboBoxRol.SelectedIndex = -1; // Restablecer el comboBox
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar la persona: {ex.Message}", "Error");
            }
        }


    }
}