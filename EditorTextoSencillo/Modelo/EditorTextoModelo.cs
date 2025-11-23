using System.Text;

namespace EditorTextoSencillo.Modelo
{
    /// <summary>
    /// Modelo que representa el estado y la lógica de negocio del editor de texto
    /// </summary>
    internal class EditorTextoModelo
    {
        // CONSTANTES PRIVADAS
        private const int MAX_ARCHIVOS_RECIENTES = 10;
        private const string NOMBRE_ARCHIVO_PREDETERMINADO = "Sin título";
        private const string RUTA_VACIA = "";

        // CAMPOS PRIVADOS
        // Campos del archivo de texto
        private string _rutaArchivo = RUTA_VACIA;
        private string _nombreArchivo = NOMBRE_ARCHIVO_PREDETERMINADO;
        private Encoding _codificacion = Encoding.UTF8;
        private string _contenido = String.Empty;
        private bool _modificado;

        // Campo para el historial de archivos
        private readonly List<string> _archivosRecientes;

        /// <summary>
        /// Constructor que inicializa el modelo con un nuevo archivo
        /// </summary>
        internal EditorTextoModelo()
        {
            NuevoArchivo();
            _archivosRecientes = new List<string>();
        }

        // PROPIEDADES INTERNAS
        internal string RutaArchivo
        {
            get => _rutaArchivo;
            set => _rutaArchivo = value ?? string.Empty;
        }

        internal string NombreArchivo
        {
            get => _nombreArchivo;
            set => _nombreArchivo = !string.IsNullOrWhiteSpace(value) ? value : NOMBRE_ARCHIVO_PREDETERMINADO;
        }

        internal Encoding Codificacion
        {
            get => _codificacion;
            set => _codificacion = value ?? Encoding.UTF8;
        }

        internal string Contenido
        {
            get => _contenido;
            set
            {
                string nuevoContenido = value ?? string.Empty;
                // Comprobación para evitar bucle infinito al actualizar la vista
                if (_contenido != nuevoContenido)
                {
                    _contenido = nuevoContenido;
                    Modificado = true;
                }
            }
        }

        internal bool Modificado
        {
            get => _modificado;
            set => _modificado = value;
        }

        internal IReadOnlyList<string> ArchivosRecientes => _archivosRecientes.AsReadOnly();

        // PROPIEDADES CALCULADAS
        internal int Lineas
        {
            get
            {
                if (string.IsNullOrEmpty(Contenido))
                    return 1;

                return Contenido.Count(c => c == '\n') + 1; // Siempre hay al menos una línea
            }
        }

        internal int Palabras
        {
            get
            {
                if (string.IsNullOrEmpty(Contenido))
                    return 0;

                int palabras = 0;
                bool enPalabra = false;

                foreach (char c in Contenido)
                {
                    if (char.IsWhiteSpace(c))
                    {
                        enPalabra = false;
                    }
                    else if (!enPalabra)
                    {
                        palabras++;
                        enPalabra = true;
                    }
                }

                return palabras;
            }
        }

        internal int Caracteres => Contenido.Length;

        // MÉTODOS INTERNOS - GESTIÓN DE ARCHIVOS
        /// <summary>
        /// Crea un nuevo archivo vacío
        /// </summary>
        internal void NuevoArchivo()
        {
            RutaArchivo = RUTA_VACIA;
            NombreArchivo = NOMBRE_ARCHIVO_PREDETERMINADO;
            Codificacion = Encoding.UTF8;
            Contenido = string.Empty;
            Modificado = false;
        }

        /// <summary>
        /// Abre un archivo desde la ruta especificada
        /// </summary>
        /// <param name="ruta">Ruta del archivo a abrir</param>
        /// <returns>True si se abrió correctamente, False en caso contrario</returns>
        internal bool AbrirArchivo(string ruta)
        {
            try
            {
                if (!File.Exists(ruta))
                {
                    return false;
                }

                RutaArchivo = ruta;
                NombreArchivo = Path.GetFileName(RutaArchivo);
                Codificacion = DetectarCodificacion(RutaArchivo);
                Contenido = File.ReadAllText(ruta, Codificacion);
                Modificado = false;

                AgregarArchivoReciente(ruta);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Guarda el archivo actual en su ubicación original
        /// </summary>
        /// <returns>True si se guardó correctamente, False en caso contrario</returns>
        internal bool GuardarArchivo()
        {
            if (string.IsNullOrEmpty(RutaArchivo))
            {
                return false;
            }
            return GuardarArchivo(RutaArchivo);
        }

        /// <summary>
        /// Guarda el archivo actual en la ruta especificada
        /// </summary>
        /// <param name="ruta">Ruta donde guardar el archivo</param>
        /// <returns>True si se guardó correctamente, False en caso contrario</returns>
        internal bool GuardarArchivo(string ruta)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ruta))
                {
                    return false;
                }

                File.WriteAllText(ruta, Contenido, Codificacion);

                RutaArchivo = ruta;
                NombreArchivo = Path.GetFileName(ruta);
                Modificado = false;

                AgregarArchivoReciente(ruta);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // MÉTODOS INTERNOS - GESTIÓN DE ARCHIVOS RECIENTES
        /// <summary>
        /// Elimina un archivo de la lista de recientes
        /// </summary>
        /// <param name="ruta">Ruta del archivo a eliminar</param>
        internal void EliminarArchivoReciente(string ruta)
        {
            if (!string.IsNullOrWhiteSpace(ruta))
            {
                _archivosRecientes.Remove(ruta);
            }
        }

        /// <summary>
        /// Limpia toda la lista de archivos recientes
        /// </summary>
        internal void LimpiarArchivosRecientes()
        {
            _archivosRecientes.Clear();
        }

        // MÉTODOS PRIVADOS - AUXILIARES
        /// <summary>
        /// Detecta la codificación de un archivo
        /// </summary>
        /// <param name="ruta">Ruta del archivo</param>
        /// <returns>Encoding detectado o UTF-8 por defecto</returns>
        private Encoding DetectarCodificacion(string ruta)
        {
            try
            {
                using (StreamReader sr = new StreamReader(ruta, detectEncodingFromByteOrderMarks: true))
                {
                    sr.Peek();
                    return sr.CurrentEncoding;
                }
            }
            catch
            {
                return Encoding.UTF8;
            }
        }

        /// <summary>
        /// Agrega un archivo a la lista de recientes
        /// </summary>
        /// <param name="ruta">Ruta del archivo a agregar</param>
        private void AgregarArchivoReciente(string ruta)
        {
            if (string.IsNullOrWhiteSpace(ruta) || !File.Exists(ruta))
            {
                return;
            }

            EliminarArchivoReciente(ruta); // Evitar duplicados
            _archivosRecientes.Insert(0, ruta); // El más reciente primero

            if (ArchivosRecientes.Count > MAX_ARCHIVOS_RECIENTES)
            {
                _archivosRecientes.RemoveAt(MAX_ARCHIVOS_RECIENTES);
            }
        }

    }
}
