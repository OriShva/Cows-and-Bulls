﻿namespace CowsAndBulls
{
using System;
using System.Windows.Forms;
static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new EntryForm());
        }
    }
}
