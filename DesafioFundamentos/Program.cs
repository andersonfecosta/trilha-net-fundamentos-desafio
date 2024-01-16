using DesafioFundamentos.Models;
using DesafioFundamentos.UI;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Estacionamento estacionamento = new Estacionamento();
        
        Menu menu = new Menu(estacionamento);
        menu.ExibirMenu();
    }
}