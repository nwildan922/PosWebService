using Pos.Model.Core;
using System.Data.Entity;

namespace Pos.Repository.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext() : base("Data Source=.;Initial Catalog=POS;Integrated Security=True")
        {

        }
        //---------------------------------------------------------------------------------------
        //CORE
        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<AccountPayment> AccountPayment { get; set; }
        public DbSet<AccountType> AccountType { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<LogModel> Logs { get; set; }

        //---------------------------------------------------------------------------------------
    }
}
