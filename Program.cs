using System;
using System.Collections.Generic;

namespace SimpleCRUD
{
    class Program
    {
        // Modelo de entidade
        public class Produto
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public decimal Preco { get; set; }
        }

        // Lista para armazenar produtos
        static List<Produto> produtos = new List<Produto>();
        static int proximoId = 1;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nCRUD de Produtos");
                Console.WriteLine("1. Criar");
                Console.WriteLine("2. Ler");
                Console.WriteLine("3. Atualizar");
                Console.WriteLine("4. Deletar");
                Console.WriteLine("5. Sair");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        CriarProduto();
                        break;
                    case "2":
                        LerProdutos();
                        break;
                    case "3":
                        AtualizarProduto();
                        break;
                    case "4":
                        DeletarProduto();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        static void CriarProduto()
        {
            Console.Write("Digite o nome do produto: ");
            string nome = Console.ReadLine();
            Console.Write("Digite o preço do produto: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal preco))
            {
                Console.WriteLine("Preço inválido!");
                return;
            }

            Produto produto = new Produto
            {
                Id = proximoId++,
                Nome = nome,
                Preco = preco
            };

            produtos.Add(produto);
            Console.WriteLine("Produto criado com sucesso!");
        }

        static void LerProdutos()
        {
            Console.WriteLine("\nLista de Produtos:");
            if (produtos.Count == 0)
            {
                Console.WriteLine("Nenhum produto cadastrado.");
                return;
            }

            foreach (var produto in produtos)
            {
                Console.WriteLine($"ID: {produto.Id}, Nome: {produto.Nome}, Preço: {produto.Preco:C}");
            }
        }

        static void AtualizarProduto()
        {
            Console.Write("Digite o ID do produto a ser atualizado: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido!");
                return;
            }

            Produto produto = produtos.Find(p => p.Id == id);
            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado.");
                return;
            }

            Console.Write("Digite o novo nome do produto (ou pressione Enter para manter o atual): ");
            string novoNome = Console.ReadLine();
            Console.Write("Digite o novo preço do produto (ou pressione Enter para manter o atual): ");
            string novoPreco = Console.ReadLine();

            if (!string.IsNullOrEmpty(novoNome))
            {
                produto.Nome = novoNome;
            }

            if (!string.IsNullOrEmpty(novoPreco) && decimal.TryParse(novoPreco, out decimal preco))
            {
                produto.Preco = preco;
            }

            Console.WriteLine("Produto atualizado com sucesso!");
        }

        static void DeletarProduto()
        {
            Console.Write("Digite o ID do produto a ser deletado: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido!");
                return;
            }

            Produto produto = produtos.Find(p => p.Id == id);
            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado.");
                return;
            }

            produtos.Remove(produto);
            Console.WriteLine("Produto deletado com sucesso!");
        }
    }
}

