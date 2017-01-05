using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Resources;
using System.Globalization;

namespace WindowsFormNavKiller
{
    public partial class Form1 : Form
    {
        private int fileDeleted;
        private int dirDeleted;
        private string appDataLocalDir;
        private string appDataDir;
        private ResourceManager LocRM;
        private bool showEx = false;
        private warnForm warn = null;

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
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-FR");
            // Declare a Resource Manager instance
            LocRM = new ResourceManager("WindowsFormNavKiller.WinFormStrings", typeof(Form1).Assembly);

            InitializeComponent();
            initializeMe();
        }

        private void initializeMe(bool clearBox = true)
        {
            pictureBox.Focus();
            pictureBox.Select();
            Process[] proc = Process.GetProcessesByName("chrome");
            if (proc.Length > 0)
            {
                //oneNavDetected = true;
                groupChrome.Enabled = true;
            }
            else
            {
                groupChrome.Enabled = false;
            }
            proc = Process.GetProcessesByName("firefox");
            if (proc.Length > 0)
            {
                //oneNavDetected = true;
                groupFireFox.Enabled = true;
            }
            else
            {
                groupFireFox.Enabled = false;
            }
            proc = Process.GetProcessesByName("MicrosoftEdge");
            if (proc.Length > 0)
            {
                //oneNavDetected = true;
                groupEdge.Enabled = true;
            }
            else
            {
                groupEdge.Enabled = false;
            }
            if (clearBox == false) return;
            hideWarn();
            textBox.Clear();
            //if ((rbc == 0) || (oneNavDetected == false))
            //if (rbc == 0)
            //{
            //        recycleBinBox.Enabled = false;
            //}
            AppendText("------------------------------------------------------", Color.Blue);
            AppendText(string.Format("Version : {0}", Application.ProductVersion), Color.Blue);


            string UserName = Environment.UserName;
            AppendText(string.Format(LocRM.GetString("UserName") + ": {0}", UserName), Color.Blue);
            AppendText("------------------------------------------------------", Color.Blue);
            appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            AppendText(LocRM.GetString("appDataStr"), Color.Blue, false);
            AppendText(string.Format(": {0}", appDataDir), Color.Blue);
            appDataLocalDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            AppendText(LocRM.GetString("appDataStr"), Color.Blue, false);
            AppendText(string.Format(" Local: {0}", appDataLocalDir), Color.Blue);
            int rbc = GetRecycleBinCount();
            string recycleBinCountStr = LocRM.GetString("recycleBinCountStr");
            AppendText(string.Format(recycleBinCountStr + ": {0}", rbc), Color.Blue);
            AppendText("------------------------------------------------------", Color.Blue);
        }

        private void showWarn()
        {
            if (warn == null)
            {
                warn = new warnForm(LocRM);
                warn.FormClosed += (sender2, e2) => { warn = null; };

                warn.StartPosition = FormStartPosition.Manual;
                warn.Location = new Point(Location.X + (Width - warn.Width) / 2, Location.Y + (Height - warn.Height) / 2);
                warn.Show(this);
               //warn.ShowDialog(this);
            }
            else
            {
                warn.Location = new Point(Location.X + (Width - warn.Width) / 2, Location.Y + (Height - warn.Height) / 2);
                warn.Show(this);
                warn.Focus();
            }
        }

        private void hideWarn()
        {
            if (warn != null)
            {
                warn.Hide();
            }
        }
        private void updateWarnLng()
        {
            if (warn != null)
            {
                warn.setLocRM(LocRM);
            }
        }

        private int GetRecycleBinCount()
        {
            SHQUERYRBINFO sqrbi = new SHQUERYRBINFO();
            sqrbi.cbSize = Marshal.SizeOf(typeof(SHQUERYRBINFO));
            int hresult = SHQueryRecycleBin(string.Empty, ref sqrbi);
            return (int)sqrbi.i64NumItems;
        }

        private void cleanChromePrefFile(string fileName)
        {
            AppendText("------------------------------------------------------", Color.Red);
            AppendText(string.Format("cleanChromePrefFile: {0}", fileName), Color.Red);
            string str = File.ReadAllText(fileName);
            str = str.Replace("exit_type\":\"Crashed", "exit_type\":\"None");
            File.WriteAllText(fileName, str);
            AppendText("------------------------------------------------------", Color.Red);
        }

