namespace FinalHP1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRegistrarMaterial = new System.Windows.Forms.Button();
            this.btnRegistrarPersona = new System.Windows.Forms.Button();
            this.btnEliminarPersona = new System.Windows.Forms.Button();
            this.btnRegistrarPrestamo = new System.Windows.Forms.Button();
            this.btnRegistrarDevolucion = new System.Windows.Forms.Button();
            this.btnIncremenarCantidad = new System.Windows.Forms.Button();
            this.btnConsultarHistorial = new System.Windows.Forms.Button();
            this.textBoxMaterialId = new System.Windows.Forms.TextBox();
            this.textBoxTitulo = new System.Windows.Forms.TextBox();
            this.dateTimePickerFechaRegistro = new System.Windows.Forms.DateTimePicker();
            this.numericUpDownCantidad = new System.Windows.Forms.NumericUpDown();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.textBoxCedula = new System.Windows.Forms.TextBox();
            this.comboBoxRol = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRegistrarMaterial
            // 
            this.btnRegistrarMaterial.Location = new System.Drawing.Point(37, 36);
            this.btnRegistrarMaterial.Name = "btnRegistrarMaterial";
            this.btnRegistrarMaterial.Size = new System.Drawing.Size(155, 36);
            this.btnRegistrarMaterial.TabIndex = 0;
            this.btnRegistrarMaterial.Text = "Registrar material";
            this.btnRegistrarMaterial.UseVisualStyleBackColor = true;
            this.btnRegistrarMaterial.Click += new System.EventHandler(this.btnRegistrarMaterial_Click);
            // 
            // btnRegistrarPersona
            // 
            this.btnRegistrarPersona.Location = new System.Drawing.Point(37, 78);
            this.btnRegistrarPersona.Name = "btnRegistrarPersona";
            this.btnRegistrarPersona.Size = new System.Drawing.Size(155, 38);
            this.btnRegistrarPersona.TabIndex = 1;
            this.btnRegistrarPersona.Text = "Registrar persona";
            this.btnRegistrarPersona.UseVisualStyleBackColor = true;
            this.btnRegistrarPersona.Click += new System.EventHandler(this.btnRegistrarPersona_Click);
            // 
            // btnEliminarPersona
            // 
            this.btnEliminarPersona.Location = new System.Drawing.Point(37, 122);
            this.btnEliminarPersona.Name = "btnEliminarPersona";
            this.btnEliminarPersona.Size = new System.Drawing.Size(155, 38);
            this.btnEliminarPersona.TabIndex = 2;
            this.btnEliminarPersona.Text = "Eliminar persona";
            this.btnEliminarPersona.UseVisualStyleBackColor = true;
            this.btnEliminarPersona.Click += new System.EventHandler(this.btnEliminarPersona_Click);
            // 
            // btnRegistrarPrestamo
            // 
            this.btnRegistrarPrestamo.Location = new System.Drawing.Point(37, 166);
            this.btnRegistrarPrestamo.Name = "btnRegistrarPrestamo";
            this.btnRegistrarPrestamo.Size = new System.Drawing.Size(155, 38);
            this.btnRegistrarPrestamo.TabIndex = 3;
            this.btnRegistrarPrestamo.Text = "Registrar prestamo";
            this.btnRegistrarPrestamo.UseVisualStyleBackColor = true;
            this.btnRegistrarPrestamo.Click += new System.EventHandler(this.btnRegistrarPrestamo_Click);
            // 
            // btnRegistrarDevolucion
            // 
            this.btnRegistrarDevolucion.Location = new System.Drawing.Point(37, 210);
            this.btnRegistrarDevolucion.Name = "btnRegistrarDevolucion";
            this.btnRegistrarDevolucion.Size = new System.Drawing.Size(155, 38);
            this.btnRegistrarDevolucion.TabIndex = 4;
            this.btnRegistrarDevolucion.Text = "Registrar devolucion";
            this.btnRegistrarDevolucion.UseVisualStyleBackColor = true;
            this.btnRegistrarDevolucion.Click += new System.EventHandler(this.btnRegistrarDevolucion_Click);
            // 
            // btnIncremenarCantidad
            // 
            this.btnIncremenarCantidad.Location = new System.Drawing.Point(37, 254);
            this.btnIncremenarCantidad.Name = "btnIncremenarCantidad";
            this.btnIncremenarCantidad.Size = new System.Drawing.Size(155, 38);
            this.btnIncremenarCantidad.TabIndex = 5;
            this.btnIncremenarCantidad.Text = "Incrementar cantidad";
            this.btnIncremenarCantidad.UseVisualStyleBackColor = true;
            this.btnIncremenarCantidad.Click += new System.EventHandler(this.btnIncremenarCantidad_Click);
            // 
            // btnConsultarHistorial
            // 
            this.btnConsultarHistorial.Location = new System.Drawing.Point(37, 298);
            this.btnConsultarHistorial.Name = "btnConsultarHistorial";
            this.btnConsultarHistorial.Size = new System.Drawing.Size(155, 38);
            this.btnConsultarHistorial.TabIndex = 6;
            this.btnConsultarHistorial.Text = "Consultar historial";
            this.btnConsultarHistorial.UseVisualStyleBackColor = true;
            this.btnConsultarHistorial.Click += new System.EventHandler(this.btnConsultarHistorial_Click);
            // 
            // textBoxMaterialId
            // 
            this.textBoxMaterialId.Location = new System.Drawing.Point(290, 42);
            this.textBoxMaterialId.Name = "textBoxMaterialId";
            this.textBoxMaterialId.Size = new System.Drawing.Size(100, 22);
            this.textBoxMaterialId.TabIndex = 7;
            // 
            // textBoxTitulo
            // 
            this.textBoxTitulo.Location = new System.Drawing.Point(414, 43);
            this.textBoxTitulo.Name = "textBoxTitulo";
            this.textBoxTitulo.Size = new System.Drawing.Size(100, 22);
            this.textBoxTitulo.TabIndex = 8;
            // 
            // dateTimePickerFechaRegistro
            // 
            this.dateTimePickerFechaRegistro.Location = new System.Drawing.Point(546, 43);
            this.dateTimePickerFechaRegistro.Name = "dateTimePickerFechaRegistro";
            this.dateTimePickerFechaRegistro.Size = new System.Drawing.Size(285, 22);
            this.dateTimePickerFechaRegistro.TabIndex = 9;
            // 
            // numericUpDownCantidad
            // 
            this.numericUpDownCantidad.Location = new System.Drawing.Point(874, 42);
            this.numericUpDownCantidad.Name = "numericUpDownCantidad";
            this.numericUpDownCantidad.Size = new System.Drawing.Size(61, 22);
            this.numericUpDownCantidad.TabIndex = 10;
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(290, 86);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(100, 22);
            this.textBoxNombre.TabIndex = 11;
            // 
            // textBoxCedula
            // 
            this.textBoxCedula.Location = new System.Drawing.Point(414, 86);
            this.textBoxCedula.Name = "textBoxCedula";
            this.textBoxCedula.Size = new System.Drawing.Size(100, 22);
            this.textBoxCedula.TabIndex = 12;
            // 
            // comboBoxRol
            // 
            this.comboBoxRol.FormattingEnabled = true;
            this.comboBoxRol.Items.AddRange(new object[] {
            "Estudiante",
            "Profesor",
            "Administrativo"});
            this.comboBoxRol.Location = new System.Drawing.Point(546, 83);
            this.comboBoxRol.Name = "comboBoxRol";
            this.comboBoxRol.Size = new System.Drawing.Size(121, 24);
            this.comboBoxRol.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 580);
            this.Controls.Add(this.comboBoxRol);
            this.Controls.Add(this.textBoxCedula);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.numericUpDownCantidad);
            this.Controls.Add(this.dateTimePickerFechaRegistro);
            this.Controls.Add(this.textBoxTitulo);
            this.Controls.Add(this.textBoxMaterialId);
            this.Controls.Add(this.btnConsultarHistorial);
            this.Controls.Add(this.btnIncremenarCantidad);
            this.Controls.Add(this.btnRegistrarDevolucion);
            this.Controls.Add(this.btnRegistrarPrestamo);
            this.Controls.Add(this.btnEliminarPersona);
            this.Controls.Add(this.btnRegistrarPersona);
            this.Controls.Add(this.btnRegistrarMaterial);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRegistrarMaterial;
        private System.Windows.Forms.Button btnRegistrarPersona;
        private System.Windows.Forms.Button btnEliminarPersona;
        private System.Windows.Forms.Button btnRegistrarPrestamo;
        private System.Windows.Forms.Button btnRegistrarDevolucion;
        private System.Windows.Forms.Button btnIncremenarCantidad;
        private System.Windows.Forms.Button btnConsultarHistorial;
        private System.Windows.Forms.TextBox textBoxMaterialId;
        private System.Windows.Forms.TextBox textBoxTitulo;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaRegistro;
        private System.Windows.Forms.NumericUpDown numericUpDownCantidad;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.TextBox textBoxCedula;
        private System.Windows.Forms.ComboBox comboBoxRol;
    }
}

