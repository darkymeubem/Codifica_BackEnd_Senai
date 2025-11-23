using Projeto_Web_Lh_Pets_versão_1; // Adicione este using
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Projeto_Web_Lh_Pets_Alunos;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapGet("/", () => "Sistema Web Lh Pets - Versão 1.0");

        app.UseStaticFiles();
        app.MapGet("/Index", (HttpContext context) =>
        {
            context.Response.Redirect("/index.html");
            return Task.CompletedTask;
        });

        Banco bancoDados = new Banco();

        app.MapGet("/listaClientes", async (HttpContext context) =>
        {
            await context.Response.WriteAsync(bancoDados.GetListaString());
        });

        app.Run();
    }
}