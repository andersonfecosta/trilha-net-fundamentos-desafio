using DesafioFundamentos.Models;
using DesafioFundamentos.Utils;

namespace DesafioFundamentos.UI
{
    public class Menu
    {
        private Estacionamento estacionamento;
        private Autenticacao autenticacao;

        public Menu(Estacionamento estacionamento)
        {
            this.estacionamento = estacionamento;
            autenticacao = new Autenticacao();
        }

        public void ExibirMenu()
        {
            bool sair = false;

            do
            {
                Console.Clear();
                Console.WriteLine("Bem-vindo ao Estacionamento\n" +
                          "1 - Cadastrar Usuário\n" +
                          "2 - Entrar no Estacionamento\n" +
                          "3 - Sair do Estacionamento\n" +
                          "4 - Listar Veículos Estacionados\n" +
                          "5 - Entrar como Administrador\n" +
                          "6 - Sair\n" +
                          "Escolha uma opção: ");                                
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        CadastrarUsuario();
                        break;
                    case "2":
                        estacionamento.EntrarNoEstacionamento();
                        break;
                    case "3":
                        estacionamento.SairDoEstacionamento();
                        break;
                    case "4":
                        estacionamento.ListarVeiculosUsuario();
                        break;
                    case "5":
                        EntrarComoAdministrador();
                        break;
                    case "6":
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar.");
                        Console.ReadKey();
                        break;
                }
            } while (!sair);
        }
        private void CadastrarUsuario()
        {
            estacionamento.CadastrarUsuario();
            Console.WriteLine("Pressione qualquer tecla para continuar.");
            Console.ReadKey();
        }
        private void EntrarComoAdministrador()
        {
            Console.Clear();
            Console.Write("Digite o login: ");
            string login = Console.ReadLine();

            Console.Write("Digite a senha: ");
            string senha = Console.ReadLine();

            bool loginSucesso = autenticacao.EfetuarLogin(login, senha);

            if (loginSucesso)
            {
                MenuAdministrador();
            }
            else
            {
                Console.WriteLine("Credenciais incorretas. Pressione qualquer tecla para voltar ao menu principal.");
                Console.ReadKey();
            }
        }
        private void MenuAdministrador()
        {
            bool sair = false;

            do
            {
                Console.Clear();
                Console.WriteLine("Bem-vindo, Administrador\n" +
                            "1 - Visualizar Lista de Usuários\n" +
                            "2 - Visualizar Lista de Veículos Estacionados\n" +
                            "3 - Modificar Valores do Estacionamento\n" +
                            "4 - Voltar ao Menu Principal\n" +
                            "Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        estacionamento.ListarUsuarios();
                        break;
                    case "2":
                        estacionamento.ListarVeiculosEstacionados();
                        break;
                    case "3":
                        ModificarValoresEstacionamento();
                        break;
                    case "4":
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar.");
                        Console.ReadKey();
                        break;
                }
            } while (!sair);
        }        

        private void ModificarValoresEstacionamento()
        {
            Console.Clear();
            Console.WriteLine("Modificar Valores do Estacionamento\n" +
                        "1 - Modificar Preço Inicial\n" +
                        "2 - Modificar Preço por Hora\n" +
                        "3 - Modificar Preço Assinatura Mensal\n" +
                        "4 - Modificar Limite de Horas Sem Cobrança\n" +
                        "5 - Modificar Limite de Horas Cobrança Meia\n" +
                        "6 - Voltar ao Menu Administrador\n" +
                        "Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.WriteLine($"Valor atual: {estacionamento.PrecoInicial}");
                    Console.Write("Informe o novo valor para Preço Inicial: ");
                    if (ValidarNovoValor(Console.ReadLine(), out decimal novoPrecoInicial))
                    {
                        estacionamento.PrecoInicial = novoPrecoInicial;
                        Console.WriteLine("Preço Inicial modificado com sucesso. Pressione qualquer tecla para continuar.");
                        Console.ReadKey();
                    }
                    break;
                case "2":
                    Console.WriteLine($"Valor atual: {estacionamento.PrecoPorHora}");
                    Console.Write("Informe o novo valor para Preço por Hora: ");
                    if (ValidarNovoValor(Console.ReadLine(), out decimal novoPrecoPorHora))
                    {
                        estacionamento.PrecoPorHora = novoPrecoPorHora;
                        Console.WriteLine("Preço por Hora modificado com sucesso. Pressione qualquer tecla para continuar.");
                        Console.ReadKey();
                    }
                    break;
                case "3":
                    Console.WriteLine($"Valor atual: {estacionamento.PrecoAssinaturaMensal}");
                    Console.Write("Informe o novo valor para Preço Assinatura Mensal: ");
                    if (ValidarNovoValor(Console.ReadLine(), out decimal novoPrecoAssinaturaMensal))
                    {
                        estacionamento.PrecoAssinaturaMensal = novoPrecoAssinaturaMensal;
                        Console.WriteLine("Preço Assinatura Mensal modificado com sucesso. Pressione qualquer tecla para continuar.");
                        Console.ReadKey();
                    }
                    break;
                case "4":
                    Console.WriteLine($"Valor atual: {estacionamento.LimiteHorasSemCobranca}");
                    Console.Write("Informe o novo valor para Limite de Horas Sem Cobrança: ");
                    if (ValidarNovoValor(Console.ReadLine(), out decimal novoLimiteHorasSemCobranca))
                    {
                        estacionamento.LimiteHorasSemCobranca = (int)novoLimiteHorasSemCobranca;
                        Console.WriteLine("Limite de Horas Sem Cobrança modificado com sucesso. Pressione qualquer tecla para continuar.");
                        Console.ReadKey();
                    }
                    break;
                case "5":
                    Console.WriteLine($"Valor atual: {estacionamento.LimiteHorasCobrancaMeia}");
                    Console.Write("Informe o novo valor para Limite de Horas Cobrança Meia: ");
                    if (ValidarNovoValor(Console.ReadLine(), out decimal novoLimiteHorasCobrancaMeia))
                    {
                        estacionamento.LimiteHorasCobrancaMeia = (int)novoLimiteHorasCobrancaMeia;
                        Console.WriteLine("Limite de Horas Cobrança Meia modificado com sucesso. Pressione qualquer tecla para continuar.");
                        Console.ReadKey();
                    }
                    break;
                case "6":
                    break;
                default:
                    Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar.");
                    Console.ReadKey();
                    break;
            }
        }

        private bool ValidarNovoValor(string novoValorStr, out decimal novoValor)
        {
            if (decimal.TryParse(novoValorStr, out novoValor) && novoValor >= 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Valor inválido. Pressione qualquer tecla para continuar.");
                Console.ReadKey();
                return false;
            }
        }
    }
}