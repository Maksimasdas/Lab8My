using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Lab8My.Models
{
    public class EntityContext : DbContext
    {
        public EntityContext() : base("DefaultConnect")
        {
            Database.SetInitializer(new DataBaseInitializer());
        }

        public DbSet<Car> Cars {  get; set; }
    }
}
