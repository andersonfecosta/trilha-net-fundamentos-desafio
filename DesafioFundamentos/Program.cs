using DesafioFundamentos.Models;
using DesafioFundamentos.UI;
using DesafioFundamentos.Utils;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        if (GerenciadorEntradaUsuario.ObterDecimalInput("Seja bem-vindo ao sistema de estacionamento!\nDigite o preço inicial:", out decimal precoInicial) &&
            GerenciadorEntradaUsuario.ObterDecimalInput("Agora digite o preço por hora:", out decimal precoPorHora))
        {
            Estacionamento estacionamento = new Estacionamento(precoInicial, precoPorHora);
            Menu menu = new Menu(estacionamento);
            menu.ExibirMenu();
        }
        else
        {
            Console.WriteLine("Valores de preço inválidos. O programa será encerrado.");
        }

        Console.WriteLine("O programa se encerrou");
    }
}