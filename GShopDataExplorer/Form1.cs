using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace GShopDataExplorer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.listBoxItens.SelectedIndexChanged += new System.EventHandler(this.listBoxItens_SelectedIndexChanged);
        }

        private List<ItemData> itensCarregados = new List<ItemData>();

        private void validarEstruturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Aqui você chama a função de validação
            ValidarEstruturaGSHOP();
        }

        private void abrirArquivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // código para abrir arquivo
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "GShop Data (*.data)|*.data|Todos os arquivos (*.*)|*.*"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                CarregarArquivo(ofd.FileName);
            }
        }

        private void CarregarArquivo(string path)
        {
            itensCarregados.Clear();
            listBoxItens.Items.Clear();
            richTextBoxLog.Clear();
            Encoding enc = GetSelectedEncoding();

            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (BinaryReader br = new BinaryReader(fs))
            {
                while (fs.Position + 64 + 128 + 4 <= fs.Length)
                {
                    byte[] nomeBytes = br.ReadBytes(64);
                    Encoding gbk1 = Encoding.GetEncoding("GBK");
                    string nome = Encoding.Unicode.GetString(nomeBytes).TrimEnd('\0');

                    byte[] descBytes = br.ReadBytes(128);
                    Encoding gbk2 = Encoding.GetEncoding("GBK");
                    string descricao = Encoding.Unicode.GetString(descBytes).TrimEnd('\0');

                    int id = br.ReadInt32();

                    var item = new ItemData
                    {
                        Nome = nome,
                        Descricao = descricao,
                        ID = id
                    };

                    itensCarregados.Add(item);
                    listBoxItens.Items.Add(nome);
                }
            }
        }

        private void ValidarEstruturaGSHOP()
        {
            richTextBoxLog.AppendText("🔍 Validação de estrutura iniciada...\n");

            foreach (var item in listBoxItens.Items)
            {
                string nome = item.ToString();
                if (string.IsNullOrWhiteSpace(nome))
                    richTextBoxLog.AppendText("⚠ Item com nome vazio.\n");
                else
                    richTextBoxLog.AppendText($"✅ Item válido: {nome}\n");
                richTextBoxLog.AppendText($"✔ {itensCarregados.Count} itens carregados.\n");
            }
        }

        private void listBoxItens_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBoxItens.SelectedIndex;
            if (index >= 0 && index < itensCarregados.Count)
            {
                var item = itensCarregados[index];
                textBoxNome.Text = item.Nome;
                textBoxDescricao.Text = item.Descricao;
                textBoxID.Text = item.ID.ToString();
            }
        }

        private void buttonExportarCSV_Click(object sender, EventArgs e)
        {
            if (itensCarregados == null || itensCarregados.Count == 0)
            {
                MessageBox.Show("Nenhum item carregado para exportar.", "Exportação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Arquivo CSV (*.csv)|*.csv",
                FileName = "itens_exportados.csv"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Encoding enc = GetSelectedEncoding();
                    using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                    {
                        sw.WriteLine("Nome;Descrição;ID");

                        foreach (var item in itensCarregados)
                        {
                            string linha = $"{Sanitizar(item.Nome)};{Sanitizar(item.Descricao)};{item.ID}";
                            sw.WriteLine(linha);
                        }
                    }

                    MessageBox.Show("Exportação concluída com sucesso!", "Exportação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao exportar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string Sanitizar(string texto)
        {
            return texto.Replace(";", ",").Replace("\n", " ").Replace("\r", " ").Trim();
        }

        private Encoding GetSelectedEncoding()
        {
            switch (comboBoxEncoding.SelectedItem.ToString())
            {
                case "UTF-8":
                    return Encoding.UTF8;
                case "GBK (936)":
                    return Encoding.GetEncoding(936); // GBK
                default:
                    return Encoding.Unicode;
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
