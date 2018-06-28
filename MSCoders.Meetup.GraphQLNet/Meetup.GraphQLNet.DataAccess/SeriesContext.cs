using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Meetup.GraphQLNet.Domain;

namespace Meetup.GraphQLNet.DataAccess
{
    public class SeriesContext : DbContext
    {
        public static long InstanceCount;
        public SeriesContext(DbContextOptions options)
            : base(options)
        {
            Interlocked.Increment(ref InstanceCount);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SerieActor>()
                .HasKey(t => new { t.SerieId, t.ActorId });
        }
        public DbSet<Serie> Series { get; set; }

        public DbSet<Actor> Actors { get; set; }

        public DbSet<SerieActor> SerieActor { get; set; }
    }
}
