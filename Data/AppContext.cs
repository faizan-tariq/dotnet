using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleDotNet.Models;

    public class AppContext : DbContext
    {
        public AppContext (DbContextOptions<AppContext> options)
            : base(options)
        {
        }

        public DbSet<SampleDotNet.Models.Video> Video { get; set; }
    }
