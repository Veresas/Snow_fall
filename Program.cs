using System;

namespace Snow_fall
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new ScreenSever())
            {
                game.Run();
            }
        }
    }
}
