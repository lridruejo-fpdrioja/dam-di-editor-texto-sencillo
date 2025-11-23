using System.Text;

namespace EditorTextoSencillo.Vista
{
    partial class EditorTexto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorTexto));
            menuStrip = new MenuStrip();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            nuevoToolStripMenuItem = new ToolStripMenuItem();
            abrirToolStripMenuItem = new ToolStripMenuItem();
            abrirRecienteToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuSeparator2 = new ToolStripSeparator();
            guardarToolStripMenuItem = new ToolStripMenuItem();
            guardarComoToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuSeparator3 = new ToolStripSeparator();
            imprimirToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuSeparator4 = new ToolStripSeparator();
            cerrarToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            editarToolStripMenuItem = new ToolStripMenuItem();
            buscarToolStripMenuItem = new ToolStripMenuItem();
            irAToolStripMenuItem = new ToolStripMenuItem();
            inicioToolStripMenuItem = new ToolStripMenuItem();
            lineaToolStripMenuItem = new ToolStripMenuItem();
            finToolStripMenuItem = new ToolStripMenuItem();
            reemplazarToolStripMenuItem = new ToolStripMenuItem();
            formatoToolStripMenuItem = new ToolStripMenuItem();
            fuenteToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuSeparator6 = new ToolStripSeparator();
            mayusculasToolStripMenuItem = new ToolStripMenuItem();
            minusculasToolStripMenuItem = new ToolStripMenuItem();
            tituloToolStripMenuItem = new ToolStripMenuItem();
            oracionToolStripMenuItem = new ToolStripMenuItem();
            verToolStripMenuItem = new ToolStripMenuItem();
            barraDeEstadoToolStripMenuItem = new ToolStripMenuItem();
            ayudaToolStripMenuItem = new ToolStripMenuItem();
            acercaDeToolStripMenuItem = new ToolStripMenuItem();
            statusStrip = new StatusStrip();
            posicionToolStripStatusLabel = new ToolStripStatusLabel();
            lineasToolStripStatusLabel = new ToolStripStatusLabel();
            palabrasToolStripStatusLabel = new ToolStripStatusLabel();
            caracteresToolStripStatusLabel = new ToolStripStatusLabel();
            codificacionToolStripStatusLabel = new ToolStripStatusLabel();
            openFileDialog = new OpenFileDialog();
            saveFileDialog = new SaveFileDialog();
            printDialog = new PrintDialog();
            printDocument = new System.Drawing.Printing.PrintDocument();
            fontDialog = new FontDialog();
            richTextBox = new RichTextBox();
            menuStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.AllowMerge = false;
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, editarToolStripMenuItem, formatoToolStripMenuItem, verToolStripMenuItem, ayudaToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(782, 28);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "Menú";
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { nuevoToolStripMenuItem, abrirToolStripMenuItem, abrirRecienteToolStripMenuItem, toolStripMenuSeparator2, guardarToolStripMenuItem, guardarComoToolStripMenuItem, toolStripMenuSeparator3, imprimirToolStripMenuItem, toolStripMenuSeparator4, cerrarToolStripMenuItem, salirToolStripMenuItem });
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new Size(73, 24);
            archivoToolStripMenuItem.Text = "&Archivo";
            // 
            // nuevoToolStripMenuItem
            // 
            nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            nuevoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            nuevoToolStripMenuItem.Size = new Size(197, 26);
            nuevoToolStripMenuItem.Text = "&Nuevo";
            // 
            // abrirToolStripMenuItem
            // 
            abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            abrirToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;
            abrirToolStripMenuItem.Size = new Size(197, 26);
            abrirToolStripMenuItem.Text = "A&brir";
            // 
            // abrirRecienteToolStripMenuItem
            // 
            abrirRecienteToolStripMenuItem.Name = "abrirRecienteToolStripMenuItem";
            abrirRecienteToolStripMenuItem.Size = new Size(197, 26);
            abrirRecienteToolStripMenuItem.Text = "Abrir &reciente";
            // 
            // toolStripMenuSeparator2
            // 
            toolStripMenuSeparator2.Name = "toolStripMenuSeparator2";
            toolStripMenuSeparator2.Size = new Size(194, 6);
            // 
            // guardarToolStripMenuItem
            // 
            guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            guardarToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.G;
            guardarToolStripMenuItem.Size = new Size(197, 26);
            guardarToolStripMenuItem.Text = "&Guardar";
            // 
            // guardarComoToolStripMenuItem
            // 
            guardarComoToolStripMenuItem.Name = "guardarComoToolStripMenuItem";
            guardarComoToolStripMenuItem.Size = new Size(197, 26);
            guardarComoToolStripMenuItem.Text = "Guardar &como";
            // 
            // toolStripMenuSeparator3
            // 
            toolStripMenuSeparator3.Name = "toolStripMenuSeparator3";
            toolStripMenuSeparator3.Size = new Size(194, 6);
            // 
            // imprimirToolStripMenuItem
            // 
            imprimirToolStripMenuItem.Name = "imprimirToolStripMenuItem";
            imprimirToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.I;
            imprimirToolStripMenuItem.Size = new Size(197, 26);
            imprimirToolStripMenuItem.Text = "&Imprimir";
            imprimirToolStripMenuItem.Click += imprimirToolStripMenuItem_Click;
            // 
            // toolStripMenuSeparator4
            // 
            toolStripMenuSeparator4.Name = "toolStripMenuSeparator4";
            toolStripMenuSeparator4.Size = new Size(194, 6);
            // 
            // cerrarToolStripMenuItem
            // 
            cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            cerrarToolStripMenuItem.Size = new Size(197, 26);
            cerrarToolStripMenuItem.Text = "C&errar archivo";
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            salirToolStripMenuItem.Size = new Size(197, 26);
            salirToolStripMenuItem.Text = "&Salir";
            // 
            // editarToolStripMenuItem
            // 
            editarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { buscarToolStripMenuItem, irAToolStripMenuItem, reemplazarToolStripMenuItem });
            editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            editarToolStripMenuItem.Size = new Size(62, 24);
            editarToolStripMenuItem.Text = "&Editar";
            // 
            // buscarToolStripMenuItem
            // 
            buscarToolStripMenuItem.Name = "buscarToolStripMenuItem";
            buscarToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.B;
            buscarToolStripMenuItem.Size = new Size(222, 26);
            buscarToolStripMenuItem.Text = "&Buscar";
            buscarToolStripMenuItem.Click += buscarToolStripMenuItem_Click;
            // 
            // irAToolStripMenuItem
            // 
            irAToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { inicioToolStripMenuItem, lineaToolStripMenuItem, finToolStripMenuItem });
            irAToolStripMenuItem.Name = "irAToolStripMenuItem";
            irAToolStripMenuItem.Size = new Size(222, 26);
            irAToolStripMenuItem.Text = "&Ir a...";
            // 
            // inicioToolStripMenuItem
            // 
            inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            inicioToolStripMenuItem.Size = new Size(128, 26);
            inicioToolStripMenuItem.Text = "Inicio";
            inicioToolStripMenuItem.Click += inicioToolStripMenuItem_Click;
            // 
            // lineaToolStripMenuItem
            // 
            lineaToolStripMenuItem.Name = "lineaToolStripMenuItem";
            lineaToolStripMenuItem.Size = new Size(128, 26);
            lineaToolStripMenuItem.Text = "Línea";
            lineaToolStripMenuItem.Click += lineaToolStripMenuItem_Click;
            // 
            // finToolStripMenuItem
            // 
            finToolStripMenuItem.Name = "finToolStripMenuItem";
            finToolStripMenuItem.Size = new Size(128, 26);
            finToolStripMenuItem.Text = "Fin";
            finToolStripMenuItem.Click += finToolStripMenuItem_Click;
            // 
            // reemplazarToolStripMenuItem
            // 
            reemplazarToolStripMenuItem.Name = "reemplazarToolStripMenuItem";
            reemplazarToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.R;
            reemplazarToolStripMenuItem.Size = new Size(222, 26);
            reemplazarToolStripMenuItem.Text = "&Reemplazar";
            // 
            // formatoToolStripMenuItem
            // 
            formatoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { fuenteToolStripMenuItem, toolStripMenuSeparator6, mayusculasToolStripMenuItem, minusculasToolStripMenuItem, tituloToolStripMenuItem, oracionToolStripMenuItem });
            formatoToolStripMenuItem.Name = "formatoToolStripMenuItem";
            formatoToolStripMenuItem.Size = new Size(79, 24);
            formatoToolStripMenuItem.Text = "&Formato";
            // 
            // fuenteToolStripMenuItem
            // 
            fuenteToolStripMenuItem.Name = "fuenteToolStripMenuItem";
            fuenteToolStripMenuItem.Size = new Size(184, 26);
            fuenteToolStripMenuItem.Text = "&Fuente";
            fuenteToolStripMenuItem.Click += fuenteToolStripMenuItem_Click;
            // 
            // toolStripMenuSeparator6
            // 
            toolStripMenuSeparator6.Name = "toolStripMenuSeparator6";
            toolStripMenuSeparator6.Size = new Size(181, 6);
            // 
            // mayusculasToolStripMenuItem
            // 
            mayusculasToolStripMenuItem.Name = "mayusculasToolStripMenuItem";
            mayusculasToolStripMenuItem.Size = new Size(184, 26);
            mayusculasToolStripMenuItem.Text = "&MAYÚSCULAS";
            // 
            // minusculasToolStripMenuItem
            // 
            minusculasToolStripMenuItem.Name = "minusculasToolStripMenuItem";
            minusculasToolStripMenuItem.Size = new Size(184, 26);
            minusculasToolStripMenuItem.Text = "m&inúsculas";
            // 
            // tituloToolStripMenuItem
            // 
            tituloToolStripMenuItem.Name = "tituloToolStripMenuItem";
            tituloToolStripMenuItem.Size = new Size(184, 26);
            tituloToolStripMenuItem.Text = "&Título";
            // 
            // oracionToolStripMenuItem
            // 
            oracionToolStripMenuItem.Name = "oracionToolStripMenuItem";
            oracionToolStripMenuItem.Size = new Size(184, 26);
            oracionToolStripMenuItem.Text = "&Oración";
            // 
            // verToolStripMenuItem
            // 
            verToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { barraDeEstadoToolStripMenuItem });
            verToolStripMenuItem.Name = "verToolStripMenuItem";
            verToolStripMenuItem.Size = new Size(44, 24);
            verToolStripMenuItem.Text = "&Ver";
            // 
            // barraDeEstadoToolStripMenuItem
            // 
            barraDeEstadoToolStripMenuItem.Checked = true;
            barraDeEstadoToolStripMenuItem.CheckOnClick = true;
            barraDeEstadoToolStripMenuItem.CheckState = CheckState.Checked;
            barraDeEstadoToolStripMenuItem.Name = "barraDeEstadoToolStripMenuItem";
            barraDeEstadoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.H;
            barraDeEstadoToolStripMenuItem.Size = new Size(250, 26);
            barraDeEstadoToolStripMenuItem.Text = "&Barra de estado";
            barraDeEstadoToolStripMenuItem.Click += barraDeEstadoToolStripMenuItem_Click;
            // 
            // ayudaToolStripMenuItem
            // 
            ayudaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { acercaDeToolStripMenuItem });
            ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            ayudaToolStripMenuItem.Size = new Size(65, 24);
            ayudaToolStripMenuItem.Text = "A&yuda";
            // 
            // acercaDeToolStripMenuItem
            // 
            acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            acercaDeToolStripMenuItem.Size = new Size(167, 26);
            acercaDeToolStripMenuItem.Text = "&Acerca de...";
            acercaDeToolStripMenuItem.Click += acercaDeToolStripMenuItem_Click;
            // 
            // statusStrip
            // 
            statusStrip.AllowMerge = false;
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { posicionToolStripStatusLabel, lineasToolStripStatusLabel, palabrasToolStripStatusLabel, caracteresToolStripStatusLabel, codificacionToolStripStatusLabel });
            statusStrip.Location = new Point(0, 423);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(782, 30);
            statusStrip.TabIndex = 1;
            statusStrip.Text = "Barra de estado";
            // 
            // posicionToolStripStatusLabel
            // 
            posicionToolStripStatusLabel.BorderSides = ToolStripStatusLabelBorderSides.Right;
            posicionToolStripStatusLabel.Name = "posicionToolStripStatusLabel";
            posicionToolStripStatusLabel.Size = new Size(140, 24);
            posicionToolStripStatusLabel.Text = "Línea: 1, Carácter: 1";
            // 
            // lineasToolStripStatusLabel
            // 
            lineasToolStripStatusLabel.Name = "lineasToolStripStatusLabel";
            lineasToolStripStatusLabel.Size = new Size(138, 24);
            lineasToolStripStatusLabel.Spring = true;
            lineasToolStripStatusLabel.Text = "Líneas: 1";
            // 
            // palabrasToolStripStatusLabel
            // 
            palabrasToolStripStatusLabel.Name = "palabrasToolStripStatusLabel";
            palabrasToolStripStatusLabel.Size = new Size(138, 24);
            palabrasToolStripStatusLabel.Spring = true;
            palabrasToolStripStatusLabel.Text = "Palabras: 0";
            // 
            // caracteresToolStripStatusLabel
            // 
            caracteresToolStripStatusLabel.Name = "caracteresToolStripStatusLabel";
            caracteresToolStripStatusLabel.Size = new Size(138, 24);
            caracteresToolStripStatusLabel.Spring = true;
            caracteresToolStripStatusLabel.Text = "Caracteres: 0";
            // 
            // codificacionToolStripStatusLabel
            // 
            codificacionToolStripStatusLabel.BorderSides = ToolStripStatusLabelBorderSides.Left;
            codificacionToolStripStatusLabel.Name = "codificacionToolStripStatusLabel";
            codificacionToolStripStatusLabel.RightToLeft = RightToLeft.No;
            codificacionToolStripStatusLabel.Size = new Size(211, 24);
            codificacionToolStripStatusLabel.Text = "Codificación: Unicode (UTF-8)";
            // 
            // openFileDialog
            // 
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            // 
            // saveFileDialog
            // 
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.FileName = "Sin título";
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            // 
            // printDialog
            // 
            printDialog.Document = printDocument;
            printDialog.UseEXDialog = true;
            // 
            // richTextBox
            // 
            richTextBox.Dock = DockStyle.Fill;
            richTextBox.Location = new Point(0, 28);
            richTextBox.Name = "richTextBox";
            richTextBox.Size = new Size(782, 395);
            richTextBox.TabIndex = 2;
            richTextBox.Text = "";
            richTextBox.SelectionChanged += richTextBox_SelectionChanged;
            // 
            // EditorTexto
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 453);
            Controls.Add(richTextBox);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            Name = "EditorTexto";
            Text = "Editor de texto: Sin título";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem nuevoToolStripMenuItem;
        private ToolStripMenuItem abrirToolStripMenuItem;
        private ToolStripMenuItem abrirRecienteToolStripMenuItem;
        private OpenFileDialog openFileDialog;
        private ToolStripSeparator toolStripMenuSeparator2;
        private ToolStripMenuItem guardarToolStripMenuItem;
        private ToolStripMenuItem guardarComoToolStripMenuItem;
        private SaveFileDialog saveFileDialog;
        private ToolStripSeparator toolStripMenuSeparator3;
        private ToolStripMenuItem imprimirToolStripMenuItem;
        private PrintDialog printDialog;
        private System.Drawing.Printing.PrintDocument printDocument;
        private ToolStripSeparator toolStripMenuSeparator4;
        private ToolStripMenuItem cerrarToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolStripMenuItem editarToolStripMenuItem;
        private ToolStripMenuItem buscarToolStripMenuItem;
        private ToolStripMenuItem irAToolStripMenuItem;
        private ToolStripMenuItem inicioToolStripMenuItem;
        private ToolStripMenuItem lineaToolStripMenuItem;
        private ToolStripMenuItem finToolStripMenuItem;
        private ToolStripMenuItem reemplazarToolStripMenuItem;
        private ToolStripMenuItem formatoToolStripMenuItem;
        private ToolStripMenuItem fuenteToolStripMenuItem;
        private FontDialog fontDialog;
        private ToolStripSeparator toolStripMenuSeparator6;
        private ToolStripMenuItem mayusculasToolStripMenuItem;
        private ToolStripMenuItem minusculasToolStripMenuItem;
        private ToolStripMenuItem tituloToolStripMenuItem;
        private ToolStripMenuItem oracionToolStripMenuItem;
        private ToolStripMenuItem verToolStripMenuItem;
        private ToolStripMenuItem barraDeEstadoToolStripMenuItem;
        private ToolStripMenuItem ayudaToolStripMenuItem;
        private ToolStripMenuItem acercaDeToolStripMenuItem;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel posicionToolStripStatusLabel;
        private ToolStripStatusLabel lineasToolStripStatusLabel;
        private ToolStripStatusLabel palabrasToolStripStatusLabel;
        private ToolStripStatusLabel caracteresToolStripStatusLabel;
        private ToolStripStatusLabel codificacionToolStripStatusLabel;
        private RichTextBox richTextBox;
    }
}
