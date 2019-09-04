using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ordbog.Service.Data
{
    public class OrdbogServiceContext : DbContext
    {
        public OrdbogServiceContext (DbContextOptions<OrdbogServiceContext> options)
            : base(options)
        {
        }

        public DbSet<Ordbog.Service.Models.Article> Articles { get; set; }
        public DbSet<Ordbog.Service.Models.Translation> Translations { get; set; }
    }
}
