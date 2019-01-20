using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Yacht.Models;

namespace Yacht.Models
{
    public class YachtContext : DbContext
    {
        public YachtContext (DbContextOptions<YachtContext> options)
            : base(options)
        {
        }

        public DbSet<Yacht.Models.Tip> Tip { get; set; }

        public DbSet<Yacht.Models.Base> Base { get; set; }

        public DbSet<Yacht.Models.Dostupnost> Dostupnost { get; set; }
    }
}
