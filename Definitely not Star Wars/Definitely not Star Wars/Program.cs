﻿using System;

namespace Definitely_not_Star_Wars
{
#if WINDOWS || LINUX
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
            using (var game = new GameManager())
                game.Run();
            
        }
    }
#endif
}
