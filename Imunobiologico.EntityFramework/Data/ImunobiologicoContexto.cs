using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Imunobiologico.EntityFramework.Data.Mapeamentos;

namespace Imunobiologico.EntityFramework.Data
{
    public class ImunobiologicoContexto : DbContext
    {

        public ImunobiologicoContexto(DbContextOptions<ImunobiologicoContexto> options)
            : base(options) { }

        public DbSet<Imunobiologico.EntityFramework.Models.Imunobiologico> Imunobiologicos { get; set;  }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ImunobiologicoMap());
        }



    }
}
