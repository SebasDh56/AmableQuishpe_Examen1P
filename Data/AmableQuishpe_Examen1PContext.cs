using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AmableQuishpe_Examen1P.Models;

    public class AmableQuishpe_Examen1PContext : DbContext
    {
        public AmableQuishpe_Examen1PContext (DbContextOptions<AmableQuishpe_Examen1PContext> options)
            : base(options)
        {
        }

        public DbSet<AmableQuishpe_Examen1P.Models.AQAuto> AQAuto { get; set; } = default!;
    }
