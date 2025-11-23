using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LHPet.Models;

namespace LHPet.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        //instâncias de clientes - simulação de dados/sgbd
        Cliente cliente1 = new Cliente(01, "Matt Ribeiro", "123.456.789-00", "email.email@gmail.com", "Rex");
        Cliente cliente2 = new Cliente(02, "Ana Silva", "987.654.321-00", "ana.silva@email.com", "Bolt");
        Cliente cliente3 = new Cliente(03, "Carlos Souza", "456.789.123-00", "carlos.souza@email.com", "Luna");
        Cliente cliente4 = new Cliente(04, "Fernanda Lima", "321.654.987-00", "fernanda.lima@email.com", "Max");
        Cliente cliente5 = new Cliente(05, "João Pedro", "789.123.456-00", "joao.pedro@email.com", "Mel");

        //LISTA CLIENTES
        List<Cliente> listaClientes = new List<Cliente>();
        //adiciona clientes na lista
        listaClientes.Add(cliente1);
        listaClientes.Add(cliente2);
        listaClientes.Add(cliente3);
        listaClientes.Add(cliente4);
        listaClientes.Add(cliente5);

        ViewBag.listaClientes = listaClientes;

        Fornecedor fornecedor1 = new Fornecedor(01, "PetShop Central", "12.345.678/0001-00", "contato@petshopcentral.com");
        Fornecedor fornecedor2 = new Fornecedor(02, "Rações Boa Vida", "98.765.432/0001-11", "vendas@racoesboavida.com");
        Fornecedor fornecedor3 = new Fornecedor(03, "Clínica Animal", "23.456.789/0001-22", "suporte@clinicaanimal.com");
        Fornecedor fornecedor4 = new Fornecedor(04, "PetBrinquedos", "87.654.321/0001-33", "info@petbrinquedos.com");
        Fornecedor fornecedor5 = new Fornecedor(05, "Banho&Tosa Feliz", "34.567.890/0001-44", "atendimento@banhoetosafeliz.com");

        //LISTA FORNECEDORES
        List<Fornecedor> listaFornecedores = new List<Fornecedor>();
        //adiciona fornecedores na lista
        listaFornecedores.Add(fornecedor1);
        listaFornecedores.Add(fornecedor2);
        listaFornecedores.Add(fornecedor3);
        listaFornecedores.Add(fornecedor4);
        listaFornecedores.Add(fornecedor5);

        ViewBag.listaFornecedores = listaFornecedores;

        return View();
    }

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