        private void emptyRecycleBin()
        {
            int rbc = GetRecycleBinCount();
            if (rbc > 0)
            {
                if (emptyBin.Checked)
                {
                    DialogResult result;
                    result = MessageBox.Show(this, LocRM.GetString("RBCleanStr"), LocRM.GetString("RBCleanBtnStr"), MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            uint IsSuccess = SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlags.SHERB_NOCONFIRMATION);
                            MessageBox.Show(this, LocRM.GetString("RBCleanOkStr"), LocRM.GetString("RBCleanBtnStr"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            AppendText(string.Format(LocRM.GetString("RBCleanOkStr")), Color.Red);
                            AppendText("------------------------------------------------------", Color.Green);
                            //recycleBinBox.Enabled = false;
                        }
                        catch (Exception ex)
                        {
                            if (showEx)
                            {
                                MessageBox.Show(this, LocRM.GetString("RBCleanBadStr") + ex.Message, LocRM.GetString("RBCleanBtnStr"), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                AppendText(string.Format(LocRM.GetString("RBCleanBadStr")), Color.Red);
                                AppendText("------------------------------------------------------", Color.Green);
                                //Application.Exit();
                            }
                        }
                    }

                }
            }
        }

        private void killChrome_Click(object sender, EventArgs e)
        {
            initializeMe();
            Process[] proc = Process.GetProcessesByName("chrome");
            AppendText("------------------------------------------------------", Color.Green);
            if (proc.Length > 0)
            {
                AppendText(LocRM.GetString("killStr") + " Chrome ...", Color.Green);
                foreach (Process theprocess in proc)
                {
                    theprocess.Kill();
                }
                groupChrome.Enabled = false;
                System.Threading.Thread.Sleep(100);
                AppendText("------------------------------------------------------", Color.Green);
                if (clearChrome.Checked)
                {
                    AppendText(LocRM.GetString("clearCacheStr") + " Chrome ...", Color.Green);
                    fileDeleted = 0;
                    dirDeleted = 0;
                    string UserName = Environment.UserName;
                    //Remove - Item - path "C:\Users\$($_.Name)\AppData\Local\Google\Chrome\User Data\Default\Cache\*" - Recurse - Force - EA SilentlyContinue #-Verbose
                    //String dirName = @"C:\Users\" + UserName + @"\AppData\Local\Google\Chrome\User Data\Default\Cache";
                    string dirName = appDataLocalDir + @"\Google\Chrome\User Data\Default\Cache";
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
                    // Clear Chrome History
                    // C:\Users\xxxxxx\AppData\Local\Google\Chrome\User Data\Default\history
                    // C:\Users\Christian\AppData\Local\Google\Chrome\User Data\Default
                    DeleteFile(appDataLocalDir + @"\Google\Chrome\User Data\Default\History");
                    // Clear Session Restore Data
                    AppendText(LocRM.GetString("clearSessionDataStr") + " Chrome ...", Color.Green);
                    //cleanPrefFile - pref "C:\Users\$($_.Name)\AppData\Local\Google\Chrome\User Data\Default\Preferences"
                    cleanChromePrefFile(appDataLocalDir + @"\Google\Chrome\User Data\Default\Preferences");
                    AppendText(string.Format("Done, Files Deleted: {0}", fileDeleted), Color.Red);
                    AppendText("------------------------------------------------------", Color.Green);
                    emptyRecycleBin();
                }
                showWarn();
            }
            else {
                AppendText(" Chrome " + LocRM.GetString("procNotFound") , Color.Orange);
                AppendText("------------------------------------------------------", Color.Green);
            }
        }

        private void killFireFox_Click(object sender, EventArgs e)
        {
            initializeMe();
            Process[] proc = Process.GetProcessesByName("firefox");
            AppendText("------------------------------------------------------", Color.Green);
            if (proc.Length > 0)
            {
                AppendText(LocRM.GetString("killStr") + " Mozilla Firefox ...", Color.Green);
                foreach (Process theprocess in proc)
                {
                    theprocess.Kill();
                }
                groupFireFox.Enabled = false;
                System.Threading.Thread.Sleep(100);
                AppendText("------------------------------------------------------", Color.Green);
                if (clearFireFox.Checked)
                {
                    fileDeleted = 0;
                    dirDeleted = 0;
                    // Clear History Data
                    // Only get subdirectories that begin with the letter ".default"
                    //                string[] dirs = Directory.GetDirectories(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Mozilla\Firefox\Profiles\", "*.default*");
                    string[] dirs = Directory.GetDirectories(appDataLocalDir + @"\Mozilla\Firefox\Profiles\", "*.default*");
                    AppendText(LocRM.GetString("clearCacheStr") + " Mozilla Firefox ...", Color.Green);
                    string searchPattern = "cache*|thumbnails|cookies.sqlite|webappsstore.sqlite|chromeappsstore.sqlite";
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
                    AppendText(LocRM.GetString("clearSessionDataStr") + " Mozilla Firefox ...", Color.Green);
                    //dirs = Directory.GetDirectories(@"C:\Users\" + Environment.UserName + @"\AppData\Roaming\Mozilla\Firefox\Profiles\", "*.default*");
                    dirs = Directory.GetDirectories(appDataDir + @"\Mozilla\Firefox\Profiles\", "*.default*");
                    foreach (string dir in dirs)
                    {
                        string[] subDirs = Directory.GetDirectories(dir, "sessionstore-backups", SearchOption.AllDirectories);
                        foreach (string sub in subDirs)
                        {
                            DeleteFilesInDirectory(sub);
                            //DeleteDirectory(sub);
                        }
                        // Clear FireFox History
                        // C:\Users\xxxxxx\AppData\Roaming\Mozilla\Firefox\Profiles\jjeu3ewf.default-1482768194919\places.sqlite
                        DeleteFile(dir + @"\places.sqlite");
                    }
                    AppendText(LocRM.GetString("doneStr") + " " + LocRM.GetString("dirDelStr"), Color.Red, false);
                    AppendText(string.Format(": {0} ", dirDeleted), Color.Red, false);
                    AppendText(LocRM.GetString("fileDelStr"), Color.Red, false);
                    AppendText(string.Format(": {0} ", fileDeleted), Color.Red);
                    AppendText("------------------------------------------------------", Color.Green);
                    emptyRecycleBin();
                }
                showWarn();
            }
            else
            {
                AppendText(" Mozilla Firefox " + LocRM.GetString("procNotFound"), Color.Orange);
                AppendText("------------------------------------------------------", Color.Green);
            }
        }

        private void killEdgeProcesses()
        {
            Process[] proc = Process.GetProcessesByName("MicrosoftEdge");
            AppendText("------------------------------------------------------", Color.Green);
            if (proc.Length > 0)
            {
                AppendText(LocRM.GetString("killStr") + " Microsoft Edge ...", Color.Green);
                foreach (Process theprocess in proc)
                {
                    try
                    {
                        AppendText(LocRM.GetString("killStr") + " Microsoft Edge ..." + theprocess.Id, Color.BlueViolet);
                        theprocess.Kill();
                    }
                    catch (Exception ex)
                    {
                        if (showEx) AppendText(ex.Message, Color.Maroon);
                        continue;
                    }
                }
            }
            //proc = Process.GetProcessesByName("MicrosoftEdgeCP");
            //AppendText("------------------------------------------------------", Color.Green);
            //if (proc.Length > 0)
            //{
            //    AppendText(LocRM.GetString("killStr") + " Microsoft EdgeCP ...", Color.Green);
            //    foreach (Process theprocess in proc)
            //    {
            //        try
            //        {
            //            AppendText(LocRM.GetString("killStr") + " Microsoft EdgeCP ..." + theprocess.Id, Color.BlueViolet);
            //            theprocess.Kill();
            //        }
            //        catch (Exception ex)
            //        {
            //            if (showEx) AppendText(ex.Message, Color.Maroon);
            //            continue;
            //        }
            //    }
            //    groupEdge.Enabled = false;
            //}
        }

        private void killEdge_Click(object sender, EventArgs e)
        {
            initializeMe();
            /*
             * 
             *  Here is some hack !
             *  As I never succeded to clean cach / session Information for Edge
             *  I will instead :
             *  1) Kill all Edge processes
             *  2) Restart / ReOpen an Edge process with "about:blank" startup page (which seems to be ok to restart without reloading the ols tabs !!)
             *  3) The reKill the Edge processes
             *  Doing this seems to allow to have a clen Edge session (with the default page opening) next time we will start edge !!
             *  
             */
            killEdgeProcesses();
            try {
                AppendText(LocRM.GetString("restart") + " Microsoft Edge ...", Color.Green);
                Process cp = Process.Start("microsoft-edge:about:blank");
            }
            catch (Exception ex)
            {
                if (showEx) AppendText(ex.Message, Color.Maroon);
            }
            killEdgeProcesses();
            groupEdge.Enabled = false;
            System.Threading.Thread.Sleep(100);
            emptyRecycleBin();
            showWarn();
        }

        private void DeleteFile(string file)
        {
            try
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
                AppendText(LocRM.GetString("delFileStr") + file, Color.Orange);
            }
            catch (Exception ex)
            {
                if (showEx)
                {
                    AppendText(ex.Message, Color.Maroon);
                }
            }
            fileDeleted++;
        }
        private void DeleteFilesInDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                //Delete all files from the Directory
                foreach (string file in Directory.GetFiles(path))
                {
                    try
                    {
                        File.SetAttributes(file, FileAttributes.Normal);
                        File.Delete(file);
                        AppendText(LocRM.GetString("delFileStr") + file, Color.YellowGreen);
                    }
                    catch (Exception ex)
                    {
                        if (showEx)
                        {
                            AppendText(ex.Message, Color.Red);
                        }
                        continue;
                   }
                    fileDeleted++;
                }

            }
        }

