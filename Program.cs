namespace Studentregistreringsprogram_Databas
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var dbCtx = new ApplicationDbContext())
            {
                var handleStudent = new HandleStudent(dbCtx);
                Menu.PrintMenu(handleStudent); // Call the PrintMenu method from the Menu class
                dbCtx.SaveChanges();
            }
            ;
        }
    }
}
