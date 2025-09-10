using System;

namespace Loja.Models
{
    public class Produto
    {
        // Identificador do produto
        public int Id { get; set; }

        // Nome do produto
        public string Nome { get; set; } = string.Empty;

        // Preço do produto
        public decimal Preco { get; set; }

        // Categoria do produto (ex: Eletrônicos, Roupas, Livros)
        public string Categoria { get; set; } = string.Empty;

        // Indica se o produto está em estoque
        public bool EmEstoque { get; set; }

        // Data de cadastro do produto
        public DateTime DataCadastro { get; set; }
    }
}
