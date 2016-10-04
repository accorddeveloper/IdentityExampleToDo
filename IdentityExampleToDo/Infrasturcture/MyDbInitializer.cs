using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using IdentityExampleToDo.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IdentityExampleToDo.Infrasturcture {
    public class MyDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var UserManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            var RoleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));

            string name = "Admin";
            string password = "123456";

            //Create Role Admin if it does not exist
            if (!RoleManager.RoleExists(name))
            {
                var roleresult = RoleManager.Create(new IdentityRole(name));
            }

            //Create User=Admin with password=123456
            var user = new ApplicationUser();
            user.UserName = "admin@example.com";

            var adminresult = UserManager.Create(user, password);

            //add user to admin role

            if (adminresult.Succeeded)
            {
                var reslt = UserManager.AddToRole(user.Id, name);
            }

            base.Seed(context);
        }
    }
}