using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Threading.Tasks;

namespace UI.Models
{
    public class AppSignInManager : SignInManager<IdentityUser, string>
    {
        public AppSignInManager(AppUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public static AppSignInManager Create(IdentityFactoryOptions<AppSignInManager> option, IOwinContext context)
        {
            var manager = context.GetUserManager<AppUserManager>();
            var sign = new AppSignInManager(manager, context.Authentication);
            return sign;
        }
        /// <summary>
        /// Override do método CreateUserIdentityAsync utilizaqda para criar Claims quando o usuário logar
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public override async Task<ClaimsIdentity> CreateUserIdentityAsync(IdentityUser user)
        {
            ClaimsIdentity claimIdenity = await base.CreateUserIdentityAsync(user);

            claimIdenity.AddClaim(new Claim(ClaimTypes.Country , "Brasil"));
            claimIdenity.AddClaim(new Claim(ClaimTypes.Gender, "Masculino"));
            claimIdenity.AddClaim(new Claim(ClaimTypes.Role, "Administrador"));

            return claimIdenity;

        }
    }
}