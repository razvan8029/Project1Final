using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project1.Models;

namespace Project1.Data
{
    public class Project1Context : DbContext
    {
        public Project1Context (DbContextOptions<Project1Context> options)
            : base(options)
        {
        }

        public DbSet<Project1.Models.Instalator> Instalator { get; set; }

        public DbSet<Project1.Models.Job> Job { get; set; }

        public DbSet<Project1.Models.Client> Client { get; set; }
    }
}
