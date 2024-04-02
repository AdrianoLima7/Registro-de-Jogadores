using Microsoft.EntityFrameworkCore;
using RegistroDeJogadores.Models;

namespace RegistroDeJogadores.Context
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Clube>? Clubes { get; set; }
        public DbSet<Jogador>? Jogadores { get; set; }
    }
}
