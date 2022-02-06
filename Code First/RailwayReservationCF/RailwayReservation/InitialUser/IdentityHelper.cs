using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RailwayReservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RailwayReservation.InitialUser
{
    public class IdentityHelper
    {
        internal static void SeedIdentities(ApplicationDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists(InitialRole.ROLE_ADMINISTRATIOR))
            {
                var roleResult = roleManager.Create(new IdentityRole(InitialRole.ROLE_ADMINISTRATIOR));
                if (roleResult.Succeeded)
                {
                    string UserName = "aminul@gmail.com";
                    string Pass = "@Aminul123";
                    ApplicationUser user = userManager.FindByName(UserName);
                    if (user == null)
                    {
                        user = new ApplicationUser()
                        {
                            UserName = UserName,
                            Email = UserName,
                            EmailConfirmed = true
                        };
                        IdentityResult identityResult = userManager.Create(user, Pass);
                        if (identityResult.Succeeded)
                        {
                            var result = userManager.AddToRole(user.Id, InitialRole.ROLE_ADMINISTRATIOR);
                        }
                    }

                }


            }
        }
    }
}