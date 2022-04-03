using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationHotel5.Models;

namespace WebApplicationHotel5.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }
        public DbSet<ChambreClass> Chambre  { get; set; }
        public DbSet<InviteClass> Invite { get; set; }
    }
}
