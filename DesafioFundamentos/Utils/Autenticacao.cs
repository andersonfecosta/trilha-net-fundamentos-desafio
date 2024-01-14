using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFundamentos.Utils
{
    public class Autenticacao
    {
        private const string UsuarioAdmin = "admin";
        private const string SenhaAdmin = "admin";

        public bool EfetuarLogin(string usuario, string senha)
        {
            return usuario.ToLower() == UsuarioAdmin && senha == SenhaAdmin;
        }
    }
}