using System.Globalization;
using System.Text;
using EditorTextoSencillo.Modelo;
using EditorTextoSencillo.Vista;

namespace EditorTextoSencillo.Controlador
{
    /// <summary>
    /// Controlador que coordina las interacciones entre el modelo y la vista
    /// </summary>
    internal class EditorTextoControlador
    {
        private readonly EditorTextoModelo _modelo;
        private readonly IEditorTextoVista _vista;

        /// <summary>
        /// Constructor que inicializa el controlador con modelo y vista
        /// </summary>
        /// <param name="modelo">Instancia del modelo del editor de texto. No puede ser null</param>
        /// <param name="vista">Instancia de la vista del editor de texto que implementa <see cref="IEditorTextoVista"/>. No puede ser null</param>
        /// <exception cref="ArgumentNullException">Se produce cuando el modelo o la vista son null</exception>
        internal EditorTextoControlador(EditorTextoModelo modelo, IEditorTextoVista vista)
        {
            _modelo = modelo ?? throw new ArgumentNullException(nameof(modelo));
            _vista = vista ?? throw new ArgumentNullException(nameof(vista));

            SuscribirEventosVista();
            ActualizarVista();
        }

        /// <summary>
        /// Suscribe los eventos de la vista a los métodos del controlador
        /// </summary>
        private void SuscribirEventosVista()
        {
            // Eventos del menú Archivo
            _vista.ArchivoNuevoClick += OnArchivoNuevoClick;
            _vista.ArchivoAbrirClick += OnArchivoAbrirClick;
            _vista.ArchivoAbrirRecienteClick += OnArchivoAbrirRecienteClick;
            _vista.ArchivoQuitarRecienteClick += OnArchivoQuitarRecienteClick;
            _vista.ArchivoLimpiarRecientesClick += OnArchivoLimpiarRecientesClick;
            _vista.ArchivoGuardarClick += OnArchivoGuardarClick;
            _vista.ArchivoGuardarComoClick += OnArchivoGuardarComoClick;
            _vista.ArchivoCerrarClick += OnArchivoCerrarClick;
            _vista.ArchivoSalirClick += OnArchivoSalirClick;

            // Eventos del menú Editar
            _vista.EditarReemplazarClick += OnEditarReemplazarClick;

            // Eventos del menú Formato
            _vista.FormatoMayusculasClick += OnFormatoMayusculasClick;
            _vista.FormatoMinusculasClick += OnFormatoMinusculasClick;
            _vista.FormatoTituloClick += OnFormatoTituloClick;
            _vista.FormatoOracionClick += OnFormatoOracionClick;

            // Eventos del cuadro de texto
            _vista.TextoCambiado += OnTextoCambiado;

            // Evento de cierre de aplicación
            _vista.AplicacionCerrando += OnAplicacionCerrando;
        }

        /// <summary>
        /// Actualiza todos los elementos de la vista con el estado actual del modelo
        /// </summary>
        private void ActualizarVista()
        {
            _vista.EstablecerTituloVentana(_modelo.Modificado ?
                $"{_modelo.NombreArchivo}*" : _modelo.NombreArchivo);
            _vista.EstablecerTexto(_modelo.Contenido);
            _vista.ActualizarBarraDeEstado(
                _modelo.Lineas, _modelo.Palabras,
                _modelo.Caracteres,
                _modelo.Codificacion.EncodingName);
            _vista.ActualizarArchivosRecientes(_modelo.ArchivosRecientes);
        }

        // MANEJADORES DE EVENTOS - MENÚ ARCHIVO
        private void OnArchivoNuevoClick(object? sender, EventArgs e)
        {
            if (!ConfirmarGuardarCambios())
            {
                return;
            }

            _modelo.NuevoArchivo();
            ActualizarVista();
        }

        private void OnArchivoAbrirClick(object? sender, EventArgs e)
        {
            if (!ConfirmarGuardarCambios())
            {
                return;
            }

            string? ruta = _vista.AbrirArchivoDialogo();
            if (string.IsNullOrWhiteSpace(ruta))
            {
                return;
            }

            ProcesarAperturaArchivo(ruta);

        }

