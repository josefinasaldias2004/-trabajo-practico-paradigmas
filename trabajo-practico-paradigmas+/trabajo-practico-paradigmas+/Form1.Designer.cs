namespace trabajo_practico_paradigmas_
{
    partial class frmTPReservas
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnRegistrar = new Button();
            btnCancelar = new Button();
            dgvReservas = new DataGridView();
            txtNombre = new TextBox();
            label1 = new Label();
            cmbSalon = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            dtpFechaEve = new DateTimePicker();
            dtpHoraIni = new DateTimePicker();
            dtpHoraFin = new DateTimePicker();
            label4 = new Label();
            label5 = new Label();
            txtCantInvi = new TextBox();
            textBox1 = new TextBox();
            label6 = new Label();
            label7 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            modeficarToolStripMenuItem = new ToolStripMenuItem();
            eliminarToolStripMenuItem = new ToolStripMenuItem();
            chkConfirmacion = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dgvReservas).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(12, 374);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(278, 32);
            btnRegistrar.TabIndex = 0;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += button1_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(17, 412);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(273, 26);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // dgvReservas
            // 
            dgvReservas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReservas.Location = new Point(316, 12);
            dgvReservas.Name = "dgvReservas";
            dgvReservas.RowHeadersWidth = 51;
            dgvReservas.Size = new Size(475, 426);
            dgvReservas.TabIndex = 2;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(33, 27);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(151, 27);
            txtNombre.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(33, 4);
            label1.Name = "label1";
            label1.Size = new Size(144, 20);
            label1.TabIndex = 4;
            label1.Text = "Nombre del evento";
            // 
            // cmbSalon
            // 
            cmbSalon.FormattingEnabled = true;
            cmbSalon.Location = new Point(33, 79);
            cmbSalon.Name = "cmbSalon";
            cmbSalon.Size = new Size(151, 28);
            cmbSalon.TabIndex = 5;
            cmbSalon.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(33, 56);
            label2.Name = "label2";
            label2.Size = new Size(47, 20);
            label2.TabIndex = 6;
            label2.Text = "Salon";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(33, 110);
            label3.Name = "label3";
            label3.Size = new Size(126, 20);
            label3.TabIndex = 7;
            label3.Text = "Fecha del evento";
            // 
            // dtpFechaEve
            // 
            dtpFechaEve.Cursor = Cursors.SizeAll;
            dtpFechaEve.Format = DateTimePickerFormat.Short;
            dtpFechaEve.Location = new Point(33, 133);
            dtpFechaEve.Name = "dtpFechaEve";
            dtpFechaEve.Size = new Size(151, 27);
            dtpFechaEve.TabIndex = 8;
            // 
            // dtpHoraIni
            // 
            dtpHoraIni.Format = DateTimePickerFormat.Time;
            dtpHoraIni.Location = new Point(33, 186);
            dtpHoraIni.MinDate = new DateTime(2026, 9, 30, 0, 0, 0, 0);
            dtpHoraIni.Name = "dtpHoraIni";
            dtpHoraIni.Size = new Size(164, 27);
            dtpHoraIni.TabIndex = 9;
            // 
            // dtpHoraFin
            // 
            dtpHoraFin.Format = DateTimePickerFormat.Time;
            dtpHoraFin.Location = new Point(33, 239);
            dtpHoraFin.MinDate = new DateTime(2026, 9, 30, 0, 0, 0, 0);
            dtpHoraFin.Name = "dtpHoraFin";
            dtpHoraFin.Size = new Size(164, 27);
            dtpHoraFin.TabIndex = 10;
            dtpHoraFin.Value = new DateTime(2029, 12, 25, 23, 59, 59, 0);
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(33, 163);
            label4.Name = "label4";
            label4.Size = new Size(105, 20);
            label4.TabIndex = 11;
            label4.Text = "Hora de inicio";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(33, 216);
            label5.Name = "label5";
            label5.Size = new Size(151, 20);
            label5.TabIndex = 12;
            label5.Text = "Hora de finalización ";
            // 
            // txtCantInvi
            // 
            txtCantInvi.Location = new Point(34, 292);
            txtCantInvi.Name = "txtCantInvi";
            txtCantInvi.Size = new Size(125, 27);
            txtCantInvi.TabIndex = 13;
            txtCantInvi.TextChanged += txtCantInvi_TextChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(33, 341);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(33, 269);
            label6.Name = "label6";
            label6.Size = new Size(160, 20);
            label6.TabIndex = 15;
            label6.Text = "Cantidad de invitados";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.Location = new Point(34, 318);
            label7.Name = "label7";
            label7.Size = new Size(66, 20);
            label7.TabIndex = 16;
            label7.Text = "Importe";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { modeficarToolStripMenuItem, eliminarToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(147, 52);
            // 
            // modeficarToolStripMenuItem
            // 
            modeficarToolStripMenuItem.Name = "modeficarToolStripMenuItem";
            modeficarToolStripMenuItem.Size = new Size(146, 24);
            modeficarToolStripMenuItem.Text = "Modeficar";
            // 
            // eliminarToolStripMenuItem
            // 
            eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            eliminarToolStripMenuItem.Size = new Size(146, 24);
            eliminarToolStripMenuItem.Text = "Eliminar";
            // 
            // chkConfirmacion
            // 
            chkConfirmacion.AutoSize = true;
            chkConfirmacion.Location = new Point(170, 343);
            chkConfirmacion.Name = "chkConfirmacion";
            chkConfirmacion.Size = new Size(120, 24);
            chkConfirmacion.TabIndex = 17;
            chkConfirmacion.Text = "Confirmación";
            chkConfirmacion.UseVisualStyleBackColor = true;
            // 
            // frmTPReservas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(814, 459);
            Controls.Add(chkConfirmacion);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(textBox1);
            Controls.Add(txtCantInvi);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(dtpHoraFin);
            Controls.Add(dtpHoraIni);
            Controls.Add(dtpFechaEve);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cmbSalon);
            Controls.Add(label1);
            Controls.Add(txtNombre);
            Controls.Add(dgvReservas);
            Controls.Add(btnCancelar);
            Controls.Add(btnRegistrar);
            Name = "frmTPReservas";
            Text = "Eventos Sociales";
            ((System.ComponentModel.ISupportInitialize)dgvReservas).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRegistrar;
        private Button btnCancelar;
        private DataGridView dgvReservas;
        private TextBox txtNombre;
        private Label label1;
        private ComboBox cmbSalon;
        private Label label2;
        private Label label3;
        private DateTimePicker dtpFechaEve;
        private DateTimePicker dtpHoraIni;
        private DateTimePicker dtpHoraFin;
        private Label label4;
        private Label label5;
        private TextBox txtCantInvi;
        private TextBox textBox1;
        private Label label6;
        private Label label7;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem modeficarToolStripMenuItem;
        private ToolStripMenuItem eliminarToolStripMenuItem;
        private CheckBox chkConfirmacion;
    }
}
