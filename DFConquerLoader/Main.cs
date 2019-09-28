using Reloaded.Injector;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace DFConquerLoader
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Play_Click(object sender, EventArgs e)
        {
            Process pConquer = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = Directory.GetCurrentDirectory() + @"\Conquer.exe",
                    Arguments = "blacknull"
                }
            };
            if (File.Exists(pConquer.StartInfo.FileName))
            {
                pConquer.Start();
                Injector injector = new Injector(pConquer);
                injector.Inject("Inject.dll");
                injector.Dispose();
            } else
            {
                DialogResult dRes = MessageBox.Show("Error cannot load the Inject.dll for inject in Conquer.exe", "Error DFConquerLoader", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (dRes == DialogResult.Retry)
                {
                    this.Play_Click(sender, e);
                }
            }
        }
    }
}
