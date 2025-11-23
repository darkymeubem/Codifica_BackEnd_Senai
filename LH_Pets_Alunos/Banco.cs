﻿using System.Data.SqlClient;

namespace Projeto_Web_Lh_Pets_versão_1
{
    class Banco
    {   

        private List<Clientes> listaClientes = new List<Clientes>();

        public List<Clientes> GetLista()
        {
            return listaClientes;
        }

        // Construtor que inicializa a conexão com o banco de dados e carrega os dados dos clientes
	
    
	public Banco()
        {
            try
            {
                Console.WriteLine("Iniciando conexão com o banco...");
                SqlConnectionStringBuilder construtorConexao = new SqlConnectionStringBuilder(
                    /*senha ficticia*/"User ID=x;Password=x;" +
                    "Server=localhost\\SQLEXPRESS;" +
                    "Database=vendas;" +
                    "Trusted_Connection=False;"
                );

                using (SqlConnection conexaoDb = new SqlConnection(construtorConexao.ConnectionString))
                {
                    Console.WriteLine("Abrindo conexão...");
                    conexaoDb.Open();
                    Console.WriteLine("Conexão aberta com sucesso!");

                    String consultaSql = "SELECT * FROM tblclientes";
                    using (SqlCommand cmdSql = new SqlCommand(consultaSql, conexaoDb))
                    {
                        using (SqlDataReader leitorDados = cmdSql.ExecuteReader())
                        {
                            Console.WriteLine("Lendo dados...");
                            int contador = 0;
                            while (leitorDados.Read())
                            {
                                listaClientes.Add(new Clientes()
                                {
                                    cpf_cnpj = leitorDados["cpf_cnpj"].ToString(),
                                    nome = leitorDados["nome"].ToString(),
                                    endereco = leitorDados["endereco"].ToString(),
                                    rg_ie = leitorDados["rg_ie"].ToString(),
                                    tipo = leitorDados["tipo"].ToString(),
                                    valor = (float)Convert.ToDecimal(leitorDados["valor"]),
                                    valor_imposto = (float)Convert.ToDecimal(leitorDados["valor_imposto"]),
                                    total = (float)Convert.ToDecimal(leitorDados["total"])
                                });
                                contador++;
                            }
                            Console.WriteLine($"Total de clientes lidos: {contador}");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao acessar o banco de dados:");
                Console.WriteLine(e.ToString());
            }
        }
	
  
 
	public String GetListaString()
	{
		string conteudoHtml = "<!DOCTYPE html>\n<html>\n<head>\n<meta charset='utf-8' />\n"+
                      "<title>Cadastro de Clientes</title>\n</head>\n<body>";
        conteudoHtml = conteudoHtml + "<b>   CPF / CNPJ    -      Nome    -    Endereço    -   RG / IE   -   Tipo  -   Valor   - Valor Imposto -   Total  </b>";

        int indice = 0;
        string corFundo = "", corTexto = "";

		foreach (Clientes cliente in GetLista())
                {

                    if (indice % 2 == 0)
                             {   corFundo = "#6f47ff"; corTexto = "white";}
                            else
                              {  corFundo = "#ffffff"; corTexto = "#6f47ff";}
                            indice++;


                    conteudoHtml = conteudoHtml + 
                   $"\n<br><div style='background-color:{corFundo};color:{corTexto};'>" +
                    cliente.cpf_cnpj + " - " + 
                    cliente.nome + " - " + cliente.endereco + " - " + cliente.rg_ie + " - " +
                    cliente.tipo + " - " + cliente.valor.ToString("C") + " - " + 
                    cliente.valor_imposto.ToString("C") + " - " + cliente.total.ToString("C") + "<br>"+
                     "</div>";
                }
		return conteudoHtml;
	}

	public void imprimirListaConsole(){

                Console.WriteLine("   CPF / CNPJ   " + " - " + "    Nome   " + 
                    " - " + "   Endereço   " + " - " + "  RG / IE  " + " - " +
                    "  Tipo " + " - " + "  Valor  " + " - " + "Valor Imposto" + 
                    " - " + "  Total  ");

                foreach (Clientes cliente in GetLista())
                {
                    Console.WriteLine(cliente.cpf_cnpj + " - " + 
                    cliente.nome + " - " + cliente.endereco + " - " + cliente.rg_ie + " - " +
                    cliente.tipo + " - " + cliente.valor.ToString("C") + " - " + 
                    cliente.valor_imposto.ToString("C") + " - " + cliente.total.ToString("C"));
                }
        }

        
    }
}