        private void deleteDirViaExe(string path)
        {
            ProcessStartInfo Info = new ProcessStartInfo();
            Info.Arguments = "/C rd /s /q "+path;  
            Info.WindowStyle = ProcessWindowStyle.Hidden;
            Info.CreateNoWindow = true;
            Info.FileName = "cmd.exe";
            Process.Start(Info);
            AppendText(LocRM.GetString("delDirStr") + " exe " + Info.ToString(), Color.OrangeRed);

        }
        private void DeleteDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                //AppendText("ok delete dir: " + path, Color.Blue);
                //Delete all files from the Directory
                foreach (string file in Directory.GetFiles(path))
                {
                    try
                    {
                        File.SetAttributes(file, FileAttributes.Normal);
                        File.Delete(file);
                        AppendText(LocRM.GetString("delFileStr") + file, Color.CadetBlue);
                    }
                    catch (Exception ex)
                    {
                        if (showEx)
                        {
                            AppendText(ex.Message, Color.DarkKhaki);
                        }
                        continue;
                    }
                    fileDeleted++;
                }
                //Delete all child Directories
                foreach (string directory in Directory.GetDirectories(path))
                {
                    try
                    {
                        //AddDirectorySecurity(path, @"MYDOMAIN\MyAccount", FileSystemRights.DeleteSubdirectoriesAndFiles, AccessControlType.Allow);
                        DeleteDirectory(directory);
                    }
                    catch (Exception ex)
                    {
                        if (showEx)
                        {
                            AppendText(ex.Message, Color.Maroon);
                        }
                        continue;
                    }
                }
                System.Threading.Thread.Sleep(1);
                try
                {
                    Directory.Delete(path);
                    AppendText(LocRM.GetString("delDirStr") + path, Color.Violet);
                }
                catch (Exception ex)
                {
                    if (showEx)
                    {
                        AppendText(ex.Message, Color.Maroon);
                    }
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
            textBox.Select(start, end - start);
            {
                textBox.SelectionColor = color;
            }
            textBox.SelectionLength = 0; // clear
        }

