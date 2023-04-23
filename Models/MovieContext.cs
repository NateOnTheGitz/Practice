using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice.Models
{
    public class MovieContext : DbContext
    {

        public MovieContext(DbContextOptions<MovieContext> options) : base (options)
        {

        }

        public DbSet<MovieInfo> MovieInfos { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
