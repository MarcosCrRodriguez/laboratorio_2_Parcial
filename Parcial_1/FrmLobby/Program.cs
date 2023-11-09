namespace FrmLobby
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // probar tener como ultima "vida" de reviente de código con una try - catch

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            try
            {
                ApplicationConfiguration.Initialize();
                Application.Run(new FrmLobby());
            }
            catch (Exception)
            {

                MessageBox.Show("Ocurrio un error inesperado en el formulario", "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}