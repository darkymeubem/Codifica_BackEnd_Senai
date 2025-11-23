namespace SistemaClientesSenai.Classes
{
    public class Clientes
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }

        protected float montante;
        protected float taxaImposto;
        protected float valorTotal;

        public Clientes(string nome, string endereco)
        {
            Nome = nome;
            Endereco = endereco;
        }

        public virtual void Pagar_Imposto(float valor)
        {
            montante = valor;
            taxaImposto = montante * 0.10f;
            valorTotal = montante + taxaImposto;

            Console.WriteLine("\n--- Pagamento ---");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Valor: {montante:C}");
            Console.WriteLine($"Imposto (10%): {taxaImposto:C}");
            Console.WriteLine($"Total: {valorTotal:C}");
        }
    }
}
