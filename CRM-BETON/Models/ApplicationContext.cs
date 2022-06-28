using Microsoft.EntityFrameworkCore;



 namespace CRM_BETON.Models
{
    public class ApplicationContext : DbContext
    {
        //  Метод создания в базе данных таблицы с полями класса Users
        public DbSet<User> Users { get; set; } = null!;

        //  Метод создания в базе данных таблицы с полями класса Orders
        public DbSet<Order> Orders { get; set; } = null!;

        // Метод добавления в таблицу данных
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        // Метод подключения к базе данных
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=gubinv.beget.tech;user=gubinv_monbeton;password=f3YLaY&U;database=gubinv_monbeton;",
                new MySqlServerVersion(new Version(5, 7, 21)));
        }
    }
}