using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ClipboardMonitor
{
    public partial class MainForm : Form
    {

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

        private const int WM_DRAWCLIPBOARD = 0x0308;        // WM_DRAWCLIPBOARD message
        private IntPtr _clipboardViewerNext;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);    // Process the message 

            if (m.Msg == WM_DRAWCLIPBOARD)
            {
                IDataObject iData = Clipboard.GetDataObject();      // Clipboard's data

                if (iData.GetDataPresent(DataFormats.Text))
                {
                    string text = (string)iData.GetData(DataFormats.Text);      // Clipboard text
                    if (!this.historico.Items.Contains(text))
                    {
                        historico.Items.Add(text);
                    }
                }
            }
        }

        public MainForm()
        {
            InitializeComponent();
            _clipboardViewerNext = SetClipboardViewer(this.Handle); // Adds our form to the chain of clipboard viewers.
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = "Clipboard Monitor v.001";
        }

        private void MainForm_Closing(object sender, FormClosingEventArgs e)
        {
            ChangeClipboardChain(this.Handle, _clipboardViewerNext);        // Removes our from the chain of clipboard viewers when the form closes.
        }

        private void LimparHistorico_Click(object sender, EventArgs e)
        {
            this.historico.Items.Clear();
        }

        private void Sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Historico_Click(object sender, EventArgs e)
        {
            if (this.copiarComCliqueToolStripMenuItem.Checked && this.historico.Items.Count > 0)
            {
                Clipboard.SetText(historico.SelectedItem.ToString());
            }
        }
    }
}
