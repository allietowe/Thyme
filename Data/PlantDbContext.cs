using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Thyme1.Models;

namespace Thyme1.Data
{
    public class PlantDbContext : IdentityDbContext
    {
        public DbSet<Plant> Plants { get; set; }
        public DbSet<PlantRooms> PlantRooms { get; set; }

        public PlantDbContext(DbContextOptions<PlantDbContext> options) : base(options)
        {
        }
    }
}

