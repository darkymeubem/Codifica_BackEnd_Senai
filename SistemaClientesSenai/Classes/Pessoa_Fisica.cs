using SistemaClientesSenai.Classes;
using System;

namespace SistemaClientesSenai.Classes
{
    public class Pessoa_Fisica : Clientes
    {
        private string _cpf;
        private string _rg;

        public string Cpf
        {
            get => _cpf;
            set
            {
                var cpfSemFormatacao = value.Replace(".", "").Replace("-", "").Replace(" ", "");
                if (cpfSemFormatacao.Length != 11 || !long.TryParse(cpfSemFormatacao, out _))
                {
                    throw new ArgumentException("CPF inválido. Deve conter 11 dígitos numéricos.");
                }
                _cpf = cpfSemFormatacao;
            }
        }

        public string Rg
        {
            get => _rg;
            set
            {
                var rgSemFormatacao = value.Replace(".", "").Replace("-", "").Replace(" ", "");
                if (rgSemFormatacao.Length != 9 || !long.TryParse(rgSemFormatacao, out _))
                {
                    throw new ArgumentException("RG inválido. Deve conter 9 dígitos numéricos.");
                }
                _rg = rgSemFormatacao;
            }
        }

        public DateTime DataNascimento { get; set; }

        public Pessoa_Fisica(string nome, string endereco, string cpf, string rg, DateTime dataNascimento)
            : base(nome, endereco)
        {
            Cpf = cpf;
            Rg = rg;
            DataNascimento = dataNascimento;
        }

        public override void Pagar_Imposto(float valor)
        {
            montante = valor;
            taxaImposto = montante * 0.15f;
            valorTotal = montante + taxaImposto;

            Console.WriteLine("\n--- Dados do Pagamento PF ---");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"CPF: {Cpf}");
            Console.WriteLine($"Valor a ser pago: {montante:C}");
            Console.WriteLine($"Valor do Imposto (15%): {taxaImposto:C}");
            Console.WriteLine($"Valor Total com Imposto: {valorTotal:C}");
        }
    }
}
