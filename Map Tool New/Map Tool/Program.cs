using System;

namespace Map_Tool
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new Game1())
                game.Run();

                //Application.EnableVisualStyles();
                //game.SetCompatibleTextRenderingDefault(false);
                //game.Run(new Form1());

        }
    }
}
