using System;
using System.IO;
using System.Text;

class GShopGenerator
{
    static void Main()
    {
        string filePath = "gshop.data";
        using FileStream fs = new(filePath, FileMode.Create);
        using BinaryWriter bw = new(fs);

        // Timestamp (exemplo: 2025-11-22 11:03:08)
        bw.Write((int)(new DateTime(2025, 11, 22, 11, 3, 8).Subtract(new DateTime(1970, 1, 1))).TotalSeconds);

        // Quantidade de itens
        bw.Write(5);

        // Itens
        string[] itemNames = {
            "Pacote Giovani",
            "Pacote Giovani",
            "Pacote Giovani",
            "Pacote Giovani",
            "Baú Celestial"
        };
        string[] itemDescricoes = {
            "Um pacote especial contendo 500 unidades. Clique com o botão direito para abrir.",
            "Um pacote especial contendo 100 unidades. Clique com o botão direito para abrir.",
            "Um pacote especial contendo 50 unidades. Clique com o botão direito para abrir.",
            "Um pacote único contendo 1 unidade. Clique com o botão direito para abrir.",
            "Uma sacola misteriosa com diversos prêmios. Pode se transformar em vários itens."
        };
        string[] surfacePaths = {
            @"superficies\pacote_giovani500.dds",
            @"superficies\pacote_giovani100.dds",
            @"superficies\pacote_giovani50.dds",
            @"superficies\pacote_giovani1.dds",
            @"superficies\bau_celestial500.dds"
        };
        int[] itemAmounts = { 500, 100, 50, 1, 500 };
        int[] itemIDs = { 17309, 17309, 17309, 17309, 17725 };

        for (int i = 0; i < 5; i++)
        {
            bw.Write(true); // activate
            bw.Write(itemIDs[i]); // shop_id
            bw.Write(0); // cat_index (Categoria 0: Especial)
            bw.Write(0); // sub_cat_index (Subcategoria 0: Baús)

            // Superfície/ícone
            byte[] surfaceBytes = Encoding.Unicode.GetBytes(surfacePaths[i]);
            Array.Resize(ref surfaceBytes, 128);
            bw.Write(surfaceBytes);

            bw.Write(itemIDs[i]);     // item_id
            bw.Write(itemAmounts[i]); // item_amount

            // 4 opções de venda
            for (int s = 0; s < 4; s++)
            {
                bw.Write(100 * itemAmounts[i]); // preço base
                bw.Write(0); // expire_date
                bw.Write(0); // duration
                bw.Write(0); // start_date
                bw.Write(0); // control_type
                bw.Write(0); // day
                bw.Write(0); // status
                bw.Write(0); // flags
            }

            // Descrição em português
            byte[] descBytes = Encoding.Unicode.GetBytes(itemDescricoes[i]);
            Array.Resize(ref descBytes, 1024);
            bw.Write(descBytes);

            // Nome do item
            byte[] nameBytes = Encoding.Unicode.GetBytes(itemNames[i]);
            Array.Resize(ref nameBytes, 64);
            bw.Write(nameBytes);

            // Gift e log
            bw.Write(0); // gift_id
            bw.Write(0); // gift_amount
            bw.Write(0); // gift_duration
            bw.Write(0); // log_price

            // NPC sellers (8 ints)
            for (int n = 0; n < 8; n++)
            {
                bw.Write(0);
            }
        }

        // Categorias
        string[] categories = {
            "Especial", "Roupas", "Coroa", "Vôo", "Animais", "Pontos", "Auxiliar", "Outros"
        };

        for (int i = 0; i < categories.Length; i++)
        {
            byte[] catBytes = Encoding.Unicode.GetBytes(categories[i]);
            Array.Resize(ref catBytes, 128);
            bw.Write(catBytes);

            // Subcategorias: só a categoria 0 terá "Baús"
            if (i == 0)
            {
                bw.Write(1); // sub_cats_count
                byte[] subBytes = Encoding.Unicode.GetBytes("Baús");
                Array.Resize(ref subBytes, 128);
                bw.Write(subBytes);
            }
            else
            {
                bw.Write(0); // sub_cats_count
            }
        }

        Console.WriteLine("Arquivo gshop.data gerado com sucesso em português!");
    }
}

// :.Dev.: Giovani V. Chaves