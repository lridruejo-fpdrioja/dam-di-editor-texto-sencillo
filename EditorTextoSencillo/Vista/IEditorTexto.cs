using System.Text;

namespace EditorTextoSencillo.Vista
{
    /// <summary>
    /// Interfaz que define el contrato para la vista del editor de texto
    /// </summary>
    internal interface IEditorTextoVista
    {

        // MANEJADORES DE EVENTOS
        // Eventos del menú Archivo
        event EventHandler ArchivoNuevoClick;
        event EventHandler ArchivoAbrirClick;
        event EventHandler<string> ArchivoAbrirRecienteClick;
        event EventHandler<string> ArchivoQuitarRecienteClick;
        event EventHandler ArchivoLimpiarRecientesClick;
        event EventHandler ArchivoGuardarClick;
        event EventHandler ArchivoGuardarComoClick;
        event EventHandler ArchivoCerrarClick;
        event EventHandler ArchivoSalirClick;

        // Eventos del menú Editar
        event EventHandler EditarReemplazarClick;

        // Eventos del menú Formato
        event EventHandler FormatoMayusculasClick;
        event EventHandler FormatoMinusculasClick;
        event EventHandler FormatoTituloClick;
        event EventHandler FormatoOracionClick;

        // Eventos del cuadro de texto
        event EventHandler TextoCambiado;

        // Evento de cierre de aplicación
        event EventHandler<FormClosingEventArgs> AplicacionCerrando;


        // MÉTODOS PARA OBTENER DATOS DE LA VISTA Y MODIFICARLA
        void EstablecerTituloVentana(string texto);
        string ObtenerTexto();
        string ObtenerTextoSeleccionado();
        void EstablecerTexto(string texto);
        void ActualizarBarraDeEstado(int lineas, int palabras, int caracteres, string codificacion);
        void ActualizarArchivosRecientes(IReadOnlyList<string> archivosRecientes);
        void Reemplazar(string texto);
        int ReemplazarSiguiente(string textoBuscar, string? textoReemplazar);
        int ReemplazarTodo(string textoBuscar, string? textoReemplazar);

        // MÉTODOS PARA DIÁLOGOS
        string? AbrirArchivoDialogo();
        DialogResult GuardarCambiosDialogo();
        string? GuardarComoDialogo();
        (string?, string?, DialogResult) ReemplazarDialogo();

        // MÉTODOS PARA MOSTRAR MENSAJES Y ERRORES
        void MostrarMensaje(string mensaje);
        void MostrarError(string error);

        // MÉTODOS DE COMPORTAMIENTO DE LA APLICACIÓN
        void CerrarAplicacion();
    }
}
