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
            login_form login_form_form = new login_form(main_Form);
            main_Form.P_User_Object = login_form_form.P_User_Object;

            Application.Run(login_form_form);


        }
    }
}