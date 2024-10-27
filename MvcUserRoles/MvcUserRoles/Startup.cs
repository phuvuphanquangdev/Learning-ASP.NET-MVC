using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using MvcUserRoles.Models;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcUserRoles.Startup))]
namespace MvcUserRoles
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        // In this method we will create default User roles and Admin user for login   
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin rool   
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                  

                var user = new ApplicationUser();
                user.UserName = "RobinHaider";
                user.Email = "robinhaider69@gmail.com";
                user.FatherName = "Jashim Uddin";

                string userPWD = "12345678";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                }
            }

            // creating Creating Manager role    
            if (!roleManager.RoleExists("Manager"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);

                //Now we create a User who will be a Manager
                var user = new ApplicationUser();
                user.UserName = "Raheel";
                user.Email = "raheel@gmail.com";
                user.FatherName = "Mubarok";

                string userPass = "87654321";

                var chekUser = UserManager.Create(user, userPass);

                //Add this user as a Manager...
                if (chekUser.Succeeded)
                {
                    var result2 = UserManager.AddToRole(user.Id, "Manager");
                }

            }

            // creating Creating Employee role    
            if (!roleManager.RoleExists("Employee"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Employee";
                roleManager.Create(role);

                //Now we create a User Who will be an Employee..
                var user = new ApplicationUser();
                user.UserName = "Saikat";
                user.Email = "saikat@gmail.com";
                user.FatherName = "Sahab Uddin";

                string userPass = "23456789";

                var chekUser = UserManager.Create(user, userPass);

                //Add this user as a Manager...
                if (chekUser.Succeeded)
                {
                    var result3 = UserManager.AddToRole(user.Id, "Employee");
                }
            }
        }
    }
}
