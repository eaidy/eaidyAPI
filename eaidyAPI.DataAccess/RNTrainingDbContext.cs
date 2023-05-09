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
            optionsBuilder.UseSqlServer("Server=localhost; Database=eaidyDb; uid=SA; pwd=ata12151215Ata.; TrustServerCertificate=True;");
        }

        public DbSet<User> Users  { get; set; }
    }
}

