using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NominaTCG
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            Application.Run(new frmMain());
        }       

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {            
            Logger.ErrorLog.ErrorRoutine(false, e.Exception);
            MessageBox.Show(e.Exception.Message,"Acción Fallida",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
    }
}
