using System;
using System.IO;
using System.Text;

class LeitorGSHOPedit
{
    static string ReadFixedString(BinaryReader br, int byteSize)
    {
        byte[] buffer = br.ReadBytes(byteSize);
        return Encoding.Unicode.GetString(buffer).TrimEnd('\0');
    }

    static void Main(string[] args) 
    {
        string path = "gshop.data";

        if (!File.Exists(path))
        {
            Console.WriteLine("Arquivo não encontrado.");
            return;
        }

        using FileStream fs = File.OpenRead(path);
        using BinaryReader br = new(fs);

        int timestamp = br.ReadInt32();
        int itemCount = br.ReadInt32();

        Console.WriteLine($"Timestamp: {timestamp}");
        Console.WriteLine($"Item Count: {itemCount}");
        Console.WriteLine($"Tamanho do arquivo: {fs.Length} bytes\n");

        // Listar itens
        Console.WriteLine("Itens:");
        for (int i = 0; i < itemCount; i++)
        {
            bool activate = br.ReadBoolean();
            int shop_id = br.ReadInt32();
            int cat_index = br.ReadInt32();
            int sub_cat_index = br.ReadInt32();
            br.ReadBytes(128); // surface
            int item_id = br.ReadInt32();
            int item_amount = br.ReadInt32();

            for (int n = 0; n < 32; n++) br.ReadInt32();

            string description = ReadFixedString(br, 1024);
            string name = ReadFixedString(br, 64);

            for (int n = 0; n < 12; n++) br.ReadInt32();

            Console.WriteLine($"[{i}] ID={item_id}, Nome='{name}', Qtd={item_amount}, Cat={cat_index}, SubCat={sub_cat_index}");
        }

        // Categorias
        Console.WriteLine("\nCategorias:");
        for (int i = 0; i < 8; i++)
        {
            if (fs.Position + 128 + 4 <= fs.Length)
            {
                string catName = ReadFixedString(br, 128);
                int subCount = br.ReadInt32();
                Console.WriteLine($"Categoria {i}: Nome='{catName}', SubCount={subCount}");

                for (int j = 0; j < subCount; j++)
                {
                    if (fs.Position + 128 <= fs.Length)
                    {
                        string subCatName = ReadFixedString(br, 128);
                        Console.WriteLine($"   Subcategoria {j}: Nome='{subCatName}'");
                    }
                }
            }
        }

        // Bloco extra
        long remaining = fs.Length - fs.Position;
        if (remaining > 0)
        {
            Console.WriteLine($"\nBloco extra detectado: {remaining} bytes após categorias.");
        }
        else
        {
            Console.WriteLine("\nNenhum bloco extra detectado.");
        }
    }
}

