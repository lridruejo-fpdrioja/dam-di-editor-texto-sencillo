using System.Drawing.Printing;
using System.Windows.Forms;

namespace EditorTextoSencillo.Vista
{
    /// <summary>
    /// Vista principal del editor de texto que implementa la interfaz IEditorTextoVista
    /// </summary>
    internal partial class EditorTexto : Form, IEditorTextoVista
    {
        // CONSTANTES
        private const string TITULO_APLICACION = "Editor de texto";
        private const string TITULO_BUSCAR = "Buscar";
        private const string TITULO_IR_A_LINEA = "Ir a línea";
        private const string TITULO_REEMPLAZAR = "Reemplazar";
        private const string TITULO_ACERCA_DE = "Acerca de";

        // MANEJADORES DE EVENTOS
        // Eventos del menú Archivo
        public event EventHandler ArchivoNuevoClick = delegate { };
        public event EventHandler ArchivoAbrirClick = delegate { };
        public event EventHandler<string> ArchivoAbrirRecienteClick = delegate { };
        public event EventHandler<string> ArchivoQuitarRecienteClick = delegate { };
        public event EventHandler ArchivoLimpiarRecientesClick = delegate { };
        public event EventHandler ArchivoGuardarClick = delegate { };
        public event EventHandler ArchivoGuardarComoClick = delegate { };
        public event EventHandler ArchivoCerrarClick = delegate { };
        public event EventHandler ArchivoSalirClick = delegate { };

        // Eventos del menú Editar
        public event EventHandler EditarReemplazarClick = delegate { };

        // Eventos del menú Formato
        public event EventHandler FormatoMayusculasClick = delegate { };
        public event EventHandler FormatoMinusculasClick = delegate { };
        public event EventHandler FormatoTituloClick = delegate { };
        public event EventHandler FormatoOracionClick = delegate { };

        // Eventos del cuadro de texto
        public event EventHandler TextoCambiado = delegate { };

        // Evento de cierre de aplicación
        public event EventHandler<FormClosingEventArgs>? AplicacionCerrando;

        /// <summary>
        /// Constructor principal que inicializa los componentes y configura eventos
        /// </summary>
        internal EditorTexto()
        {
            InitializeComponent();
            ConfigurarEventosVista();

        }

        // CONFIGURACIÓN EVENTOS
        private void ConfigurarEventosVista()
        {
            // Eventos del menú Archivo
            nuevoToolStripMenuItem.Click += (s, e) => ArchivoNuevoClick?.Invoke(this, e);
            abrirToolStripMenuItem.Click += (s, e) => ArchivoAbrirClick?.Invoke(this, e);
            guardarToolStripMenuItem.Click += (s, e) => ArchivoGuardarClick?.Invoke(this, e);
            guardarComoToolStripMenuItem.Click += (s, e) => ArchivoGuardarComoClick?.Invoke(this, e);
            cerrarToolStripMenuItem.Click += (s, e) => ArchivoCerrarClick?.Invoke(this, e);
            salirToolStripMenuItem.Click += (s, e) => ArchivoSalirClick?.Invoke(this, e);

            // Eventos del menú Editar
            reemplazarToolStripMenuItem.Click += (s, e) => EditarReemplazarClick?.Invoke(this, e);

            // Eventos del menú Formato
            mayusculasToolStripMenuItem.Click += (s, e) => FormatoMayusculasClick?.Invoke(this, e);
            minusculasToolStripMenuItem.Click += (s, e) => FormatoMinusculasClick?.Invoke(this, e);
            tituloToolStripMenuItem.Click += (s, e) => FormatoTituloClick?.Invoke(this, e);
            oracionToolStripMenuItem.Click += (s, e) => FormatoOracionClick?.Invoke(this, e);

            // Eventos del cuadro de texto
            richTextBox.TextChanged += (s, e) => TextoCambiado?.Invoke(this, e);

            // Evento de cierrre de aplicación
            this.FormClosing += (s, e) => AplicacionCerrando?.Invoke(this, e);
        }

        // MÉTODOS DE LA INTERFAZ
        #region Implementación de los métodos de la interfaz

        #region Actualización de la vista
        public void EstablecerTituloVentana(string nombreArchivo)
        {
            Text = $"{TITULO_APLICACION}: {nombreArchivo}";
        }

