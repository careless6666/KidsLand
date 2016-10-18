using System;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NLog;

namespace KidsLand.Models.EF
{
    public class EntitiesContextInitializer : DropCreateDatabaseIfModelChanges<KidsLandIdentityContext>
    {
        public static readonly Logger logger = LogManager.GetCurrentClassLogger();
        protected override void Seed(KidsLandIdentityContext context)
        {
            InitializeIdentityForEF(context);
            base.Seed(context);
        }

        private void InitializeIdentityForEF(KidsLandIdentityContext context)
        {
            try
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var myinfo = new MyUserInfo() { FirstName = "Админ", LastName = "Админов" };
                const string name = "admin";
                const string password = "admina";
                const string us = "User";

                //Create Role Test and User Test
                roleManager.Create(new IdentityRole(us));
                userManager.Create(new ApplicationUser() { UserName = us });


                //Create Role Admin if it does not exist
                if (!roleManager.RoleExists(name))
                {
                    var roleresult = roleManager.Create(new IdentityRole("Admin"));
                }

                //Create User=Admin with password=123456
                var user = new ApplicationUser { UserName = name, HomeTown = "Seattle", MyUserInfo = myinfo };
                var adminresult = userManager.Create(user, password);

                //Add User Admin to Role Admin
                if (adminresult.Succeeded)
                {
                var result = userManager.AddToRole(user.Id, name);
                }

                var n = new News { NewsTitle = "Title", NewsBody = "Body", NewsImg = "123", NewsDate = DateTime.Now };
                context.News.Add(n);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
            
        }
        
        
        //protected override void Seed(KidsLandEntities context)
        //{
            //var u = new User
            //{
            //    UserName = "admin",
            //    Password = "admin",
            //    Email = "admin@ymail.ru",
            //    Roles = new Collection<Role> { new Role { Name = "Admin" } },
            //};

            //context.Users.Add(u);

            //var r = new Role {Name = "User"};
            //context.Roles.Add(r);

            //context.SaveChanges();
        //}

        
    }
}