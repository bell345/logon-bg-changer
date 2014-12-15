using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace LogonBGChanger2 {
    public partial class Main: Form {

        private static RegistryKey BaseKey;
        private const string BGREGKEY = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Authentication\LogonUI\Background";

        public Main() {
            InitializeComponent();
            this.Init();
        }
        private static void SetBaseKey() {
            try {
                if (Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE") == "AMD64")
                    BaseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                else BaseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
                #region Error handling
            } catch (System.Security.SecurityException) {
                MessageBox.Show("The application cannot connect to the registry, as it does not have proper security clearance to access it.", "SecurityException - LogonBGChanger", MessageBoxButtons.OK, MessageBoxIcon.Error); Application.Exit();
            } catch (ArgumentException) {
                MessageBox.Show("The application cannot connect to the registry, as our values are invalid.", "ArgumentException - LogonBGChanger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            } catch (UnauthorizedAccessException) {
                MessageBox.Show("The application cannot connect to the registry, as it does not have proper security clearance to access it.", "UnauthorizedAccessException - LogonBGChanger", MessageBoxButtons.OK, MessageBoxIcon.Error); Application.Exit();
                #endregion
            } 
        }
        private static int GetRegValue() {
            RegistryKey subKey = null;
            int value = -1;
            try {
                subKey = BaseKey.OpenSubKey(BGREGKEY);
                #region Error handling
            } catch (ArgumentNullException) {
                MessageBox.Show("The application cannot connect to the registry, as our key is invalid. You might not have proper permissions or the system is 32-bit (not tested).", "ArgumentNullException - LogonBGChanger", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                Application.Exit(); 
            } catch (System.Security.SecurityException) {
                MessageBox.Show("The application cannot connect to the registry, as it does not have proper security clearance to access it.", "SecurityException - LogonBGChanger", MessageBoxButtons.OK, MessageBoxIcon.Error); Application.Exit(); 
            } catch (Exception) {
                MessageBox.Show("An error has prevented the program from accessing the registry.", "Exception - LogonBGChanger", MessageBoxButtons.OK, MessageBoxIcon.Error); Application.Exit();
                #endregion
            }
            try {
                value = (int)subKey.GetValue("OEMBackground");
                #region Error handling
            } catch (System.IO.IOException) {
                MessageBox.Show("An error has prevented the program from accessing the registry.", "IOException - LogonBGChanger", MessageBoxButtons.OK, MessageBoxIcon.Error); Application.Exit();
            } catch (System.Security.SecurityException) {
                MessageBox.Show("The application cannot connect to the registry, as it does not have proper security clearance to access it.", "SecurityException - LogonBGChanger", MessageBoxButtons.OK, MessageBoxIcon.Error); Application.Exit();
            } catch (UnauthorizedAccessException) {
                MessageBox.Show("The application cannot connect to the registry, as it does not have proper security clearance to access it.", "UnauthorizedAccessException - LogonBGChanger", MessageBoxButtons.OK, MessageBoxIcon.Error); Application.Exit();
            } catch (Exception) {
                MessageBox.Show("An error has prevented the program from accessing the registry.", "Exception - LogonBGChanger", MessageBoxButtons.OK, MessageBoxIcon.Error); Application.Exit();
                #endregion
            }
            return value;
        }
        private void SetRegValue(int value) {
            RegistryKey subKey = null;
            try {
                subKey = BaseKey.CreateSubKey(BGREGKEY);
                #region Error handling
            } catch (ArgumentNullException) {
                MessageBox.Show("The application cannot connect to the registry, as our key is invalid. You might not have proper permissions or the system is 32-bit (not tested).", "ArgumentNullException - LogonBGChanger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit(); 
            } catch (System.Security.SecurityException) {
                MessageBox.Show("The application cannot connect to the registry, as it does not have proper security clearance to access it.", "SecurityException - LogonBGChanger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit(); 
            } catch (UnauthorizedAccessException) {
                MessageBox.Show("The application cannot connect to the registry, as it does not have proper security clearance to access it.", "UnauthorizedAccessException - LogonBGChanger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            } catch (System.IO.IOException) {
                MessageBox.Show("An error has prevented the program from accessing the registry.", "IOException - LogonBGChanger", MessageBoxButtons.OK, MessageBoxIcon.Error); Application.Exit();
            } catch (Exception) {
                MessageBox.Show("An error has prevented the program from accessing the registry.", "Exception - LogonBGChanger", MessageBoxButtons.OK, MessageBoxIcon.Error); Application.Exit();
                #endregion
            }
            try {
                subKey.SetValue("OEMBackground", value);
                #region Error handling
            } catch (ArgumentNullException) {
                MessageBox.Show("The application cannot edit the registry, as our key is invalid. You might not have proper permissions or the system is 32-bit (not tested).", "ArgumentNullException - LogonBGChanger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            } catch (ArgumentException) {
                MessageBox.Show("The application cannot connect to the registry, as our values are invalid.", "ArgumentException - LogonBGChanger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            } catch (System.Security.SecurityException) {
                MessageBox.Show("The application cannot edit the registry, as it does not have proper security clearance to access it.", "SecurityException - LogonBGChanger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            } catch (UnauthorizedAccessException) {
                MessageBox.Show("The application cannot edit the registry, as it does not have proper security clearance to access it.", "UnauthorizedAccessException - LogonBGChanger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            } catch (System.IO.IOException) {
                MessageBox.Show("An error has prevented the program from accessing the registry.", "IOException - LogonBGChanger", MessageBoxButtons.OK, MessageBoxIcon.Error); Application.Exit();
            } catch (Exception) {
                MessageBox.Show("An error has prevented the program from accessing the registry.", "Exception - LogonBGChanger", MessageBoxButtons.OK, MessageBoxIcon.Error); Application.Exit();
                #endregion
            }
            value = GetRegValue();
            if (value == 1) {
                Step2Box.Show();
                MessageBox.Show("The system will now accept custom logon backgrounds (value set to "+value+").", "LogonBGChanger", MessageBoxButtons.OK);
            } else {
                Step2Box.Hide();
                MessageBox.Show("The system will no longer accept custom logon backgrounds (value set to " + value + ").", "LogonBGChanger", MessageBoxButtons.OK);
            }
        }
        public void Init() {
            SetBaseKey();
            if (GetRegValue() == 1) RegToggle.Checked = true;
            else RegToggle.Checked = false;
        }

        private void RegToggle_Clicked(object sender, EventArgs e) {
            SetRegValue(RegToggle.Checked?1:0);
        }
    }
}