        public string ObtenerTexto()
        {
            return richTextBox.Text;
        }

        public string ObtenerTextoSeleccionado()
        {
            return richTextBox.SelectedText;
        }

        public void EstablecerTexto(string texto)
        {
            richTextBox.Text = texto;
        }

        public void ActualizarBarraDeEstado(int lineas, int palabras, int caracteres, string codificacion)
        {
            ActualizarPosicionCursor();
            lineasToolStripStatusLabel.Text = $"Líneas: {lineas}";
            palabrasToolStripStatusLabel.Text = $"Palabras: {palabras}";
            caracteresToolStripStatusLabel.Text = $"Caracteres: {caracteres}";
            codificacionToolStripStatusLabel.Text = $"Codificación: {codificacion}";
        }

        public void ActualizarArchivosRecientes(IReadOnlyList<string> archivosRecientes)
        {
            abrirRecienteToolStripMenuItem.DropDownItems.Clear();

            abrirRecienteToolStripMenuItem.Enabled = archivosRecientes.Count > 0; // Deshabilitar abrir reciente si no hay recientes

            foreach (string ruta in archivosRecientes)
            {
                ToolStripMenuItem archivoReciente = new ToolStripMenuItem(Path.GetFileName(ruta));
                archivoReciente.Tag = ruta;
                archivoReciente.Name = Path.GetFileName(ruta) + "Reciente";
                archivoReciente.Click += (s, e) => ArchivoAbrirRecienteClick?.Invoke(this, ruta);
                abrirRecienteToolStripMenuItem.DropDownItems.Add(archivoReciente);
            }

            if (abrirRecienteToolStripMenuItem.Enabled == true)
            {
                ToolStripSeparator toolStripMenuSeparator4 = new ToolStripSeparator();
                toolStripMenuSeparator4.Name = "toolStripMenuSeparator4";
                abrirRecienteToolStripMenuItem.DropDownItems.Add(toolStripMenuSeparator4);

                ToolStripMenuItem quitarRecienteToolStripMenuItem = new ToolStripMenuItem("Quitar reciente");
                quitarRecienteToolStripMenuItem.Name = "quitarRecienteToolStripMenuItem";
                abrirRecienteToolStripMenuItem.DropDownItems.Add(quitarRecienteToolStripMenuItem);

                foreach (string ruta in archivosRecientes)
                {
                    ToolStripMenuItem archivoRecienteQuitar = new ToolStripMenuItem(Path.GetFileName(ruta));
                    archivoRecienteQuitar.Tag = ruta;
                    archivoRecienteQuitar.Name = Path.GetFileName(ruta) + "RecienteQuitar";
                    archivoRecienteQuitar.Click += (s, e) => ArchivoQuitarRecienteClick?.Invoke(this, ruta);
                    quitarRecienteToolStripMenuItem.DropDownItems.Add(archivoRecienteQuitar);
                }

                ToolStripSeparator toolStripMenuSeparator5 = new ToolStripSeparator();
                toolStripMenuSeparator5.Name = "toolStripMenuSeparator5";
                quitarRecienteToolStripMenuItem.DropDownItems.Add(toolStripMenuSeparator5);

                ToolStripMenuItem limpiarRecientesToolStripMenuItem = new ToolStripMenuItem("Limpiar recientes");
                limpiarRecientesToolStripMenuItem.Name = "limpiarRecientesToolStripMenuItem";
                limpiarRecientesToolStripMenuItem.Click += (s, e) => ArchivoLimpiarRecientesClick?.Invoke(this, e);
                quitarRecienteToolStripMenuItem.DropDownItems.Add(limpiarRecientesToolStripMenuItem);
            }

        }
        #endregion

        public void Reemplazar(string texto)
        {
            if (richTextBox.SelectionLength > 0)
            {
                richTextBox.SelectedText = texto;
            }
        }

