namespace LearnMate
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
            Application.Run(new frmLoginScreen());

            //ToDo 27/09/22: Create each different subform [735,398] (e.g. time organiser, manage classes etc.) like homepage is. Remember this is a SUBFORM so you only need to
            //make the relevant images and controls. don't implement them yet, as their use depends on the database. Once they are created, work on creating 
            //json file with NewtonSoft. watch tutorials. then implement
            //dont forget to document.
        }
    }
}