namespace ClipboardMonitor
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.historico = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.limparHistóricoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restaurarPadrõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iniciarMinimizadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iniciarComOWindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.armazenarHistóricoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copiarComCliqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modoEscuroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // historico
            // 
            this.historico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.historico.BackColor = System.Drawing.Color.White;
            this.historico.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.historico.FormattingEnabled = true;
            this.historico.ItemHeight = 15;
            this.historico.Items.AddRange(new object[] {
            "testes",
            "testest",
            "tsetset",
            "etestset",
            "tsetsets",
            "esttestse"});
            this.historico.Location = new System.Drawing.Point(2, 51);
            this.historico.Name = "historico";
            this.historico.ScrollAlwaysVisible = true;
            this.historico.Size = new System.Drawing.Size(309, 394);
            this.historico.TabIndex = 2;
            this.historico.Click += new System.EventHandler(this.Historico_Click);
            // 
            // button1
            // 
            this.button1.Image = global::ClipboardMonitor.Properties.Resources.filter;
            this.button1.Location = new System.Drawing.Point(286, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 22);
            this.button1.TabIndex = 5;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(2, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(283, 20);
            this.textBox1.TabIndex = 4;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.configuraçõesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(313, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.limparHistóricoToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // limparHistóricoToolStripMenuItem
            // 
            this.limparHistóricoToolStripMenuItem.Name = "limparHistóricoToolStripMenuItem";
            this.limparHistóricoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.limparHistóricoToolStripMenuItem.Text = "Limpar histórico";
            this.limparHistóricoToolStripMenuItem.Click += new System.EventHandler(this.LimparHistorico_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.Sair_Click);
            // 
            // configuraçõesToolStripMenuItem
            // 
            this.configuraçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restaurarPadrõesToolStripMenuItem,
            this.iniciarMinimizadoToolStripMenuItem,
            this.iniciarComOWindowsToolStripMenuItem,
            this.armazenarHistóricoToolStripMenuItem,
            this.copiarComCliqueToolStripMenuItem,
            this.modoEscuroToolStripMenuItem});
            this.configuraçõesToolStripMenuItem.Name = "configuraçõesToolStripMenuItem";
            this.configuraçõesToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.configuraçõesToolStripMenuItem.Text = "Configurações";
            // 
            // restaurarPadrõesToolStripMenuItem
            // 
            this.restaurarPadrõesToolStripMenuItem.Name = "restaurarPadrõesToolStripMenuItem";
            this.restaurarPadrõesToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.restaurarPadrõesToolStripMenuItem.Text = "Restaurar padrões";
            // 
            // iniciarMinimizadoToolStripMenuItem
            // 
            this.iniciarMinimizadoToolStripMenuItem.Name = "iniciarMinimizadoToolStripMenuItem";
            this.iniciarMinimizadoToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.iniciarMinimizadoToolStripMenuItem.Text = "Iniciar minimizado";
            // 
            // iniciarComOWindowsToolStripMenuItem
            // 
            this.iniciarComOWindowsToolStripMenuItem.Name = "iniciarComOWindowsToolStripMenuItem";
            this.iniciarComOWindowsToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.iniciarComOWindowsToolStripMenuItem.Text = "Iniciar com o windows";
            // 
            // armazenarHistóricoToolStripMenuItem
            // 
            this.armazenarHistóricoToolStripMenuItem.Name = "armazenarHistóricoToolStripMenuItem";
            this.armazenarHistóricoToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.armazenarHistóricoToolStripMenuItem.Text = "Armazenar histórico";
            // 
            // copiarComCliqueToolStripMenuItem
            // 
            this.copiarComCliqueToolStripMenuItem.CheckOnClick = true;
            this.copiarComCliqueToolStripMenuItem.Name = "copiarComCliqueToolStripMenuItem";
            this.copiarComCliqueToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.copiarComCliqueToolStripMenuItem.Text = "Copiar com clique";
            // 
            // modoEscuroToolStripMenuItem
            // 
            this.modoEscuroToolStripMenuItem.Name = "modoEscuroToolStripMenuItem";
            this.modoEscuroToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.modoEscuroToolStripMenuItem.Text = "Modo escuro";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 450);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.historico);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(329, 489);
            this.Name = "MainForm";
            this.Text = "Clipboard Monitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_Closing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox historico;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem limparHistóricoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restaurarPadrõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iniciarMinimizadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iniciarComOWindowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem armazenarHistóricoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copiarComCliqueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modoEscuroToolStripMenuItem;
    }
}

