using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioFundamentos.Models;
using DesafioFundamentos.Utils;

namespace DesafioFundamentos.UI
{
    public class Menu
    {
        private Estacionamento estacionamento;
        private Autenticacao autenticacao;

        public Menu()
        {
            estacionamento = new Estacionamento(20, 10);
            autenticacao = new Autenticacao();
        }

        public void ExibirMenu()
        {
            bool sair = false;

            do
            {
                Console.Clear();
                Console.WriteLine("Bem-vindo ao Estacionamento");
                Console.WriteLine("1 - Cadastrar Usuário");
                Console.WriteLine("2 - Entrar no Estacionamento");
                Console.WriteLine("3 - Sair do Estacionamento");
                Console.WriteLine("4 - Listar Veículos Estacionados");
                Console.WriteLine("5 - Entrar como Administrador");
                Console.WriteLine("6 - Sair");

                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        CadastrarUsuario();
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
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
                Console.WriteLine("Bem-vindo, Administrador");
                Console.WriteLine("1 - Visualizar Lista de Usuários");
                Console.WriteLine("2 - Visualizar Lista de Veículos Estacionados");
                Console.WriteLine("3 - Modificar Valores do Estacionamento");
                Console.WriteLine("4 - Voltar ao Menu Principal");

                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        break;
                    case "2":
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
            Console.WriteLine("Modificar Valores do Estacionamento");
            Console.WriteLine("1 - Modificar Preço Inicial");
            Console.WriteLine("2 - Modificar Preço por Hora");
            Console.WriteLine("3 - Modificar Preço Assinatura Mensal");
            Console.WriteLine("4 - Modificar Limite de Horas Sem Cobrança");
            Console.WriteLine("5 - Modificar Limite de Horas Cobrança Meia");
            Console.WriteLine("6 - Voltar ao Menu Administrador");

            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    ModificarValor(estacionamento.PrecoInicial, "Preço Inicial");
                    break;
                case "2":
                    ModificarValor(estacionamento.PrecoPorHora, "Preço por Hora");
                    break;
                case "3":
                    ModificarValor(estacionamento.PrecoAssinaturaMensal, "Preço Assinatura Mensal");
                    break;
                case "4":
                    ModificarValor(estacionamento.LimiteHorasSemCobranca, "Limite de Horas Sem Cobrança");
                    break;
                case "5":
                    ModificarValor(estacionamento.LimiteHorasCobrancaMeia, "Limite de Horas Cobrança Meia");
                    break;
                case "6":
                    break;
                default:
                    Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar.");
                    Console.ReadKey();
                    break;
            }
        }
        private void ModificarValor(decimal valor, string nomeValor)
        {
            Console.Write($"Informe o novo valor para {nomeValor}: ");
            string novoValorStr = Console.ReadLine();

            if (decimal.TryParse(novoValorStr, out decimal novoValor))
            {
                valor = novoValor;
                Console.WriteLine($"{nomeValor} modificado com sucesso. Pressione qualquer tecla para continuar.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Valor inválido. Pressione qualquer tecla para continuar.");
                Console.ReadKey();
            }
    }
    }
}