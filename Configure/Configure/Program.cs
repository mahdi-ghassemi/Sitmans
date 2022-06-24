using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Configure
{
    static class Program
    {
        private static string RtoL;
        private static string LanguageCode;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                #region

                if (File.Exists(Environment.CurrentDirectory + "\\Interop.TINYLib.dll"))
                {
                    if (File.Exists(Environment.CurrentDirectory + "\\Acpm.dll"))
                    {

                        if (File.Exists(Environment.CurrentDirectory + "\\EditAgent.dll"))
                        {
                            LocalData ld = new LocalData();
                            RtoL = ld.Decrypt(ld.GetDataFromDll("Setting", "RightToLeft", "ID = 1"), true, "");
                            LanguageCode = ld.Decrypt(ld.GetDataFromDll("Setting", "LanguageCode", "ID = 1"), true, "");
                            if (RtoL == "1")
                            {
                                Application.EnableVisualStyles();
                                Application.SetCompatibleTextRenderingDefault(false);
                                Application.Run(new frmLogin_RtoL(LanguageCode));

                            }
                            else if (RtoL == "0")
                            {
                                Application.EnableVisualStyles();
                                Application.SetCompatibleTextRenderingDefault(false);
                                Application.Run(new frmLogin_LtoR(LanguageCode));
                            }

                        }
                        else
                        {
                            MessageBox.Show("File EditAgent.dll Not Found.", "Dll Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.Exit();
                        }
                    }
                    else
                    {
                        MessageBox.Show("File Acpm.dll Not Found.", "Dll Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                }
                else
                {
                    MessageBox.Show("File Interop.TINYLib.dll Not Found.", "Dll Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if(ex.InnerException!=null)
                MessageBox.Show(ex.InnerException.Message);
            }
        }
    }
}
