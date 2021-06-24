using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Varun_Banking.Models;

namespace Varun_Banking.Data
{
    public class Varun_BankingContext : DbContext
    {
        public Varun_BankingContext (DbContextOptions<Varun_BankingContext> options)
            : base(options)
        {
        }

        public DbSet<Varun_Banking.Models.VarunBank> VarunBank { get; set; }
    }
}
