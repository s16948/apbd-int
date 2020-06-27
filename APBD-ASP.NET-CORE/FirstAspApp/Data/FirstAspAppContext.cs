using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FirstAspApp.Models
{
    public class FirstAspAppContext : DbContext
    {
        public FirstAspAppContext (DbContextOptions<FirstAspAppContext> options)
            : base(options)
        {
        }

        public DbSet<FirstAspApp.Models.Movie> Movie { get; set; }
    }
}
