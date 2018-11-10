using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUD.Models
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}