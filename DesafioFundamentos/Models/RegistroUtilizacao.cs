using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFundamentos.Models
{
    public class RegistroUtilizacao
    {
        public Veiculo Veiculo { get; }
        public int Horas { get; }
        public decimal Valor { get; }

        public RegistroUtilizacao(Veiculo veiculo, int horas, decimal valor)
        {
            Veiculo = veiculo;
            Horas = horas;
            Valor = valor;
        }
    }
}