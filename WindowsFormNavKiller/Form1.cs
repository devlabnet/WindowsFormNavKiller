﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace WindowsFormNavKiller
{
    public partial class Form1 : Form
    {
        private int fileDeleted;
        private int dirDeleted;
        String appDataLocalDir;
        String appDataDir;

        enum RecycleFlags : int
        {
            SHERB_NOCONFIRMATION = 0x00000001, // Don't ask for confirmation
            SHERB_NOPROGRESSUI = 0x00000001, // Don't show progress
            SHERB_NOSOUND = 0x00000004 // Don't make sound when the action is executed
        }

        [DllImport("Shell32.dll", CharSet = CharSet.Unicode)]
        static extern uint SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, RecycleFlags dwFlags);

        [DllImport("shell32.dll")]
        static extern int SHQueryRecycleBin(string pszRootPath, ref SHQUERYRBINFO pSHQueryRBInfo);

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public struct SHQUERYRBINFO
        {
            public int cbSize;
            public long i64Size;
            public long i64NumItems;
        }

        public Form1()
        {
            InitializeComponent();
            pictureBox.Focus();
            pictureBox.Select();
            Process[] proc = Process.GetProcessesByName("chrome");
            if (proc.Length > 0)
            {
                groupChrome.Enabled = true;
            }
            else
            {
                groupChrome.Enabled = false;
            }
            proc = Process.GetProcessesByName("firefox");
            if (proc.Length > 0)
            {
                groupFireFox.Enabled = true;
            }
            else
            {
                groupFireFox.Enabled = false;
            }
            proc = Process.GetProcessesByName("MicrosoftEdge");
            if (proc.Length > 0)
            {
                groupEdge.Enabled = true;
            }
            else
            {
                groupEdge.Enabled = false;
            }
            AppendText("------------------------------------------------------", Color.Blue);
            String UserName = Environment.UserName;
            AppendText(String.Format("UserName: {0}", UserName), Color.Blue);
            AppendText("------------------------------------------------------", Color.Blue);
            appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            AppendText(String.Format("appData: {0}", appDataDir), Color.Blue);
            appDataLocalDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            AppendText(String.Format("appData Local: {0}", appDataLocalDir), Color.Blue);
            AppendText("------------------------------------------------------", Color.Blue);
            int rbc = GetRecycleBinCount();
            AppendText(String.Format("Recycle Bin Count: {0}", rbc), Color.OrangeRed);
            AppendText("------------------------------------------------------", Color.Blue);
            if (rbc == 0)
            {
                recycleBinBox.Enabled = false;
            }
        }

        private static int GetRecycleBinCount()
        {
            SHQUERYRBINFO sqrbi = new SHQUERYRBINFO();
            sqrbi.cbSize = Marshal.SizeOf(typeof(SHQUERYRBINFO));
            int hresult = SHQueryRecycleBin(string.Empty, ref sqrbi);
            return (int)sqrbi.i64NumItems;
        }

        private void cleanChromePrefFile(String fileName)
        {
            AppendText("------------------------------------------------------", Color.Red);
            AppendText(String.Format("cleanChromePrefFile: {0}", fileName), Color.Red);
            string str = File.ReadAllText(fileName);
            str = str.Replace("exit_type\":\"Crashed", "exit_type\":\"None");
            File.WriteAllText(fileName, str);
            AppendText("------------------------------------------------------", Color.Red);
        }

        private void emptyRecycleBin()
        {
            if (recycleBinBox.Enabled) {
                if (emptyBin.Checked)
                {
                    DialogResult result;
                    result = MessageBox.Show("Are you sure to delete all items in recycle bin", "Empty Recycle bin", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            uint IsSuccess = SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlags.SHERB_NOCONFIRMATION);
                            MessageBox.Show("Empty the RecycleBin successsfully", "Empty the RecycleBin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            AppendText(String.Format("Empty Recycle Bin successsfully ... "), Color.Red);
                            AppendText("------------------------------------------------------", Color.Green);
                            recycleBinBox.Enabled = false;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Empty the RecycleBin failed" + ex.Message, "Empty the RecycleBin", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            AppendText(String.Format("Empty Recycle Bin failed ... "), Color.Red);
                            AppendText("------------------------------------------------------", Color.Green);
                            //Application.Exit();
                        }
                    }

                }
            }
        }

        private void killChrome_Click(object sender, EventArgs e)
        {
            Process[] proc = Process.GetProcessesByName("chrome");
            AppendText("------------------------------------------------------", Color.Green);
            AppendText("Kill Chrome Process...", Color.Green);
            foreach (Process theprocess in proc)
            {
                theprocess.Kill();
            }
            groupChrome.Enabled = false;
            if (clearChrome.Checked)
            {
                AppendText("Clearing Chrome Caches...", Color.Green);
                fileDeleted = 0;
                dirDeleted = 0;
                String UserName = Environment.UserName;
                //Remove - Item - path "C:\Users\$($_.Name)\AppData\Local\Google\Chrome\User Data\Default\Cache\*" - Recurse - Force - EA SilentlyContinue #-Verbose
                //String dirName = @"C:\Users\" + UserName + @"\AppData\Local\Google\Chrome\User Data\Default\Cache";
                String dirName = appDataLocalDir + @"\Google\Chrome\User Data\Default\Cache";
                DeleteDirectory(dirName);
                //Remove-Item - path "C:\Users\$($_.Name)\AppData\Local\Google\Chrome\User Data\Default\Cache2\entries\*" - Recurse - Force - EA SilentlyContinue #-Verbose
                //dirName = @"C:\Users\" + UserName + @"\AppData\Local\Google\Chrome\User Data\Default\Cache2\entries";
                dirName = appDataLocalDir + @"\Google\Chrome\User Data\Default\Cache2\entries";
                DeleteDirectory(dirName);
                //Remove-Item - path "C:\Users\$($_.Name)\AppData\Local\Google\Chrome\User Data\Default\Cookies" - Recurse - Force - EA SilentlyContinue #-Verbose
                //dirName = @"C:\Users\" + UserName + @"\AppData\Local\Google\Chrome\User Data\Default\Cookies";
                dirName = appDataLocalDir + @"\Google\Chrome\User Data\Default\Cookies";
                DeleteDirectory(dirName);
                //Remove-Item - path "C:\Users\$($_.Name)\AppData\Local\Google\Chrome\User Data\Default\Media Cache" - Recurse - Force - EA SilentlyContinue #-Verbose
                //dirName = @"C:\Users\" + UserName + @"\AppData\Local\Google\Chrome\User Data\Default\Media Cache";
                dirName = appDataLocalDir + @"\Google\Chrome\User Data\Default\Media Cache";
                DeleteDirectory(dirName);
                //Remove-Item - path "C:\Users\$($_.Name)\AppData\Local\Google\Chrome\User Data\Default\Cookies-Journal" - Recurse - Force - EA SilentlyContinue #-Verbose
                //dirName = @"C:\Users\" + UserName + @"\AppData\Local\Google\Chrome\User Data\Default\Cookies-Journal";
                dirName = appDataLocalDir + @"\Google\Chrome\User Data\Default\Cookies-Journal";
                DeleteDirectory(dirName);
                // Clear Session Restore Data
                AppendText("Clearing Chrome Session Data...", Color.Green);
                //cleanPrefFile - pref "C:\Users\$($_.Name)\AppData\Local\Google\Chrome\User Data\Default\Preferences"
                cleanChromePrefFile(appDataLocalDir + @"\Google\Chrome\User Data\Default\Preferences");
                AppendText(String.Format("Done, Files Deleted: {0}", fileDeleted), Color.Red);
                AppendText("------------------------------------------------------", Color.Green);
                emptyRecycleBin();
            }
        }

        private void killFireFox_Click(object sender, EventArgs e)
        {
            Process[] proc = Process.GetProcessesByName("firefox");
            AppendText("------------------------------------------------------", Color.Green);
            AppendText("Kill Mozilla Firefox Process...", Color.Green);
            foreach (Process theprocess in proc)
            {
                theprocess.Kill();
            }
            AppendText("------------------------------------------------------", Color.Green);
            groupFireFox.Enabled = false;
            if (clearFireFox.Checked)
            {
                fileDeleted = 0;
                dirDeleted = 0;
                // Clear History Data
                // Only get subdirectories that begin with the letter ".default"
//                string[] dirs = Directory.GetDirectories(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Mozilla\Firefox\Profiles\", "*.default*");
                string[] dirs = Directory.GetDirectories(appDataLocalDir + @"\Mozilla\Firefox\Profiles\", "*.default*");
                AppendText("Clearing Mozilla Firefox Caches...", Color.Green);
                String searchPattern = "cache*|thumbnails|cookies.sqlite|webappsstore.sqlite|chromeappsstore.sqlite";
                foreach (string dir in dirs)
                {
                    string[] searchPatterns = searchPattern.Split('|');
                    foreach (string pat in searchPatterns)
                    {
                        string[] subDirs = Directory.GetDirectories(dir, pat, SearchOption.AllDirectories);
                        foreach (string sub in subDirs)
                        {
                            DeleteDirectory(sub);
                        }
                    }
                }
                // Clear Session Restore Data
                AppendText("Clearing Mozilla Firefox Session Data...", Color.Green);
                //dirs = Directory.GetDirectories(@"C:\Users\" + Environment.UserName + @"\AppData\Roaming\Mozilla\Firefox\Profiles\", "*.default*");
                dirs = Directory.GetDirectories(appDataDir + @"\Mozilla\Firefox\Profiles\", "*.default*");
                foreach (string dir in dirs)
                {
                    string[] subDirs = Directory.GetDirectories(dir, "sessionstore-backups", SearchOption.AllDirectories);
                    foreach (string sub in subDirs)
                    {
                        DeleteDirectory(sub);
                    }
                }
                AppendText(String.Format("Done, Dirs Deleted: {0} , Files Deleted: {1}", dirDeleted, fileDeleted), Color.Red);
                AppendText("------------------------------------------------------", Color.Green);
                emptyRecycleBin();
            }
        }
        private void killEdge_Click(object sender, EventArgs e)
        {
            Process[] proc = Process.GetProcessesByName("MicrosoftEdge");
            AppendText("------------------------------------------------------", Color.Green);
            AppendText("Kill Microsoft Edge Process...", Color.Green);
            foreach (Process theprocess in proc)
            {
                theprocess.Kill();
            }
            AppendText("------------------------------------------------------", Color.Green);
            groupEdge.Enabled = false;
            if (clearEdge.Checked)
            {
                AppendText("Clearing Microsoft Edge Caches...", Color.Green);
                fileDeleted = 0;
                dirDeleted = 0;
                String UserName = Environment.UserName;
                //Remove - Item - path "C:\Users\$($_.Name)\AppData\Local\Microsoft\Windows\WER\*" - Recurse - Force - EA SilentlyContinue #-Verbose
                String dirName = appDataLocalDir + @"\Microsoft\Windows\WER";
                DeleteDirectory(dirName);
                //Remove-Item - path "C:\Users\$($_.Name)\AppData\Local\Temp\*" - Recurse - Force - EA SilentlyContinue #-Verbose
                dirName = appDataLocalDir + @"\Temp";
                DeleteDirectory(dirName);
                //Remove-Item - path "C:\Windows\Temp\*" - Recurse - Force - EA SilentlyContinue #-Verbose
                //dirName = @"C:\Windows\Temp";
                //DeleteDirectory(dirName);

                // Clear Session Restore Data
                AppendText("Clearing Microsoft Edge Session Data...", Color.Green);
                string[] theFiles = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.History), "*", SearchOption.AllDirectories);
                foreach (string file in theFiles)
                {
                    try
                    {
                        File.Delete(file);
                        AppendText("delete file: " + file, Color.CadetBlue);
                    }
                    catch (Exception)
                    {
                    }
                    fileDeleted++;
                }

                AppendText(String.Format("Done, Files Deleted: {0}", fileDeleted), Color.Red);
                AppendText("------------------------------------------------------", Color.Green);
            }
            emptyRecycleBin();
        }

        private void DeleteDirectory(string path)
        {
            //AppendText("delete dir: "+path, Color.BlueViolet);
            if (Directory.Exists(path))
            {
                //AppendText("ok delete dir: " + path, Color.Blue);
                //Delete all files from the Directory
                foreach (string file in Directory.GetFiles(path))
                {
                    try
                    {
                        File.Delete(file);
                        AppendText("delete file: " + file, Color.CadetBlue);
                   }
                    catch (Exception)
                    {
                    }
                    fileDeleted++;
                }
                //Delete all child Directories
                foreach (string directory in Directory.GetDirectories(path))
                {
                    try
                    {
                        DeleteDirectory(directory);

                    }
                    catch (Exception)
                    {
                    }
                }
                Thread.Sleep(1); // This makes the difference between whether it works or not. Sleep(0) is not enough.
                try
                {
                    Directory.Delete(path);
                    AppendText("delete directory: " + path, Color.Violet);
                }
                catch (Exception)
                {
                }
                dirDeleted++;
            }
        }

        // Append text of the given color.
        private void AppendText(string text, Color color, bool newLine = true)
        {
            int start = textBox.TextLength;
            textBox.AppendText(text);
            if (newLine) textBox.AppendText(Environment.NewLine);
            int end = textBox.TextLength;
            // TextBox may transform chars, so (end-start) != text.Length
            textBox.Select(start, end-start);
            {
                textBox.SelectionColor = color;
            }
            textBox.SelectionLength = 0; // clear
        }

        private void textBox_DoubleClick(object sender, EventArgs e)
        {
            textBox.Clear();
            AppendText("------------------------------------------------------", Color.Blue);
            String UserName = Environment.UserName;
            AppendText(String.Format("UserName: {0}", UserName), Color.Blue);
            AppendText("------------------------------------------------------", Color.Blue);
            appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            AppendText(String.Format("appData: {0}", appDataDir), Color.Blue);
            appDataLocalDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            AppendText(String.Format("appData Local: {0}", appDataLocalDir), Color.Blue);
            AppendText("------------------------------------------------------", Color.Blue);
        }
    }
}