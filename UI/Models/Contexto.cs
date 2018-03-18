using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class Contexto : IdentityDbContext<IdentityUser>
    {
        public Contexto()
            : base("name=DbIdentity")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public static Contexto Create() => new Contexto();
    }
}