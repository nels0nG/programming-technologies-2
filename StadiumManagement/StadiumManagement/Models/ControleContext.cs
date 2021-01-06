using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StadiumManagement.Models
{
    public class ControleContext : DbContext
    {
        public ControleContext(): base("DefaultConnection")
        {
                
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public System.Data.Entity.DbSet<StadiumManagement.Models.Usuario> Usuarios { get; set; }
        public IEnumerable<object> Users { get; internal set; }
    }
}