        private void OnArchivoAbrirRecienteClick(object? sender, string ruta)
        {
            if (!ConfirmarGuardarCambios())
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(ruta))
            {
                return;
            }

            ProcesarAperturaArchivo(ruta);
        }

        private void OnArchivoQuitarRecienteClick(object? sender, string ruta)
        {
            _modelo.EliminarArchivoReciente(ruta);
            _vista.ActualizarArchivosRecientes(_modelo.ArchivosRecientes);
        }

        private void OnArchivoLimpiarRecientesClick(object? sender, EventArgs e)
        {
            _modelo.LimpiarArchivosRecientes();
            _vista.ActualizarArchivosRecientes(_modelo.ArchivosRecientes);
        }

        private void OnArchivoGuardarClick(object? sender, EventArgs e)
        {
            GuardarArchivo();
        }

        private void OnArchivoGuardarComoClick(object? sender, EventArgs e)
        {
            GuardarArchivoComo();
        }

        private void OnArchivoCerrarClick(object? sender, EventArgs e)
        {
            if (!ConfirmarGuardarCambios())
            {
                return;
            }

            _modelo.NuevoArchivo();
            ActualizarVista();
        }

        private void OnArchivoSalirClick(object? sender, EventArgs e)
        {
            _vista.CerrarAplicacion();
        }

        // MANEJADORES DE EVENTOS - MENÚ EDITAR
        private void OnEditarReemplazarClick(object? sender, EventArgs e)
        {
            (string? textoBuscar, string? textoReemplazar, DialogResult reemplazar) = _vista.ReemplazarDialogo();

            if (string.IsNullOrEmpty(textoBuscar) || reemplazar == DialogResult.Cancel)
            {
                return;
            }

            int reemplazos = 0;

            switch (reemplazar)
            {
                case DialogResult.OK:
                    reemplazos = _vista.ReemplazarTodo(textoBuscar, textoReemplazar);
                    _vista.MostrarMensaje(reemplazos > 0
                        ? $"Se han reemplazado {reemplazos} coincidencias."
                        : "No se han encontrado coincidencias");
                    break;
                case DialogResult.None:
                default:
                    return;
            }
        }

        // MANEJADORES DE EVENTOS - MENÚ FORMATO
        private void OnFormatoMayusculasClick(object? sender, EventArgs e)
        {
            AplicarFormatoTexto(texto => texto.ToUpper());
        }

        private void OnFormatoMinusculasClick(object? sender, EventArgs e)
        {
            AplicarFormatoTexto(texto => texto.ToLower());
        }

        private void OnFormatoTituloClick(object? sender, EventArgs e)
        {
            AplicarFormatoTexto(FormatoTitulo);
        }

        private void OnFormatoOracionClick(object? sender, EventArgs e)
        {
            AplicarFormatoTexto(FormatoOracion);
        }

        // MÉTODOS DEL CUADRO DE TEXTO
        private void OnTextoCambiado(object? sender, EventArgs e)
        {
            _modelo.Contenido = _vista.ObtenerTexto();
            _vista.EstablecerTituloVentana(_modelo.Modificado ?
                $"{_modelo.NombreArchivo}*" : _modelo.NombreArchivo);
            _vista.ActualizarBarraDeEstado(
                _modelo.Lineas,
                _modelo.Palabras,
                _modelo.Caracteres,
                _modelo.Codificacion.EncodingName);
        }

        // MÉTODO DE CIERRE DE LA APLICACIÓN
        private void OnAplicacionCerrando(object? sender, FormClosingEventArgs e)
        {
            if (!ConfirmarGuardarCambios())
            {
                e.Cancel = true;
            }
        }

