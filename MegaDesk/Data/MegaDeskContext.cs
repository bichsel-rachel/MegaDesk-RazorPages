﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MegaDesk.Models;

namespace MegaDesk.Data
{
    public class MegaDeskContext : DbContext
    {
        public MegaDeskContext (DbContextOptions<MegaDeskContext> options)
            : base(options)
        {
        }

        public DbSet<MegaDesk.Models.Order> Order { get; set; }
    }
}
