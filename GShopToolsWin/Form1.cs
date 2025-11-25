using RJCodeAdvance.RJControls;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace GShopToolsWin
{
    public partial class Form1 : Form
    {       
        public Form1()
        {
            InitializeComponent();

            // Mapear controles gerados pelo designer para os campos usados no código
            txtArquivoValidar = this.textBox_validarArquivo;
            txtResultadoValidar = this.richTextBox1;
            txtArquivoOrigem = this.textBox2;       
            txtArquivoDestino = this.textBox3;      
            txtArquivo1 = this.textBox4;
            txtArquivo2 = this.textBox5;
            txtResultadoComparar = this.richTextBox2;

            // Substitui button_btnValidar por RJButton - Em tempo de execução
            var button_btnValidarRJ = new RJButton 
            {
                Text = button_btnValidar.Text,
                Location = button_btnValidar.Location,
                Size = button_btnValidar.Size
            };
            this.Controls.Remove(button_btnValidar);
            this.Controls.Add(button_btnValidarRJ);
            button_btnValidarRJ.Click += button_btnValidar_Click;
            button_btnValidar = button_btnValidarRJ;

            // Substitui button_carregar_arquivo_validar por RJButton - Em tempo de execução
            var button_carregar_arquivo_validarRJ = new RJButton 
            {
                Text = button_carregar_arquivo_validar.Text,
                Location = button_carregar_arquivo_validar.Location,
                Size = button_carregar_arquivo_validar.Size
            };
            this.Controls.Remove(button_carregar_arquivo_validar);
            this.Controls.Add(button_carregar_arquivo_validarRJ);
            button_carregar_arquivo_validarRJ.Click += button_carregar_arquivo_validar_Click;
            button_carregar_arquivo_validar = button_carregar_arquivo_validarRJ;

            // Substitui button_btnReparar por RJButton - Em tempo de execução
            var button_btnRepararRJ = new RJButton 
            {
                Text = button_btnReparar.Text,
                Location = button_btnReparar.Location,
                Size = button_btnReparar.Size
            };
            this.Controls.Remove(button_btnReparar);
            this.Controls.Add(button_btnRepararRJ);
            button_btnRepararRJ.Click += button_btnReparar_Click;
            button_btnReparar = button_btnRepararRJ;

            // Substitui button_carregar_arquivo_reparar por RJButton - Em tempo de execução
            var button_carregar_arquivo_repararRJ = new RJButton 
            {
                Text = button_carregar_arquivo_reparar.Text,
                Location = button_carregar_arquivo_reparar.Location,
                Size = button_carregar_arquivo_reparar.Size
            };
            this.Controls.Remove(button_carregar_arquivo_reparar);
            this.Controls.Add(button_carregar_arquivo_repararRJ);
            button_carregar_arquivo_repararRJ.Click += button_carregar_arquivo_reparar_Click;
            button_carregar_arquivo_reparar = button_carregar_arquivo_repararRJ;

            // Substitui button_btnComparar por RJButton - Em tempo de execução
            var button_btnCompararRJ = new RJButton
            {
                Text = button_btnComparar.Text,
                Location = button_btnComparar.Location,
                Size = button_btnComparar.Size
            };
            this.Controls.Remove(button_btnComparar);
            this.Controls.Add(button_btnCompararRJ);
            button_btnCompararRJ.Click += button_btnComparar_Click;
            button_btnComparar = button_btnCompararRJ;

            // Substitui button_carregar_arquivo_comparar por RJButton - Em tempo de execução
            var button_carregar_arquivo_compararRJ = new RJButton 
            {
                Text = button_carregar_arquivo_comparar.Text,
                Location = button_carregar_arquivo_comparar.Location,
                Size = button_carregar_arquivo_comparar.Size
            };
            this.Controls.Remove(button_carregar_arquivo_comparar);
            this.Controls.Add(button_carregar_arquivo_compararRJ);
            button_carregar_arquivo_compararRJ.Click += button_carregar_arquivo_comparar_Click;
            button_carregar_arquivo_comparar = button_carregar_arquivo_compararRJ;
        }

        private void button_btnValidar_Click(object sender, EventArgs e) 
        {
            string path = txtArquivoValidar.Text;
            if (!File.Exists(path)) { MessageBox.Show("Arquivo não encontrado."); return; }

            using FileStream fs = new(path, FileMode.Open);
            using BinaryReader br = new(fs);

            int timestamp = br.ReadInt32();
            int itemCount = br.ReadInt32();
            StringBuilder log = new();
            log.AppendLine($"Timestamp: {timestamp} | Itens: {itemCount}");

            for (int i = 0; i < itemCount; i++)
            {
                br.BaseStream.Seek(1 + 4 + 4 + 4 + 128 + 4 + 4, SeekOrigin.Current);
                for (int s = 0; s < 4; s++) br.BaseStream.Seek(4 * 8, SeekOrigin.Current);
                byte[] name = br.ReadBytes(64);
                string nomeItem = Encoding.Unicode.GetString(name).Replace("\0", "").Trim();
                if (string.IsNullOrWhiteSpace(nomeItem))
                    log.AppendLine($"Item {i} com nome vazio.");
                br.BaseStream.Seek(4 * 12, SeekOrigin.Current);
            }

            txtResultadoValidar.Text = log.ToString();
        }

        private void button_btnReparar_Click(object sender, EventArgs e) 
        {
            string origem = txtArquivoOrigem.Text;
            string destino = txtArquivoDestino.Text;

            if (!File.Exists(origem)) { MessageBox.Show("Arquivo de origem não encontrado."); return; }
            if (string.IsNullOrWhiteSpace(destino)) { MessageBox.Show("Informe um caminho de destino."); return; }
            if (Directory.Exists(destino))
            {
                MessageBox.Show("O destino informado é um diretório. Indique um arquivo (ex.: C:\\pasta\\arquivo.data).");
                return;
            }

            try
            {
                using FileStream fsIn = new(origem, FileMode.Open, FileAccess.Read);
                using BinaryReader br = new(fsIn);

                // tenta criar diretório pai se necessário
                string parent = Path.GetDirectoryName(destino);
                if (!string.IsNullOrEmpty(parent) && !Directory.Exists(parent))
                    Directory.CreateDirectory(parent);

                using FileStream fsOut = new(destino, FileMode.Create, FileAccess.Write);
                using BinaryWriter bw = new(fsOut);

                bw.Write(br.ReadInt32());
                int itemCount = br.ReadInt32();
                bw.Write(itemCount);

                for (int i = 0; i < itemCount; i++)
                {
                    bw.Write(br.ReadBoolean());
                    bw.Write(br.ReadInt32());
                    bw.Write(br.ReadInt32());
                    bw.Write(br.ReadInt32());
                    bw.Write(br.ReadBytes(128));
                    bw.Write(br.ReadInt32());
                    bw.Write(br.ReadInt32());

                    for (int s = 0; s < 4; s++)
                        for (int f = 0; f < 8; f++)
                            bw.Write(br.ReadInt32());

                    bw.Write(br.ReadBytes(1024));
                    byte[] name = br.ReadBytes(64);
                    string nome = Encoding.Unicode.GetString(name).Replace("\0", "").Trim();
                    if (string.IsNullOrWhiteSpace(nome))
                    {
                        nome = $"Item_{i}";
                        name = Encoding.Unicode.GetBytes(nome);
                        Array.Resize(ref name, 64);
                    }
                    bw.Write(name);

                    for (int n = 0; n < 12; n++) bw.Write(br.ReadInt32());
                }

                for (int c = 0; c < 8; c++)
                {
                    byte[] cat = br.ReadBytes(128);
                    string nomeCat = Encoding.Unicode.GetString(cat).Replace("\0", "").Trim();
                    if (string.IsNullOrWhiteSpace(nomeCat))
                    {
                        nomeCat = $"Categoria_{c}";
                        cat = Encoding.Unicode.GetBytes(nomeCat);
                        Array.Resize(ref cat, 128);
                    }
                    bw.Write(cat);

                    int subCount = br.ReadInt32();
                    bw.Write(subCount);
                    for (int s = 0; s < subCount; s++)
                    {
                        byte[] sub = br.ReadBytes(128);
                        string nomeSub = Encoding.Unicode.GetString(sub).Replace("\0", "").Trim();
                        if (string.IsNullOrWhiteSpace(nomeSub))
                        {
                            nomeSub = $"Sub_{s}";
                            sub = Encoding.Unicode.GetBytes(nomeSub);
                            Array.Resize(ref sub, 128);
                        }
                        bw.Write(sub);
                    }
                }

                MessageBox.Show("Arquivo reparado com sucesso.");
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"Acesso negado ao criar o arquivo de destino: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao reparar arquivo: {ex.Message}");
            }
        }

        private void button_btnComparar_Click(object sender, EventArgs e) 
        {
            string file1 = txtArquivo1.Text;
            string file2 = txtArquivo2.Text;
            if (!File.Exists(file1) || !File.Exists(file2)) { MessageBox.Show("Arquivos não encontrados."); return; }

            byte[] bytes1 = File.ReadAllBytes(file1);
            byte[] bytes2 = File.ReadAllBytes(file2);
            int minLength = Math.Min(bytes1.Length, bytes2.Length);
            int diffs = 0;
            StringBuilder log = new();

            for (int i = 0; i < minLength; i++)
            {
                if (bytes1[i] != bytes2[i])
                {
                    log.AppendLine($"Byte {i}: {bytes1[i]:X2} vs {bytes2[i]:X2}");
                    diffs++;
                }
            }

            if (bytes1.Length != bytes2.Length)
                log.AppendLine($"Tamanhos diferentes: {bytes1.Length} vs {bytes2.Length}");

            log.AppendLine($"Total de diferenças: {diffs}");
            txtResultadoComparar.Text = log.ToString();
        }

        private void button_carregar_arquivo_validar_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "Selecione o arquivo gshop.data",
                Filter = "Arquivos GSHOP (*.data)|*.data|Todos os arquivos (*.*)|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Mostra o caminho selecionado na TextBox
                txtArquivoValidar.Text = ofd.FileName;

                // Opcional: já carrega informações básicas do arquivo
                try
                {
                    using FileStream fs = new(ofd.FileName, FileMode.Open, FileAccess.Read);
                    using BinaryReader br = new(fs);

                    int timestamp = br.ReadInt32();
                    int itemCount = br.ReadInt32();

                    StringBuilder log = new();
                    log.AppendLine($"Arquivo selecionado: {Path.GetFileName(ofd.FileName)}");
                    log.AppendLine($"Caminho completo: {ofd.FileName}");
                    log.AppendLine($"Timestamp: {timestamp}");
                    log.AppendLine($"Itens declarados: {itemCount}");

                    txtResultadoValidar.Text = log.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao abrir arquivo: {ex.Message}");
                }
            }
        }

        private void button_carregar_arquivo_reparar_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "Selecione o arquivo gshop.data",
                Filter = "Arquivos GSHOP (*.data)|*.data|Todos os arquivos (*.*)|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };

            if (ofd.ShowDialog() != DialogResult.OK) return;
            
            txtArquivoOrigem.Text = ofd.FileName;

            string dir = Path.GetDirectoryName(ofd.FileName) ?? "";
            string name = Path.GetFileNameWithoutExtension(ofd.FileName);
            string ext = Path.GetExtension(ofd.FileName);
            txtArquivoDestino.Text = Path.Combine(dir, $"{name}_repaired{ext}");
        }

        private bool primeiroArquivoSelecionado = false;
        private void button_carregar_arquivo_comparar_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "Selecione os dois arquivos gshop.data para comparar",
                Filter = "Arquivos GSHOP (*.data)|*.data|Todos os arquivos (*.*)|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                //Multiselect = true
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (!primeiroArquivoSelecionado)
                {
                    // Primeira vez → joga no txtBox4 (txtArquivo1)
                    txtArquivo1.Text = ofd.FileName;
                    primeiroArquivoSelecionado = true;
                }
                else
                {
                    // Segunda vez → joga no txtBox5 (txtArquivo2)
                    txtArquivo2.Text = ofd.FileName;
                    primeiroArquivoSelecionado = false;
                }
                /*
                // Opcional: já carrega informações básicas do arquivo no richTextBox1
                try
                {
                    using FileStream fs = new(ofd.FileName, FileMode.Open, FileAccess.Read);
                    using BinaryReader br = new(fs);

                    int timestamp = br.ReadInt32();
                    int itemCount = br.ReadInt32();

                    StringBuilder log = new();
                    log.AppendLine($"Arquivo selecionado: {Path.GetFileName(ofd.FileName)}");
                    log.AppendLine($"Caminho completo: {ofd.FileName}");
                    log.AppendLine($"Timestamp: {timestamp}");
                    log.AppendLine($"Itens declarados: {itemCount}");

                    txtResultadoValidar.Text = log.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao abrir arquivo: {ex.Message}");
                }
                */
            }
        }
    }
}
