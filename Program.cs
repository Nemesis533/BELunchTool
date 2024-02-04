using CommonWinForms.CommonForms;
using Common_WinfForm;
using CommonWinForms;

namespace BELunchTool
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
            main_form main_Form = new main_form();
            Application.Run(main_Form);


        }
    }
}