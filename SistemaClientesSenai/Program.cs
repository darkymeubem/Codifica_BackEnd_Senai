using System;
using SistemaClientesSenai.Classes;

namespace SistemaClientesSenai
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Bem-vindo ao Sistema de Gestão de Clientes ClientLab");
            Console.WriteLine("-----------------------------------------------------");

            bool prosseguir = true;
            while (prosseguir)
            {
                Console.WriteLine("\nEscolha o tipo de cliente para cadastro:");
                Console.WriteLine("1 - Pessoa Física");
                Console.WriteLine("2 - Pessoa Jurídica");
                Console.WriteLine("3 - Sair");
                Console.Write("Escolha: ");
                string escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        CadastrarPessoaFisica();
                        break;
                    case "2":
                        CadastrarPessoaJuridica();
                        break;
                    case "3":
                        prosseguir = false;
                        Console.WriteLine("\nFinalizando o sistema...");
                        break;
                    default:
                        Console.WriteLine("\nEscolha inválida. Tente novamente.");
                        break;
                }
            }
        }

        private static string LerEntradaObrigatoria(string prompt)
        {
            string valorDigitado;
            do
            {
                Console.Write(prompt);
                valorDigitado = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(valorDigitado))
                    Console.WriteLine("Este campo é obrigatório. Por favor, preencha.");
            } while (string.IsNullOrWhiteSpace(valorDigitado));
            return valorDigitado;
        }

        public static void CadastrarPessoaFisica()
        {
            Console.WriteLine("\n--- Cadastro de Pessoa Física ---");

            string nome = LerEntradaObrigatoria("Nome: ");
            string endereco = LerEntradaObrigatoria("Endereço: ");

            string cpf;
            while (true)
            {
                cpf = LerEntradaObrigatoria("CPF (com ou sem formatação): ");
                try
                {
                    _ = new Pessoa_Fisica(nome, endereco, cpf, "000000000", DateTime.Now);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Aviso: {ex.Message}");
                }
            }

            string rg;
            while (true)
            {
                rg = LerEntradaObrigatoria("RG (com ou sem formatação): ");
                try
                {
                    _ = new Pessoa_Fisica(nome, endereco, cpf, rg, DateTime.Now);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Aviso: {ex.Message}");
                }
            }

            DateTime dataNascimento;
            while (true)
            {
                Console.Write("Data de Nascimento (dd/mm/aaaa): ");
                if (DateTime.TryParse(Console.ReadLine(), out dataNascimento))
                    break;
                Console.WriteLine("Data de nascimento inválida. Use o formato dd/mm/aaaa.");
            }

            try
            {
                Pessoa_Fisica pessoaFisica = new Pessoa_Fisica(nome, endereco, cpf, rg, dataNascimento);

                Console.WriteLine("\n--- Informações Cadastradas ---");
                Console.WriteLine($"Nome: {pessoaFisica.Nome}");
                Console.WriteLine($"Endereço: {pessoaFisica.Endereco}");
                Console.WriteLine($"CPF: {pessoaFisica.Cpf}");
                Console.WriteLine($"RG: {pessoaFisica.Rg}");
                Console.WriteLine($"Data de Nascimento: {pessoaFisica.DataNascimento.ToShortDateString()}");

                float montante;
                while (true)
                {
                    Console.Write("\nInforme um valor para simular o pagamento de imposto: ");
                    if (float.TryParse(Console.ReadLine(), out montante))
                        break;
                    Console.WriteLine("Aviso: Valor inválido. Por favor, informe apenas números.");
                }
                pessoaFisica.Pagar_Imposto(montante);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\nAviso ao cadastrar pessoa física: {ex.Message}");
                Console.WriteLine("Tente novamente, por favor.");
            }
        }

        public static void CadastrarPessoaJuridica()
        {
            Console.WriteLine("\n--- Cadastro de Pessoa Jurídica ---");

            string nome = LerEntradaObrigatoria("Nome da Empresa: ");
            string endereco = LerEntradaObrigatoria("Endereço: ");

            string cnpj;
            while (true)
            {
                cnpj = LerEntradaObrigatoria("CNPJ (com ou sem formatação): ");
                try
                {
                    _ = new Pessoa_Juridica(nome, endereco, cnpj, "000000000");
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Aviso: {ex.Message}");
                }
            }

            string ie;
            while (true)
            {
                ie = LerEntradaObrigatoria("Inscrição Estadual (com ou sem formatação): ");
                try
                {
                    _ = new Pessoa_Juridica(nome, endereco, cnpj, ie);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Aviso: {ex.Message}");
                }
            }

            try
            {
                Pessoa_Juridica pessoaJuridica = new Pessoa_Juridica(nome, endereco, cnpj, ie);

                Console.WriteLine("\n--- Informações Cadastradas ---");
                Console.WriteLine($"Nome da Empresa: {pessoaJuridica.Nome}");
                Console.WriteLine($"Endereço: {pessoaJuridica.Endereco}");
                Console.WriteLine($"CNPJ: {pessoaJuridica.Cnpj}");
                Console.WriteLine($"Inscrição Estadual: {pessoaJuridica.Ie}");

                float montante;
                while (true)
                {
                    Console.Write("\nInforme um valor para simular o pagamento de imposto: ");
                    if (float.TryParse(Console.ReadLine(), out montante))
                        break;
                    Console.WriteLine("Aviso: Valor inválido. Por favor, informe apenas números.");
                }
                pessoaJuridica.Pagar_Imposto(montante);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\nAviso ao cadastrar pessoa jurídica: {ex.Message}");
                Console.WriteLine("Tente novamente, por favor.");
            }
        }
    }
}
