namespace Studentregistreringsprogram_Databas
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var dbCtx = new ApplicationDbContext())
            {
                //var adminRole = new UserRole { RoleName = "Admin" };
                //var userRole = new UserRole { RoleName = "User" };

                //dbCtx.Roles.AddRange(adminRole, userRole);
                //dbCtx.SaveChanges();

                //var admin = new SystemUser
                //{
                //    UserName = "admin",
                //    Password = "admin",
                //    UserRoleId = adminRole.RoleId
                //};
                //var user = new SystemUser
                //{
                //    UserName = "user",
                //    Password = "user",
                //    UserRoleId = userRole.RoleId

                //};
                //dbCtx.AddRange(admin, user);
                //dbCtx.SaveChanges();

                var application = new Application();
                var loggedInUser = application.Login(dbCtx);
                var handleStudent = new HandleStudent(dbCtx);
                Menu.PrintMenu(handleStudent, loggedInUser); // Call the PrintMenu method from the Menu class
                dbCtx.SaveChanges();
            }
        }
    }
}
