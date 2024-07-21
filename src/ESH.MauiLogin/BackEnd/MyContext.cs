
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESH.MauiLogin.BackEnd
{
    public class MyContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var db = Path.Combine(FileSystem.Current.AppDataDirectory, "myLogin.db");
            optionsBuilder.UseSqlite($"Data Source={db}");

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