        private void textBox_DoubleClick(object sender, EventArgs e)
        {
            //textBox.Clear();
            initializeMe();
        }

        private void fToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-FR");
            LocRM = new ResourceManager("WindowsFormNavKiller.WinFormStrings", typeof(Form1).Assembly);
            this.Controls.Clear();
            this.InitializeComponent();
            initializeMe();
            if (warn != null)
            {
                warn.Close();
                warn = null;
            }
        }

        private void eToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-EN");
            LocRM = new ResourceManager("WindowsFormNavKiller.WinFormStrings", typeof(Form1).Assembly);
            this.Controls.Clear();
            this.InitializeComponent();
            initializeMe();
            if (warn != null)
            {
                warn.Close();
                warn = null;
            }
        }

        private void goToWebSiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://devlabnet.eu/softdev/visual/navkill/support/");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            //timer1.Interval = 5000;// mili-seconds
            //timer1.Tick += new System.EventHandler(timer1_Tick);
            //timer1.Start();
        }

        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    //System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
        //    //timer1.Interval = 10000;// 10 seconds
        //    //timer1.Tick += new System.EventHandler(timer1_Tick);
        //    //timer1.Start();
        //}

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    initializeMe(false);
        //}

        private void pictureBox_Click(object sender, EventArgs e)
        {
            initializeMe(false);
        }
    }
}
