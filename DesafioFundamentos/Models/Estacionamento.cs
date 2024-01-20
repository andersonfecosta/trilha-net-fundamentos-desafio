namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 20;
        private decimal precoPorHora = 10;
        private decimal precoAssinaturaMensal = 50;
        private decimal limiteHorasSemCobranca = 12;
        private decimal limiteHorasCobrancaMeia = 20;
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

        public decimal LimiteHorasSemCobranca
        {
            get { return limiteHorasSemCobranca; }
            set { limiteHorasSemCobranca = value; }
        }

        public decimal LimiteHorasCobrancaMeia
        {
            get { return limiteHorasCobrancaMeia; }
            set { limiteHorasCobrancaMeia = value; }
        }

        private List<Usuario> usuarios = new List<Usuario>();

        public Estacionamento()
        {

        }

        public void EntrarNoEstacionamento()
        {
            Console.Clear();
            Console.WriteLine("Entrar no Estacionamento\n" +
                        "Digite seu CPF: ");
            string cpf = Console.ReadLine();

            Usuario usuario = usuarios.FirstOrDefault(u => u.CPF == cpf);

            if (usuario == null)
            {
                Console.WriteLine("Usuário não cadastrado. Cadastre-se primeiro.");
            }
            else
            {
                Console.Write("Digite a placa do veículo: ");
                string placaVeiculo = Console.ReadLine();
                if (ValidarPlacaVeiculo(placaVeiculo))
                {
                    Console.Write("Digite o modelo do veículo: ");
                    string modeloVeiculo = Console.ReadLine();
                    Console.Write("Digite a cor do veículo: ");
                    string corVeiculo = Console.ReadLine();
                    usuario.AdicionarVeiculo(placaVeiculo, modeloVeiculo, corVeiculo);
                    Console.WriteLine("Entrada realizada com sucesso. Pressione qualquer tecla para continuar.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Placa do veículo inválida. Entrada não realizada.");
                }
            }
        }   


        public void SairDoEstacionamento()
        {
            Console.Clear();
            Console.WriteLine("Sair do Estacionamento");

            Console.Write("Digite seu CPF: ");
            string cpf = Console.ReadLine();

            Usuario usuario = usuarios.FirstOrDefault(u => u.CPF == cpf);

            if (usuario != null)
            {
                Console.Write("Digite a placa do veículo: ");
                string placaVeiculo = Console.ReadLine();

                Veiculo veiculo = usuario.VeiculosEstacionados.FirstOrDefault(v => v.Placa == placaVeiculo);

                if (veiculo != null)
                {
                    Console.Write("Digite a quantidade de horas estacionado: ");
                    if (int.TryParse(Console.ReadLine(), out int horasEstacionado) && horasEstacionado >= 0)
                    {
                        decimal valorVeiculo = CalcularValorVeiculo(usuario, horasEstacionado);
                        usuario.RegistrarUtilizacao(veiculo, horasEstacionado, valorVeiculo);
                        usuario.RemoverVeiculo(placaVeiculo);

                        if (valorVeiculo > 0)
                        {
                            Console.WriteLine($"Retirada do veículo {veiculo.Modelo} (Placa: {placaVeiculo}, Cor: {veiculo.Cor}) para o usuário {usuario.Nome}");
                            Console.WriteLine($"Valor a ser pago: R$ {valorVeiculo}");
                            Console.WriteLine("Pressione qualquer tecla para continuar.");
                        }
                        else
                        {
                            Console.WriteLine($"Retirada do veículo {veiculo.Modelo} (Placa: {placaVeiculo}, Cor: {veiculo.Cor}) para o usuário {usuario.Nome}");
                            Console.WriteLine("Sem cobrança. Pressione qualquer tecla para continuar.");
                        }

                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Quantidade de horas inválida. Pressione qualquer tecla para continuar.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine($"Veículo com placa {placaVeiculo} não encontrado para o usuário {usuario.Nome}. Pressione qualquer tecla para continuar.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine($"Usuário com CPF {cpf} não encontrado. Pressione qualquer tecla para continuar.");
                Console.ReadKey();
            }
        }
        public void ListarVeiculosUsuario()
        {
            Console.Clear();
            Console.WriteLine("Lista de veículos");

            Console.Write("Digite seu CPF: ");
            string cpf = Console.ReadLine();
            Usuario usuario = usuarios.FirstOrDefault(u => u.CPF == cpf);

            if (usuario != null)
            {
                Console.WriteLine($"Veículos estacionados para {usuario.Nome}:");

                foreach (Veiculo veiculo in usuario.VeiculosEstacionados)
                {
                    Console.WriteLine($"  Placa: {veiculo.Placa}, Modelo: {veiculo.Modelo}, Cor: {veiculo.Cor}");
                }

                Console.WriteLine("Pressione qualquer tecla para continuar.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"Usuário com CPF {cpf} não encontrado.");
                Console.WriteLine("Pressione qualquer tecla para continuar.");
                Console.ReadKey();
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

            Console.WriteLine("Pressione qualquer tecla para continuar.");
            Console.ReadKey();
        }

        public void ListarUsuarios()
        {
            Console.WriteLine("Usuários Cadastrados:");
            
            foreach (Usuario usuario in usuarios)
            {
                Console.WriteLine($"Nome: {usuario.Nome}");                               
            }

            Console.WriteLine("Pressione qualquer tecla para continuar.");
            Console.ReadKey();
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
            Console.Clear();
            Console.WriteLine("Cadastro de Usuário:/n" +
                        "Informe seu nome:");
            string nome = Console.ReadLine();

            Console.WriteLine("Informe seu telefone:");
            string telefone = Console.ReadLine();

            Console.WriteLine("Informe seu CPF:");
            string cpf = Console.ReadLine();

            if (ValidarCpf(cpf))
            {
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
            else
            {
                Console.WriteLine("CPF inválido. Cadastro não realizado.");
            }
        }

        public Boolean ValidarCpf(string cpf) => cpf.Length == 11 && long.TryParse(cpf, out _);

        public bool ValidarPlacaVeiculo(string placa) => placa.Length == 7;
    }
}