        // MÉTODOS PRIVADOS - AUXILIARES
        /// <summary>
        /// Confirma si se deben guardar los cambios antes de continuar
        /// </summary>
        /// <returns>True si se puede continuar, False si se debe cancelar</returns>
        private bool ConfirmarGuardarCambios()
        {
            if (!_modelo.Modificado)
            {
                return true;
            }

            DialogResult guardarCambios = _vista.GuardarCambiosDialogo();

            switch (guardarCambios)
            {
                case DialogResult.Yes:
                    return GuardarArchivo();
                case DialogResult.No:
                    return true;
                case DialogResult.Cancel:
                default:
                    return false;
            }
        }

        /// <summary>
        /// Procesa la apertura de un archivo con manejo de errores
        /// </summary>
        /// <param name="ruta">Ruta del archivo a abrir</param>
        private void ProcesarAperturaArchivo(string ruta)
        {
            if (_modelo.AbrirArchivo(ruta))
            {
                ActualizarVista();
            }
            else
            {
                _vista.MostrarError($"No se pudo abrir el archivo: {ruta}");
                _modelo.EliminarArchivoReciente(ruta);
                _vista.ActualizarArchivosRecientes(_modelo.ArchivosRecientes);
            }
        }

        /// <summary>
        /// Aplica formato al texto seleccionado
        /// </summary>
        /// <param name="formateador">Función que aplica el formato</param>
        private void AplicarFormatoTexto(Func<string, string> formateador)
        {
            string texto = _vista.ObtenerTextoSeleccionado();
            if (!string.IsNullOrWhiteSpace(texto))
            {
                _vista.Reemplazar(formateador(texto));
            }
        }

        /// <summary>
        /// Guarda el archivo actual
        /// </summary>
        /// <returns>True si se guardó correctamente, False en caso contrario</returns>
        private bool GuardarArchivo()
        {
            if (string.IsNullOrWhiteSpace(_modelo.RutaArchivo))
            {
                return GuardarArchivoComo();
            }

            if (_modelo.GuardarArchivo())
            {
                ActualizarVista();
                return true;
            }
            else
            {
                _vista.MostrarError("No se pudo guardar el archivo.");
                return false;
            }
        }

        /// <summary>
        /// Guarda el archivo con un nombre nuevo
        /// </summary>
        /// <returns>True si se guardó correctamente, False en caso contrario</returns>
        private bool GuardarArchivoComo()
        {
            string? ruta = _vista.GuardarComoDialogo();
            if (string.IsNullOrWhiteSpace(ruta))
            {
                return false;
            }

            if (_modelo.GuardarArchivo(ruta))
            {
                ActualizarVista();
                return true;
            }
            else
            {
                _vista.MostrarError("No se pudo guardar el archivo.");
                return false;
            }
        }

        // MÉTODOS DE FORMATEO DE TEXTO
        /// <summary>
        /// Convierte texto a formato título (primera letra de cada palabra en mayúscula)
        /// </summary>
        /// <param name="texto">Texto a formatear</param>
        /// <returns>Texto formateado</returns>
        private string FormatoTitulo(string texto)
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(texto.ToLower());
        }

        /// <summary>
        /// Convierte texto a formato oración (primera letra de cada oración en mayúscula)
        /// </summary>
        /// <param name="texto">Texto a formatear</param>
        /// <returns>Texto formateado</returns>
        private string FormatoOracion(string texto)
        {
            StringBuilder resultado = new StringBuilder();
            bool nuevaOracion = true;

            for (int i = 0; i < texto.Length; i++)
            {
                char caracterActual = texto[i];

                if (nuevaOracion && char.IsLetter(caracterActual))
                {
                    resultado.Append(char.ToUpper(caracterActual));
                    nuevaOracion = false;
                }
                else
                {
                    resultado.Append(char.ToLower(caracterActual));
                }

                if (caracterActual == '.' || caracterActual == '!' || caracterActual == '?')
                {
                    nuevaOracion = true;

                    if (i + 1 < texto.Length && texto[i + 1] == ' ')
                    {
                        resultado.Append(' ');
                        i++;
                    }
                }
            }

            return resultado.ToString();
        }
    }
}