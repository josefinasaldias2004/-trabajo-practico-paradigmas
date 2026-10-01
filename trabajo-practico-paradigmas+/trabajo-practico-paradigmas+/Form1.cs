using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using trabajo_practico_paradigmas_.Modelos;

namespace trabajo_practico_paradigmas_
{
    public partial class frmTPReservas : Form
    {
      //  private readonly IEventoRepository _repo;
        private int _idEventoModificar = 0;
        private const int MaximoNombre = 100; // Ajustar a la consigna completa.
        private readonly CheckBox chkConfirmada = new CheckBox();

        // Permite seguir usando Application.Run(new frmTPReservas()).
        public frmTPReservas() : this(new EventoRepositoryMemoria()) { }

        public frmTPReservas(IEventoRepository repo)
        {
            InitializeComponent();
            this._repo = repo ?? throw new ArgumentNullException(nameof(repo));
            StartPosition = FormStartPosition.CenterScreen;
            Load += frmTPReservas_Load;
            btnCancelar.Click += btnCancelar_Click;
            modeficarToolStripMenuItem.Click += mnuModificar_Click;
            eliminarToolStripMenuItem.Click += mnuEliminar_Click;
            dgvReservas.CellMouseDown += dgvReservas_CellMouseDown;
            contextMenuStrip1.Opening += (sender, e) =>
                e.Cancel = dgvReservas.SelectedRows.Count == 0;
        }

        private void InicializarControles()
        {
            this._idEventoModificar = 0;
            txtNombre.Clear();
            txtCantInvi.Text = "0";
            textBox1.Text = "0";
            dtpFechaEve.MinDate = DateTime.Today;
            dtpFechaEve.Value = DateTime.Today;
            dtpHoraIni.Value = DateTime.Today.AddHours(18);
            dtpHoraFin.Value = DateTime.Today.AddHours(19);
            cmbSalon.SelectedIndex = 0;
            chkConfirmada.Checked = false;
            btnRegistrar.Text = "Registrar";
            txtNombre.Focus();
        }

        private async void frmTPReservas_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            Text = "Eventos Sociales";
            txtNombre.MaxLength = MaximoNombre;
            cmbSalon.Items.Clear();
            cmbSalon.Items.AddRange(new object[] {
                "Salón Principal", "Salón Norte", "Salón Jardín", "Salón Patagonia"
            });
            cmbSalon.DropDownStyle = ComboBoxStyle.DropDownList;
 
            dtpFechaEve.MinDate = DateTime.Today;
           
            dtpHoraIni.CustomFormat = "HH:mm";
         
            dtpHoraFin.Format = DateTimePickerFormat.Custom;
            dtpHoraFin.CustomFormat = "HH:mm";
            dtpHoraFin.ShowUpDown = true;

           
            InicializarControles();
            await CargarGrilla();
        }

