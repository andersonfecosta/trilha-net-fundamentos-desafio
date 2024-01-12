using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioFundamentos.Models;

namespace DesafioFundamentos.UI
{
    public class Menu
    {
        private Estacionamento estacionamento;

        public Menu(Estacionamento estacionamento)
        {
            this.estacionamento = estacionamento;
        }

        public void ExibirMenu()
        {
            bool exibirMenu = true;

            while (exibirMenu)
            {
                Console.Clear();
                Console.WriteLine("Digite a sua opção:");
                Console.WriteLine("1 - Cadastrar veículo");
                Console.WriteLine("2 - Remover veículo");
                Console.WriteLine("3 - Listar veículos");
                Console.WriteLine("4 - Encerrar");

                switch (Console.ReadLine())
                {
                    case "1":
                        estacionamento.AdicionarVeiculo();
                        break;

                    case "2":
                        estacionamento.RemoverVeiculo();
                        break;

                    case "3":
                        estacionamento.ListarVeiculos();
                        break;

                    case "4":
                        exibirMenu = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }

                Console.WriteLine("Pressione uma tecla para continuar");
                Console.ReadLine();
            }
        }
    }
}