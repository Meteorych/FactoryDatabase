using Npgsql;

namespace FactoryDatabase
{
    public  static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
       
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(@"Host=localhost;Port=5433;Database=factory;Username=postgres;Password=doomslayer");
        }
    }
}