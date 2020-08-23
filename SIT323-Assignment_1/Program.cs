using System;
using System.Windows.Forms;

namespace SIT323_Assignment
{
    public static class Program
    {
        public static TaskHome AllocationForm;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AllocationForm = new TaskHome();
            Application.Run(AllocationForm);
        }
    }
}