        public int ReemplazarSiguiente(string textoBuscar, string? textoReemplazar)
        {
            if (string.IsNullOrEmpty(textoBuscar))
            {
                return 0;
            }

            textoReemplazar ??= string.Empty;

            int indiceInicio = richTextBox.SelectionStart + richTextBox.SelectionLength;
            int indiceCoincidencia = richTextBox.Find(textoBuscar, indiceInicio, RichTextBoxFinds.None);

            if (indiceCoincidencia == -1 && indiceInicio > 0)
            {
                indiceCoincidencia = richTextBox.Find(textoBuscar, 0, RichTextBoxFinds.None);
            }

            if (indiceCoincidencia != -1)
            {
                richTextBox.Select(indiceCoincidencia, textoBuscar.Length);
                richTextBox.SelectedText = textoReemplazar;
                richTextBox.ScrollToCaret();
                return 1;
            }

            return 0;
        }

        public int ReemplazarTodo(string textoBuscar, string? textoReemplazar)
        {
            if (string.IsNullOrEmpty(textoBuscar))
            {
                return 0;
            }

            textoReemplazar ??= string.Empty;
            int reemplazos = 0;
            int indiceInicio = 0;

            while (indiceInicio < richTextBox.TextLength)
            {
                int indiceCoincidencia = richTextBox.Find(textoBuscar, indiceInicio, RichTextBoxFinds.None);

                if (indiceCoincidencia == -1)
                {
                    break;
                }

                richTextBox.Select(indiceCoincidencia, textoBuscar.Length);
                richTextBox.SelectedText = textoReemplazar;

                reemplazos++;
                indiceInicio = indiceCoincidencia + textoReemplazar.Length;
            }

            return reemplazos;
        }
        #endregion

        // DIÁLOGOS
        #region Diálogos
        public string? AbrirArchivoDialogo()
        {
            return openFileDialog.ShowDialog() == DialogResult.OK ? openFileDialog.FileName : null;
        }

        public DialogResult GuardarCambiosDialogo()
        {
            return MessageBox.Show(
                "¿Quieres guardar los cambios?",
                TITULO_APLICACION,
                MessageBoxButtons.YesNoCancel);
        }

        public string? GuardarComoDialogo()
        {
            return saveFileDialog.ShowDialog() == DialogResult.OK ? saveFileDialog.FileName : null;
        }

        // TODO: Reemplaza siempre todo
        public (string?, string?, DialogResult) ReemplazarDialogo()
        {
            using Form reemplazarDialogo = CrearDialogoReemplazar();
            DialogResult reemplazar = reemplazarDialogo.ShowDialog();

            string textoBuscar = ((TextBox)reemplazarDialogo.Controls[1]).Text;
            string textoReemplazar = ((TextBox)reemplazarDialogo.Controls[3]).Text;

            if (reemplazar == DialogResult.Cancel || string.IsNullOrEmpty(textoBuscar))
            {
                return (null, null, DialogResult.Cancel);
            }

            return (textoBuscar, textoReemplazar, reemplazar);
        }
        #endregion

        // MENSAJES
        public void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(
                mensaje,
                TITULO_APLICACION,
                MessageBoxButtons.OK);
        }

        public void MostrarError(string error)
        {
            MessageBox.Show(
                error,
                $"{TITULO_APLICACION}: ERROR",
                MessageBoxButtons.OK);
        }

        // COMPORTAMIENTO DE LA APLICACIÓN
        public void CerrarAplicacion()
        {
            this.Close();
        }

        // MANEJADORES DE EVENTOS INTERNOS DE LA VISTA
        #region Manejadores de eventos internos de la vista
        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.PrintPage += ImprimirPag;

                printDocument.Print();

