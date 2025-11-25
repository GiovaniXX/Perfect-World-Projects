using System.Windows.Forms;

namespace GShopDataExplorer
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirArquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ferramentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem validarEstruturaToolStripMenuItem;
        private System.Windows.Forms.ListBox listBoxItens;
        private System.Windows.Forms.GroupBox groupBoxDetalhes;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.TextBox textBoxDescricao;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.Label labelDescricao;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.Button buttonExportarCSV;
        private System.Windows.Forms.ComboBox comboBoxEncoding;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirArquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ferramentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.validarEstruturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxItens = new System.Windows.Forms.ListBox();
            this.groupBoxDetalhes = new System.Windows.Forms.GroupBox();
            this.labelNome = new System.Windows.Forms.Label();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.labelDescricao = new System.Windows.Forms.Label();
            this.textBoxDescricao = new System.Windows.Forms.TextBox();
            this.labelID = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.buttonExportarCSV = new System.Windows.Forms.Button();
            this.comboBoxEncoding = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.groupBoxDetalhes.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.ferramentasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(882, 24);
            this.menuStrip1.TabIndex = 0;
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirArquivoToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // abrirArquivoToolStripMenuItem
            // 
            this.abrirArquivoToolStripMenuItem.Name = "abrirArquivoToolStripMenuItem";
            this.abrirArquivoToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.abrirArquivoToolStripMenuItem.Text = "Abrir .data";
            this.abrirArquivoToolStripMenuItem.Click += new System.EventHandler(this.abrirArquivoToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // ferramentasToolStripMenuItem
            // 
            this.ferramentasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.validarEstruturaToolStripMenuItem});
            this.ferramentasToolStripMenuItem.Name = "ferramentasToolStripMenuItem";
            this.ferramentasToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.ferramentasToolStripMenuItem.Text = "Ferramentas";
            // 
            // validarEstruturaToolStripMenuItem
            // 
            this.validarEstruturaToolStripMenuItem.Name = "validarEstruturaToolStripMenuItem";
            this.validarEstruturaToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.validarEstruturaToolStripMenuItem.Text = "Validar Estrutura";
            this.validarEstruturaToolStripMenuItem.Click += new System.EventHandler(this.validarEstruturaToolStripMenuItem_Click);
            // 
            // listBoxItens
            // 
            this.listBoxItens.BackColor = System.Drawing.SystemColors.Control;
            this.listBoxItens.Location = new System.Drawing.Point(12, 47);
            this.listBoxItens.Name = "listBoxItens";
            this.listBoxItens.Size = new System.Drawing.Size(435, 394);
            this.listBoxItens.TabIndex = 1;
            // 
            // groupBoxDetalhes
            // 
            this.groupBoxDetalhes.Controls.Add(this.labelNome);
            this.groupBoxDetalhes.Controls.Add(this.textBoxNome);
            this.groupBoxDetalhes.Controls.Add(this.labelDescricao);
            this.groupBoxDetalhes.Controls.Add(this.textBoxDescricao);
            this.groupBoxDetalhes.Controls.Add(this.labelID);
            this.groupBoxDetalhes.Controls.Add(this.textBoxID);
            this.groupBoxDetalhes.Location = new System.Drawing.Point(465, 40);
            this.groupBoxDetalhes.Name = "groupBoxDetalhes";
            this.groupBoxDetalhes.Size = new System.Drawing.Size(400, 142);
            this.groupBoxDetalhes.TabIndex = 2;
            this.groupBoxDetalhes.TabStop = false;
            this.groupBoxDetalhes.Text = "Detalhes do Item";
            // 
            // labelNome
            // 
            this.labelNome.Location = new System.Drawing.Point(10, 30);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(64, 23);
            this.labelNome.TabIndex = 0;
            this.labelNome.Text = "Nome:";
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(80, 30);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(300, 20);
            this.textBoxNome.TabIndex = 1;
            // 
            // labelDescricao
            // 
            this.labelDescricao.Location = new System.Drawing.Point(10, 70);
            this.labelDescricao.Name = "labelDescricao";
            this.labelDescricao.Size = new System.Drawing.Size(64, 23);
            this.labelDescricao.TabIndex = 2;
            this.labelDescricao.Text = "Descrição:";
            // 
            // textBoxDescricao
            // 
            this.textBoxDescricao.Location = new System.Drawing.Point(80, 70);
            this.textBoxDescricao.Name = "textBoxDescricao";
            this.textBoxDescricao.Size = new System.Drawing.Size(300, 20);
            this.textBoxDescricao.TabIndex = 3;
            // 
            // labelID
            // 
            this.labelID.Location = new System.Drawing.Point(10, 110);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(64, 23);
            this.labelID.TabIndex = 4;
            this.labelID.Text = "ID:";
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(80, 110);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(100, 20);
            this.textBoxID.TabIndex = 5;
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBoxLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxLog.Location = new System.Drawing.Point(465, 219);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.Size = new System.Drawing.Size(400, 215);
            this.richTextBoxLog.TabIndex = 3;
            this.richTextBoxLog.Text = "";
            // 
            // buttonExportarCSV
            // 
            this.buttonExportarCSV.Location = new System.Drawing.Point(465, 188);
            this.buttonExportarCSV.Name = "buttonExportarCSV";
            this.buttonExportarCSV.Size = new System.Drawing.Size(150, 25);
            this.buttonExportarCSV.TabIndex = 0;
            this.buttonExportarCSV.Text = "Exportar para CSV";
            this.buttonExportarCSV.Click += new System.EventHandler(this.buttonExportarCSV_Click);
            // 
            // comboBoxEncoding
            // 
            this.comboBoxEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEncoding.Items.AddRange(new object[] {
            "Unicode",
            "UTF-8",
            "GBK (936)"});
            this.comboBoxEncoding.Location = new System.Drawing.Point(715, 192);
            this.comboBoxEncoding.Name = "comboBoxEncoding";
            this.comboBoxEncoding.Size = new System.Drawing.Size(150, 21);
            this.comboBoxEncoding.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 450);
            this.Controls.Add(this.comboBoxEncoding);
            this.Controls.Add(this.buttonExportarCSV);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.listBoxItens);
            this.Controls.Add(this.groupBoxDetalhes);
            this.Controls.Add(this.richTextBoxLog);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "GShop Data Explorer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxDetalhes.ResumeLayout(false);
            this.groupBoxDetalhes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
    }
}

