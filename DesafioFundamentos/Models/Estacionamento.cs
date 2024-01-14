namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 20;
        private decimal precoPorHora = 10;
        private decimal precoAssinaturaMensal = 50;
        private int limiteHorasSemCobranca = 12;
        private int limiteHorasCobrancaMeia = 20;
        public decimal PrecoInicial
        {
            get { return precoInicial; }
            set { precoInicial = value; }
        }

        public decimal PrecoPorHora
        {
            get { return precoPorHora; }
            set { precoPorHora = value; }
        }

        public decimal PrecoAssinaturaMensal
        {
            get { return precoAssinaturaMensal; }
            set { precoAssinaturaMensal = value; }
        }

        public int LimiteHorasSemCobranca
        {
            get { return limiteHorasSemCobranca; }
            set { limiteHorasSemCobranca = value; }
        }

        public int LimiteHorasCobrancaMeia
        {
            get { return limiteHorasCobrancaMeia; }
            set { limiteHorasCobrancaMeia = value; }
        }

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
                decimal valorVeiculo = CalcularValorVeiculo(usuario, horasEstacionado);
                usuario.RegistrarUtilizacao(veiculo, horasEstacionado, valorVeiculo);
                usuario.RemoverVeiculo(placaVeiculo);
                if (valorVeiculo > 0)
                {
                    Console.WriteLine($"{usuario.Nome} retirou o veículo {veiculo.Modelo} (Placa: {placaVeiculo}, Cor: {veiculo.Cor}) - Valor a ser pago: R$ {valorVeiculo}");
                }
                else
                {
                    Console.WriteLine($"{usuario.Nome} retirou o veículo {veiculo.Modelo} (Placa: {placaVeiculo}, Cor: {veiculo.Cor}) - Sem cobrança");
                }
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

        private decimal CalcularValorVeiculo(Usuario usuario, int horasEstacionado)
        {
            bool assinante = usuario.AssinaturaMensal;

            if (assinante)
            {
                int horasTotais = horasEstacionado;

                foreach (var registro in usuario.registros)
                {
                    
                    horasTotais += registro.Horas;
                    
                }

                if (horasTotais <= limiteHorasSemCobranca)
                {
                    return 0;
                }
                else if (horasTotais <= limiteHorasCobrancaMeia)
                {
                    return precoPorHora * horasEstacionado / 2;
                }
                else
                {
                    return precoPorHora * horasEstacionado; 
                }
            }
            else
            {
                return precoInicial + precoPorHora * (horasEstacionado - 1); 
            }
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
