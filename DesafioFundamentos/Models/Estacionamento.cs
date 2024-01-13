namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<Usuario> usuarios = new List<Usuario>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void EntrarNoEstacionamento(Usuario usuario, string placaVeiculo)
        {
            if (!usuarios.Contains(usuario))
            {
                usuarios.Add(usuario);
            }

            usuario.AdicionarVeiculo(placaVeiculo);
        }


        public void SairDoEstacionamento(Usuario usuario, string placaVeiculo, int horasEstacionado)
        {
            Veiculo veiculo = usuario.VeiculosEstacionados.FirstOrDefault(v => v.Placa == placaVeiculo);

            if (veiculo != null)
            {
                decimal valorVeiculo = CalcularValorVeiculo(horasEstacionado);

                usuario.RemoverVeiculo(placaVeiculo);

                Console.WriteLine($"{usuario.Nome} retirou o veículo {veiculo.Modelo} (Placa: {placaVeiculo}, Cor: {veiculo.Cor}) - Valor a ser pago: R$ {valorVeiculo}");
            }
            else
            {
                Console.WriteLine($"Veículo com placa {placaVeiculo} não encontrado para o usuário {usuario.Nome}");
            }
        }

        public void ListarVeiculosEstacionados()
        {
            Console.WriteLine("Veículos estacionados:");
            
            foreach (Usuario usuario in usuarios)
            {
                Console.WriteLine($"Nome: {usuario.Nome}");
                
                foreach (Veiculo veiculo in usuario.VeiculosEstacionados)
                {
                    Console.WriteLine($"  Placa: {veiculo.Placa}, Modelo: {veiculo.Modelo}, Cor: {veiculo.Cor}");
                }
            }
        }

        private decimal CalcularValorVeiculo(int horas)
        {
            return precoInicial + (precoPorHora * horas);
        }

        public void CadastrarUsuario()
        {
            Console.WriteLine("Cadastro de Usuário:");
            Console.WriteLine("Informe seu nome:");
            string nome = Console.ReadLine();

            Console.WriteLine("Informe seu telefone:");
            string telefone = Console.ReadLine();

            Console.WriteLine("Informe seu CPF:");
            string cpf = Console.ReadLine();

            if (usuarios.Any(u => u.CPF == cpf))
            {
                Console.WriteLine("Usuário já cadastrado.");
            }
            else
            {
                Usuario novoUsuario = new Usuario(nome, telefone, cpf);
                usuarios.Add(novoUsuario);
                Console.WriteLine($"Usuário {nome} cadastrado com sucesso!");
            }
        }
    }
}
