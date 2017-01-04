using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.Globalization;

namespace WindowsFormNavKiller
{
    public partial class warnForm : Form
    {
        private ResourceManager LocRM;
 
        public warnForm(ResourceManager Loc)
        {
            InitializeComponent();
            LocRM = Loc;
        }

        private void ZHPLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                // Change the color of the link text by setting LinkVisited 
                // to true.
                ZHPLabel.LinkVisited = true;
                //Call the Process.Start method to open the default browser 
                //with a URL:
                System.Diagnostics.Process.Start("https://www.nicolascoolman.com/download/zhpcleaner/");
            }
            catch (Exception )
            {
                MessageBox.Show(LocRM.GetString("UnableOpenSite") + "ZHPCleaner.");
            }
        }

        private void ADWLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                // Change the color of the link text by setting LinkVisited 
                // to true.
                ADWLabel.LinkVisited = true;
                //Call the Process.Start method to open the default browser 
                //with a URL:
                System.Diagnostics.Process.Start("https://www.nicolascoolman.com/fr/download/adwcleaner/");
            }
            catch (Exception )
            {
                MessageBox.Show(LocRM.GetString("UnableOpenSite") + "ADWCleaner.");
            }
        }

        public void setLocRM(ResourceManager Loc)
        {
            LocRM = Loc;
        }
    }
}
