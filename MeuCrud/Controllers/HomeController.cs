using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MeuCrud.Models;

namespace MeuCrud.Controllers;

public class HomeController : Controller
{

    // Variável Global para acessar o Banco de Dados
    private BancoDados banco = new BancoDados();

    public IActionResult Index()
    {
        var lista = banco.PessoaDB.ToList(); // Seleciona todos os registros da tabela Pessoa

        ViewBag.Pessoas = lista; // Envia as informações para o arquivo Index.cshtml

        return View();
    }


    public IActionResult Adicionar(Pessoa input)
    {
        banco.PessoaDB.Add(input);

        banco.SaveChanges(); // Salva as alterações no banco de dados

        return RedirectToAction("Index"); // Vai para a função Index
    }


    public IActionResult Excluir(int Id)
    {
        // Localiza a pessoa que será excluída (pelo Id)
        var pessoa = banco.PessoaDB.Find(Id);

        if (pessoa != null)
        {
            banco.PessoaDB.Remove(pessoa);  // Remove o registro do banco de dados

            banco.SaveChanges(); // Salva as alterações no banco de dados
        }
        return RedirectToAction("Index");
    }


    public IActionResult Editar(int id)
    {
        var pessoa = banco.PessoaDB.Find(id);   // Localiza a pessoa que será editada (pelo Id)

        return View(pessoa);    // Envia as informações "dessa pessoa"para o arquivo Editar.cshtml
        // Por não ser uma ViewBag, mas sim um Model, é necessário informar o tipo Pessoa na View (Editar.cshtml)
    }

    [HttpPost]
    public IActionResult ConfirmarEdicao(Pessoa input)
    {
        banco.PessoaDB.Update(input); // Atualiza o registro no banco de dados

        banco.SaveChanges(); 

        return RedirectToAction("Index");
    }



    // --------------------------------------------------------------------------------

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
