using Microsoft.EntityFrameworkCore;
using StudentInfoSystem.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInfoSystem.Models
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        { 
           
        }
        public DbSet<Sys_User> Sys_User { get; set; }
    }
}
