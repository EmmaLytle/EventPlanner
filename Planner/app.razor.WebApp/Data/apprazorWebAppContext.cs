using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using lib.DAL.Data.Model;

namespace app.razor.WebApp.Data
{
    public class apprazorWebAppContext : DbContext
    {
        public apprazorWebAppContext (DbContextOptions<apprazorWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<lib.DAL.Data.Model.EventPlan> EventPlan { get; set; }
    }
}
