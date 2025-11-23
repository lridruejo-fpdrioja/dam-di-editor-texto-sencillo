using EditorTextoSencillo;
using EditorTextoSencillo.Controlador;
using EditorTextoSencillo.Modelo;
using EditorTextoSencillo.Vista;

namespace EditorTextoSencillo
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Crear las instancias del modelo, la vista y el controlador.
            var modelo = new EditorTextoModelo();
            var vista = new EditorTexto();
            var controlador = new EditorTextoControlador(modelo, vista);


            Application.Run(vista);
        }
    }
}