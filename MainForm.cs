using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ClipboardMonitor
{
    public partial class MainForm : Form
    {

        // WM_DRAWCLIPBOARD é mensagem que o programa recebe referente as chamadas da área de transferência no windows
        // essas mensagens são encaminhadas para após registrar o programa como Clipboard Viewer (SetClipboardViewer).
        // fonte: https://www.fluxbytes.com/csharp/monitor-clipboard-in-c/

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

        private const int WM_DRAWCLIPBOARD = 0x0308; 
        private IntPtr _clipboardViewerNext;

        protected override void WndProc(ref Message m)
        {
            // processa a mensagem
            base.WndProc(ref m);
            // se o tipo da mensagem for evento de área de transferência
            if (m.Msg == WM_DRAWCLIPBOARD)
            {
                // obtém os dados da área de transferência
                IDataObject iData = Clipboard.GetDataObject();
                // se o tipo for texto
                if (iData.GetDataPresent(DataFormats.Text))
                {
                    string text = (string)iData.GetData(DataFormats.Text);
                    // verifica se o item já consta na lista
                    if (!this.historico.Items.Contains(text))
                    {
                        // adiciona na lista e no collection(usado no filtro)
                        historico.Items.Add(text);
                        historicoCollection.Add(text);
                    }
                }
            }
        }

        List<string> historicoCollection = new List<string>();
        public MainForm()
        {
            InitializeComponent();
            // registra o form na cadeia de Clipboard Viewers
            _clipboardViewerNext = SetClipboardViewer(this.Handle);
            // salva no collection o conteúdo do listbox
            foreach (string str in historico.Items)
            {
                historicoCollection.Add(str);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = "Clipboard Monitor v.001";
        }

        private void MainForm_Closing(object sender, FormClosingEventArgs e)
        {
            // remove o form na cadeia de Clipboard Viewers antes de fechar 
            ChangeClipboardChain(this.Handle, _clipboardViewerNext);
        }

        private void LimparHistorico_Click(object sender, EventArgs e)
        {
            // limpa o conteúdo do listBox
            historico.Items.Clear();
            // limpa o conteúdo do collection
            historicoCollection.Clear();
        }

        private void Sair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Historico_Click(object sender, EventArgs e)
        {
            // se a opção está habilitada e possui item no listBox
            if (copiarComCliqueToolStripMenuItem.Checked && historico.Items.Count > 0)
            {
                // define o conteúdo da área de transferência atual com o conteúdo da linha clicada
                Clipboard.SetText(historico.SelectedItem.ToString());
            }
        }

        private void filtro_TextChanged(object sender, EventArgs e)
        {
            // pausa o "painting" do listbox
            historico.BeginUpdate();
            // limpa o listBox
            historico.Items.Clear();
            // se o campo filtro tem texto
            if (string.IsNullOrEmpty(filtro.Text) == false)
            {
                // filtra de acordo com o texto digitado
                foreach(string str in historicoCollection)
                {
                    if (str.Contains(filtro.Text))
                    {
                        historico.Items.Add(str);
                    }
                }
            }
            // se não tem texto, preenche com o collection inteiro
            else
            {
                foreach (string str in historicoCollection)
                {
                   historico.Items.Add(str);
                }
            }
            // finaliza a edição e permite o listBox processar o "painting"
            historico.EndUpdate();
        } 

    }
}
