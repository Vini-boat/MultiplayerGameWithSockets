namespace Client
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            NetworkClient networkClient = new NetworkClient();

            ApplicationConfiguration.Initialize();
            var loginform = new Login(networkClient);
            if (loginform.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new ChatForm(networkClient));

            }
        }
    }
}