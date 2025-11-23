using System;

namespace SistemaClientesSenai.Classes
{
    public class Pessoa_Juridica : Clientes
    {
        private string _cnpj;
        private string _ie;

        public string Cnpj
        {
            get => _cnpj;
            set
            {
                var cnpjSemFormatacao = value.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "");
                if (cnpjSemFormatacao.Length != 14 || !long.TryParse(cnpjSemFormatacao, out _))
                    throw new ArgumentException("CNPJ inválido. Deve conter 14 dígitos numéricos.");
                _cnpj = cnpjSemFormatacao;
            }
        }

        public string Ie
        {
            get => _ie;
            set
            {
                var ieSemFormatacao = value.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "");
                if (ieSemFormatacao.Length < 9 || ieSemFormatacao.Length > 12 || !long.TryParse(ieSemFormatacao, out _))
                    throw new ArgumentException("Inscrição Estadual inválida. Deve conter entre 9 e 12 dígitos numéricos.");
                _ie = ieSemFormatacao;
            }
        }

        public Pessoa_Juridica(string nome, string endereco, string cnpj, string ie)
            : base(nome, endereco)
        {
            Cnpj = cnpj;
            Ie = ie;
        }

        public override void Pagar_Imposto(float valor)
        {
            montante = valor;
            taxaImposto = montante * 0.05f;
            valorTotal = montante + taxaImposto;

            Console.WriteLine("\n--- Pagamento PJ ---");
            Console.WriteLine($"Empresa: {Nome}");
            Console.WriteLine($"CNPJ: {Cnpj}");
            Console.WriteLine($"Valor: {montante:C}");
            Console.WriteLine($"Imposto (5%): {taxaImposto:C}");
            Console.WriteLine($"Total: {valorTotal:C}");
        }
    }
}
