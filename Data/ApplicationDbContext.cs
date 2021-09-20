using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

using JobFair.Models;

namespace JobFair.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Register> Registers { get; set; }
        
        public DbSet<Company> Companies { get; set; }

        public DbSet<Seeker> Seekers { get; set; }

        public DbSet<InterestedCandidate> InterestedCandidates { get; set; }

        public DbSet<SelecetedCandidate> SelecetedCandidates { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
