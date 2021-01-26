using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class NoticiaDBContext : DbContext
    {
        public NoticiaDBContext(DbContextOptions<NoticiaDBContext> options) : base(options) { }
        public DbSet<Autor> Autor { get; set; }
        public DbSet<Noticia> Noticia { get; set; }
    }
}