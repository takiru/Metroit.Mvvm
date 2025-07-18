using Metroit.Mvvm.WinForms.Test;
using System;
using System.Windows.Forms;

namespace Test
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
            
            // TODO: アクティブウィンドウの把握で必要
            ActiveFormTracker.StartTracking();
            
            Application.Run(new Form1());
        }
    }
}