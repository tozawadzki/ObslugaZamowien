﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObslugaZamowien.DAL
{
    public class OrdersContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
    }
}
