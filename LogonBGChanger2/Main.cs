using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace LogonBGChanger2 {
    partial class Main: Form {
        private static RegistryKey BaseKey;
        private const string BGREGKEY = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Authentication\LogonUI\Background";
        private const string BGPATH = @"C:\Windows\System32\oobe\info\backgrounds\";
        private const string BGFILE = BGPATH + "backgroundDefault.jpg";
        private const string BGBACKUP = BGFILE + ".bak";
        private static Dictionary<string, string> ErrReasons = new Dictionary<string, string>();

        public Main() {
            InitializeComponent();
            this.Init();
        }
        #region Error handling
        private static void SetErrorReasons() {
            ErrReasons["ArgumentNullException"] = "because it has a null argument.";
            ErrReasons["ArgumentException"] = "because it has a badly formed argument.";
            ErrReasons["DirectoryNotFoundException"] = "beacuse it cannot find a directory.";
            ErrReasons["FileNotFoundException"] = "beacuse it cannot find the file.";
            ErrReasons["IOException"] = "because it has encountered an error.";
            ErrReasons["NotSupportedException"] = "because it has encountered an error.";
            ErrReasons["PathTooLongException"] = "as the file name is too long for the system to handle.";
            ErrReasons["SecurityException"] = "because it has encountered a security-related error.";
            ErrReasons["UnauthorizedAccessException"] = "because it does not have sufficient security clearance.";
            ErrReasons["Exception"] = "because it has encountered an error.";
        }
        private static void ShowError(string operation, string errorType) {
            string reason = ErrReasons["Exception"];
            if (ErrReasons.ContainsKey(errorType)) reason = ErrReasons[errorType];
            MessageBox.Show("The program "+operation+" "+reason, errorType+" - LogonBGChanger", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion
        private static void SetBaseKey() {
            string ooe = "cannot connect to the registry";
            try {
                if (Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE") == "AMD64")
                    BaseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                else BaseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
                #region Error handling
            } catch (Exception e) {
                ShowError(ooe, e.GetType().Name); 
                Application.Exit();
                #endregion
            } 
        }
        private static int GetRegValue() {
            RegistryKey subKey = null;
            string ooe = "cannot access the registry";
            int value = -1;

            try {
                subKey = BaseKey.OpenSubKey(BGREGKEY);
                #region Error handling
            } catch (Exception e) {
                ShowError(ooe, e.GetType().Name); 
                Application.Exit();
                #endregion
            }

            try {
                value = (int)subKey.GetValue("OEMBackground");
                #region Error handling
            } catch (Exception e) {
                ShowError(ooe, e.GetType().Name); 
                Application.Exit();
                #endregion
            }
            return value;
        }
        private void SetRegValue(int value) {
            RegistryKey subKey = null;
            string ooe = "cannot modify the registry";

            try {
                subKey = BaseKey.CreateSubKey(BGREGKEY);
                #region Error handling
            } catch (Exception e) {
                ShowError(ooe, e.GetType().Name);
                return;
                #endregion
            }
            try {
                subKey.SetValue("OEMBackground", value);
                #region Error handling
            } catch (Exception e) {
                ShowError(ooe, e.GetType().Name);
                return;
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
        private void PreviewBackground(string fileName) {
            FileInfo fileInfo = null;
            string ooe = "cannot read the current file";
            try {
                fileInfo = new FileInfo(fileName);
                #region Error handling
            } catch (Exception e) {
                ShowError(ooe, e.GetType().Name);
                return;
                #endregion
            }

            if (fileInfo.Length > 256000) {
                MessageBox.Show("The current image is larger than 256 KB. Please select another JPG file.", "LogonBGChanger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } else if (fileInfo.Extension.ToLower() != ".jpg" && fileInfo.Extension.ToLower() != ".jpeg") {
                MessageBox.Show("The current image is not a JPG file. Please select a valid file.", "LogonBGChanger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MissingLabel.Hide();
            BGBox.ImageLocation = fileName;
        }
        private void ResetPreview() {
            MissingLabel.Show();
            BGBox.ImageLocation = "";
        }
        private static void BackupBG() {
            string ooe = "cannot backup the current background";
            try {
                if (File.Exists(BGBACKUP)) File.Delete(BGBACKUP);
                #region Error handling
            } catch (Exception e) {
                ShowError(ooe, e.GetType().Name);
                Application.Exit();
                #endregion
            }
            try {
                File.Copy(BGFILE, BGBACKUP);
                #region Error handling
            } catch (Exception e) {
                ShowError(ooe, e.GetType().Name);
                Application.Exit();
                #endregion
            }
        }
        private static void RestoreBG() {
            if (!File.Exists(BGBACKUP)) return;
            string ooe = "cannot replace the backup file";
            try {
                if (File.Exists(BGFILE)) File.Delete(BGFILE);
                #region Error handling
            } catch (Exception e) {
                ShowError(ooe, e.GetType().Name);
                Application.Exit();
                #endregion
            }
            ooe = "cannot restore the background";
            try {
                File.Copy(BGBACKUP, BGFILE);
                #region Error handling
            } catch (Exception e) { 
                ShowError(ooe, e.GetType().Name);
                Application.Exit();
                #endregion
            }
            MessageBox.Show("The background has been restored successfully.", "LogonBGChanger", MessageBoxButtons.OK);
        }
        private void UseBackground(string fileName) {
            string ooe = "cannot use the current file";
            FileInfo fileInfo = null;
            try {
                fileInfo = new FileInfo(fileName);
                #region Error handling
            } catch (Exception e) { 
                ShowError(ooe, e.GetType().Name);
                #endregion
            }

            if (fileInfo.Length > 256000) {
                MessageBox.Show("The current image is larger than 256 KB. Please select another JPG file.", "LogonBGChanger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } else if (fileInfo.Extension.ToLower() != ".jpg" && fileInfo.Extension.ToLower() != ".jpeg") {
                MessageBox.Show("The current image is not a JPG file. Please select a valid file.", "LogonBGChanger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } else if (fileName == BGFILE) {
                MessageBox.Show("The selected background is already the logon background. Please select another file.", "LogonBGChanger", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ooe = "cannot replace the currrent background";
            try {
                if (File.Exists(BGFILE)) File.Delete(BGFILE);
                #region Error handling
            } catch (Exception e) {
                ShowError(ooe, e.GetType().Name);
                return;
                #endregion
            }
            try {
                File.Copy(fileName, BGFILE);
                #region Error handling
            } catch (Exception e) {
                ShowError(ooe, e.GetType().Name);
                return;
                #endregion
            }
            MessageBox.Show("The background has been replaced successfully. File "+fileInfo.Name+" is now the logon background.", "LogonBGChanger", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void Init() {
            SetErrorReasons();
            SetBaseKey();
            RegToggle.Checked = GetRegValue() == 1;
            if (File.Exists(BGFILE)) BackupBG();
            if (File.Exists(BGFILE)) PreviewBackground(BGFILE);
            else ResetPreview();
        }
        // ================
        //  Event handlers 
        // ================
        private void RegToggle_Clicked(object sender, EventArgs e) {
            SetRegValue(RegToggle.Checked ? 1 : 0);
            RegToggle.Checked = GetRegValue() == 1;
        }
        private void BrowseButton_Click(object sender, EventArgs e) {
            if (BGDialog.ShowDialog() == DialogResult.OK)
                PreviewBackground(BGDialog.FileName);
        }
        private void UseButton_Click(object sender, EventArgs e) {
            UseBackground(BGBox.ImageLocation);
        }
        private void OKButton_Click(object sender, EventArgs e) {
            Application.Exit();
        }
        private void AboutButton_Click(object sender, EventArgs e) {
            new About().ShowDialog();
        }
        private void ResetButton_Click(object sender, EventArgs e) {
            PreviewBackground(BGFILE);
        }
        private void RevertButton_Click(object sender, EventArgs e) {
            RestoreBG();
            PreviewBackground(BGFILE);
        }
    }
}
