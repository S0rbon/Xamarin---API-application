using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KlassenlisteService.Models
{
    public class KlassenlistesContext : DbContext
    {
        public KlassenlistesContext()
                : base("name=KlassenlistesContext")
        {
        }
        public DbSet<Klassenliste> Klassenlistes { get; set; }
    }
}