namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {            
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();

            if (!VeiculoEstacionado(placa))
            {
                veiculos.Add(placa);
                Console.WriteLine($"O veículo {placa} foi estacionado com sucesso.");
            }
            else
            {
                Console.WriteLine($"O veículo {placa} já está estacionado. Confira se digitou a placa corretamente");
            }
        }

        public void RemoverVeiculo()
        {                           
            Console.WriteLine("Digite a placa do veículo para remover:");       
            string placa = Console.ReadLine();

            if (VeiculoEstacionado(placa))
            {  
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                if (int.TryParse(Console.ReadLine(), out int horas) && horas >= 0)
                {
                    decimal valorTotal = CalcularValorTotal(horas);
                    veiculos.Remove(placa);
                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                else
                {
                    Console.WriteLine("Quantidade de horas inválida.");
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (String placa in veiculos)
                {
                    Console.WriteLine(placa);

                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        private bool VeiculoEstacionado(string placa)
        {
            return veiculos.Any(x => x.ToUpper() == placa.ToUpper());
        }

        private decimal CalcularValorTotal(int horas)
        {
            return precoInicial + (precoPorHora * horas);
        }
    }
}
