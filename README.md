# Atividade meramente educacional (ADS-IFRO)

# Loja - Sistema de Gerenciamento de Produtos

## Descrição
Este é um projeto ASP.NET Core MVC que demonstra o uso dos três principais tipos de **Actions**:  
- **ViewResult**  
- **JsonResult**  
- **FileResult**  

O sistema é um exemplo de **gerenciamento de produtos** para uma loja, permitindo:  
- Listar produtos  
- Visualizar detalhes  
- Filtrar por categoria  
- Exportar dados em CSV, TXT e JSON  
- Consultar dados via JSON (AJAX ou API)

---

## Tecnologias Utilizadas
- ASP.NET Core MVC (.NET 9.0)  
- C#  
- Razor Views  
- Bootstrap 5 (para estilização das Views)  

---

## Funcionalidades

### ViewResult
- `Index()` → Lista todos os produtos em tabela.  
- `Detalhes(int id)` → Exibe detalhes de um produto.  
- `Categoria(string categoria)` → Filtra produtos por categoria.  

### JsonResult
- `ObterProdutosJson()` → Retorna todos os produtos em JSON.  
- `BuscarProduto(int id)` → Retorna um produto específico em JSON.  
- `ProdutosPorCategoria(string categoria)` → Retorna produtos filtrados em JSON.  

### FileResult
- `ExportarCsv()` → Gera arquivo CSV com lista de produtos.  
- `RelatorioTxt()` → Gera relatório TXT com estatísticas de produtos.  
- `ExportarJson()` → Exporta todos os produtos em JSON.  

---

## Estrutura do Projeto


---

## Dados de Teste

Lista estática de produtos:

| Nome       | Categoria    | Preço  | Em Estoque |
|-----------|-------------|-------|------------|
| Smartphone | Eletrônicos | 2500  | Sim        |
| Notebook   | Eletrônicos | 4500  | Não        |
| Camiseta   | Roupas      | 80    | Sim        |
| Calça      | Roupas      | 150   | Sim        |
| Romance    | Livros      | 45    | Sim        |
| Técnico    | Livros      | 120   | Não        |

---

## Como Executar

1. Clonar o repositório:
```bash
git clone https://github.com/edinei101/Loja.git
