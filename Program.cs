namespace Studentregistreringsprogram_Databas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dbCtx = new ApplicationDbContext(); // Create a new instance of the ApplicationDbContext class

           Menu.PrintMenu(); // Call the PrintMenu method from the Menu class
            dbCtx.SaveChanges();
        }
    }
}
