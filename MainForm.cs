using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace ClipboardMonitor
{
    public partial class MainForm : Form
    {
        // collection para filtrar o conteúdo do listBox
        List<string> historicoCollection = new List<string>();
        
        // WM_DRAWCLIPBOARD é mensagem que o programa recebe referente as chamadas da área de transferência no windows
        // essas mensagens são encaminhadas para após registrar o programa como Clipboard Viewer (SetClipboardViewer).
        // fonte: https://www.fluxbytes.com/csharp/monitor-clipboard-in-c/

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

        private const int WM_DRAWCLIPBOARD = 0x0308; 
        private IntPtr _clipboardViewerNext;

        private bool closeApp = false;

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
                    if (!this.historicoCollection.Contains(text))
                    {
                        // adiciona na lista e no collection(usado no filtro)
                        historico.Items.Add(text);
                        historicoCollection.Add(text);
                    }
                }
            }
        }

        public MainForm()
        {
            InitializeComponent();
            // registra o form na cadeia de Clipboard Viewers
            _clipboardViewerNext = SetClipboardViewer(this.Handle);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // preenche o título do form com a versão do aplicativo
            string versao_atual = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            this.Text = String.Format("Clipboard Monitor {0}", versao_atual.Substring(0,3));
            // define as dimensões da janela de acordo com as configurações salvas
            this.Height = Properties.Settings.Default.altura_da_janela;
            this.Width = Properties.Settings.Default.largura_da_janela;
            // posição da janela
            this.Top = Properties.Settings.Default.posicao_da_janela_x;
            this.Left = Properties.Settings.Default.posicao_da_janela_y;
            // define o estado dos menus de acordo com as opções salvas
            iniciarMinimizadoToolStripMenuItem.Checked = Properties.Settings.Default.iniciar_minimizado;
            iniciarComOWindowsToolStripMenuItem.Checked =  File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + @"\ClipboardMonitor.lnk");
            copiarComCliqueToolStripMenuItem.Checked = Properties.Settings.Default.copiar_com_clique;            
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (iniciarMinimizadoToolStripMenuItem.Checked) { 
                // altera o estado da janela para minimizado
                this.WindowState = FormWindowState.Minimized;
                // fecha o form
                this.Hide();
            }
        }

        private void MainForm_Closing(object sender, FormClosingEventArgs e)
        {
            // guarda a posição da janela
            Properties.Settings.Default.posicao_da_janela_x = this.Top;
            Properties.Settings.Default.posicao_da_janela_y = this.Left;
            // guarda o valor da altura x largura
            Properties.Settings.Default.altura_da_janela = this.Height;
            Properties.Settings.Default.largura_da_janela = this.Width;
            // salva as propriedades
            Properties.Settings.Default.Save();
            // minimiza se é o usuário fechando o form pelo "X"
            if (e.CloseReason == CloseReason.UserClosing && !closeApp)
            {
                this.Hide();
                e.Cancel = true;
            } else { 
                // remove o form na cadeia de Clipboard Viewers antes de fechar 
                ChangeClipboardChain(this.Handle, _clipboardViewerNext);
            }
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
            // para fechar o form e não minimizar
            closeApp = true;
            // fecha o aplicativo
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

        private void Filtro_TextChanged(object sender, EventArgs e)
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

        private void IniciarMinimizadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // guarda o valor da propriedade
            Properties.Settings.Default.iniciar_minimizado = iniciarMinimizadoToolStripMenuItem.Checked;
            // salva a propriedade
            Properties.Settings.Default.Save();
        }

        private void IniciarComOWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // salva ou remove da inicialização do windows
            RegisterInStartup(iniciarComOWindowsToolStripMenuItem.Checked);
            // guarda o valor da propriedade
            Properties.Settings.Default.iniciar_minimizado = iniciarComOWindowsToolStripMenuItem.Checked;
            // salva a propriedade
            Properties.Settings.Default.Save();
        }

        private void CopiarComCliqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // guarda o valor da propriedade
            Properties.Settings.Default.copiar_com_clique = copiarComCliqueToolStripMenuItem.Checked; 
            // salva a propriedade
            Properties.Settings.Default.Save();
        }

        private void NotifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            // mostra o form
            this.Show();
            // restaura o estado da janela
            this.WindowState = FormWindowState.Normal;
        }

        //https://stackoverflow.com/questions/5089601/how-to-run-a-c-sharp-application-at-windows-startup
        //Since question is WPF related, notice that Application.ExecutablePath is part of System.Windows.Forms, and will result in cannot resolve symbol in WPF project. You can use System.Reflection.Assembly.GetExecutingAssembly().Location as proper replacement. – itsho Feb 22 '15 at 7:024
        //Assembly.GetExecutingAssembly() will get the assembly currently running the code.It will not get the correct assembly if the code is executed on another assembly. Use Assembly.GetEntryAssembly() instead. 
        private void RegisterInStartup(bool isChecked)
        {            
            //shell:startup

            if (isChecked)
            {
                //create shortcut to file in startup
                IWshRuntimeLibrary.WshShell wsh = new IWshRuntimeLibrary.WshShell();
                IWshRuntimeLibrary.IWshShortcut shortcut = wsh.CreateShortcut(
                Environment.GetFolderPath(Environment.SpecialFolder.Startup) + @"\ClipboardMonitor.lnk") as IWshRuntimeLibrary.IWshShortcut;
                shortcut.Arguments = "";
                shortcut.TargetPath = Environment.CurrentDirectory + @"\ClipboardMonitor.exe";
                shortcut.WindowStyle = 1;
                shortcut.Description = "Clipboard Monitor";
                shortcut.WorkingDirectory = Environment.CurrentDirectory + @"\";
                //shortcut.IconLocation = @"clipboard.ico";
                shortcut.Save();
            } 
            else
            {  
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + @"\ClipboardMonitor.lnk"))
                {  
                    File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + @"\ClipboardMonitor.lnk");
                }
            }
        }
    }
}
