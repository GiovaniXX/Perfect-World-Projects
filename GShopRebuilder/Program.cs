using System;
using System.IO;
using System.Text;

class GShopRebuilder
{
    static string ReadFixedString(BinaryReader br, int byteSize)
    {
        byte[] buffer = br.ReadBytes(byteSize);
        return Encoding.Unicode.GetString(buffer).TrimEnd('\0');
    }

    static void WriteFixedString(BinaryWriter bw, string value, int byteSize)
    {
        int charCount = byteSize / 2;
        string padded = value.PadRight(charCount, '\0');
        byte[] buffer = new byte[byteSize];
        Encoding.Unicode.GetBytes(padded, 0, charCount, buffer, 0);
        bw.Write(buffer);
    }

    static void Main(string[] args)
    {
        string inputPath = "gshop.data";
        string outputPath = "gshop_limpo.data";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Arquivo não encontrado.");
            return;
        }

        using FileStream fsIn = File.OpenRead(inputPath);
        using BinaryReader br = new(fsIn);
        using FileStream fsOut = File.Create(outputPath);
        using BinaryWriter bw = new(fsOut);

        // Cabeçalho original
        int timestamp = br.ReadInt32();
        int itemCount = br.ReadInt32();
        bw.Write(timestamp);
        bw.Write(itemCount);

        // Copiar todos os itens exatamente como estão
        for (int i = 0; i < itemCount; i++)
        {
            bool activate = br.ReadBoolean();
            int shop_id = br.ReadInt32();
            int cat_index = br.ReadInt32();
            int sub_cat_index = br.ReadInt32();
            byte[] surface = br.ReadBytes(128);
            int item_id = br.ReadInt32();
            int item_amount = br.ReadInt32();

            int[] sale = new int[32];
            for (int n = 0; n < 32; n++) sale[n] = br.ReadInt32();

            string description = ReadFixedString(br, 1024);
            string name = ReadFixedString(br, 64);

            int gift_id = br.ReadInt32();
            int gift_amount = br.ReadInt32();
            int gift_duration = br.ReadInt32();
            int log_price = br.ReadInt32();
            int[] npcs = new int[8];
            for (int n = 0; n < 8; n++) npcs[n] = br.ReadInt32();

            // Grava exatamente como lido
            bw.Write(activate);
            bw.Write(shop_id);
            bw.Write(cat_index);
            bw.Write(sub_cat_index);
            bw.Write(surface);
            bw.Write(item_id);
            bw.Write(item_amount);
            foreach (int val in sale) bw.Write(val);
            WriteFixedString(bw, description, 1024);
            WriteFixedString(bw, name, 64);
            bw.Write(gift_id);
            bw.Write(gift_amount);
            bw.Write(gift_duration);
            bw.Write(log_price);
            foreach (int npc in npcs) bw.Write(npc);
        }

        // Categorias: sempre 8, cada uma com 256 subcategorias
        for (int i = 0; i < 8; i++)
        {
            string catName = ReadFixedString(br, 128);
            int subCount = br.ReadInt32();

            if (string.IsNullOrWhiteSpace(catName))
                catName = $"Categoria {i}";

            // Forçar subCount = 256 para compatibilidade
            subCount = 256;

            WriteFixedString(bw, catName, 128);
            bw.Write(subCount);

            for (int j = 0; j < 256; j++)
            {
                string subCatName = ReadFixedString(br, 128);
                if (string.IsNullOrWhiteSpace(subCatName))
                    subCatName = "";
                WriteFixedString(bw, subCatName, 128);
            }
        }

        // Copiar bloco extra final (assinatura de versão)
        long remaining = fsIn.Length - fsIn.Position;
        if (remaining > 0)
        {
            byte[] extra = br.ReadBytes((int)remaining);
            bw.Write(extra);
            Console.WriteLine($"Bloco extra de {remaining} bytes preservado.");
        }

        Console.WriteLine($"✅ Arquivo reconstruído: {outputPath} com {itemCount} itens, 8 categorias e 256 subcategorias cada.");
    }
}
