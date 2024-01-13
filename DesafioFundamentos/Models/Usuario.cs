using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFundamentos.Models
{
    public class Usuario
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        public List<Veiculo> VeiculosEstacionados { get; set; } 
        public List<RegistroUtilizacao> registros = new List<RegistroUtilizacao>();
        public bool AssinaturaMensal { get; set; }
        
        public Usuario(string nome, string telefone, string cpf)
        {
            Nome = nome;
            Telefone = telefone;
            CPF = cpf;
            VeiculosEstacionados = new List<Veiculo>();
            registros = new List<RegistroUtilizacao>();
        }

        public void AdicionarVeiculo(string placaVeiculo)
        {
            if (!VeiculosEstacionados.Any(v => v.Placa == placaVeiculo))
            {
                Veiculo veiculo = new Veiculo(placaVeiculo, "", ""); 
                VeiculosEstacionados.Add(veiculo);
            }
            else
            {
                Console.WriteLine("Usuário já possui esse veículo estacionado.");
            }
        }

        public void RemoverVeiculo(string placaVeiculo)
        {
            Veiculo veiculoRemover = VeiculosEstacionados.FirstOrDefault(v => v.Placa == placaVeiculo);
            if (veiculoRemover != null)
            {
                VeiculosEstacionados.Remove(veiculoRemover);
            }
            else
            {
                Console.WriteLine("Veículo não encontrado para remoção.");
            }
        }  
        public void RegistrarUtilizacao(Veiculo veiculo, int horas, decimal valor)
        {
            RegistroUtilizacao registro = new RegistroUtilizacao(veiculo, horas, valor);
            registros.Add(registro);            
        }      
    }
}