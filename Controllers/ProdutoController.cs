using Microsoft.AspNetCore.Mvc;
using Loja.Models;
using System.Text;
using System.Text.Json;

namespace Loja.Controllers
{
    public class ProdutoController : Controller
    {
        // Lista estática de produtos (simulando banco de dados)
        private static List<Produto> produtos = new List<Produto>
        {
            new Produto { Id = 1, Nome = "Smartphone", Preco = 2500, Categoria = "Eletrônicos", EmEstoque = true, DataCadastro = DateTime.Now },
            new Produto { Id = 2, Nome = "Notebook", Preco = 4500, Categoria = "Eletrônicos", EmEstoque = false, DataCadastro = DateTime.Now },
            new Produto { Id = 3, Nome = "Camiseta", Preco = 80, Categoria = "Roupas", EmEstoque = true, DataCadastro = DateTime.Now },
            new Produto { Id = 4, Nome = "Calça", Preco = 150, Categoria = "Roupas", EmEstoque = true, DataCadastro = DateTime.Now },
            new Produto { Id = 5, Nome = "Romance", Preco = 45, Categoria = "Livros", EmEstoque = true, DataCadastro = DateTime.Now },
            new Produto { Id = 6, Nome = "Técnico", Preco = 120, Categoria = "Livros", EmEstoque = false, DataCadastro = DateTime.Now }
        };

    
        // A) ViewResult Actions
        // Lista todos os produtos
        public IActionResult Index()
        {
            return View(produtos);
        }

        // Mostra os detalhes de um produto
        public IActionResult Detalhes(int id)
        {
            var produto = produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null) return NotFound();
            return View(produto);
        }

        // Filtra produtos por categoria
        public IActionResult Categoria(string categoria)
        {
            var produtosFiltrados = produtos.Where(p => p.Categoria == categoria).ToList();
            ViewBag.Categoria = categoria;
            return View(produtosFiltrados);
        }

      
        // B) JsonResult Actions
        // Retorna todos os produtos em JSON
        public JsonResult ObterProdutosJson()
        {
            return Json(new { sucesso = true, dados = produtos });
        }

        // Retorna um produto específico em JSON
        public JsonResult BuscarProduto(int id)
        {
            var produto = produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
                return Json(new { sucesso = false, mensagem = "Produto não encontrado" });

            return Json(new { sucesso = true, dados = produto });
        }

        // Retorna produtos filtrados em JSON
        public JsonResult ProdutosPorCategoria(string categoria)
        {
            var produtosFiltrados = produtos.Where(p => p.Categoria == categoria).ToList();
            return Json(new { sucesso = true, dados = produtosFiltrados });
        }

    
        // C) FileResult Actions
        // Exporta produtos para CSV
        public FileResult ExportarCsv()
        {
            var conteudo = new StringBuilder();
            conteudo.AppendLine("Id,Nome,Preco,Categoria,EmEstoque,DataCadastro");

            foreach (var produto in produtos)
            {
                conteudo.AppendLine($"{produto.Id},{produto.Nome},{produto.Preco},{produto.Categoria},{produto.EmEstoque},{produto.DataCadastro:dd/MM/yyyy}");
            }

            var bytes = Encoding.UTF8.GetBytes(conteudo.ToString());
            return File(bytes, "text/csv", "produtos.csv");
        }

        // Gera relatório em TXT
        public FileResult RelatorioTxt()
        {
            var totalProdutos = produtos.Count;
            var produtosPorCategoria = produtos.GroupBy(p => p.Categoria)
                                               .Select(g => $"{g.Key}: {g.Count()} produtos");

            var conteudo = new StringBuilder();
            conteudo.AppendLine("RELATÓRIO DE PRODUTOS");
            conteudo.AppendLine($"Total de produtos: {totalProdutos}");
            conteudo.AppendLine("Produtos por categoria:");
            foreach (var linha in produtosPorCategoria) conteudo.AppendLine(linha);

            var bytes = Encoding.UTF8.GetBytes(conteudo.ToString());
            return File(bytes, "text/plain", "relatorio.txt");
        }

        // Exporta produtos para JSON em arquivo
        public FileResult ExportarJson()
        {
            var json = JsonSerializer.Serialize(produtos, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            var bytes = Encoding.UTF8.GetBytes(json);
            return File(bytes, "application/json", "produtos.json");
        }
    }
}

