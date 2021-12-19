using Microsoft.EntityFrameworkCore;
using SmkLab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmkLab.Data
{
    public class StudentsContext : DbContext
    {
        public StudentsContext(DbContextOptions<StudentsContext> options) : base(options)
        {
        }

        public DbSet<Students> tblstudent { get; set; }
    }
}
