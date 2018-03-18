using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;

namespace AppConsole
{
    class Auth
    {
        Claim _nome, _role, _email;
        ClaimsPrincipal _principal;

        public Auth(string nome, string role, string email, string nameClain)
        {
            _nome = new Claim(ClaimTypes.Name, nome);
            _role = new Claim(ClaimTypes.Role, role);
            _email = new Claim(ClaimTypes.Email, email);

            IList<Claim> Claims = new List<Claim>() { _nome, _role, _email };

            //Criando uma Identidade e associando-a ao ambiente
            ClaimsIdentity identity = new ClaimsIdentity(Claims, nameClain);
            _principal = new ClaimsPrincipal(identity);
            Thread.CurrentPrincipal = _principal;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var auth = new Auth("Uira Peixoto", "Admin", "uira.peixoto@gmail.com", "Usuario");
            
            ClaimsPrincipal currentPrincipal = Thread.CurrentPrincipal as ClaimsPrincipal;

            Console.WriteLine("Claims do Usuário:\n");

            foreach (Claim ci in currentPrincipal.Claims)
                Console.WriteLine(ci.Value);

            Console.Write("\n\n");
            Console.WriteLine("Usuário Autenticado:" + Thread.CurrentPrincipal.Identity.IsAuthenticated);
            Console.WriteLine("Identidade:" + Thread.CurrentPrincipal.Identity.Name);
            Console.Write("\n");


            //Criando uma Identidade e associando-a ao ambiente.
            Console.Write("\n");
            Console.WriteLine(Thread.CurrentPrincipal.Identity + " Pertence a role Administrador? \n" + Thread.CurrentPrincipal.IsInRole("Admin"));
            Console.Read();

        }
    }
}
