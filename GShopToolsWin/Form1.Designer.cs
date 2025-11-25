using RJCodeAdvance.RJControls;
using System.Windows.Forms;

namespace GShopToolsWin
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
       
        private TextBox txtArquivoValidar;
        private RichTextBox txtResultadoValidar;
        private TextBox txtArquivoOrigem;
        private TextBox txtArquivoDestino;
        private TextBox txtArquivo1;
        private TextBox txtArquivo2;
        private RichTextBox txtResultadoComparar;

        private Button btnValidar;
        private Button btnReparar;
        private Button btnComparar;

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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_validarArquivo = new System.Windows.Forms.TextBox();
            this.button_btnValidar = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.button_btnReparar = new System.Windows.Forms.Button();
            this.button_btnComparar = new System.Windows.Forms.Button();
            this.button_carregar_arquivo_reparar = new System.Windows.Forms.Button();
            this.button_carregar_arquivo_comparar = new System.Windows.Forms.Button();
            this.button_carregar_arquivo_validar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Arquivo para validar:";
            // 
            // textBox_validarArquivo
            // 
            this.textBox_validarArquivo.Location = new System.Drawing.Point(122, 34);
            this.textBox_validarArquivo.Name = "textBox_validarArquivo";
            this.textBox_validarArquivo.Size = new System.Drawing.Size(496, 20);
            this.textBox_validarArquivo.TabIndex = 1;
            // 
            // button_btnValidar
            // 
            this.button_btnValidar.Location = new System.Drawing.Point(624, 32);
            this.button_btnValidar.Name = "button_btnValidar";
            this.button_btnValidar.Size = new System.Drawing.Size(113, 23);
            this.button_btnValidar.TabIndex = 2;
            this.button_btnValidar.Text = "Validar Estrutura";
            this.button_btnValidar.UseVisualStyleBackColor = true;
            this.button_btnValidar.Click += new System.EventHandler(this.button_btnValidar_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(12, 61);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(725, 151);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Arquivo original:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 253);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Salvar como:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 312);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Arquivo 1:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 338);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Arquivo 2:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(100, 220);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(518, 20);
            this.textBox2.TabIndex = 8;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(100, 246);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(518, 20);
            this.textBox3.TabIndex = 9;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(100, 305);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(518, 20);
            this.textBox4.TabIndex = 10;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(100, 331);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(518, 20);
            this.textBox5.TabIndex = 11;
            // 
            // richTextBox2
            // 
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.Location = new System.Drawing.Point(15, 374);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(724, 248);
            this.richTextBox2.TabIndex = 12;
            this.richTextBox2.Text = "";
            // 
            // button_btnReparar
            // 
            this.button_btnReparar.Location = new System.Drawing.Point(624, 218);
            this.button_btnReparar.Name = "button_btnReparar";
            this.button_btnReparar.Size = new System.Drawing.Size(113, 23);
            this.button_btnReparar.TabIndex = 13;
            this.button_btnReparar.Text = "Reparar Arquivo";
            this.button_btnReparar.UseVisualStyleBackColor = true;
            this.button_btnReparar.Click += new System.EventHandler(this.button_btnReparar_Click);
            // 
            // button_btnComparar
            // 
            this.button_btnComparar.Location = new System.Drawing.Point(624, 303);
            this.button_btnComparar.Name = "button_btnComparar";
            this.button_btnComparar.Size = new System.Drawing.Size(113, 23);
            this.button_btnComparar.TabIndex = 14;
            this.button_btnComparar.Text = "Comparar";
            this.button_btnComparar.UseVisualStyleBackColor = true;
            this.button_btnComparar.Click += new System.EventHandler(this.button_btnComparar_Click);
            // 
            // button_carregar_arquivo_reparar
            // 
            this.button_carregar_arquivo_reparar.Location = new System.Drawing.Point(624, 246);
            this.button_carregar_arquivo_reparar.Name = "button_carregar_arquivo_reparar";
            this.button_carregar_arquivo_reparar.Size = new System.Drawing.Size(113, 23);
            this.button_carregar_arquivo_reparar.TabIndex = 15;
            this.button_carregar_arquivo_reparar.Text = "Carregar Arquivo";
            this.button_carregar_arquivo_reparar.UseVisualStyleBackColor = true;
            this.button_carregar_arquivo_reparar.Click += new System.EventHandler(this.button_carregar_arquivo_reparar_Click);
            // 
            // button_carregar_arquivo_comparar
            // 
            this.button_carregar_arquivo_comparar.Location = new System.Drawing.Point(624, 329);
            this.button_carregar_arquivo_comparar.Name = "button_carregar_arquivo_comparar";
            this.button_carregar_arquivo_comparar.Size = new System.Drawing.Size(113, 23);
            this.button_carregar_arquivo_comparar.TabIndex = 16;
            this.button_carregar_arquivo_comparar.Text = "Carregar Arquivo";
            this.button_carregar_arquivo_comparar.UseVisualStyleBackColor = true;
            this.button_carregar_arquivo_comparar.Click += new System.EventHandler(this.button_carregar_arquivo_comparar_Click);
            // 
            // button_carregar_arquivo_validar
            // 
            this.button_carregar_arquivo_validar.Location = new System.Drawing.Point(624, 3);
            this.button_carregar_arquivo_validar.Name = "button_carregar_arquivo_validar";
            this.button_carregar_arquivo_validar.Size = new System.Drawing.Size(113, 23);
            this.button_carregar_arquivo_validar.TabIndex = 17;
            this.button_carregar_arquivo_validar.Text = "Carregar Arquivo";
            this.button_carregar_arquivo_validar.UseVisualStyleBackColor = true;
            this.button_carregar_arquivo_validar.Click += new System.EventHandler(this.button_carregar_arquivo_validar_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(758, 651);
            this.Controls.Add(this.button_carregar_arquivo_validar);
            this.Controls.Add(this.button_carregar_arquivo_comparar);
            this.Controls.Add(this.button_carregar_arquivo_reparar);
            this.Controls.Add(this.button_btnComparar);
            this.Controls.Add(this.button_btnReparar);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button_btnValidar);
            this.Controls.Add(this.textBox_validarArquivo);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "GSHOP Tools - by Giovani V. Chaves";
            this.Click += new System.EventHandler(this.button_btnValidar_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label label1;
        private TextBox textBox_validarArquivo;
        private Button button_btnValidar;
        private RichTextBox richTextBox1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private RichTextBox richTextBox2;
        private Button button_btnReparar;
        private Button button_btnComparar;
        private Button button_carregar_arquivo_reparar;
        private Button button_carregar_arquivo_comparar;
        private Button button_carregar_arquivo_validar;
    }

    #endregion
}

