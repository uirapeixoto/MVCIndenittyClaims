using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace UI.Models
{
    public class AppUserManager : UserManager<IdentityUser>
    {

        public AppUserManager(IUserStore<IdentityUser> store) : base(store)
        {
        }

        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> option, IOwinContext context)
        {
            var contexto = context.Get<ApplicationDbContext>();

            var store = new UserStore<IdentityUser>(contexto);

            var userManager = new AppUserManager(store);

            return userManager;
        }
    }
}