                printDocument.PrintPage -= ImprimirPag;
            }
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using Form buscarDialogo = CrearDialogoBuscar();

            // Mostrar el diálogo de forma no modal para que no bloquee la aplicación
            buscarDialogo.ShowDialog();

            ActualizarPosicionCursor();
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.SelectionStart = 0;
            richTextBox.SelectionLength = 0;
            richTextBox.ScrollToCaret();
        }

        private void lineaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using Form irALineaDialogo = CrearDialogoIrALinea();

            if (irALineaDialogo.ShowDialog() == DialogResult.OK)
            {
                int linea = (int)((NumericUpDown)irALineaDialogo.Controls[1]).Value;
                if (linea > 0 && linea <= richTextBox.Lines.Length)
                {
                    int posicion = richTextBox.GetFirstCharIndexFromLine(linea - 1);
                    richTextBox.SelectionStart = posicion;
                    richTextBox.SelectionLength = 0;
                    richTextBox.ScrollToCaret();
                }
            }

            ActualizarPosicionCursor();
        }

        private void finToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.SelectionStart = richTextBox.TextLength;
            richTextBox.SelectionLength = 0;
            richTextBox.ScrollToCaret();
        }

        private void fuenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox.Font = fontDialog.Font;
            }
        }

        private void barraDeEstadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = barraDeEstadoToolStripMenuItem.Checked;
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string mensaje = @"Editor de texto sencillo
                Versión: 1.0
                Autora: Lara Ridruejo Alcalde
                Editor de texto sencillo creado con Windows Forms .NET 9.0";

            MessageBox.Show(
                mensaje,
                TITULO_ACERCA_DE,
                MessageBoxButtons.OK);
        }

        private void richTextBox_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarPosicionCursor();
        }
        #endregion

        // MÉTODOS AUXILIARES
        // Calcular la posición del cursor
        private void ActualizarPosicionCursor()
        {
            int pos = richTextBox.SelectionStart;
            int numLinea = richTextBox.GetLineFromCharIndex(pos) + 1;
            int numCaracter = pos - richTextBox.GetFirstCharIndexOfCurrentLine() + 1;

            posicionToolStripStatusLabel.Text = $"Línea: {numLinea}, Columna: {numCaracter}";
        }

        private void ImprimirPag(object sender, PrintPageEventArgs e)
        {
            if (e?.Graphics == null)
            {
                throw new InvalidOperationException("No se puede imprimir: Graphics es null.");
            }

            e.Graphics.DrawString(
                richTextBox.Text,
                richTextBox.Font,
                Brushes.Black,
                e.MarginBounds.Left,
                e.MarginBounds.Top
            );

            e.HasMorePages = false;
        }

        private void RealizarBusqueda(string textoBuscar)
        {
            int indiceInicio = richTextBox.SelectionStart + richTextBox.SelectionLength;
            int indiceCoincidencia = richTextBox.Find(textoBuscar, indiceInicio, RichTextBoxFinds.None);

            if (indiceCoincidencia >= 0)
            {
                richTextBox.Select(indiceCoincidencia, textoBuscar.Length);
                richTextBox.ScrollToCaret();
            }
            else
            {
                indiceCoincidencia = richTextBox.Find(textoBuscar, 0, RichTextBoxFinds.None);

                if (indiceCoincidencia >= 0)
                {
                    richTextBox.Select(indiceCoincidencia, textoBuscar.Length);
                    richTextBox.ScrollToCaret();
                }
                else
                {
                    MessageBox.Show("No se han encontrado coincidencias.", TITULO_BUSCAR, MessageBoxButtons.OK);
                }
            }
        }

        #region Creación de diálogos
        private Form CrearDialogoBuscar()
        {
            Form buscarDialogo = new Form
            {
                Text = "Buscar",
                Size = new Size(280, 200),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MinimizeBox = false,
                MaximizeBox = false
            };
            Label lblBuscar = new Label()
            {
                Text = "Buscar:",
                Location = new Point(10, 10),
                Width = 240,
                Height = 30
            };
            TextBox txtBuscar = new TextBox()
            {
                Text = richTextBox.SelectedText,
                Location = new Point(10, 45),
                Width = 240,
                Height = 30
            };
            Button btnBuscarSiguiente = new Button()
            {
                Text = "Buscar siguiente",
                Location = new Point(10, 95),
                Width = 140,
                Height = 50,
                DialogResult = DialogResult.None
            };
            Button btnCancelar = new Button()
            {
                Text = "Cancelar",
                Location = new Point(170, 95),
                Width = 80,
                Height = 50,
                Name = "btnCancelar",
                DialogResult = DialogResult.Cancel
            };

            btnBuscarSiguiente.Click += (s, e) =>
            {
                if (!string.IsNullOrEmpty(txtBuscar.Text))
                {
                    RealizarBusqueda(txtBuscar.Text);
                }
            };

            buscarDialogo.Controls.AddRange(new Control[] {
                    lblBuscar,
                    txtBuscar,
                    btnBuscarSiguiente,
                    btnCancelar
            });
            buscarDialogo.AcceptButton = btnBuscarSiguiente;
            buscarDialogo.CancelButton = btnCancelar;
            return buscarDialogo;
        }

        private Form CrearDialogoReemplazar()
        {
            Form reemplazarDialogo = new Form
            {
                Text = TITULO_REEMPLAZAR,
                Size = new Size(280, 320),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MinimizeBox = false,
                MaximizeBox = false,
                Name = "reemplazarDialogo"
            };
            Label lblBuscar = new Label()
            {
                Text = "Buscar:",
                Location = new Point(10, 10),
                Width = 240,
                Height = 30
            };
            TextBox txtBuscar = new TextBox()
            {
                Text = richTextBox.SelectedText,
                Location = new Point(10, 42),
                Width = 240,
                Height = 30
            };
            Label lblReemplazar = new Label()
            {
                Text = "Reemplazar con:",
                Location = new Point(10, 80),
                Width = 240,
                Height = 30
            };
            TextBox txtReemplazar = new TextBox()
            {
                Location = new Point(10, 112),
                Width = 240,
                Height = 30
            };
            Button btnReemplazarSiguiente = new Button()
            {
                Text = "Reemplazar siguiente",
                Location = new Point(10, 155),
                Width = 115,
                Height = 50,
                DialogResult = DialogResult.None
            };
            Button btnCancelar = new Button()
            {
                Text = "Cancelar",
                Location = new Point(135, 155),
                Width = 115,
                Height = 50,
                DialogResult = DialogResult.Cancel
            };
            Button btnReemplazarTodo = new Button()
            {
                Text = "Reemplazar todo",
                Location = new Point(10, 210),
                Width = 240,
                Height = 50,
                DialogResult = DialogResult.OK
            };

            btnReemplazarSiguiente.Click += (s, e) =>
            {
                if (!string.IsNullOrEmpty(txtBuscar.Text))
                {
                    if (ReemplazarSiguiente(txtBuscar.Text, txtReemplazar.Text) == 0)
                    {
                        MessageBox.Show(
                            "No se encontraron más coincidencias.",
                            TITULO_REEMPLAZAR,
                            MessageBoxButtons.OK);
                    }
                }
            };

            reemplazarDialogo.Controls.AddRange(new Control[] {
                    lblBuscar,
                    txtBuscar,
                    lblReemplazar,
                    txtReemplazar,
                    btnReemplazarSiguiente,
                    btnCancelar,
                    btnReemplazarTodo
            });
            reemplazarDialogo.AcceptButton = btnReemplazarSiguiente;
            reemplazarDialogo.CancelButton = btnCancelar;
            return reemplazarDialogo;
        }

        private Form CrearDialogoIrALinea()
        {
            Form irALineaDialogo = new Form

            {
                Text = TITULO_IR_A_LINEA,
                Size = new Size(280, 170),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MinimizeBox = false,
                MaximizeBox = false,
                Name = "irALineaDialogo"
            };

            Label lblNumeroLinea = new Label()
            {
                Text = "Número de línea:",
                Location = new Point(10, 10),
                Width = 130,
                Height = 30
            };
            NumericUpDown txtNumeroLinea = new NumericUpDown()
            {
                Location = new Point(150, 10),
                Width = 100,
                Height = 30,
                Minimum = 1,
                Maximum = Math.Max(1, richTextBox.Lines.Length),
                Value = 1
            };
            Button btnAceptar = new Button()
            {
                Text = "Aceptar",
                Location = new Point(20, 60),
                Width = 100,
                Height = 50,
                DialogResult = DialogResult.OK
            };
            Button btnCancelar = new Button()
            {
                Text = "Cancelar",
                Location = new Point(140, 60),
                Width = 100,
                Height = 50,
                DialogResult = DialogResult.Cancel
            };

            irALineaDialogo.Controls.AddRange(new Control[] {
                    lblNumeroLinea,
                    txtNumeroLinea,
                    btnAceptar,
                    btnCancelar
            });
            irALineaDialogo.AcceptButton = btnAceptar;
            irALineaDialogo.CancelButton = btnCancelar;
            return irALineaDialogo;
        }
        #endregion
    }
}