        private async Task CargarGrilla()
        {
           // List<Evento> lista = await _repo.GetAllAsync();
           // dgvReservas.DataSource = lista;
            dgvReservas.Columns["IdEvento"].Visible = false;
            dgvReservas.Columns["NombreEvento"].HeaderText = "Nombre del evento";
            dgvReservas.Columns["Salon"].HeaderText = "Salón";
            dgvReservas.Columns["FechaEvento"].HeaderText = "Fecha del evento";
            dgvReservas.Columns["FechaEvento"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvReservas.Columns["HoraInicio"].HeaderText = "Hora de inicio";
            dgvReservas.Columns["HoraInicio"].DefaultCellStyle.Format = "HH:mm";
            dgvReservas.Columns["HoraFin"].HeaderText = "Hora de fin";
            dgvReservas.Columns["HoraFin"].DefaultCellStyle.Format = "HH:mm";
            dgvReservas.Columns["CantidadInvitados"].HeaderText = "Cantidad de invitados";
            dgvReservas.Columns["CantidadInvitados"].DefaultCellStyle.Format = "N0";
            dgvReservas.Columns["Importe"].DefaultCellStyle.Format = "N2";
        }

     
        private async void button1_Click(object sender, EventArgs e)
        {
            btnRegistrar.Enabled = false;
            btnCancelar.Enabled = false;
            contextMenuStrip1.Enabled = false;
            try
            {
                ValidarFormulario();
                Evento nuevoEvento = new Evento();
                nuevoEvento.IdEvento = this._idEventoModificar;
                nuevoEvento.NombreEvento = txtNombre.Text.Trim();
                nuevoEvento.Salon = cmbSalon.Text;
                nuevoEvento.FechaEvento = dtpFechaEve.Value.Date;
                nuevoEvento.HoraInicio = nuevoEvento.FechaEvento.AddHours(dtpHoraIni.Value.Hour)
                    .AddMinutes(dtpHoraIni.Value.Minute);
                nuevoEvento.HoraFin = nuevoEvento.FechaEvento.AddHours(dtpHoraFin.Value.Hour)
                    .AddMinutes(dtpHoraFin.Value.Minute);
                nuevoEvento.CantidadInvitados = int.Parse(txtCantInvi.Text);
                nuevoEvento.Importe = decimal.Parse(textBox1.Text.Trim(),
                    NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign,
                    CultureInfo.CurrentCulture);
                nuevoEvento.Confirmada = chkConfirmada.Checked;

                await ValidarReglas(nuevoEvento);
                if (nuevoEvento.IdEvento == 0)
                    await _repo.CreateAsync(nuevoEvento);
                else
                    await _repo.UpdateAsync(nuevoEvento);
                await CargarGrilla();
                InicializarControles();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
            finally
            {
                btnRegistrar.Enabled = true;
                btnCancelar.Enabled = true;
                contextMenuStrip1.Enabled = true;
            }
        }

        private void ValidarFormulario()
        {
            var errores = new List<string>();
            string nombre = txtNombre.Text.Trim();
            if (nombre == string.Empty)
                errores.Add("El nombre del evento es obligatorio.");
            if (nombre.Length > MaximoNombre)
                errores.Add("El nombre no puede superar " + MaximoNombre + " caracteres.");
            if (cmbSalon.SelectedIndex < 0)
                errores.Add("Seleccioná un salón.");
            if (dtpFechaEve.Value.Date < DateTime.Today)
                errores.Add("La fecha del evento no puede ser anterior a hoy.");
            TimeSpan inicio = new TimeSpan(dtpHoraIni.Value.Hour, dtpHoraIni.Value.Minute, 0);
            TimeSpan fin = new TimeSpan(dtpHoraFin.Value.Hour, dtpHoraFin.Value.Minute, 0);
            if (fin <= inicio)
                errores.Add("La hora de fin debe ser posterior a la hora de inicio.");
            int invitados;
            if (!int.TryParse(txtCantInvi.Text, out invitados))
                errores.Add("La cantidad de invitados debe ser un número entero.");
            else if (invitados < 0 || invitados >= 150)
                errores.Add("La cantidad de invitados debe estar entre 0 y 149.");
            decimal importe;
            if (!decimal.TryParse(textBox1.Text.Trim(),
                NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign,
                CultureInfo.CurrentCulture, out importe))
                errores.Add("El importe debe ser numérico. Separador decimal: " +
                    CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            else if (importe < 0)
                errores.Add("El importe debe ser igual o mayor a cero.");
            if (errores.Count > 0)
                throw new Exception(string.Join("\n", errores));
        }

        private async Task ValidarReglas(Evento evento)
        {
            List<Evento> lista = await _repo.GetAllAsync();
            if (lista.Any(e => e.IdEvento != evento.IdEvento &&
                string.Equals(e.NombreEvento.Trim(), evento.NombreEvento, StringComparison.OrdinalIgnoreCase)))
                throw new Exception("Ya existe un evento con ese nombre.");
            if (lista.Any(e => e.IdEvento != evento.IdEvento &&
                e.FechaEvento.Date == evento.FechaEvento.Date && e.Salon == evento.Salon))
                throw new Exception("Ya existe una reserva para esa fecha y salón.");
        }

        private async void mnuModificar_Click(object sender, EventArgs e)
        {
            if (dgvReservas.SelectedRows.Count == 0) return;
            try
            {
                int id = Convert.ToInt32(dgvReservas.SelectedRows[0].Cells["IdEvento"].Value);
                Evento evento = await _repo.GetByIdAsync(id);
                if (evento == null) throw new Exception("La reserva ya no existe.");
                if (evento.FechaEvento.Date < DateTime.Today)
                    throw new Exception("No se puede modificar una reserva con fecha pasada.");
                this._idEventoModificar = evento.IdEvento;
                txtNombre.Text = evento.NombreEvento;
                cmbSalon.SelectedItem = evento.Salon;
                dtpFechaEve.Value = evento.FechaEvento;
                dtpHoraIni.Value = evento.HoraInicio;
                dtpHoraFin.Value = evento.HoraFin;
                txtCantInvi.Text = evento.CantidadInvitados.ToString();
                textBox1.Text = evento.Importe.ToString(CultureInfo.CurrentCulture);
                chkConfirmada.Checked = evento.Confirmada;
                btnRegistrar.Text = "Guardar cambios";
            }
            catch (Exception ex) { MostrarError(ex); }
        }

        private async void mnuEliminar_Click(object sender, EventArgs e)
        {
            if (dgvReservas.SelectedRows.Count == 0) return;
            int id = Convert.ToInt32(dgvReservas.SelectedRows[0].Cells["IdEvento"].Value);
            DialogResult respuesta = MessageBox.Show(this, "¿Deseás eliminar la reserva?",
                "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta != DialogResult.Yes) return;
            try
             {
                await _repo.DeleteAsync(id);
                if (this._idEventoModificar == id) InicializarControles();
                await CargarGrilla();
            }
            catch (Exception ex) { MostrarError(ex); }
        }

        private void dgvReservas_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            dgvReservas.ClearSelection();
            if (e.RowIndex >= 0)
            {
                dgvReservas.Rows[e.RowIndex].Selected = true;
                dgvReservas.CurrentCell = dgvReservas.Rows[e.RowIndex].Cells["NombreEvento"];
            }
        }

        private void MostrarError(Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnCancelar_Click(object sender, EventArgs e) { InicializarControles(); }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void txtCantInvi_TextChanged(object sender, EventArgs e) { }
    }
}
