using System;
using eaidyAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace eaidyAPI.DataAccess
{
	public class RNTrainingDbcontext : DbContext
	{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost; Database=<DBName>; uid=SA; pwd=<Password>; TrustServerCertificate=True;");
        }

        public DbSet<User> Users  { get; set; }
    }
}

