using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFundamentos.Utils
{
    public class GerenciadorEntradaUsuario
    {
        public static bool ObterDecimalInput(string mensagem, out decimal resultado)
    {
        Console.WriteLine(mensagem);
        return decimal.TryParse(Console.ReadLine(), out resultado) && resultado >= 0;
    }

    public static bool ObterInteiroInput(string mensagem, out int resultado)
    {
        Console.WriteLine(mensagem);
        return int.TryParse(Console.ReadLine(), out resultado) && resultado >= 0;
    }
    }
}